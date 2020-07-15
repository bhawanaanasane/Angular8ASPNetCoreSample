using Fla.Service.Authentication;
using Fla.Service.Users;
using FLA.Core.Domain.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fla.Service.Helper
{
   public class WebWorkContext:IWorkContext
    {
        #region Const

        private const string CUSTOMER_COOKIE_NAME = ".FLADispatchApplication.User";

        #endregion

        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IAuthenticationService _authenticationService;

        private readonly iUserService _userService;




        private readonly IUserAgentHelper _userAgentHelper;



        private UserLogin _cachedUser;
        private UserLogin _originalUserIfImpersonated;


        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="httpContextAccessor">HTTP context accessor</param>
        /// <param name="currencySettings">Currency settings</param>
        /// <param name="authenticationService">Authentication service</param>
        /// <param name="currencyService">Currency service</param>
        /// <param name="customerService">Customer service</param>
        /// <param name="genericAttributeService">Generic attribute service</param>
        /// <param name="languageService">Language service</param>
        /// <param name="storeContext">Store context</param>
        /// <param name="storeMappingService">Store mapping service</param>
        /// <param name="userAgentHelper">User gent helper</param>
        /// <param name="vendorService">Vendor service</param>
        /// <param name="localizationSettings">Localization settings</param>
        /// <param name="taxSettings">Tax settings</param>
        public WebWorkContext(IHttpContextAccessor httpContextAccessor,

            IAuthenticationService authenticationService,

            iUserService userService,


            IUserAgentHelper userAgentHelper
          )
        {
            this._httpContextAccessor = httpContextAccessor;

            this._authenticationService = authenticationService;

            this._userService = userService;

            this._userAgentHelper = userAgentHelper;

        }

        #endregion

        #region Utilities

        /// <summary>
        /// Get nop customer cookie
        /// </summary>
        /// <returns>String value of cookie</returns>
        protected virtual string GetCustomerCookie()
        {
            return _httpContextAccessor.HttpContext?.Request?.Cookies[CUSTOMER_COOKIE_NAME];
        }

        /// <summary>
        /// Set nop customer cookie
        /// </summary>
        /// <param name="customerGuid">Guid of the customer</param>
        protected virtual void SetCustomerCookie(Guid customerGuid)
        {
            if (_httpContextAccessor.HttpContext?.Response == null)
                return;

            //delete current cookie value
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(CUSTOMER_COOKIE_NAME);

            //get date of cookie expiration
            var cookieExpires = 24 * 365; //TODO make configurable
            var cookieExpiresDate = DateTime.Now.AddHours(cookieExpires);

            //if passed guid is empty set cookie as expired
            if (customerGuid == Guid.Empty)
                cookieExpiresDate = DateTime.Now.AddMonths(-1);

            //set new cookie value
            var options = new Microsoft.AspNetCore.Http.CookieOptions
            {
                HttpOnly = true,
                Expires = cookieExpiresDate
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append(CUSTOMER_COOKIE_NAME, customerGuid.ToString(), options);
        }







        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current customer
        /// </summary>
        public virtual UserLogin CurrentUser
        {
            get
            {
                //whether there is a cached value
                if (_cachedUser != null)
                    return _cachedUser;

                UserLogin user = null;

                //check whether request is made by a background (schedule) task
                if (_httpContextAccessor.HttpContext == null)
                {
                    //in this case return built-in customer record for background task
                    //code comment
                    //  user = _userService.GetCustomerBySystemName(SystemCustomerNames.BackgroundTask);
                }

                //if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                //{
                //    //check whether request is made by a search engine, in this case return built-in customer record for search engines
                //    if (_userAgentHelper.IsSearchEngine())
                //        customer = _customerService.GetCustomerBySystemName(SystemCustomerNames.SearchEngine);
                //}

                if (user == null || !user.Active)
                {
                    //try to get registered user
                    user = _authenticationService.GetAuthenticatedUser();
                }
                //  customer = _authenticationService.GetAuthenticatedCustomer();
                //if (user != null && user.Active)
                //{
                //    get impersonate user if required
                //    var impersonatedCustomerId = user.GetAttribute<int?>(SystemCustomerAttributeNames.ImpersonatedCustomerId);
                //    if (impersonatedCustomerId.HasValue && impersonatedCustomerId.Value > 0)
                //    {
                //        var impersonatedCustomer = _userService.GetUserLogin(id: impersonatedCustomerId.Value);
                //        if (impersonatedCustomer != null && impersonatedCustomer.Active)
                //        {
                //            set impersonated customer
                //            _originalCustomerIfImpersonated = user;
                //            user = impersonatedCustomer;
                //        }
                //    }
                //}

                if (user == null || !user.Active)
                {
                    //get guest customer
                    var customerCookie = GetCustomerCookie();
                    if (!string.IsNullOrEmpty(customerCookie))
                    {
                        if (Guid.TryParse(customerCookie, out Guid userGuid))
                        {
                            //get customer from cookie (should not be registered)
                            var customerByCookie = _userService.GetUserLoginByGuid(userGuid);
                            if (customerByCookie != null && !customerByCookie.IsRegistered())
                                user = customerByCookie;
                        }
                    }
                }

                //if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                //{
                //    //create guest if not exists
                //    customer = _customerService.InsertGuestCustomer();
                //}

                if (user != null)
                {
                    //set customer cookie
                    SetCustomerCookie(user.UserLoginGuid);

                    //cache the found customer
                    _cachedUser = user;
                }

                return _cachedUser;
            }
            set
            {
                SetCustomerCookie(value.UserLoginGuid);
                _cachedUser = value;
            }
        }

        /// <summary>
        /// Gets the original customer (in case the current one is impersonated)
        /// </summary>
        public virtual UserLogin OriginalUserIfImpersonated
        {
            get { return _originalUserIfImpersonated; }
        }


        /// <summary>
        /// Gets or sets value indicating whether we're in admin area
        /// </summary>
        public virtual bool IsAdmin { get; set; }



        #endregion
    }
}

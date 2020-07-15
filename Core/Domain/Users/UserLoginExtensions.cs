using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Users
{
    public static class UserLoginExtensions
    {
        #region Customer role

        /// <summary>
        /// Gets a value indicating whether customer is in a certain customer role
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="customerRoleSystemName">Customer role system name</param>
        /// <param name="onlyActiveCustomerRoles">A value indicating whether we should look only in active customer roles</param>
        /// <returns>Result</returns>
        public static bool IsInUserRole(this UserLogin user,
            string userRoleSystemName, bool onlyActiveUserRoles = true)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrEmpty(userRoleSystemName))
                throw new ArgumentNullException(nameof(userRoleSystemName));

            var result = user.Role != null;
            return result;
        }

        /// <summary>
        /// Gets a value indicating whether customer a search engine
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>Result</returns>
        public static bool IsSearchEngineAccount(this UserLogin user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (!user.IsSystemAccount || string.IsNullOrEmpty(user.SystemName))
                return false;

            var result = user.SystemName.Equals(SystemUserNames.SearchEngine, StringComparison.InvariantCultureIgnoreCase);
            return result;
        }

        /// <summary>
        /// Gets a value indicating whether the customer is a built-in record for background tasks
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>Result</returns>
        public static bool IsBackgroundTaskAccount(this UserLogin user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (!user.IsSystemAccount || string.IsNullOrEmpty(user.SystemName))
                return false;

            var result = user.SystemName.Equals(SystemUserNames.BackgroundTask, StringComparison.InvariantCultureIgnoreCase);
            return result;
        }

        /// <summary>
        /// Gets a value indicating whether customer is administrator
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="onlyActiveCustomerRoles">A value indicating whether we should look only in active customer roles</param>
        /// <returns>Result</returns>
        public static bool IsAdmin(this UserLogin user, bool onlyActiveCustomerRoles = true)
        {
            return IsInUserRole(user, SystemUsersRoleNames.Admin, onlyActiveCustomerRoles);
        }

        /// <summary>
        /// Gets a value indicating whether customer is a forum moderator
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="onlyActiveCustomerRoles">A value indicating whether we should look only in active customer roles</param>
        /// <returns>Result</returns>
        public static bool IsForumModerator(this UserLogin user, bool onlyActiveCustomerRoles = true)
        {
            return IsInUserRole(user, SystemUsersRoleNames.User, onlyActiveCustomerRoles);
        }

        /// <summary>
        /// Gets a value indicating whether customer is registered
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="onlyActiveCustomerRoles">A value indicating whether we should look only in active customer roles</param>
        /// <returns>Result</returns>
        public static bool IsRegistered(this UserLogin user, bool onlyActiveCustomerRoles = true)
        {
            return IsInUserRole(user, SystemUsersRoleNames.Registered, onlyActiveCustomerRoles);
        }

        /// <summary>
        /// Gets a value indicating whether customer is guest
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="onlyActiveCustomerRoles">A value indicating whether we should look only in active customer roles</param>
        /// <returns>Result</returns>
        public static bool IsGuest(this UserLogin user, bool onlyActiveCustomerRoles = true)
        {
            return IsInUserRole(user, SystemUsersRoleNames.Guests, onlyActiveCustomerRoles);
        }

        /// <summary>
        /// Gets a value indicating whether customer is vendor
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="onlyActiveCustomerRoles">A value indicating whether we should look only in active customer roles</param>
        /// <returns>Result</returns>
        public static bool IsClient(this UserLogin user, bool onlyActiveCustomerRoles = true)
        {
            return IsInUserRole(user, SystemUsersRoleNames.Client, onlyActiveCustomerRoles);
        }



        #endregion

        #region Addresses

        /// <summary>
        /// Remove address
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="address">Address</param>
        //public static void RemoveAddress(this UserLogin user, Address address)
        //{
        //    if (user.Addresses.Contains(address))
        //    {
        //        if (user.BillingAddress == address) user.BillingAddress = null;
        //        if (user.ShippingAddress == address) user.ShippingAddress = null;

        //        user.Addresses.Remove(address);
        //    }
        //}

        #endregion
    }
}

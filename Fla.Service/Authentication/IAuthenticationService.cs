using FLA.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fla.Service.Authentication
{
   public partial interface IAuthenticationService
    {
        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="user">Customer</param>
        /// <param name="isPersistent">Whether the authentication session is persisted across multiple requests</param>
        void SignIn(UserLogin user, bool isPersistent);

        /// <summary>
        /// Sign out
        /// </summary>
        void SignOut();

        /// <summary>
        /// Get authenticated User
        /// </summary>
        /// <returns>User</returns>
        UserLogin GetAuthenticatedUser();
    }
}

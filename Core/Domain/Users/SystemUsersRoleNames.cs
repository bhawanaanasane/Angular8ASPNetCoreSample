using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Users
{
    public static partial class SystemUsersRoleNames
    {
        /// <summary>
        /// Administrators
        /// </summary>
        public static string Admin { get { return "Admin"; } }

        /// <summary>
        /// ForumModerators
        /// </summary>
        public static string User { get { return "User"; } }

        /// <summary>
        /// Registered
        /// </summary>
        public static string Registered { get { return "Registered"; } }

        /// <summary>
        /// Guests
        /// </summary>
        public static string Guests { get { return "Guests"; } }

        /// <summary>
        /// Vendors
        /// </summary>
        public static string Client { get { return "Client"; } }
    }
}

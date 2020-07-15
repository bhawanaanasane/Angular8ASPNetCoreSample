using FLA.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fla.Service.Helper
{
    public interface IWorkContext
    {
        /// <summary>
        /// Gets or sets the current User
        /// </summary>
        UserLogin CurrentUser { get; set; }

        /// <summary>
        /// Gets the original User (in case the current one is impersonated)
        /// </summary>
        UserLogin OriginalUserIfImpersonated { get; }



        /// <summary>
        /// Gets or sets value indicating whether we're in admin area
        /// </summary>
        bool IsAdmin { get; set; }
    }
}

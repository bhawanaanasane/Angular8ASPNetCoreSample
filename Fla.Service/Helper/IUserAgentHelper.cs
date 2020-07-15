using System;
using System.Collections.Generic;
using System.Text;

namespace Fla.Service.Helper
{
    public partial interface IUserAgentHelper
    {

        /// <summary>
        /// Get a value indicating whether the request is made by mobile device
        /// </summary>
        /// <returns></returns>
        bool IsMobileDevice();

        /// <summary>
        /// Get a value indicating whether the request is made by IE8 browser
        /// </summary>
        /// <returns></returns>
        bool IsIe8();
    }
}

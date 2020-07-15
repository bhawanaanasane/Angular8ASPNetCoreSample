using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Scheduling
{
    public enum Types
    {
        Select = 0,
        Chassis_pickup = 1,
        Chassis_Return = 2,
        Chassis_Transfer = 3,
        PrePull = 4,
        RoundTrip = 5,
        Drop = 6,
        Empty_Return = 7,
        Final_Return = 8,
        Export = 9,
        Stop_Off = 10,
        
    }
}

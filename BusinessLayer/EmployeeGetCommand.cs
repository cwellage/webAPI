using NServiceBus;
using System;

namespace CommandLayer
{
    public class EmployeeGetCommand :IMessage
    {
        public int EmployeeId { get; set; }
    }
}

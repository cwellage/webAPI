using NServiceBus;
using System;

namespace CommandLayer
{
    public class EmployeePostCommand :ICommand
    {
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using DataLayer;
using System.Linq;
using NServiceBus.Config;
using System.Threading;

namespace CommandLayer
{
    public class EmployeeCommandhandler : IHandleMessages<EmployeePostCommand>
    {
        MyDB database = new MyDB();
        public async Task<Employee> Handle(EmployeeGetCommand message, IMessageHandlerContext context)
        {
            var emp = database.Employees.FirstOrDefault(a => a.Id == message.EmployeeId);
            return await Task.FromResult(emp).ConfigureAwait(false);
        }

        public Task Handle(EmployeePostCommand message, IMessageHandlerContext context)
        {
            Employee emp = new Employee { DepartmentId = message.DepartmentId, EmployeeName = message.EmployeeName };
            database.Employees.Add(emp);
            Thread.Sleep(10000);
            return database.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using DataLayer;
using System.Linq;
using NServiceBus.Config;
using System.Threading;
using Serilog;

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

        public async Task Handle(EmployeePostCommand message, IMessageHandlerContext context)
        {
            try
            {
                Employee emp = new Employee { DepartmentId = message.DepartmentId, EmployeeName = message.EmployeeName };
                database.Employees.Add(emp);
                Thread.Sleep(10000);/// asume more processing is to be done
                var task = await database.SaveChangesAsync();
                Log.Information("Employee {emp} has been added", message.EmployeeName);
                return;
            }
            catch (Exception e)
            {
                Log.Error("error in saving employee {emp} {exception }", message.EmployeeName, e.InnerException.Message);
                return;
            }         
        }
    }
}

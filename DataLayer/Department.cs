using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DataLayer
{
    public class Department
    {
        [OpenApiIgnore]
        public int Id { get; set; }

        public string DepartmentName { get; set; }
    }
}

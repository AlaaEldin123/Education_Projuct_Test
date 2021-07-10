using CreativityEdu.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativityEdu.VM
{
    public class EmployeeCreateVm
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Db { get; set; }
        public string PhoneNumber { get; set; }
        public Department Departmant { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public Double Salary { get; set; }
    }
}

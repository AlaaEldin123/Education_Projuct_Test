using CreativityEdu.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreativityEdu.Models
{
    public class Courses : BaseEntity<int>
    {
        public string Title { get; set; }
        public string ShourDescraption { get; set; }
        public string Descraption { get; set; }
        public Department departmant { get; set; }
        public string EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employess Employees { get; set; }

    }
}

using CreativityEdu.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreativityEdu.Models
{
    public class Employess : BaseEntity<int>
    {
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        public double Sallary { get; set; }
        public Department Department { get; set; }

    }
}

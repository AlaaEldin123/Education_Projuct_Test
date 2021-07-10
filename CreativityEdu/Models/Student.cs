using CreativityEdu.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreativityEdu.Models
{
    public class Student : BaseEntity<long>
    {

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        public StudentStatus Status { get; set; }
        public Nationlaity Nationality { get; set; }
    }
}

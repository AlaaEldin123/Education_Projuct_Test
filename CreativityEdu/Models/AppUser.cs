using CreativityEdu.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativityEdu.Models
{
    public class AppUser: IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public override string PhoneNumber { get; set; }
    }
}

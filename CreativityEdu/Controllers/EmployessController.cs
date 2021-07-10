using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreativityEdu.Data;
using CreativityEdu.Models;
using CreativityEdu.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreativityEdu.Controllers
{
    public class EmployessController : Controller
    {
        private CreativityEduContext _CreativityEduContext;
        private UserManager<AppUser> _userManager;
        public EmployessController(CreativityEduContext creativityEduContext, UserManager<AppUser> userManager)
        {
            _CreativityEduContext = creativityEduContext;
            _userManager = userManager;
        }





        public IActionResult Index()
        {
            var listEmployees = _CreativityEduContext.Employess.Include(x => x.User).Where(x => x.IsDelete == false).ToList();
            return View(listEmployees);
        }




        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateVm empolyee)
        {
            var newUser = new AppUser
            {
                FirstName = empolyee.FirstName,
                LastName = empolyee.LastName,
                Email = empolyee.Email,
                Gender = empolyee.Gender,
                Address = empolyee.Address, 
                PhoneNumber = empolyee.PhoneNumber,
                UserName = empolyee.Email,
            };
            var result = await _userManager.CreateAsync(newUser, empolyee.Password);


            var newEmployee = new Employess
            {
                Sallary = empolyee.Salary,
                Department = empolyee.Departmant,
                UserId = newUser.Id
            };
            await _CreativityEduContext.Employess.AddAsync(newEmployee);
            await _CreativityEduContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //EDIT EMPLOYEE
        public IActionResult Edit(long id)
        {
            //search employee in db  by id 
            var employee = _CreativityEduContext.Employess.Include(x => x.User).FirstOrDefault(x => x.Id == id);

            //mapping data from employee class to createemolyeevm class 
            var updatEmployee = new EmployeeCreateVm()
            {

                Id = employee.Id,
                FirstName = employee.User.FirstName,
                LastName = employee.User.LastName,
                Email = employee.User.Email,
                Db = employee.User.DateOfBirthDate,
                Departmant = employee.Department,
                PhoneNumber = employee.User.PhoneNumber,
                Salary = employee.Sallary
            };
            return View("Edit", updatEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeCreateVm employee)
        {
            //search employee in db by id 
            var editEmployee = await _CreativityEduContext.Employess.FirstOrDefaultAsync(x => x.Id == employee.Id);
            editEmployee.Department = employee.Departmant;
            await _CreativityEduContext.SaveChangesAsync();

            var userDb = await _userManager.FindByIdAsync(editEmployee.UserId);
            userDb.FirstName = employee.FirstName;
            userDb.LastName = employee.LastName;
            userDb.PhoneNumber = employee.PhoneNumber;
            userDb.Email = employee.Email;
            userDb.UserName = employee.Email;

            await _userManager.UpdateAsync(userDb);
            await _CreativityEduContext.SaveChangesAsync();

            return RedirectToAction("index");
        }


        public IActionResult Delete(long id)
        {
            var employee = _CreativityEduContext.Employess.FirstOrDefault(x => x.Id == id);
            employee.IsDelete = true;
            _CreativityEduContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}


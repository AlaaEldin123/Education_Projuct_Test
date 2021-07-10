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
    public class StudentController : Controller
    {


        private CreativityEduContext _creativityEduContext;
        private UserManager<AppUser> _userManager;

        public StudentController(CreativityEduContext dbContext, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _creativityEduContext = dbContext;
        }

        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentVm student)
        {

            var user = new AppUser
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                PhoneNumber = student.PhoneNumber,
                Email = student.Email,
                UserName = student.Email
            };
            var newUser = await _userManager.CreateAsync(user, student.Password);



            var newStudent = new Student
            {
                Nationality = student.Nationlaity,
                Status = Enums.StudentStatus.On,
                User = user
                //UserId = user.Id
            };
            await _creativityEduContext.Students.AddAsync(newStudent);
            await _creativityEduContext.SaveChangesAsync();

            return RedirectToAction("index");
        }


        public IActionResult Index()
        {
            var allStudent = _creativityEduContext.Students.Where(x => x.IsDelete == false).Include(x => x.User).ToList();
            return View(allStudent);
        }

        public IActionResult Edit(long id)
        {
            //search student in db  by id 
            var student = _creativityEduContext.Students.Include(x => x.User).FirstOrDefault(x => x.Id == id);


            var updateStudent = new CreateStudentVm
            {

                Id = student.Id,
                FirstName = student.User.FirstName,
                LastName = student.User.LastName,
                Email = student.User.Email,
                Db = student.User.DateOfBirthDate,
                Nationlaity = student.Nationality,
                PhoneNumber = student.User.PhoneNumber
            };



            return View("Edit", updateStudent);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(CreateStudentVm student)
        {
            //search student in db by id 
            var editStudent = await _creativityEduContext.Students.FirstOrDefaultAsync(x => x.Id == student.Id);
            editStudent.Nationality = student.Nationlaity;
            await _creativityEduContext.SaveChangesAsync();

            var userDb = await _userManager.FindByIdAsync(editStudent.UserId);
            userDb.FirstName = student.FirstName;
            userDb.LastName = student.LastName;
            userDb.PhoneNumber = student.PhoneNumber;
            userDb.Email = student.Email;
            userDb.UserName = student.Email;

            await _userManager.UpdateAsync(userDb);
            await _creativityEduContext.SaveChangesAsync();

            return RedirectToAction("index");
        }





        


        public IActionResult Delete(long id)
        {
            var student = _creativityEduContext.Students.FirstOrDefault(x => x.Id == id);
            student.IsDelete = true;
            _creativityEduContext.SaveChanges();


            return RedirectToAction("Index");
        }





    }
}

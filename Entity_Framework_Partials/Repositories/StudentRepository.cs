using Entity_Framework_Partials.DataBase;
using Entity_Framework_Partials.Interfaces;
using Entity_Framework_Partials.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Partials.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        #region D.I
        private readonly SchoolDbContext _db;

        public StudentRepository(SchoolDbContext db)
        {
            _db = db;
        }
        #endregion

        #region (C)reate
        public async Task<Student> CreateStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.FirstName) || string.IsNullOrWhiteSpace(student.LastName) ||
                string.IsNullOrWhiteSpace(student.Email) || string.IsNullOrWhiteSpace(student.PhoneNumber))
            {
                return null;
            }
            var newStudent = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                Email = student.Email,
                Courses = student.Courses,
                PhoneNumber = student.PhoneNumber,
            };

            if (newStudent == null)
            {
                return null;
            }

            await _db.Students.AddAsync(newStudent);

            await _db.SaveChangesAsync();

            return newStudent;

        }
        #endregion

        #region (R)ead
        public async Task<List<Student>> AllStudents()
        {
            var students = await _db.Students.ToListAsync();

            if (students == null || students.Count == 0)
            {
                return null;
            }
            return students;
        }

        public async Task<Student> FindStudent(Guid id)
        {
            if (id == null)
            {
                return null;
            }
            var student = await _db.Students.SingleOrDefaultAsync(x => x.Id == id);

            if (student == null)
            {
                return null;
            }
            return student;
        }
        #endregion

        #region (U)pdate
        public async Task<Student> EditStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.FirstName) || string.IsNullOrWhiteSpace(student.LastName) ||
                string.IsNullOrWhiteSpace(student.Email) || string.IsNullOrWhiteSpace(student.PhoneNumber))
            {
                return null;
            }
            var original = await _db.Students.SingleOrDefaultAsync(x => x.Id == student.Id);

            if (original == null)
            {
                return null;
            }

            original.FirstName = student.FirstName;
            original.LastName = student.LastName;
            original.Age = student.Age;
            original.Email = student.Email;
            original.Courses = student.Courses;
            original.PhoneNumber = student.PhoneNumber;

            await _db.SaveChangesAsync();

            return original;
        }
        #endregion

        #region (D)elete
        public async Task<bool> DeleteStudent(Guid id)
        {
            if (id == null)
            {
                return false;
            }

            var student = await _db.Students.SingleOrDefaultAsync(x => x.Id == id);

            if (student == null)
            {
                return false;
            }

            _db.Students.Remove(student);

            await _db.SaveChangesAsync();

            return true;
        }
        #endregion
    }
}

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
    public class TeacherRepository : ITeacherRepository
    {
        #region D.I
        private readonly SchoolDbContext _db;

        public TeacherRepository(SchoolDbContext db)
        {
            _db = db;
        }
        #endregion

        #region (C)reate
        public async Task<Teacher> CreateTeacher(Teacher teacher)
        {
            if (string.IsNullOrWhiteSpace(teacher.FirstName) || string.IsNullOrWhiteSpace(teacher.LastName) ||
                string.IsNullOrWhiteSpace(teacher.Email) || string.IsNullOrWhiteSpace(teacher.PhoneNumber))
            {
                return null;
            }

            var newTeacher = new Teacher()
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Age = teacher.Age,
                Email = teacher.Email,
                PhoneNumber = teacher.PhoneNumber,
            };

            if (newTeacher == null)
            {
                return null;
            }

            await _db.Teachers.AddAsync(newTeacher);

            await _db.SaveChangesAsync();

            return newTeacher;
        }
        #endregion

        #region (R)ead
        public async Task<Teacher> FindTeacher(Guid id)
        {
            if (id == null)
            {
                return null;
            }

            var teacher = await _db.Teachers.SingleOrDefaultAsync(x => x.Id == id);

            if (teacher == null)
            {
                return null;
            }
            return teacher;
        }

        public async Task<List<Teacher>> AllTeachers()
        {
            var teachers = await _db.Teachers.ToListAsync();

            if (teachers == null || teachers.Count == 0)
            {
                return null;
            }

            return teachers;
        }
        #endregion

        #region (U)pdate
        public async Task<Teacher> EditTeacher(Teacher teacher)
        {
            if (string.IsNullOrWhiteSpace(teacher.FirstName) || string.IsNullOrWhiteSpace(teacher.LastName) ||
                string.IsNullOrWhiteSpace(teacher.Email) || string.IsNullOrWhiteSpace(teacher.PhoneNumber))
            {
                return null;
            }

            var original = await _db.Teachers.SingleOrDefaultAsync(x => x.Id == teacher.Id);

            if (original == null)
            {
                return null;
            }

            original.FirstName = teacher.FirstName;
            original.LastName = teacher.LastName;
            original.Age = teacher.Age;
            original.Email = teacher.Email;
            original.PhoneNumber = teacher.PhoneNumber;

            await _db.SaveChangesAsync();

            return original;
        }
        #endregion

        #region (D)elete
        public async Task<bool> DeleteTeacher(Guid id)
        {
            if (id == null)
            {
                return false;
            }

            var teacher = await _db.Teachers.SingleOrDefaultAsync(x => x.Id == id);

            if (teacher == null)
            {
                return false;
            }
            _db.Teachers.Remove(teacher);

            var test = await _db.SaveChangesAsync();

            return true;
        }
        #endregion
    }
}

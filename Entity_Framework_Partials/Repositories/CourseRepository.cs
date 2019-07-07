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
    // Potentially add more methods here later for Assignments.
    public class CourseRepository : ICourseRepository
    {
        #region D.I
        private readonly SchoolDbContext _db;

        public CourseRepository(SchoolDbContext db)
        {
            _db = db;
        }
        #endregion

        #region (C)Reate
        public async Task<Course> CreateCourse(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.Name))
            {
                return null;
            }

            var newCourse = new Course()
            {
                Name = course.Name,
                Points = course.Points,
                Students = course.Students,
                Assignments = course.Assignments,
                Grade = course.Grade,
                Teacher = course.Teacher,
                Description = course.Description
            };

            if (newCourse == null)
            {
                return null;
            }
            await _db.Courses.AddAsync(newCourse);

            await _db.SaveChangesAsync();

            return newCourse;
        }
        #endregion

        #region (R)ead
        public async Task<Course> FindCourse(Guid id)
        {
            if (id == null)
            {
                return null;
            }
            var course = await _db.Courses.SingleOrDefaultAsync(x => x.Id == id);

            if (course == null)
            {
                return null;
            }

            return course;
        }

        public async Task<List<Course>> AllCourses()
        {
            var courses = await _db.Courses.ToListAsync();

            if (courses == null || courses.Count == 0)
            {
                return null;
            }
            return courses;
        }
        #endregion

        #region (U)pdate
        public async Task<Course> EditCourse(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.Name))
            {
                return null;
            }

            var original = await _db.Courses.SingleOrDefaultAsync(x => x.Id == course.Id);

            if (original == null)
            {
                return null;
            }

            original.Name = course.Name;
            original.Points = course.Points;
            original.Students = course.Students;
            original.Assignments = course.Assignments;
            original.Grade = course.Grade;
            original.Teacher = course.Teacher;
            original.Description = course.Description;

            await _db.SaveChangesAsync();

            return original;
        }
        #endregion

        #region (D)elete
        public async Task<bool> DeleteCourse(Guid id)
        {
            if (id == null)
            {
                return false;
            }

            var course = await _db.Courses.SingleOrDefaultAsync(x => x.Id == id);

            if (course == null)
            {
                return false;
            }

            _db.Courses.Remove(course);

            await _db.SaveChangesAsync();

            return true;
        }
        #endregion
    }
}

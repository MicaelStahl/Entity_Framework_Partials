using Entity_Framework_Partials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Partials.Interfaces
{
    // Add extra methods for Assignment here later.
    public interface ICourseRepository
    {
        // (C)RUD
        public Task<Course> CreateCourse(Course course);

        //C(R)UD
        public Task<Course> FindCourse(Guid id);
        public Task<List<Course>> AllCourses();

        // CR(U)D
        public Task<Course> EditCourse(Course course);

        // CRU(D)
        public Task<bool> DeleteCourse(Guid id);
    }
}

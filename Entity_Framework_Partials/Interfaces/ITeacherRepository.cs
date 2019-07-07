using Entity_Framework_Partials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Partials.Interfaces
{
    interface ITeacherRepository
    {
        // (C)RUD
        public Task<Teacher> CreateTeacher(Teacher teacher);

        //C(R)UD
        public Task<Teacher> FindTeacher(Guid id);
        public Task<List<Teacher>> AllTeachers();

        // CR(U)D
        public Task<Teacher> EditTeacher(Teacher teacher);

        // CRU(D)
        public Task<bool> DeleteTeacher(Guid id);
    }
}

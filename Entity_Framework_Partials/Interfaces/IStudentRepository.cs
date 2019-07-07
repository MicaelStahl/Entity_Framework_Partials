using Entity_Framework_Partials.DataBase;
using Entity_Framework_Partials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Partials.Interfaces
{
    public interface IStudentRepository
    {
        // (C)RUD
        public Task<Student> CreateStudent(Student student);

        // C(R)UD
        public Task<Student> FindStudent(Guid id);
        public Task<List<Student>> AllStudents();

        // CR(U)D
        public Task<Student> EditStudent(Student student);

        // CRU(D)
        public Task<bool> DeleteStudent(Guid id);
    }
}

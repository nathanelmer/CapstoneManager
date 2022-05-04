using CapstoneManager.Models;
using System.Collections.Generic;

namespace CapstoneManager.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetStudentsByClassId(int id);
        Student GetStudentById(int id);
        public void Update(Student student);
        public void Add(Student student);
        public void Delete(int id);
    }
}
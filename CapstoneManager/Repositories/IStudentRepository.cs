using CapstoneManager.Models;
using System.Collections.Generic;

namespace CapstoneManager.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetStudentsByClassId(int id);
        Student GetStudentById(int id);
    }
}
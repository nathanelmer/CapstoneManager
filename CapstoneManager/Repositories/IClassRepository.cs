using CapstoneManager.Models;
using System.Collections.Generic;

namespace CapstoneManager.Repositories
{
    public interface IClassRepository
    {
        List<Class> GetClassesByTeacherId(int id);
        int Add(Class newClass);
        void AddTeacherClass(TeacherClass tc);
    }
}
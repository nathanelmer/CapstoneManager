using CapstoneManager.Models;
using System.Collections.Generic;

namespace CapstoneManager.Repositories
{
    public interface IClassRepository
    {
        List<Class> GetClassesByTeacherId(int id);
    }
}
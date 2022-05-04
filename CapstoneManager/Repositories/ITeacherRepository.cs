using CapstoneManager.Models;

namespace CapstoneManager.Repositories
{
    public interface ITeacherRepository
    {
        Teacher GetByFirebaseUserId(string id);
        void Add(Teacher teacher);
    }
}
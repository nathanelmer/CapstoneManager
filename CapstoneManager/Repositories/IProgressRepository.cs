using CapstoneManager.Models;
using System.Collections.Generic;

namespace CapstoneManager.Repositories
{
    public interface IProgressRepository
    {
        List<Progress> GetProgressTypes();
    }
}
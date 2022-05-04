using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapstoneManager.Repositories;
using CapstoneManager.Models;

namespace CapstoneManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepo;
        public TeacherController(ITeacherRepository teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }
        [HttpGet("{firebaseUserId}")]
        public IActionResult GetTeacher(string firebaseUserId)
        {
            return Ok(_teacherRepo.GetByFirebaseUserId(firebaseUserId));
        }

        [HttpGet("DoesUserExist/{firebaseUserId}")]
        public IActionResult DoesUserExist(string firebaseUserId)
        {
            var teacher = _teacherRepo.GetByFirebaseUserId(firebaseUserId);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Post(Teacher teacher)
        {
            _teacherRepo.Add(teacher);
            return NoContent();
        }
    }
}

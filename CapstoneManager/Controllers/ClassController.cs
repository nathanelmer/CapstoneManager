using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapstoneManager.Repositories;
using CapstoneManager.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace CapstoneManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepo;
        private readonly IClassRepository _classRepository;
        public ClassController(ITeacherRepository teacherRepo, IClassRepository classRepo)
        {
            _teacherRepo = teacherRepo;
            _classRepository = classRepo;
        }
        private Teacher GetCurrentTeacher()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _teacherRepo.GetByFirebaseUserId(firebaseUserId);
        }
        [HttpGet]
        public IActionResult GetTeachersClasses()
        {
            var teacher = GetCurrentTeacher();
            try
            {
                return Ok(_classRepository.GetClassesByTeacherId(teacher.Id));
            } 
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet("all")]
        public IActionResult GetAllClasses()
        {
            try
            {
                var classes = _classRepository.GetAllClasses();
                return Ok(classes);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost("join")]
        public IActionResult JoinClass(TeacherClass tc)
        {
            try
            {
                tc.TeacherId = GetCurrentTeacher().Id;
                _classRepository.AddTeacherClass(tc);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(Class newClass)
        {
            
            try
            {
                var teacher = GetCurrentTeacher();
                int classId = _classRepository.Add(newClass);
                var tc = new TeacherClass
                {
                    ClassId = classId,
                    TeacherId = teacher.Id
                };
                _classRepository.AddTeacherClass(tc);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _classRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

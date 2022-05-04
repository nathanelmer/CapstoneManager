using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapstoneManager.Repositories;
using Microsoft.AspNetCore.Authorization;
using CapstoneManager.Models;
using System;

namespace CapstoneManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;
        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }
        [HttpGet("{id}")]
        public IActionResult GetStudentsByClassId(int id)
        {
            try
            {
                return Ok(_studentRepo.GetStudentsByClassId(id));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            
        }
        [HttpGet("details/{id}")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                return Ok(_studentRepo.GetStudentById(id));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            
        }
        [HttpPut("edit/{id}")]
        public IActionResult Put(int id, Student student)
        {
                if (id != student.Id)
                {
                    return BadRequest();
                }
                else
                {
                    _studentRepo.Update(student);
                    return NoContent();
                }   
        }
        [HttpPost]
        public IActionResult Post(Student student)
        {
            try
            {
                _studentRepo.Add(student);
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
                _studentRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }
    }
}

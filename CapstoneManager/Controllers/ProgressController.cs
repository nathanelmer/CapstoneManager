using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapstoneManager.Repositories;
using System.Collections.Generic;
using System;

namespace CapstoneManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressRepository _progressRepository;
        public ProgressController(IProgressRepository progressRepository)
        {
            _progressRepository = progressRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_progressRepository.GetProgressTypes());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

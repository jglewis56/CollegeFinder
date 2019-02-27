using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeFinder.Api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CollegeFinder.Api.Models;

namespace CollegeFinder.API.Controllers
{
    // See a list of colleges in the system
    // Add a new college to the system
    // Click on a college to see the details
    // Edit the details of a college(from the details screen)
    // Delete a college from the system
    
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeRepository _repo;
        private readonly IConfiguration _config;
        private readonly DataContext _context;

        public CollegeController(ICollegeRepository repo, IConfiguration config, DataContext context)
        {
            _repo = repo;
            _config = config;
            _context = context;
        }

        //Get api/colleges
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _context.Colleges.ToListAsync();
            return Ok(values);
        }
        [HttpPost("new")]

        public async Task<IActionResult> AddNewCollege(string name, string location, List<Major> majors)
        {
            if(await _repo.CollegeExists(name))
            {
                return BadRequest("College exists");
            }
            var college = new College{
                Name = name,
                Location = location,
                Majors = majors
            };
            var createdCollege = await _repo.AddNewCollege(college);
            return StatusCode(201);
        }

        [HttpPost("update/{name}")]
        public async Task<IActionResult> UpdateCollege(string name)
        {
            if (await _repo.CollegeExists(name))
            {
                await _repo.UpdateCollege(name);
                return StatusCode(201);
            }
            return BadRequest("College does not exist");
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            if (await _repo.CollegeExists(name))
            {
                await _repo.DeleteCollege(name);
                return StatusCode(201);
            }
            return BadRequest("College does not exist");
        }
    }
}
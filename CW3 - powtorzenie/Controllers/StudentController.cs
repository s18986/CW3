using CW3___powtorzenie.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW3___powtorzenie.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IDbService _DbService;
        public StudentController(IDbService dbService)
        {
            _DbService = dbService;
        }
        [HttpGet("{id}")]
        public IActionResult getStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2)
            {
                return Ok("Malewski");
            }
            else
            {
                return NotFound("Nie znaleziono takiego studenta");
            }
        }

        [HttpGet]
        public IActionResult getStudents(string Orderby)
        {
            return Ok(_DbService.GetStudents());
        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.indexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {
            return Ok("Aktualizacja dokonczona");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok("Usuwanie dokonczone");
        }
    }
}

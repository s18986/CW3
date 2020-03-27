using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CW3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        
        [HttpGet("{id}")]
        public IActionResult getStudent(int id)
        {
            if(id==1)
            {
                return Ok("Kowalski");
            }else if(id==2)
            {
                return Ok("Malewski");
            }else
            {
                return NotFound("Nie znaleziono takiego studenta");
            }
        }
        
        [HttpGet]
        public string getStudents(string Orderby)
        {
            return $"Kowalski, Malewski, Andrzejewski sortowanie={Orderby}";
        }
        [HttpPost]
        public IActionResult CreateStudent(Models.Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }
        [HttpPut]
        public IActionResult PutStudent(String id)
        {
            return Ok(200);
        }
        [HttpDelete]
        public IActionResult DeleteStudent(String id)
        {
            Console.WriteLine("Usuwanie ukonczone")
            return Ok(200);
        }
    }
}
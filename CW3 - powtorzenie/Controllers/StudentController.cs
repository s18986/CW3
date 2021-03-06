﻿using CW3___powtorzenie.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CW3___powtorzenie.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IDbService _DbService;
        public const string ConString = "Data Source=db-mssql;Initial Catalog=s18986;Integrated Security=True";
        public StudentController(IDbService dbService)
        {
            _DbService = dbService;
        }
        /*
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
        */
        [HttpGet]
        public IActionResult getStudents()
        {
            var list = new List<Student>();
                using (SqlConnection con = new SqlConnection(ConString))
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "select * from Dbo.Student, Dbo.Enrollment, Studies where Dbo.Enrollment.IdEnrollment=Dbo.Student.IdEnrollment and Dbo.Enrollment.IdStudy=Dbo.Studies.IdStudy";
                    con.Open();

                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        var st = new Student();
                        st.indexNumber = dr["IndexNumber"].ToString();
                        st.Firstname = dr["FirstName"].ToString();
                        st.Lastname = dr["LastName"].ToString();
                        st.Semester = (int)dr["Semester"];
                        st.BirthDate = (DateTime)dr["BirthDate"];
                        st.Studia = dr["Name"].ToString();
                        list.Add(st);
                    }
                };
           return Ok(list);
        }
         [HttpGet("{IndexNumber}")]
         public IActionResult getStudent(string IndexNumber)
         {
             using (SqlConnection con = new SqlConnection(ConString))
             using (SqlCommand com = new SqlCommand())
             {
                 com.Connection = con;
                 com.CommandText = "select * from Dbo.Student, Dbo.Enrollment where IndexNumber = @index and Dbo.Enrollment.IdEnrollment=Dbo.Student.IdEnrollment";
                com.Parameters.AddWithValue("index", IndexNumber);
                 con.Open();

                 var dr = com.ExecuteReader();
                 while (dr.Read())
                 {
                     var st = new Student();
                     st.indexNumber = dr["IndexNumber"].ToString();
                     st.Firstname = dr["FirstName"].ToString();
                     st.Lastname = dr["LastName"].ToString();
                     return Ok(st);
                 }

             }
             return NotFound();
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

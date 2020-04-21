using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW3___powtorzenie.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;
        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student{ idStudent=1, Firstname="Jan", Lastname="Kowalski"},
                new Student{ idStudent=2, Firstname="Grzegorz", Lastname="Rafczyk"},
                new Student{ idStudent=3, Firstname="Michał", Lastname="Alajak"}
            };
        }
        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}

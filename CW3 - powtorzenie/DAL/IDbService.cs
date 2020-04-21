using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW3___powtorzenie.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}

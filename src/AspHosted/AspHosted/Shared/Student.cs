using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspHosted.Shared
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}

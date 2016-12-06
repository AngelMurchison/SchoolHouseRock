using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHouseRockSQL
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Instructor { get; set; }

        public int? CourseNumber { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Title}, {Instructor} -- {CourseNumber}.";
        }
    }
}

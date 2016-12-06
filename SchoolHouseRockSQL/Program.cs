using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SchoolHouseRockSQL
{
    class Program
    {
        static List<Course> ReadFromCourses(SqlConnection conn)
        {
            var rv = new List<Course>();
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"SELECT ID, Title, Instructors, CourseNumber FROM Courses";

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader[0];
                    var title = reader[1];
                    var instructors = reader[2];
                    var courseid = reader[3];
                    var course = new Course
                    {
                        Id = (int)id,
                        Title = title as string,
                        Instructor = instructors as string,
                        CourseNumber = courseid as int?
                    };
                    rv.Add(course);
                }
                conn.Close();
            }
            return rv;
        }


        static List<Course> CountCourses(SqlConnection conn)
        {
            var rv = new List<Course>();
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"SELECT ID FROM Courses";

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader[0];
                    var course = new Course
                    {
                        Id = (int)id
                    };
                    rv.Add(course);
                }
                conn.Close();
            }
            return rv;
        }


        static void Main(string[] args)
        {
            var connectionStrings = @"Server=localhost\SQLEXPRESS;Database=DotNetUniversity;Trusted_Connection=True;";
            using (var connection = new SqlConnection(connectionStrings))
            {
                var courseCount = CountCourses(connection);
                var courses = ReadFromCourses(connection);
                foreach (var course in courses)
                {
                    Console.WriteLine(course);
                }
                Console.ReadLine();
                Console.WriteLine($"There are {courseCount.Count} courses at Dot Com University!");
                Console.ReadLine();
            }
        }
    }
}

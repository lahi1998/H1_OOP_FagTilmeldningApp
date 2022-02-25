using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldningApp.Codes
{
    internal class DatabaseHandler
    {
        enum TecDBTables
        {
            Teacher,
            Course,
            Student,
            Enrollment
        }
        public string ConnectionString
        {
            get => "Data Source=SKAB1-PC-05;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public object GetRecords(TecDBTables tableName)
        {
            object list = new object();
            using SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            SqlCommand command = new SqlCommand($"SELECT * FROM {tableName}", con);

            SqlDataReader reader = command.ExecuteReader();
            switch (tableName)
            {
                case TecDBTables.Teacher:
                    List<Teacher> teachers = new List<Teacher>();
                    while (reader.Read())
                    {
                        teachers.Add(new Teacher() { TeacherId = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2) });
                    }
                    list = teachers;
                    break;
                case TecDBTables.Course:
                    List<Course> courses = new List<Course>();
                    while (reader.Read())
                    {
                        courses.Add(new Course() { CourseId = reader.GetInt32(0), Coursename = reader.GetString(1), TeacherID = reader.GetInt32(2) });
                    }
                    list = courses;
                    break;
                case TecDBTables.Student:
                    List<Student> students = new List<Student>();
                    while (reader.Read())
                    {
                        students.Add(new Student() { StudentId = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2) });
                    }
                    list = students;
                    break;
                case TecDBTables.Enrollment:
                    List<Enrollment> enrollments = new List<Enrollment>();
                    while (reader.Read())
                    {
                        enrollments.Add(new Enrollment() { Id = reader.GetInt32(0), StudentId = reader.GetInt32(1), CourseId = reader.GetInt32(2) });
                    }
                    list = enrollments;
                    break;
            }

            return list;
        }
    }



        
}

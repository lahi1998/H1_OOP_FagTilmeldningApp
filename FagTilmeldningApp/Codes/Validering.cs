using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldningApp.Codes
{
    internal class Validering
    {



        public string Input_Control(string t1, string t2)
        {
            string tjek1svar = "n", tjek2svar = "n";
            string returnsvar = "h";

            if (t1.All(char.IsDigit))
            {
                tjek1svar = "y";
            }

            if (t2.All(char.IsDigit))
            {
                tjek2svar = "y";

            }

            //retursvar valg
            if (tjek1svar == "y" && tjek2svar == "n")
            {
                returnsvar = "c";
            }
            if (tjek1svar == "n" && tjek2svar == "y")
            {
                returnsvar = "b";
            }
            if (tjek1svar == "n" && tjek2svar == "n")
            {
                returnsvar = "d";
            }
            if (tjek1svar == "y" && tjek2svar == "y")
            {
                returnsvar = "a";

            }
            return returnsvar;
        }

        public int Student_Course_Control(int s1, int s2, List<Student> students, List<Course> courses)
        {

            
            string Ssvar = "n", Csvar = "n";
            int svar = 2;
            Student student = students.FirstOrDefault(a => a.Id == s1);
            if (student != null)
            {
                Ssvar = "y";
            }

            Course course = courses.FirstOrDefault(c => c.Id == s2);
            if (course != null)
            {
                Csvar = "y";
            }
            
            //retursvar valg
            if (Ssvar == "y" && Csvar == "y")
            {
                svar = 1;
            }
            if (Ssvar == "n" && Csvar == "n")
            {
                svar = 2;
            }
            if (Ssvar == "n" && Csvar == "y")
            {
                svar = 3;
            }
            if (Ssvar == "y" && Csvar == "n")
            {
                svar = 4;
            }

            

            return svar;

        }

        public int Control_Enrollments(int e1, int e2, List<Enrollment> enrollments)
        {

            int tjeksvar1 = 2;
            foreach (Enrollment line in enrollments)
            {
                if (line.StudentId == e1 && line.CourseId == e2)
                {
                    tjeksvar1 = 1;
                }
            }

            return tjeksvar1;
        }
    }
}

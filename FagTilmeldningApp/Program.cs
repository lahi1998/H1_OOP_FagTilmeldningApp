global using FagTilmeldningApp.Codes;
global using FagTilmeldningApp.Codes.Models;

//Iteration 2

//Lists
List<Teacher> teachers = new()
{
    new Teacher() { Id = 1, FirstName = "Niels", LastName = "Olesen" },
    new Teacher() { Id = 2, FirstName = "Henrik", LastName = "Paulsen" }

};

List<Student> students = new()
{
    new Student() { Id = 1, FirstName = "martin", LastName = "Jensen" },
    new Student() { Id = 1, FirstName = "Patrik", LastName = "Nielsen" },
    new Student() { Id = 1, FirstName = "Susanne", LastName = "Hansen" },
    new Student() { Id = 1, FirstName = "Thomas", LastName = "Olsen" }

};

List<Course> courses = new()
{
    new Course() { Id = 1, Coursename = "Grundlæggende programmering", TeacherID = 1 },
    new Course() { Id = 2, Coursename = "Database programmering", TeacherID = 1 },
    new Course() { Id = 6, Coursename = "Studieteknik", TeacherID = 1 },
    new Course() { Id = 7, Coursename = "Cleintside programmering", TeacherID = 2 }

};

List<Enrollment> enrollments = new()
{

};




//Fag og forløb linje
Semester SM = new();



int tæller = 0;
int Nstudentid;
int Ncourseid;
string systemsvar;
string? tjek1, tjek2;
string tjeksvar = "h";
//menu + lidt kontrollering om det tal og om de er i systemet
do
{
    Console.Clear();
    Console.WriteLine("-------------------------------------");
    Console.WriteLine(SM.SchoolName + "," + " " + SM.SemesterNavn + " " + "Fag tilmeldning app");
    Console.WriteLine("-------------------------------------");
    Console.WriteLine("ingen bogstaver i ID");
    Console.WriteLine("-------------------------------------");

    if (tjeksvar == "b")
    {
        Console.WriteLine("du må ikke bruge bogstaver, du brugte dem i elev id");
    }
    if (tjeksvar == "c")
    {
        Console.WriteLine("du må ikke bruge bogstaver, du brugte dem i høvedforløb id");
    }
    if (tjeksvar == "d")
    {
        Console.WriteLine("du må da være dum");
    }

    Console.WriteLine("indsæt elev id");
    tjek1 = Console.ReadLine();
   

    Console.WriteLine("indsæt hovedforløb id");
    tjek2 = Console.ReadLine();
    

    Validering sq = new();
    tjeksvar = (sq.Inputcontrol(t1: tjek1, t2: tjek2));

} while (tjeksvar !="a");


Ncourseid = Convert.ToInt32(tjek2);
Nstudentid = Convert.ToInt32(tjek1);
Validering q = new();
systemsvar = (q.Student_course_control(s1: Nstudentid, s2: Ncourseid));




Enrollment NewEnrollment = new Enrollment() { Id = tæller, StudentId = Nstudentid, CourseId = Ncourseid };
enrollments.Add(NewEnrollment);

foreach (Enrollment line in enrollments)
{
    tæller++;
}





Console.ReadKey();


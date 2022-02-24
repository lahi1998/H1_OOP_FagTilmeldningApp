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
    new Student() { Id = 1, FirstName = "Martin", LastName = "Jensen" },
    new Student() { Id = 2, FirstName = "Patrik", LastName = "Nielsen" },
    new Student() { Id = 3, FirstName = "Susanne", LastName = "Hansen" },
    new Student() { Id = 4, FirstName = "Thomas", LastName = "Olsen" }

};

List<Course> courses = new()
{
    new Course() { Id = 1, Coursename = "Grundlæggende programmering", TeacherID = 1 },
    new Course() { Id = 2, Coursename = "Database programmering", TeacherID = 1 },
    new Course() { Id = 6, Coursename = "Studieteknik", TeacherID = 1 },
    new Course() { Id = 7, Coursename = "Clientside programmering", TeacherID = 2 }

};

List<Enrollment> enrollments = new()
{

};

Console.Write("Angiv skole: ");
string SchoolName = Console.ReadLine();

Console.Write("Angiv Hovedforløb: ");
string SemesterNavn = Console.ReadLine();


//parent: school child:semerster grandchild: Uddannelselinje
Semester FM = new(SemesterNavn, SchoolName);










string flere_elever = "n", elev = null;

do
{
start:

    int systemsvar, retursvar;
    int Nstudentid, Ncourseid;
    int tæller = 0, tæller1 = 0, tæller2 = 0, tæller3 = 0;

    string? tjek1, tjek2;
    string tjeksvar = "?";


    //menu + lidt kontrollering om det tal og om de er i systemet
    do
    {


        do
        {
            //menu
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(FM.SchoolName + "," + " " + FM.SemesterNavn + " " + "Fag tilmeldning app");
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("ingen bogstaver i ID");
            Console.WriteLine("-------------------------------------");

            if (elev != null)
            {
                Console.SetCursorPosition(0, 12);
                Console.WriteLine(elev);
                Console.WriteLine("-------------------------------------");

            }    

            tæller = 0;
            tæller1 = 0;
            tæller2 = 0;
            tæller3 = 0;


            foreach (Enrollment line in enrollments)
            {
                if (line.CourseId == 1)
                {
                    tæller++;
                }
            }
            foreach (Enrollment line in enrollments)
            {
                if (line.CourseId == 2)
                {
                    tæller1++;
                }
            }
            foreach (Enrollment line in enrollments)
            {

                if (line.CourseId == 6)
                {
                    tæller2++;
                }
            }
            foreach (Enrollment line in enrollments)
            {
                if (line.CourseId == 7)
                {
                    tæller3++;
                }
            }

            Console.SetCursorPosition(0, 7);
            Console.WriteLine(tæller + " " + "Grundlæggende programmering");
            Console.WriteLine(tæller1 + " " + "Database programmering");
            Console.WriteLine(tæller2 + " " + "Studieteknik");
            Console.WriteLine(tæller3 + " " + "Clientside programmering");



            Console.SetCursorPosition(0, 16);
            Console.Write("indsæt elev id: ");
            tjek1 = Console.ReadLine();

            Console.SetCursorPosition(0, 17);
            Console.Write("indsæt hovedforløb id: ");
            tjek2 = Console.ReadLine();

            // tjekker om den tal
            Validering sq = new();
            tjeksvar = (sq.Input_Control(t1: tjek1, t2: tjek2));

            if (tjeksvar == "b")
            {
                Console.WriteLine("du må ikke bruge bogstaver, du brugte dem i elev id");
                Console.SetCursorPosition(0, 5);
            }
            if (tjeksvar == "c")
            {
                Console.WriteLine("du må ikke bruge bogstaver, du brugte dem i høvedforløb id");
                Console.SetCursorPosition(0, 5);
            }
            if (tjeksvar == "d")
            {
                Console.WriteLine("du må da være dum");
                Console.SetCursorPosition(0, 5);
            }


        } while (tjeksvar != "a");



        //tjekker om de er i systemet/listerne

        Ncourseid = Convert.ToInt32(tjek2);
        Nstudentid = Convert.ToInt32(tjek1);
        Validering q = new();
        systemsvar = (q.Student_Course_Control(s1: Nstudentid, s2: Ncourseid, students, courses));

        if (systemsvar == 2)
        {
            Console.WriteLine("det elev id samt hovedforløbs id du har intasted er ikke i systemet");
            Console.SetCursorPosition(0, 5);
        }
        if (systemsvar == 3)
        {
            Console.WriteLine("det elev id du har intasted er ikke i systemet");
            Console.SetCursorPosition(0, 5);
        }
        if (systemsvar == 4)
        {
            Console.WriteLine("det hovedforløbs id du har intasted er ikke i systemet");
            Console.SetCursorPosition(0, 5);
        }

    } while (systemsvar != 1);



    elev = null;

    //tjek om elev er sat til hovedforløbet
    Validering t = new();
    retursvar = (t.Control_Enrollments(e1: Nstudentid, e2: Ncourseid, enrollments));





    if (retursvar == 1)
    {
        Console.Clear();
        Console.SetCursorPosition(10, 10);
        Console.WriteLine("elev er allerede i klasse");
        System.Threading.Thread.Sleep(5000);
    }

    if (retursvar == 1)
    {
        goto start;
    }

    if (retursvar == 2)
    {
        Student student = students.FirstOrDefault(a => a.Id == Nstudentid);
        Course course = courses.FirstOrDefault(b => b.Id == Ncourseid);

        elev = (student.FirstName + " " + student.LastName + " " + course.Coursename);
        
    }


    //adder til listen Enrollment med hvad elev er i et kursus der sammen.
    Enrollment NewEnrollment = new Enrollment() { Id = tæller, StudentId = Nstudentid, CourseId = Ncourseid };
    enrollments.Add(NewEnrollment);

    Console.WriteLine("");
    Console.Write(" vil du tilføje flere elever til hovedforløb y/n: ");
    flere_elever = Console.ReadLine();

} while (flere_elever == "y");


        Console.ReadKey();


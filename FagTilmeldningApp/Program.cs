global using FagTilmeldningApp.Codes;
global using FagTilmeldningApp.Codes.Models;

//Iteration 4

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


Console.Write("Angiv Uddannelselnje: ");
string uddannelselinje = Console.ReadLine();


string? uddannelseslinjeBeskrivelse = null;
bool exitLoop = false;
while (!exitLoop)
{
    Console.WriteLine();
    Console.WriteLine("Ønsker du at angiv en kort beskrivelse af uddannelseslinje: ");
    Console.WriteLine("1) Ja");
    Console.WriteLine("2) Nej");
    Console.Write("Vælg 1 eller 2: ");
    switch ((Console.ReadKey()).Key)
    {
        case ConsoleKey.D1:
            Console.WriteLine();
            Console.WriteLine("Angiv kort beskrivelse af uddannelseslinje: ");
            uddannelseslinjeBeskrivelse = Console.ReadLine();
            exitLoop = true;
            break;
        case ConsoleKey.D2:
            exitLoop = true;
            break;
        default:
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Forkert valgt, prøv igen: ");
            Console.ForegroundColor = ConsoleColor.White;
            break;
    }
}

//parent: school child:semerster
Semester FM = new(SemesterNavn, SchoolName);
if (uddannelseslinjeBeskrivelse != null)
    FM.SetUddannelseslinje(uddannelselinje, uddannelseslinjeBeskrivelse);
else
    FM.SetUddannelseslinje(uddannelselinje);



//indsæt elever i kurserne;
string? flere_elever = "n", elev = null;
do
{
start:

    int systemsvar, retursvar;
    int Nstudentid, Ncourseid;
    int tæller = 0, tæller1 = 0, tæller2 = 0, tæller3 = 0;

    string? tjek1, tjek2;
    string? tjeksvar = "?";

    //menu + lidt kontrollering om det tal og om de er i systemet
    do
    {
        do
        {
            //menu
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(FM.SchoolName + "," + " " + uddannelselinje + "," + " " + FM.SemesterNavn + " " + "Fag tilmeldning app.");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[ " + uddannelseslinjeBeskrivelse + " ]");
            Console.ForegroundColor = ConsoleColor.White;
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
            Console.Write("indsæt kursus id: ");
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


    Console.WriteLine();
    Console.WriteLine("vil du tilføje flere elever?");
    Console.WriteLine("1) Ja");
    Console.WriteLine("2) Nej");
    Console.Write("Vælg 1 eller 2: ");
    switch ((Console.ReadKey()).Key)
    {
        case ConsoleKey.D1:

            flere_elever = "y";
            break;
        case ConsoleKey.D2:
            flere_elever = "n";
            //menu
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(FM.SchoolName + "," + " " + uddannelselinje + "," + " " + FM.SemesterNavn + " " + "Fag tilmeldning app.");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[ " + uddannelseslinjeBeskrivelse + " ]");
            Console.ForegroundColor = ConsoleColor.White;
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

            Console.ReadKey();
            break;

    }


} while (flere_elever == "y");




Console.ReadKey();



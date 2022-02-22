using FagTilmeldningApp.Codes;
using FagTilmeldningApp.Codes.Models;
//Iteration 1

 
//Fag og forløb linje
Semester SM = new Semester();

Console.Clear();
Console.WriteLine("-------------------------------------");
Console.WriteLine(SM.SchoolName + "," + " " + SM.SemesterNavn + " " + "Fag tilmeldning app");
Console.WriteLine("-------------------------------------");




List<Teacher> teachers = new();
{
    new Teacher() { Id = 1, FirstName = "Niels", LastName = "Olesen" },
    new Teacher() { Id = 2, FirstName = "Henrik", LastName = "Paulsen" }

};

List<Student> students = new();
{
    new Student() { Id = 1, FirstName = "martin", LastName = "Jensen" },
    
}
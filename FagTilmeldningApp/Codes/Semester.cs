using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldningApp.Codes
{
    internal class Semester : School
    {
        public string? SemesterNavn { get; set; }

        public Semester(string? SemesterNavn, string? SchoolName) : base(SchoolName)
        {
            Console.Write("Angiv Hovedforløb: ");
            SemesterNavn = Console.ReadLine();
        }
    }
}

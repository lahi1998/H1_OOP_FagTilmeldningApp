using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldningApp.Codes
{
    internal class School
    {
        public string? SchoolName;

        public School(string? SchoolName)
        {
            Console.Write("Angiv skole:");
            SchoolName = Console.ReadLine();
        }

    }
}

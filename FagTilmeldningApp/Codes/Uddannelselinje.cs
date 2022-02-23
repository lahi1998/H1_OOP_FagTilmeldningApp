using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldningApp.Codes
{
    internal class Uddannelselinje : Semester
    {
        public string? uddannelselinje;

        public Uddannelselinje()
        {
            Console.Write("Angiv Uddannelselnje: ");
            uddannelselinje = Console.ReadLine();
        }
    }
}

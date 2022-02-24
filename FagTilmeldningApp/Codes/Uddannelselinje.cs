using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldningApp.Codes
{
    internal class Uddannelselinje : Semester
    {
        public string? uddannelselinje { get; set; }
        
        public Uddannelselinje(string? uddannelselinje, string? SemesterNavn, string? Schoolname) :base(SemesterNavn, Schoolname)
        {
            uddannelselinje = uddannelselinje;
        }

    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldningApp.Codes
{
    internal abstract class School
    {
        public string? SchoolName { get; set; }

        public abstract string? Uddannelseslinje { get; set; }

        public School(string? schoolName)
        {
            SchoolName = schoolName;
        }

        public abstract void SetUddannelseslinje(string uddannelseslinje);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldningApp.Codes
{
    internal class Validering
    {


        

        public string Inputcontrol(string t1, string t2)
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
    }
}

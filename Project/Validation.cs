using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project
{
    class Validation
    {
        public Boolean validateUsername(String usernameIn)
        {
            if (Regex.IsMatch(usernameIn, @"^[PI]{2}\d{6}"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean validatePassword(String passwordIn)
        {
            if (passwordIn.Length < 8)
            {
                return false;
            }
            if (!Regex.IsMatch(passwordIn, @"\d"))
            {
                return false;
            }
            if (!Regex.IsMatch(passwordIn, "[a-z]"))
            {
                return false;
            }
            if (!Regex.IsMatch(passwordIn, "[A-Z]"))
            {
                return false;
            }
            if (!Regex.IsMatch(passwordIn, "[#$?&@!*+/{£^>~|]"))
            {
                return false;
            }
            return true;
        }
    }
}

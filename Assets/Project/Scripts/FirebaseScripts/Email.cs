using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Scripts.FirebaseScripts
{
    public static class Email
    {
        public static string Parse(string email)
        {
            char[] separators = new char[] { ' ', '@', '.', '#', '[', ']', '%', '\'', '\"'};
            string[] splited = email.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(string.Empty, splited);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InformationTechnologyCompany
{
    public class NameDomen
    {
        static readonly string[] endOfEmails = { "@gmail.com", "@mail.ru", "@yahoo.com" };

        public static string EndOfEmail()
        {
            var rand = new Random();
            int index = rand.Next(0, endOfEmails.Length);
            string endOfEmail = endOfEmails[index];

            return endOfEmail;
        }
    }
}

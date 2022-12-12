using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Net;
using System.Runtime.InteropServices;

namespace Password_Generator
{
    internal class Program
    {
        private static void Generate_Password()
        {
            Random rand = new Random();
            Console.WriteLine("Input length of password");
            var pass_len = 0;
            var password_str = "";
            bool Checker()
            {
                try
                {
                    pass_len = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("!You typed non-integer!");
                    pass_len = 5;
                    return false;
                }
                return true;

            }
            if (Checker())
            {
                string letterset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@";
                List<string> password = new List<string>();
                for (int i = 0; i < pass_len; i++)
                {
                    int index = rand.Next(0, letterset.Length);
                    char ch = letterset[index];
                    password.Add((ch).ToString());
                }
                password_str = string.Join("", password);
                Console.WriteLine(password_str);
                Console.WriteLine("Does it password satisfies your security?");
                Console.WriteLine("Input yes or no");
                string user_choose = Console.ReadLine();
                if (user_choose == "yes")
                {
                    write_password(password_str);
                }
            }
        }
        static void system_exit()
        {
            Console.WriteLine("Do you want to leave?");
            Console.WriteLine("Input yes or no");
            string user_choice = Console.ReadLine();
            if (user_choice == "yes")
            {
                Environment.Exit(0);
            }
        }
        static void write_password(string generated_pass)
        {
            Console.WriteLine("Write site for which you want this password to be used");
            string site_name = Console.ReadLine();
            string path = "passwords.txt";
            using (FileStream file = new FileStream(path, FileMode.Append))
            using (StreamWriter stream = new StreamWriter(file))
                stream.WriteLine(site_name + " - " + generated_pass);
            Console.WriteLine("Password has been writen to passwords.txt");
        }
        static void menu()
        {
            string user_choice = Console.ReadLine().ToLower();
            if (user_choice == "show")
            {
                Console.WriteLine("Write the name of the site from which you need a password");
                string user_site = Console.ReadLine();
                string s;
                using (StreamReader file = new StreamReader("passwords.txt", Encoding.GetEncoding(1251)))
                    while ((s = file.ReadLine()) != null)
                    {
                        if (s.Contains(user_site))
                        {
                            Console.WriteLine(s);
                        }
                    }
            }
            if (user_choice == "new")
            {
                Generate_Password();
            }
            else
            {
                Console.WriteLine("There is no such command");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("HELLO, THIS IS PASSWORD GENERATOR");
            Console.WriteLine("You can type show to show your existing passwords or new to generate new password");
            while (true) {
               Console.WriteLine("Input command");
               menu();
            }
        }
    }
}

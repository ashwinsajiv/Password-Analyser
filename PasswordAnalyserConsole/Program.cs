using System;
using System.Threading.Tasks;
using PasswordAnalyserConsole.Services;

namespace PasswordAnalyserConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var option = "n";
            do
            {
                Console.Clear();
                string enterPassword = "Enter your password: ";
                string password = SecuredRead(enterPassword);
                Console.ReadKey();
                PasswordAnalyser pwa = new PasswordAnalyser(password);
                await pwa.CheckStrength();
                Console.WriteLine("Your password strength is " + pwa.Strength + " and it has been breached " + pwa.Breach + " times.");
                Console.WriteLine("Do you want to check again? (y/Y)");
                option = Console.ReadLine();
            } while (option == "y" || option == "Y");
        }
        static string SecuredRead(string enterPassword)
        {
            try
            {
                Console.Write(enterPassword);
                string password = "";
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        password += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                        {
                            password = password.Substring(0, (password.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            if (string.IsNullOrWhiteSpace(password))
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Password cannot be empty, press any key to continue");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nPress any key to see the results");
                                break;
                            }
                        }
                    }
                } while (true);
                return password;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

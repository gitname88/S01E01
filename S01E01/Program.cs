using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace cSharpeningS01E01
{
    class Program
    {
        static void Main(string[] args)
        {

            YearStats();

            ValidateEmail();

            SumOfNumbers();

            Console.ReadKey();


        }

        static void YearStats()
        {

            Console.WriteLine("Current date: " + DateTime.Today.ToString("yyyy/MM/dd"));
            Console.WriteLine($"Days elapsed since the start of the year: " + DateTime.Today.DayOfYear);

            var startsWithTuesday = false;
            var year = DateTime.Today.Year;

            do
            {
                if (DateTime.IsLeapYear(year) == true)
                {

                    DateTime firstDayOfYear = new DateTime(year, 1, 1);

                    if (firstDayOfYear.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        Console.WriteLine("Next leap year starting with a Tuesday: " + year);
                        startsWithTuesday = true;
                        break;
                    }
                }

                year++;

            } while (startsWithTuesday == false);

        }

        static void ValidateEmail()
        {
            Console.WriteLine("Please enter email you would like to be validated: ");
            var enteredEmail = Console.ReadLine();

            //Had no time to write my own validator, so I used the next best option! 
            var email = new EmailAddressAttribute();

            if (email.IsValid(enteredEmail))
            {
                Console.WriteLine("Entered email is valid! :)");
            }
            else
            {
                Console.WriteLine("Entered email is not valid.. :(((((((((");
            }

        }

        static void SumOfNumbers()
        {
            Console.WriteLine("Enter a sequence of numbers devided by ',': ");
            var sequence = Console.ReadLine();

            try
            {

                var numbers = sequence.Split(',').Select(int.Parse).ToArray();
                Console.WriteLine("Sum of the entered sequence is: " + numbers.Sum());
            }
            catch
            {

                //Again had no time to be more detailed, sorry. :(
                Console.WriteLine("Sorry, something went wrong! Please try again.");
                SumOfNumbers();

            }


        }
    }
}

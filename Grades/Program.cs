using System;
using System.Collections.Generic;
using System.Linq;
//using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello");

            GradeBook book = new GradeBook();

            //book.NameChanged += new NameChangedDelegate(OnNameChanged); // verbose
            //book.NameChanged += new NameChangedDelegate(OnNameChanged2); // verbose
            book.NameChanged += OnNameChanged;
            book.NameChanged += OnNameChanged2;
            //book.NameChanged = null; // this is not valid for events

            book.Name = "Scott's Grade Book";
            book.Name = "My Grade Book";
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, float result)
        {
            //Console.WriteLine(description + ": " + result);
            //Console.WriteLine("{0}: {1:F2}", description, result);

            // C# 6.0
            Console.WriteLine($"{description}: {result:F2}");
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

        static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("***");
        }
    }
}

//double sideA, sideB, result;

//Console.WriteLine("Enter side A: ");
//if (!double.TryParse(Console.ReadLine(), out sideA))
//{
//    Console.WriteLine("Invalid input for side A. Please enter a valid number.");
//    return;
//}

//Console.WriteLine("Enter side B: ");
//if (!double.TryParse(Console.ReadLine(), out sideB))
//{
//    Console.WriteLine("Invalid input for side B. Please enter a valid number.");
//    return;
//}

//result = sideA * sideB;

//Console.WriteLine("The result is {0:0.00}", result);

//using System;

//class Program
//{
//    static void Main()
//    {
//        // Use ANSI escape codes to change text color
//        // Console.WriteLine("\u001b[31mo\u001b[0m");
//        List<string> a = new List<string>();
//        a.Add("A");
//        a.Add("B"); 
//        a.Add("C");

//        a[a.Count - 1] = $"\u001b[31m{a[a.Count-1]}";

//        Console.WriteLine(a[a.Count-1]);
//        Console.WriteLine(a[a.Count-2]);
//    }
//}

// C# program to illustrate the
// ForegroundColor property
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Program
{

    static void Main(string[] args)
    {

        // Display current Foreground color
        Console.WriteLine("Default Foreground Color: {0}",
                                Console.ForegroundColor);

        // Set the Foreground color to blue
        Console.ForegroundColor
            = ConsoleColor.Blue;

        // Display current Foreground color
        Console.WriteLine("Changed Foreground Color: {0}",
                                Console.ForegroundColor);


    }
}








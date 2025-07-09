using System;
using System.Data.Common;
using System.Net.WebSockets;
using System.Text.RegularExpressions;


namespace MyNamespace
{

   class Program
   {
      static string Children(string child1, string child2)
      {
         // This method is not used in the current code
         return $"Children: {child1} and {child2}";
      }

      static int AddInt(int x, int y)
      {
         return x + y;
      }
      static double AddDouble(double x, double y)
      {
         return x + y;
      }

      public class Car
      {
         public string color = "red";
      }

//'Program.Car.color' is inaccessible due to its protection level?
      static void Main(string[] args)
      {
         //OOP:
         System.Console.WriteLine("________OOP_____");

         Car myCar = new Car();
         Console.WriteLine($"the color of MyCar is {myCar.color}");


         System.Console.WriteLine("_____END_OOP_____");
         //end of OOP

         // Call MyMethod
         var result = Children(child2: "Alice", child1: "Bob");
         System.Console.WriteLine($"The result is: {result}");
         int addIntResult = AddInt(5, 10);
         System.Console.WriteLine($"The result of AddInt is: {addIntResult}");
         double addDoubleResult = AddDouble(5.5, 10.15);
         System.Console.WriteLine($"The result of AddDouble is: {addDoubleResult}");

         System.Console.WriteLine("==========================");
         System.Console.WriteLine("==========================");



         // Console.WriteLine("Hello, World!");

         // System.Console.WriteLine("enter an a value: ");
         // var a = double.Parse(Console.ReadLine());
         // System.Console.WriteLine("enter a b value: ");
         // // var b = !string.IsNullOrEmpty(Console.ReadLine()) ? double.Parse(Console.ReadLine()) : 0;
         // var bInput = Console.ReadLine();
         // var result = double.TryParse(bInput, out var b) ? b : 0;

         // System.Console.WriteLine($"value of a: {a}, value of b: {b},\n The result is: {result}");

         //WHILE LOOP
         // var wanttocontinue = false;
         // while (!wanttocontinue)
         // {
         //    System.Console.WriteLine("Enter an a value: "); var aInput = Console.ReadLine(); var a = string.IsNullOrWhiteSpace(aInput); System.Console.WriteLine($"Is Null Or Empty: {a}");

         //    System.Console.WriteLine("Do you want to continue? (y/n)"); var response = Console.ReadLine()?.ToLower().Trim();

         //    if (response == "y")
         //    {
         //       wanttocontinue = false;
         //    }
         //    else if (response == "n")
         //    {
         //       wanttocontinue = true;
         //    }
         //    else
         //    {
         //       while (response != "y" && response != "n")
         //       {
         //          System.Console.WriteLine("Invalid input. Please enter 'y' or 'n': ");
         //          response = Console.ReadLine()?.ToLower().Trim();
         //          if (response == "y")
         //          {
         //             wanttocontinue = false;
         //             break;
         //          }
         //          else if (response == "n")
         //          {
         //             wanttocontinue = true;
         //             break;
         //          }
         //          break;
         //       }
         //    }
         // }

         //ARRAY
         var names = new[] { "John", "Jane", "Doe" };
         foreach (var name in names)
         {
            System.Console.WriteLine($"Name: {name}");
         }
         System.Console.WriteLine("------");
         var secondName = names[1]; // Access Jane
         names[1] = $"{secondName} & Alice"; // Change Jane to Alice
         foreach (var name in names)
         {
            System.Console.WriteLine($"Name: {name}");
         }
         System.Console.WriteLine("------");

         System.Console.WriteLine(" multi dimensional array");

         //MULTI-DIMENSIONAL ARRAY
         var rowsAndCells = new int[3][]{
            new[] { 1, 2, 3 },
            new[] { 4, 5, 6 },
            new[] { 7, 8, 9 }
         };

         for (var row = 0; row < rowsAndCells.Length; row++)
         {
            System.Console.WriteLine($"row: {row}");
            foreach (var cell in rowsAndCells[row])
            {
               System.Console.WriteLine($"cell: {cell}");
            }
         }




      }

   }
}

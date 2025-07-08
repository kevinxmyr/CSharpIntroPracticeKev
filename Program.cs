using System;

namespace MyNamespace
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Hello, World!");

         System.Console.WriteLine("enter an a value: ");
         var a = double.Parse(Console.ReadLine());
         System.Console.WriteLine("enter a b value: ");
         // var b = !string.IsNullOrEmpty(Console.ReadLine()) ? double.Parse(Console.ReadLine()) : 0;
         var bInput = Console.ReadLine();
         var result = double.TryParse(bInput, out var b) ? b : 0;

         System.Console.WriteLine($"value of a: {a}, value of b: {b},\n The result is: {result}");

      }
   }
}
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Linq;
using System.ComponentModel;

class Program
{
   static void Main(string[] args)
   {
      string welcomeMessage = "-----your program starts here-----";
      Console.WriteLine($"{welcomeMessage.Trim().ToUpper()}");
      var prog = new Program();
      prog.PrintName();
      prog.PrintNameWithParameter("kai");
      prog.PrintNameWithNameAndAge("kai", 32);
      prog.PrintNumbers("one", "two", "three");
      System.Console.WriteLine("--OPTIONAL PARAMS--");
      prog.PrintWithOptionalParams(99); //only first number is supplied
      prog.PrintWithOptionalParams(99, age: 32); //number and indicate the key supplied
      prog.PrintWithOptionalParams(99, name: "kai"); //number and indicate the key supplied
      prog.PrintNameArrowFunc("kai jin pogi");
      var sumofnumbers = prog.AddTwoNumbers(10, 20);
      System.Console.WriteLine($"sum of two number is: {sumofnumbers}");
      System.Console.WriteLine("adding numbers with using enum");
      var sumofnumberswithenum = prog.AddNumbersWithEnum(10, Operation.Divide, 20, 30);
      System.Console.WriteLine($"operation with enum num1 +-*/ sum of the rest of the numbers: {sumofnumberswithenum}");
      System.Console.WriteLine("--OPTIONAL PARAMS--");


      //CALCULATION OF INTEREST
      // System.Console.WriteLine("Initial Money to invest:");
      // var inputinitialAmount = Console.ReadLine();
      // var initialAmount = inputinitialAmount != null ? double.Parse(inputinitialAmount) : 0;
      // System.Console.WriteLine("how many months (12/24/36/48):");
      // var buwanreading = Console.ReadLine();
      // var months = buwanreading != null ? int.Parse(buwanreading) : 0;
      // System.Console.WriteLine("interest rate:");
      // var inputintRate = Console.ReadLine();
      // var intRate = inputintRate != null ? double.Parse(inputintRate) : 0;

      // var resultOfcalculation = prog.CalculateInterest(months, initialAmount, intRate);
      // System.Console.WriteLine($"result of calculation: {resultOfcalculation.ToString("C2")}");


      //-----

      var string1 = "string1_demo";
      var string2 = "stringTWO_DEMO";

      prog.ModifyText(ref string2);
      System.Console.WriteLine($"string1: {string1}, string2: {string2}");

      System.Console.WriteLine("--- out and ref ---");
      string errorMessage;
      //change the second paramyer to 0 or divisible by 10
      var divres = prog.DivisionProcess(10, 0, out errorMessage);
      if (string.IsNullOrEmpty(errorMessage))
      {
         System.Console.WriteLine($"result of division: {divres}");
      }
      else
      {
         System.Console.WriteLine($"walang result na nakasama dito kasi walan anmang laman kaya... error message: {errorMessage}");
      }
      System.Console.WriteLine("--- out and ref ---");
      System.Console.WriteLine("--- recursive function ---");

      var factorialArgument = 10;

      System.Console.WriteLine($"Factorial of {factorialArgument} result is {prog.Factorial(factorialArgument).ToString("")}");


      System.Console.WriteLine("--- recursive function ---");

      var n = 123.58;
      System.Console.WriteLine($"formatted number: {n.ToString("XXX ###,###.00", CultureInfo.InvariantCulture)}");

      System.Console.WriteLine("--- value type vs reference type ---");
      System.Console.WriteLine("value type");
      int aa = 10;
      int bb = aa;
      aa = 20;
      System.Console.WriteLine($"aa: {aa}, bb: {bb}");

   }

   public int Factorial(int number)
   {
      if (number == 1) return number;

      return number * Factorial(number - 1);
   }

   public int DivisionProcess(int a, int b, out string message)
   {
      message = ""; // or null
      if (b == 0)
      {
         message = "cannot divide by zero";
         return 0;
      }
      return a / b;
   }

   public void ModifyText(ref string str2)
   {
      str2 = "new ang string two";
   }
   //akin
   public double CalculateInterest(int months, double initialAmount, double intRate = .25)
   {
      intRate = intRate / 100; // 0.0025
      var total = initialAmount;
      double intrestearned = 0;
      double totalInterestEarned = 0;
      for (int i = 0; i < months; i++)
      {
         intrestearned = total * intRate;
         total = total + intrestearned;
         totalInterestEarned += intrestearned;
         Console.WriteLine($"Month {i + 1}: {total.ToString("C2")} {intrestearned.ToString("F2")}");
      }
      System.Console.WriteLine($"total interest earned in {months} is {totalInterestEarned.ToString("C2")}");
      System.Console.WriteLine($"interest rate in {months} months is {intRate * months}%");
      return total;


   }


   public void PrintName()
   {
      Console.WriteLine("using print name");
      var anyname = "john";
      Console.WriteLine($"name is: {anyname}");
   }
   public void PrintNameWithParameter(string name)
   {
      Console.WriteLine("using print name with params (string name)");
      Console.WriteLine($"name is: {name}");
   }
   public void PrintNameWithNameAndAge(string name, int age)
   {
      Console.WriteLine("using print name and age (string name, int age)");
      System.Console.WriteLine("********");
      Console.WriteLine($"you are {name}, {age} years old.");
      System.Console.WriteLine("********");
   }
   public void PrintNumbers(params string[] numbers)
   {
      Console.WriteLine("using print numbers (params string[] numbers)");
      foreach (var number in numbers)
      {
         Console.WriteLine(number);
      }
      System.Console.WriteLine("OR");
      System.Console.WriteLine(string.Join(", ", numbers));
   }

   public void PrintWithOptionalParams(long num, int? age = null, string name = "default_John_Appleseed")
   {
      System.Console.WriteLine($"num: {num}, age: {(age.HasValue ? age.Value : "null")}, name: {name}");
   }

   private void PrintNameArrowFunc(string name) => System.Console.WriteLine($"name is: {name} — printed in arrow function tawag ko sa js LOL");

   // with return type
   public int AddTwoNumbers(int num1, int num2) => num1 + num2;

   public enum Operation
   {
      Add,
      Subtract,
      Multiply,
      Divide
   }

   public float AddNumbersWithEnum(int num1, Operation op, params int[] otherNumbers)
   {

      var sumofothernumbers = otherNumbers.Sum(); // pwede din lagay dito sa variable or yun sa baba;
      switch (op)
      {
         case Operation.Add:
            return num1 + otherNumbers.Sum();
         case Operation.Subtract:
            return num1 - otherNumbers.Sum();
         case Operation.Multiply:
            return num1 * otherNumbers.Sum();
         case Operation.Divide:
            return (float)num1 / (float)otherNumbers.Sum();
         default: return 0.1F;
      }
   }

   /*
      get the withholding tax percentage
      taxPercentage = ( interest / yourmoney ) * 100;

      money: 1000
      int earned: 5.97




   */

}
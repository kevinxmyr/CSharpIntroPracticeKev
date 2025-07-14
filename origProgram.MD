using System;
using System.ComponentModel;
using System.Data.Common;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
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


      //'Program.Car.color' is inaccessible due to its protection level?
      static void Main(string[] args)
      {
         //OOP:
         System.Console.WriteLine("________OOP_____");

         Car myAltis = new Car("altis", "solarized silver", 2012);
         System.Console.WriteLine($"Car model: {myAltis.model}. Color: {myAltis.color}. Year: {myAltis.year}.");

         Person person1 = new Person("Kai", 32, new string[] { "new yorkies", "laguna", "bay area" });
         if (person1.age > 30)
         {
            System.Console.WriteLine($"Person: {person1.name} is older than 30 years old. lives in {string.Join(" ", person1.Address)}.");
         }
         else
         {
            System.Console.WriteLine($"Person: {person1.name} is younger than 30 years old.");
         }

         System.Console.WriteLine("---LISTS (e.g. Countries)---");

         var countries = new string[] { "USA", "Canada" };

         var listCountries = new List<string>(countries);
         var listInitialCountries = new List<string>(countries)
         {
            "Japan",
            "China",
         };
         var nl = new List<string>(listInitialCountries);
         System.Console.WriteLine(string.Join(", ", nl));
         var countryToAdd = "Australia";
         nl.Add("Australia");
         System.Console.WriteLine($"added country: {countryToAdd} to the list of countries.");
         System.Console.WriteLine($"updated list of countries: {string.Join(", ", nl)}");
         var countryToRemove = "China";
         nl.Remove(countryToRemove);
         System.Console.WriteLine($"removed country: {countryToRemove} from the list of countries.");
         System.Console.WriteLine($"updated list of countries: {string.Join(", ", nl)}");



         //LINQ AND LAMBDA EXPRESSIONS
         System.Console.WriteLine("---LINQ AND LAMBDA EXPRESSIONS---");
         var letter = 'j';
         var countriesWithA = nl.Where(country => country.Contains(letter, StringComparison.OrdinalIgnoreCase)).ToList();
         System.Console.WriteLine($"Countries containing {letter}: {string.Join(", ", countriesWithA)}");
         System.Console.WriteLine("-------");

         var numberss = new int[] { 1, 2, 3, 4, 5 };
         var evenNumbers = new List<int>();
         foreach (var number in numberss)
         {
            if (number % 2 == 1)
            {
               evenNumbers.Add(number);
            }
         }
         foreach (var evenNumber in evenNumbers)
         {
            System.Console.WriteLine($"Even number: {evenNumber}");
         }

         var lambdaevenNumbers = numberss.Where(num => num % 2 == 0);
         foreach (var evenNumber in lambdaevenNumbers)
         {
            System.Console.WriteLine($"Even number (using lambda): {evenNumber}");
         }

         var linqevennumbers = from num in numberss
                               where num % 2 == 0
                               select num;
         foreach (var evenNumber in linqevennumbers)
         {
            System.Console.WriteLine($"Even number (using LINQ): {evenNumber}");
         }

         // LINQ Query Syntax
         var myArray = new int[] { 3, 9, 1, 7, 4, 7, 2, 8, 5, 6 };
         var linqQuery = from mynum in myArray
                         where mynum < 5
                         orderby mynum descending
                         select mynum;
         foreach (var num in linqQuery) System.Console.WriteLine($"Sorted number using LINQ: {num}");
         //LAMBDA EXPRESSIONS
         var lambdaQuery = myArray
                           .Where(num => num < 5)
                           .OrderByDescending(num => num)
                           .Select(num => $"and numero: {num}");

         foreach (var num in lambdaQuery)
         {
            System.Console.WriteLine($"Number (using lambda): {num}");
         }



         // for (var i = 0; i < listInitialCountries.Count; i++)
         // {
         //    System.Console.WriteLine($"{i}: {listInitialCountries[i]}");
         // }

         var ne = Enumerable.Range(1, 10);
         System.Console.WriteLine("Numbers from 1 to 10: ");
         foreach (var number in ne)
         {
            System.Console.WriteLine(number);
         }
         var firstNumber = ne.FirstOrDefault();
         var lastNUmber = ne.LastOrDefault();

         var firstEvenNumber = ne.LastOrDefault(n => n % 2 == 0);

         var average = ne.Average();
         var sumavg = ne.Sum();
         var count = ne.Count();
         System.Console.WriteLine($"the avg: {average}, sum: {sumavg}, count: {count}");

         System.Console.WriteLine($"firstnumber: {firstNumber}, lastNUmber: {lastNUmber} {firstEvenNumber}");

         //where in lambda only:
         var newList = Enumerable.Range(1, 20);
         var w = newList.Where(n => n <= 5).Sum();
         System.Console.WriteLine($"the average of numbers less than or equal to 5 is: {w}");

         //range in c# only?

         var listofNumbers = new List<int>(ne);
         System.Console.WriteLine($"List of numbers: {string.Join(", ", listofNumbers)}");

         listofNumbers = (from num in listofNumbers
                          where num % 2 == 1
                          select num).ToList();

         System.Console.WriteLine($"List of odd numbers: {string.Join(", ", listofNumbers)}");


         //----
         System.Console.WriteLine("-------");

         var repeatednumbersArray = new[] { 1, 2, 2, 3, 4, 4 };
         var listrepeatednumbers = new List<int>(repeatednumbersArray);

         var listofrepeatednumbersDistince = listrepeatednumbers.Distinct().ToList();
         System.Console.WriteLine($"List of repeated LIST numbers: {string.Join(", ", listofrepeatednumbersDistince)}");

         var distinctNumbers = repeatednumbersArray.Distinct();
         System.Console.WriteLine($"Distinct numbers: {string.Join(" ", distinctNumbers)} ");

         System.Console.WriteLine("-------");
         var numero = new[] { 1, 2, 3, 4, 5 };
         var excludedNUmbers = new[] { 2 };
         var newnumbers = numero.Except(excludedNUmbers);

         System.Console.WriteLine($"numbers original: {string.Join(",", numero)} without this mofos: {string.Join(", ", newnumbers)}");

         System.Console.WriteLine("_____END_OOP_____");

         System.Console.WriteLine("007-STRING-DATETIME-NULLABLE-ENUM");
         System.Console.WriteLine("string in unmutable");
         var stringexample = "hello";
         foreach (var c in stringexample) System.Console.WriteLine(c);
         stringexample = "world";
         foreach (var c in stringexample) System.Console.WriteLine(c);

         string sampleString; //null
         string samplestringnull = null;
         String stringUsingClass = "test"; //same as small S and BIG S;

         var myname = "John";
         myname += " Jane";
         System.Console.WriteLine($"{myname}"); //printing onli
                                                // can iterate strings ⬇︎
         foreach (var c in myname) System.Console.WriteLine(c);

         char[] nameChar = myname.ToCharArray(); // convert string to char array DATATYPE
         var stringFromArray = new string(nameChar); // babalik naman ang char to string

         //verbatim string literal
         var verbatimString = @"This is a verbatim string literal.

        It can span multiple lines.";
         System.Console.WriteLine(verbatimString);
         var stringwithspecialcharacter = @"""test\only""";
         System.Console.WriteLine(stringwithspecialcharacter);
         var multiplestringline = @"
            multi
            line
            string
            ";
         System.Console.WriteLine(multiplestringline);

         System.Console.WriteLine("STRING ESCAPE SEQUENCE");
         var stringWithEscapeSequence = "This \t (tab here) is a string with an escape sequence: \nNew line here.";
         System.Console.WriteLine(stringWithEscapeSequence);

         string firstString = "";


         if (!string.IsNullOrEmpty(firstString))
            System.Console.WriteLine("firstString is NOT null or empty");
         else
            System.Console.WriteLine("firstString is null or empty");

         System.Console.WriteLine("END-007-STRING-DATETIME-NULLABLE-ENUM");

         //# MANIPULATE OF STRING VALUES:
         System.Console.WriteLine("---MANIPULATE OF STRING VALUES---");

         var myString = "Hello, World!";
         System.Console.WriteLine($"Original string: {myString}");
         System.Console.WriteLine($"Length of string: {myString.Length}");
         // Original string
         string originalString = "heLlO wOrLd and aGaIN";

         // Convert to lowercase for processing
         string lowerString = originalString.ToLower();

         // Split into words
         string[] words = lowerString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

         // Check if there are at least 2 words
         if (words.Length >= 2)
         {
            // Get the second word
            string secondWord = words[1];
            Console.WriteLine($"Second word found: '{secondWord}'");

            // Replace the second word with "universe"
            words[1] = "universe";

            // Join the words back together
            string result = string.Join(" ", words);

            Console.WriteLine($"Original string: '{originalString}'");
            Console.WriteLine($"Lowercase string: '{lowerString}'");
            Console.WriteLine($"Final result: '{result}'");
         }
         else
         {
            Console.WriteLine("String doesn't have enough words to replace the second word.");
         }
         System.Console.WriteLine($"Lowercase: {myString.ToLower()}");
         System.Console.WriteLine($"Contains 'World': {myString.Contains("World")}");
         System.Console.WriteLine($"reversed string: {new string(myString.Reverse().ToArray())}");
         //capitalize first letter in every word in a string
         System.Console.WriteLine($"capitalize first letter in every word in a string: {string.Join(" ", myString.Split(' ').Select(x => x.Substring(0, 1).ToUpper() + x.Substring(1)))}");
         string newstring = "0123456789";
         System.Console.WriteLine($"{string.Join(" ", newstring.Split(' ').Select(letter => letter.Substring(0, 1).ToUpper() + letter.Substring(1)))}");

         System.Console.WriteLine($"original string: {myString},  substring of 1, 4: {myString.Substring(0, 2)}");

         var strToTrim = "   Hello, World!   ";
         System.Console.WriteLine($"Trimmed string: '{strToTrim.Trim()}'");
         System.Console.WriteLine($"Trimmed start: '{strToTrim.TrimStart()}'");
         System.Console.WriteLine($"Trimmed end: '{strToTrim.TrimEnd()}'");
         System.Console.WriteLine($"Index of 'World': {myString.IndexOf("World")}");
         System.Console.WriteLine($"Index of 'World' (case-insensitive): {myString.IndexOf("world", StringComparison.OrdinalIgnoreCase)}");

         var myString2 = "Hello-World!-again-and-again:what:is-this.again";
         var myString2Split = string.Join("*", myString2.Split(new char[] { '-', '!', ':', '.', ' ' }));
         System.Console.WriteLine($"{myString2Split}");
         // foreach (var word in myString2Split)
         // {
         //    System.Console.Write(word);
         // }

         // var joiningwithaskterisk = string.Join("*", myString2Split);
         // System.Console.WriteLine($"\nJoining with asterisk: {joiningwithaskterisk}");

         //!NULLABLE

         string str = null;
         int? nullablenum = 2;

         if (nullablenum.HasValue) System.Console.WriteLine(nullablenum.Value);
         else System.Console.WriteLine("nullablenum is null.");


         //! enums - decalared a enum below

         var bg = Gender.Male;
         System.Console.WriteLine($"gender: {bg}, gender value in number: {(int)bg}");

         switch (bg)
         {
            case Gender.Male:
               System.Console.WriteLine("MALE");
               break;
            case (Gender.Female):
               System.Console.WriteLine("FEMALE");
               break;
            default:
               System.Console.WriteLine("unknown bich");
               break;
         }

         var valForGender = 1;
         Gender genderfromint = (Gender)valForGender;
         var genderStringValue = "Male";
         Gender genderfromstring = (Gender)Enum.Parse(typeof(Gender), genderStringValue);

         System.Console.WriteLine($"gender from int {genderfromint}");
         System.Console.WriteLine($"gender from string {genderfromstring}");






         //end of OOP

         // Call MyMethod
         // var result = Children(child2: "Alice", child1: "Bob");
         // System.Console.WriteLine($"The result is: {result}");
         // int addIntResult = AddInt(5, 10);
         // System.Console.WriteLine($"The result of AddInt is: {addIntResult}");
         // double addDoubleResult = AddDouble(5.5, 10.15);
         // System.Console.WriteLine($"The result of AddDouble is: {addDoubleResult}");


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
         // var names = new[] { "John", "Jane", "Doe" };
         // foreach (var name in names)
         // {
         //    System.Console.WriteLine($"Name: {name}");
         // }
         // System.Console.WriteLine("------");
         // var secondName = names[1]; // Access Jane
         // names[1] = $"{secondName} & Alice"; // Change Jane to Alice
         // foreach (var name in names)
         // {
         //    System.Console.WriteLine($"Name: {name}");
         // }
         // System.Console.WriteLine("------");

         // System.Console.WriteLine(" multi dimensional array");

         // //MULTI-DIMENSIONAL ARRAY
         // var rowsAndCells = new int[3][]{
         //    new[] { 1, 2, 3 },
         //    new[] { 4, 5, 6 },
         //    new[] { 7, 8, 9 }
         // };

         // for (var row = 0; row < rowsAndCells.Length; row++)
         // {
         //    System.Console.WriteLine($"row: {row}");
         //    foreach (var cell in rowsAndCells[row])
         //    {
         //       System.Console.WriteLine($"cell: {cell}");
         //    }
         // }
      }
      public enum Gender
      {
         Male,
         Female,
         Unknown
      }

      public enum SampleQuarterMonths
      {
         First = 3,
         Second = 6,
         Third = 9,
         Fourth = 12
      }

      public enum SampleStartsAt5 //mag increment siya based sa unang value dos is 10, tres is 15
      {
         Una = 5,
         Dos,
         Tres

      }

   }
}

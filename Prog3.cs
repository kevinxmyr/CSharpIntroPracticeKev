public class Person
{
   public string name;
   public int age;
   public string[] Address { get; set; }

   public Person(string nameP, int ageP, string[] addressP)
   {
      name = nameP;
      age = ageP;
      Address = addressP ?? new string[] { "Default Street" };
   }
}
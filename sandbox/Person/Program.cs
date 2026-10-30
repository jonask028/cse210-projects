class Program
{
  static void Main(string[] args)
  {
    Person newPerson = new("Jonas", "Kennedy", 26, 152.0);

    Console.WriteLine(newPerson.GetPersonalInfo());

    Policeman newPoliceman = new("Bob", "Vance", 36, 180.5, "sig sauer 2622");
    Console.WriteLine(newPoliceman.GetPolicemanInfo());

    Doctor newDoctor = new("Mike", "Johnson", 32, 165.0, "stethoscope");
    Console.WriteLine(newDoctor.GetDoctorInfo());

    List<Person> myPeople = new();
    myPeople.AddRange(newPerson, newPoliceman, newDoctor);

    foreach (Person person in myPeople)
    {
      Console.WriteLine(person.GetPersonalInfo());
    }

  }
}

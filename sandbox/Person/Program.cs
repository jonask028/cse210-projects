class Program
{
  static void DisplayPersonInformation(Person person)
  {
    Console.WriteLine(person.GetPersonalInfo());
  }

  static void Main(string[] args)
  {
    // Person newPerson = new("Jonas", "Kennedy", 26, 152.0);

    // Console.WriteLine(newPerson.GetPersonalInfo());

    Policeman newPoliceman = new("Bob", "Vance", 36, 180.5, "sig sauer 2622");
    // Console.WriteLine(newPoliceman.GetPolicemanInfo());

    Doctor newDoctor = new("Mike", "Johnson", 32, 165.0, "stethoscope");
    // Console.WriteLine(newDoctor.GetDoctorInfo());

    List<Person> myPeople = [];
    myPeople.AddRange(newPoliceman, newDoctor);

    foreach (Person person in myPeople)
    {
      DisplayPersonInformation(person);
    }

  }
}

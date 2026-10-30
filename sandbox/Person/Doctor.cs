class Doctor : Person
{

  private string _tools;

  public Doctor(string firstName, string lastName, int age, double weight, string tools)
  : base(firstName, lastName, age, weight)
  {
    _tools = tools;
  }

  public string GetDoctorInfo()
  {
    return $"{GetPersonalInfo()} They use a {_tools}";
  }
}
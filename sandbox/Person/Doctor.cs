class Doctor : Person
{

  private string _tools;

  public Doctor(string firstName, string lastName, int age, double weight, string tools)
  : base(firstName, lastName, age, weight)
  {
    _tools = tools;
  }

  public override string GetPersonalInfo()
  {
    return $"{base.GetPersonalInfo()} They use a {_tools}";
  }

  public override double GetSalaryInfo()
  {
    return 400000.00;
  }
}
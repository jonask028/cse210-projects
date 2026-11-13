class Policeman : Person
{
  private string _weapons;

  public Policeman(string firstName, string lastName, int age, double weight, string weapons)
  : base(firstName, lastName, age, weight)
  {
    _weapons = weapons;
  }

  public override string GetPersonalInfo()
  {
    return $"{base.GetPersonalInfo()} They use a {_weapons}";
  }

  public override double GetSalaryInfo()
  {
    return 80000.00;
  }
}
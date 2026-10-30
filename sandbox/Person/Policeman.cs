class Policeman : Person
{
  private string _weapons;

  public Policeman(string firstName, string lastName, int age, double weight, string weapons)
  : base(firstName, lastName, age, weight)
  {
    _weapons = weapons;
  }

  public string GetPolicemanInfo()
  {
    return $"{GetPersonalInfo()} They use a {_weapons}";
  }
}
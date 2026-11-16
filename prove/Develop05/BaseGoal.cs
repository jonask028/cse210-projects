abstract class BaseGoal(string name, string description, int points)
{
  protected readonly string _name = name;
  protected readonly string _description = description;
  protected readonly int _points = points;

  public abstract int CompleteGoal();

  public abstract void DisplayGoal();
}
class SimpleGoal(string name, string description, int points) : BaseGoal(name, description, points)
{
  private bool _isComplete = false;

  public override int CompleteGoal()
  {
    _isComplete = true;
    return _points;
  }

  public override void DisplayGoal()
  {
    Console.WriteLine($"[{(_isComplete ? "X" : " ")}] {_name}: {_description} - Points: {_points}");
  }
}
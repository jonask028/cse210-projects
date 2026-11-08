class Menu
{
  public int ProcessMenu()
  {
    bool done = false;
    do
    {
      Console.Clear();
      Console.WriteLine("Welcome to the Mindfullness Program");
      Console.WriteLine("Select an Activity: ");
      Console.WriteLine(" 1. Breathe");
      Console.WriteLine(" 2. List");
      Console.WriteLine(" 3. Reflect");
      Console.WriteLine("Q to quit");
      Console.Write("> ");

      string input = Console.ReadLine();
      if (!int.TryParse(input, out int option))
      {
        if (input.ToUpper().Equals("Q"))
        {
          done = true;
        }
        else
        {
          Console.WriteLine($"{input} is not a valid response");
        }
      }
      switch (option)
      {
        case 1:
          BreathingActivity breathing = new("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", "Well done!");
          breathing.DisplayInfo();
          breathing.Breathe();
          break;
        case 2:
          ListingActivity listing = new("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", "Well done!");
          listing.DisplayInfo();
          listing.List();
          break;
        case 3:
          ReflectionActivity reflection = new("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience.This will help you recognize the power you have and how you can use it in other aspects of your life.", "Good Work");
          reflection.DisplayInfo();
          reflection.Reflect();
          break;
      }

    } while (!done);

    return 1;
  }
}
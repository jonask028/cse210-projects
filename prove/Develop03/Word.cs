class Word(string word)
{
  private string _word = word;
  private bool _hidden = false;

  public bool IsHidden()
  {
    if (_hidden)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  public void ToggleHidden()
  {
    _hidden = !_hidden;
  }

  public string GetWordString()
  {
    return _word;
  }

  public void DisplayWord()
  {
    Console.Write(_word + " ");
  }

  public void DisplayHiddenWord()
  {
    foreach (char letter in _word)
    {
      Console.Write("_");
    }
    Console.Write(" ");
  }
}
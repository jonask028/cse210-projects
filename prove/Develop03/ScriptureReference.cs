class ScriptureReference
{

  private string _bookName;
  private int _chapter;
  private List<int> _verses;

  public ScriptureReference(string bookName, int chapter, int verse)
  {
    _bookName = bookName;
    _chapter = chapter;
    _verses = [verse];
  }

  public ScriptureReference(string bookName, int chapter, int startVerse, int endVerse)
  {
    _bookName = bookName;
    _chapter = chapter;
    _verses = [];
    for (int i = startVerse; i <= endVerse; i++)
    {
      _verses.Add(i);
    }
  }

  public void DisplayReference()
  {
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine(GetScriptureReferenceString());
  }

  public void SaveReference(StreamWriter outputFile)
  {
    if (_verses.Count > 1)
      outputFile.WriteLine($"{_bookName}#{_chapter}#{_verses[0]}#{_verses[^1]}");
    else
      outputFile.WriteLine($"{_bookName}#{_chapter}#{_verses[0]}");
  }

  public List<int> GetVerses()
  {
    return _verses;
  }

  public string GetScriptureReferenceString()
  {
    if (_verses.Count == 1)
    {
      return $"{_bookName} {_chapter}:{_verses[0]}";
    }
    else if (_verses.Count > 1)
    {
      return $"{_bookName} {_chapter}:{_verses[0]}-{_verses[^1]}";
    }
    else
    {
      return "Reference has no verses";
    }
  }


}
class Scripture
{

  private ScriptureReference _reference;
  private List<Word> _words = [];
  public Scripture(string bookName, int chapter, int verse, string text)
  {
    Console.WriteLine("Making scripture with one verse");
    _reference = new(bookName, chapter, verse);
    CreateWords(text);
  }

  public Scripture(string bookName, int chapter, int startVerse, int endVerse, string text)
  {
    Console.WriteLine("Making scripture with multiple verses");
    _reference = new(bookName, chapter, startVerse, endVerse);
    CreateWords(text);
  }

  public Scripture(ScriptureReference reference, string text)
  {
    _reference = reference;
    CreateWords(text);
  }

  private void CreateWords(string text)
  {
    string[] words = text.Split(" ");
    foreach (string word in words)
    {
      Word newWord = new(word);
      _words.Add(newWord);
    }
  }

  public void DisplayScripture()
  {
    bool allHidden = false;
    int count = 1;
    do
    {
      Console.Clear();
      _reference.DisplayReference();
      List<int> verseNumbers = _reference.GetVerses();
      // foreach (int number in verseNumbers)
      // { Console.WriteLine(number); }
      List<string> wordList = GetWordList();
      // Console.WriteLine("word list: " + string.Join(" ", wordList));
      List<List<Word>> versesWords = [];
      // Console.WriteLine($"Word Count: {_words.Count}");
      for (int i = 0; i < verseNumbers.Count; i++)
      {
        int startIndex = wordList.IndexOf($"{verseNumbers[i]}");
        // Console.WriteLine($"Start index: {startIndex} verse: {verseNumbers[i]}");
        int endIndex = wordList.IndexOf($"{((i + 1) < verseNumbers.Count ? verseNumbers[i + 1] : wordList[^1])}");
        // Console.WriteLine($"End index: {endIndex}");
        // Console.WriteLine($"End Word: {_words[endIndex - 1].GetWordString()}");
        int wordCount = endIndex - startIndex;
        List<Word> verseWordList = _words.Slice(startIndex, wordCount);
        // Console.WriteLine("verse text: " + string.Join(" ", wordList.Slice(startIndex, wordCount)));
        versesWords.Add(verseWordList);
      }
      // Console.WriteLine($"{versesWords.Count} verses");
      foreach (List<Word> verseWords in versesWords)
      {
        // Console.Write(verseWords.ToString());
        foreach (Word word in verseWords)
        {
          if (verseWords.IndexOf(word) % 15 == 0)
          {
            Console.Write("\n");
          }
          if (!word.IsHidden())
          {
            word.DisplayWord();
          }
          else
          {
            word.DisplayHiddenWord();
          }
        }
        Console.Write("\n");
      }
      Console.Write("\n");
      Console.WriteLine("-------------------------------------------\n");
      int wordsLeft = HideWords();
      if (wordsLeft == 0)
      {
        if (count == 0)
        {
          Console.WriteLine("\nPush enter to return to menu");
          Console.ReadLine();
          allHidden = true;
        }
        else
        {
          count -= 1;
          Console.WriteLine("\nPush enter to hide words");
          Console.ReadLine();
        }
      }
      else
      {
        Console.WriteLine("\nPush enter to hide words");
        Console.ReadLine();
      }
    } while (!allHidden);
    foreach (Word word in _words)
    {
      word.ToggleHidden();
    }
  }

  public void MemorizeScripture()
  {
    DisplayScripture();
  }

  public void SaveScripture()
  {
    using StreamWriter outputFile = new($"../../../scriptures/{_reference.GetScriptureReferenceString()}.txt");
    _reference.SaveReference(outputFile);
    foreach (Word word in _words)
    {
      outputFile.Write(word.GetWordString() + " ");
    }
  }

  private int HideWords()
  {
    int textLength = _words.Count;
    List<(Word, int)> unhiddenWords = GetUnhiddenWords();
    int numToHide = unhiddenWords.Count > textLength / 10 ? textLength / 10 : unhiddenWords.Count;
    Random random = new();
    for (int i = 0; i < numToHide; i++)
    {
      int randIndex = random.Next(0, unhiddenWords.Count);
      Word wordToHide = unhiddenWords[randIndex].Item1;
      int wordIndex = unhiddenWords[randIndex].Item2;
      wordToHide.ToggleHidden();
      _words[wordIndex] = wordToHide;
      unhiddenWords.Remove((wordToHide, wordIndex));
    }
    return unhiddenWords.Count;
  }

  private List<(Word, int)> GetUnhiddenWords()
  {
    List<(Word, int)> unhiddenWords = [];
    for (int i = 0; i < _words.Count; i++)
    {
      if (!_words[i].IsHidden())
      {
        unhiddenWords.Add((_words[i], i));
      }
    }
    return unhiddenWords;
  }

  private List<string> GetWordList()
  {
    List<string> wordList = [];
    foreach (Word word in _words)
    {
      string wordString = word.GetWordString();
      wordList.Add(wordString);
    }
    return wordList;
  }
}
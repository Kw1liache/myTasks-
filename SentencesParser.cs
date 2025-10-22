using System.Text;
namespace TextAnalysis;

static class SentencesParserTask
{
    public static List<List<string>> ParseSentences(string text)
    {
        var sentencesList = new List<List<string>>();
        var sentenceDelimiters = new[] { '.', '!', '?', ';', ':', '(', ')' };
        
        foreach (var sentence in text.Split(sentenceDelimiters, StringSplitOptions.RemoveEmptyEntries))
        {
            var words = ParseSentence(sentence);
			if (words.Count > 0) 	
				sentencesList.Add(words);
        }
        
        return sentencesList;
    }
    
    private static List<string> ParseSentence(string sentence)
	{
		var words = new List<string>();
		var word = new StringBuilder();

		ProcessCharacters(sentence, word, words);

		if (word.Length > 0) 
			words.Add(word.ToString());
		return words;
	}

	private static void ProcessCharacters(string sentence, StringBuilder word, List<string> words)
	{
		foreach (char c in sentence)
		{
			if (char.IsLetter(c) || c == '\'')
				word.Append(char.ToLower(c));
			else if (word.Length > 0)
			{
				words.Add(word.ToString());
				word.Clear();
			}
		}
	}
}

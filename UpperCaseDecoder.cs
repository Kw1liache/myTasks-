# Этот код выполняет сбор и преобразование сообщения из массива строк. Вот что он делает пошагово:
private static string DecodeMessage(string[] lines)
{
    List<string> list = new List<string>();
    foreach (var line in lines)
    {
        string[] words = line.Split(' ');
        foreach (var word in words)
        {
            if (!string.IsNullOrEmpty(word) && Char.IsUpper(word[0]))
                list.Add(word);
        }
    }
    
    return list
}

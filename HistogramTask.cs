namespace Names;

internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
    {
        var birthsPerDay = new double[31];
        foreach (var person in names)
        {
            if (person.Name == name && person.BirthDate.Day != 1)
            {
                birthsPerDay[person.BirthDate.Day - 1]++;
            }
        }

        var days = new string[31];
        for (var i = 0; i < 31; i++)
        {
            days[i] = (i + 1).ToString();
        }
        
        return new HistogramData(
            $"Рождаемость людей с именем '{name}'", 
            days, 
            birthsPerDay);
    }
}
namespace Names;

internal static class HeatmapTask
{
    public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
    {
        const int daysCount = 30;
        const int monthsCount = 12;

        var days = CreateLabels(daysCount, 2);    
        var months = CreateLabels(monthsCount, 1); 
        
        var heatmapData = new double[daysCount, monthsCount];

        foreach (var person in names)
        {
            if (person.BirthDate.Day != 1)
            {
                var dayIndex = person.BirthDate.Day - 2;
                var monthIndex = person.BirthDate.Month - 1;
                heatmapData[dayIndex, monthIndex]++;
            }
        }
    
        return new HeatmapData("Карта рождаемости по датам", heatmapData, days, months);
    }
    
    private static string[] CreateLabels(int count, int startFrom)
    {
        var labels = new string[count];
        for (var i = 0; i < count; i++)
        {
            labels[i] = (i + startFrom).ToString();
        }
        return labels;
    }
}

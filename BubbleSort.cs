public static void BubbleSortRange(int[] array, int left, int right)
{
    for (var i = left; i < right; i++)
        for (var j = left; j < right; j++)
            if (array[j] > array[j + 1])
            {
                var t = array[j + 1];
                array[j + 1] = array[j];
                array[j] = t;
            }
}

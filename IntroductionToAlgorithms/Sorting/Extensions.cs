namespace IntroductionToAlgorithms.Sorting
{
    public static class Extensions
    {
        public static void Swap<T>(this T[] array, int i, int j)
        {
            var temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
    }
}
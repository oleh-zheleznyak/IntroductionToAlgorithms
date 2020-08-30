using System;

namespace IntroductionToAlgorithms.Sorting
{
    public class CountSort : ISort<byte>
    {
        public void Sort(byte[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            if (array.Length <= 1) return;

            var count = new byte[byte.MaxValue + 1];
            var original = new byte[array.Length];

            Array.Copy(array, original, array.Length);

            CountNumberOfOccurrences(array, count);

            CountNumberOfElementsLessThan(count);

            PlaceElements(array, count, original);
        }

        private static void PlaceElements(byte[] array, byte[] count, byte[] original)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var value = original[i];
                var index = count[value] - 1;
                array[index] = value;

                count[value]--;
            }
        }

        private static void CountNumberOfElementsLessThan(byte[] count)
        {
            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }
        }

        private static void CountNumberOfOccurrences(byte[] array, byte[] count)
        {
            for (int i = 0; i < array.Length; i++)
            {
                count[array[i]]++;
            }
        }
    }
}

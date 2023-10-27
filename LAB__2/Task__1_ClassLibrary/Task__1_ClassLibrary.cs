namespace Task__1_ClassLibrary
{
    public static class StringExtensions
    {
        public static string Reverse(this string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static int CountOccurrences(this string input, char target)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (c == target)
                {
                    count++;
                }
            }
            return count;
        }
    }

    public static class ArrayExtensions
    {
        public static int CountOccurrences<T>(this T[] array, T target) where T : IEquatable<T>
        {
            int count = 0;
            foreach (T element in array)
            {
                if (element.Equals(target))
                {
                    count++;
                }
            }
            return count;
        }

        public static T[] RemoveDuplicates<T>(this T[] array) where T : IEquatable<T>
        {
            List<T> uniqueElements = new List<T>();
            foreach (T element in array)
            {
                if (!uniqueElements.Contains(element))
                {
                    uniqueElements.Add(element);
                }
            }
            return uniqueElements.ToArray();
        }
    }

}
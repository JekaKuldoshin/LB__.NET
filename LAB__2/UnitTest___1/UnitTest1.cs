using Task__1_ClassLibrary;

namespace UnitTest___1
{
    [TestFixture]
    public class ExtensionsTests
    {
        [Test]
        public void StringReverseTest()
        {
            string input = "hello";
            string reversed = input.Reverse();
            Assert.AreEqual("olleh", reversed);
        }

        [Test]
        public void StringCountOccurrencesTest()
        {
            string input = "hello";
            int count = input.CountOccurrences('l');
            Assert.AreEqual(2, count);
        }

        [Test]
        public void ArrayCountOccurrencesTest()
        {
            int[] numbers = { 1, 2, 3, 4, 2, 5, 2 };
            int count = numbers.CountOccurrences(2);
            Assert.AreEqual(3, count);
        }

        [Test]
        public void ArrayRemoveDuplicatesTest()
        {
            int[] numbers = { 1, 2, 3, 4, 2, 5, 2 };
            int[] uniqueNumbers = numbers.RemoveDuplicates();
            Assert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, uniqueNumbers);
        }
    }

}





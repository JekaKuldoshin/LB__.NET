using ExtendedDictionary__ClassLibrary;
using Newtonsoft.Json.Linq;

namespace UnitTest__2
{
    [TestFixture]
    public class ExtendedDictionaryTests
    {
        [Test]
        public void AddElement_ContainsKey_ReturnsTrue()
        {
            var dictionary = new ExtendedDictionary<string, int, double>();
            dictionary.Add("key1", 42, 3.14);
            Assert.IsTrue(dictionary.ContainsKey("key1"));
        }

        [Test]
        public void RemoveElement_KeyDoesNotExist_CountRemainsSame()
        {
            var dictionary = new ExtendedDictionary<string, int, double>();
            dictionary.Add("key1", 42, 3.14);
            dictionary.Remove("non_key1");
            Assert.AreEqual(1, dictionary.Count);
        }

        [Test]
        public void RemoveElement_KeyExists_CountDecreases()
        {
            var dictionary = new ExtendedDictionary<string, int, double>();
            dictionary.Add("key1", 42, 3.14);
            dictionary.Remove("key1");
            Assert.AreEqual(0, dictionary.Count);
        }

        [Test]
        public void ContainsValues_ValuesExist_ReturnsTrue()
        {
            var dictionary = new ExtendedDictionary<string, int, double>();
            dictionary.Add("key1", 42, 3.14);
            Assert.IsTrue(dictionary.ContainsValues(42, 3.14));
        }

        [Test]
        public void Indexer_KeyExists_ReturnsElement()
        {
            var dictionary = new ExtendedDictionary<string, int, double>();
            dictionary.Add("key1", 42, 3.14);
            var element = dictionary["key1"];
            Assert.AreEqual(42, element.Value1);
            Assert.AreEqual(3.14, element.Value2);
        }

        [Test]
        public void Count_Property_ReturnsCorrectCount()
        {
            var dictionary = new ExtendedDictionary<string, int, double>();
            dictionary.Add("key1", 42, 3.14);
            dictionary.Add("key2", 55, 2.71);

            Assert.AreEqual(2, dictionary.Count);
        }

    }
}





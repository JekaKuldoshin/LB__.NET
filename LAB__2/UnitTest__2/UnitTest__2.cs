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
            dictionary.Remove("nonExistentKey");
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

        //        Додавання елемента у словник: Тест AddElement_ContainsKey_ReturnsTrue() перевіряє, чи можна правильно додати елемент до словника.

        //Видалення елемента зі словника за заданим ключем: Тести RemoveElement_KeyDoesNotExist_CountRemainsSame() та RemoveElement_KeyExists_CountDecreases() перевіряють, чи можна видалити елемент зі словника за заданим ключем, навіть якщо елемент не існує(перший тест) та якщо елемент існує(другий тест).

        //Перевірка наявності елемента із заданим ключем: Тест AddElement_ContainsKey_ReturnsTrue() перевіряє, чи можна перевірити наявність елемента за ключем після його додавання.

        //Перевірка наявності елемента із заданим значенням (значення1 та значення2): Тест ContainsValues_ValuesExist_ReturnsTrue() перевіряє, чи можна перевірити наявність елемента за значеннями value1 та value2.

        //Повернення елемента за заданим ключем (реалізувати операцію індексування): Тест Indexer_KeyExists_ReturnsElement() перевіряє, чи можна отримати елемент за ключем за допомогою індексатора.

        //Властивість, що повертає кількість елементів: Тести RemoveElement_KeyDoesNotExist_CountRemainsSame() та RemoveElement_KeyExists_CountDecreases() перевіряють зміну кількості елементів після додавання та видалення.

        [Test]
        public void Count_Property_ReturnsCorrectCount()
        {
            var dictionary = new ExtendedDictionary<string, int, double>();
            dictionary.Add("key1", 42, 3.14);
            dictionary.Add("key2", 55, 2.71);

            Assert.AreEqual(2, dictionary.Count);
        }

        //У цьому тесті ми додаємо два елементи до словника та перевіряємо, чи повертає властивість Count правильну кількість елементів.Якщо властивість Count реалізована в вашому класі ExtendedDictionary<T, U, V>, цей тест перевірить її коректність.

    }
}





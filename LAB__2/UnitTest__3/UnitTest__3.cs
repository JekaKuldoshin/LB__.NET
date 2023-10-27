using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using Task__3_ClassLibrary;


namespace UnitTest__3
{
    [TestFixture]
    public class LinqTests
    {
        private string[] A;
        private int[] B;
        private string[] C;

        private List<string> myCars;
        private List<string> yourCars;

        [SetUp]
        public void Initialize()
        {
            A = new string[] { "Fallout 3", "Daxter 2", "System Shock 2", "Morrowind", "Pes 2013" };
            B = new int[] { 2, -7, -10, 6, 7, 9, 3 };
            C = new string[] { "Light Green", "Red", "Green", "Yellow", "Purple", "Dark Green", "Light Red", "Dark Red", "Dark Yellow", "Light Yellow" };

            myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            yourCars = new List<string> { "BMW", "Saab", "Aztec" };
        }

        [Test]
        public void Test_Result_A()
        {
            var resultA = from item in A where item.Contains("2") select item;
            CollectionAssert.AreEqual(new string[] { "Daxter 2", "System Shock 2", "Pes 2013" }, resultA.ToArray());
        }

        [Test]
        public void Test_Result_B_PositiveNumbers()
        {
            var positiveNumbers = from number in B where number > 0 select number;
            CollectionAssert.AreEqual(new int[] { 2, 6, 7, 9, 3 }, positiveNumbers.ToArray());
        }

        [Test]
        public void TestGreenShades()
        {
            var greenShades = from shade in C where shade.Contains("Green") select shade;
            CollectionAssert.AreEqual(new string[] { "Light Green", "Green", "Dark Green" }, greenShades.ToArray());
        }

        [Test]
        public void TestFastCars()
        {
            var cars = new List<Car>
            {
                new Car { Model = "Yugo", MaxSpeed = 180, Color = "Red" },
                new Car { Model = "Aztec", MaxSpeed = 210, Color = "Green" },
                new Car { Model = "BMW", MaxSpeed = 250, Color = "Blue" },
                new Car { Model = "Saab", MaxSpeed = 190, Color = "Black" }
            };

            var fastCars = from car in cars where car.MaxSpeed > 200 select car;
            CollectionAssert.AreEqual(new string[] { "Aztec", "BMW" }, fastCars.Select(car => car.Model).ToArray());
        }

        [Test]
        public void TestHighInventoryProducts()
        {
            var products = new List<Product>
            {
                new Product { Name = "Product A", Inventory = 60 },
                new Product { Name = "Product B", Inventory = 40 },
                new Product { Name = "Product C", Inventory = 70 }
            };

            var highInventoryProducts = from product in products where product.Inventory > 50 select product;
            CollectionAssert.AreEqual(new string[] { "Product A", "Product C" }, highInventoryProducts.Select(product => product.Name).ToArray());
        }

        [Test]
        public void TestCombinedCars()
        {
            var combinedCars = myCars.Union(yourCars).Distinct();
            CollectionAssert.AreEqual(new string[] { "Yugo", "Aztec", "BMW", "Saab" }, combinedCars.ToArray());
        }
    }
}

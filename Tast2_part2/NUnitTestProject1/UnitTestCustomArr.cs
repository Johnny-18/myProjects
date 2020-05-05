using NUnit.Framework;
using Tast2_part2;

namespace Tests
{
    public class CustomArrTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Add_mustBeAddedIntegerElementOnZeroPosition_withValue_10()
        {
            //arrange
            CustomArr<int> ca = new CustomArr<int>(0,1);
            int value = 10;
            //act
            ca.Add(value);
            //assert
            Assert.AreNotEqual(default(int),ca[0]);
        }

        [Test]
        public void Indexer_mustBeAddedStringElementOnFirstPosition_withValue_asd()
        {
            //arrange
            CustomArr<string> ca = new CustomArr<string>(0, 3);
            string value = "asd";
            //act
            ca[1] = value;
            //assert
            Assert.AreEqual(value, ca[1]);
        }

        [Test]
        public void Constructor_withIntegerArrayParametr_Values_1_2_3_4()
        {
            //arrange
            int [] arr = { 1, 2, 3, 4 };
            CustomArr<int> ca;
            bool check = false;
            //act
            ca = new CustomArr<int>(arr);
            for (int i = 0; i < ca.Count; i++)
            {
                if (ca[i] != arr[i]) check = true;
            }
            //assert
            Assert.AreEqual(false, check);
        }
    }
}
using NUnit.Framework;
using Task2_1Ex;

namespace Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        private BinaryTree<int> bt;   
        [SetUp]
        public void Setup()
        {
            bt = new BinaryTree<int>();
        }

        [Test]
        public void AddTest_MustAddOneElement()
        {
            //arrange
            int data = 1;
            //act
            bt.Add(data);
            //assert
            Assert.AreNotEqual(null,bt.GetHead());
        }
        
        [Test]
        public void RemoveAll_wasOneElement_mustBeNull()
        {
            //arrange
            bt = new BinaryTree<int>(1);
            //act
            bt.RemoveAll();
            //assert
            Assert.AreEqual(null, bt.GetHead());
        }

        [Test]
        public void Remove_withoutBranch_wasElementWithValue_102_mustBeRemoved()
        {
            //arrange
            bool check = false;
            int data = 102;
            //act
            bt.Add(10);
            bt.Add(data);
            bt.Add(9);
            bt.Remove(102);
            foreach (var item in bt)
            {
                if (item == data)
                    check = true;
            }
            //assert
            Assert.AreEqual(false, check);
        }

        [Test]
        public void Remove_withOneBranch_wasElementWithValue_102_mustBeRemoved()
        {
            //arrange
            bool check = false;
            int data = 102;
            //act
            bt.Add(10);
            bt.Add(data);
            bt.Add(213);
            bt.Add(9);
            bt.Remove(102);
            foreach (var item in bt)
            {
                if (item == data)
                    check = true;
            }
            //assert
            Assert.AreEqual(false, check);
        }

        [Test]
        public void Remove_withTwoBranch_wasElementWithValue_102_mustBeRemoved()
        {
            //arrange
            bool check = false;
            int data = 102;
            //act
            bt.Add(10);
            bt.Add(data);
            bt.Add(213);
            bt.Add(9);
            bt.Add(90);
            bt.Remove(102);
            foreach (var item in bt)
            {
                if (item == data)
                    check = true;
            }
            //assert
            Assert.AreEqual(false, check);
        }
    }
}
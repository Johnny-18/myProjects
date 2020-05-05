using NUnit.Framework;
using ExOneForCourse_Matrix;

namespace Tests
{
    public class Tests
    {
        Matrix<int> matrix1;
        Matrix<int> matrix2;
        [SetUp]
        public void Setup()
        {
            int[,] arr = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = 1;
                }
            }
            matrix1 = new Matrix<int>(arr,3,3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = 2;
                }
            }
            matrix2 = new Matrix<int>(arr,3,3);
        }

        [Test]
        public void Matrix_operatorPlus_wasFirstMatrixWithValue_1_and_secondWithValue_2_mustBe_matrixWithValue_3()
        {
            //arrange
            int[,] arr = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = 3;
                }
            }
            Matrix<int> expected = new Matrix<int>(arr, 3, 3);
            //act
            Matrix<int> actual = new Matrix<int>(matrix1 + matrix2);
            //assert
            Assert.AreEqual(expected,actual);
        }
    }
}
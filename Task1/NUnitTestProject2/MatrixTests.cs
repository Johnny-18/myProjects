using NUnit.Framework;
using ExOneForCourse_Matrix;

namespace Tests
{
    public class MatrixTests
    {
        Matrix<int> matrix1;
        Matrix<int> matrix2;
        [SetUp]
        public void Setup()
        {
            int [,] arr = new int[3,3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = 1;
                }
            }
            matrix1 = new Matrix<int>(arr, 3, 3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = 2;
                }
            }
            matrix2 = new Matrix<int>(arr, 3, 3);
        }

        [Test]
        public void OperatorPlus_objWithValue_1_plusObjWithValue_2_mustBeValue_3InMatrix()
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
            Matrix<int> excepted = new Matrix<int>(arr, 3, 3);
            //act
            Matrix<int> actual = matrix1 + matrix2;
            //assert
            Assert.AreEqual(excepted, actual);
        }
        [Test]
        public void OperatorPlusWithValue_3_andObjWithValue_1_mustBeMatrixWithValue_4()
        {
            //arrange
            int value = 3;
            int[,] arr = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = 4;
                }
            }
            Matrix<int> excepted = new Matrix<int>(arr, 3, 3);
            //act
            Matrix<int> actual = matrix1 + value;
            //assert
            Assert.AreEqual(excepted, actual);
        }
        [Test]
        public void OperatorMinusWithObjValue_2_minusObjValue_1_mustBeValue_1()
        {
            //arrange
            Matrix<int> expected = matrix1;
            //act
            Matrix<int> actual = matrix2 - matrix1;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void OperatorMultiplicationWithObjValue_2_andObjWithValue_2_Dimansion3RowAnd3Column_mustBeValue_12()
        {
            //arrange
            int[,] arr = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = 12;
                }
            }
            Matrix<int> expected = new Matrix<int>(arr, 3, 3);
            //act
            Matrix<int> actual = matrix2 * matrix2;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
using System;
using System.Collections.Generic;

namespace ExOneForCourse_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int [,]arr = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = 1; 
                }
            }
            Matrix<int> matrix1 = new Matrix<int>(arr,3,3);
            int[,] arr1 = new int[2, 3];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr1[i, j] = 3;
                }
            }
            Matrix<int> matrix2 = new Matrix<int>(arr1,2,3);
            Matrix<int> res = new Matrix<int>(matrix2 * matrix1);
            DataBaseService dbs = new DataBaseService();
            List<Matrix<int>> listMatrix = new List<Matrix<int>>();
            listMatrix.Add(res);
            listMatrix.Add(matrix1);
            listMatrix.Add(matrix2);
            dbs.JsonSerialize(listMatrix);
            List<Matrix<int>> fromDeserelization = dbs.JsonDeserialize<int>();
            Console.ReadKey();
        }
    }
}

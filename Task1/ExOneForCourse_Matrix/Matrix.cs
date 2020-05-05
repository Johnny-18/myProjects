using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExOneForCourse_Matrix
{
    [DataContract]
    public class Matrix<T> : ICloneable, IComparer<T>
    {
        [DataMember]
        private T [,] arr;
        public T this[int column,int row]
        {
            get
            {
                if (arr != null) return arr[column,row];
                else throw new System.NullReferenceException("NullReferenceInMatrixException!");
            }
        }
        [DataMember]
        public int sizeRow { get; private set; }
        [DataMember]
        public int sizeColumn { get;  private set; }
        public Matrix()
        {
            
        }
        public Matrix(T[,] arr, int sizeRow, int sizeColumn)
        {
            if (arr != null)
            {
                this.arr = new T[sizeRow, sizeColumn];

                for (int i = 0; i < sizeRow; i++)
                {
                    for (int j = 0; j < sizeColumn; j++)
                    {
                        this.arr[i, j] = arr[i, j];
                    }
                }

                this.sizeRow = sizeRow;
                this.sizeColumn = sizeColumn;
            }
            else throw new System.ArgumentNullException("ArgumentNullInConstructMatrixException!");
        }
        public Matrix(Matrix<T> data)
        {
            if (data != null && data.arr != null)
            {
                arr = new T[data.sizeRow,data.sizeColumn];
                for (int i = 0; i < data.sizeRow; i++)
                {
                    for (int j = 0; j < data.sizeColumn; j++)
                    {
                        arr[i, j] = data.arr[i, j];
                    }
                }

                sizeColumn = data.sizeColumn;
                sizeRow = data.sizeRow;
            }
            else throw new System.ArgumentNullException("ArgumentNullInConstructMatrixException!");
        }
        public int Compare(T x, T y)
        {
            dynamic newX = x;
            dynamic newY = y;

            if (newX > newY)
                return newX - newY;
            else if (newX < newY)
                return newY - newX;

            return 0;
        }
        public int Compare(T [,] arr1, T [,] arr2)
        {
            if (arr1 == null || arr2 == null)
                throw new ArgumentNullException("ArgumentNullException!");

            if (arr1.Length != arr2.Length) return Math.Abs(arr1.Length - arr2.Length);
            else
            {
                int res = 0;
                for (int i = 0; i < arr1.GetLength(i); i++)
                {
                    for (int j = 0; j < arr1.Length / arr1.GetLength(i); j++)
                    {
                        res += Compare(arr1[i, j], arr2[i, j]);
                    }
                }
                return res;
            }

        }
        public override bool Equals(object obj)
        {
            Matrix<T> value = obj as Matrix<T> ?? throw new ArgumentNullException("ArgumentNullException!");

            if (this == null || value == null || arr == null || value.arr == null)
                throw new ArgumentNullException("ArgumentNullException!");

            if (arr.Length != value.arr.Length ||
                sizeColumn != value.sizeColumn || 
                sizeRow != value.sizeRow)
                return false;
            else
            {
                for (int i = 0; i < sizeRow; i++)
                {
                    for (int j = 0; j < sizeColumn; j++)
                    {
                        dynamic thisTemp = arr[i, j];
                        dynamic valueTemp = value.arr[i, j];
                        if (thisTemp != valueTemp) return false;
                    }
                }
            }
            return true;
        }
        public object Clone()
        {
            if (arr == null)
                throw new NullReferenceException("NullReferenceException!");
            return new Matrix<T>(arr, sizeRow, sizeColumn);
        }
        public static Matrix<T> operator +(Matrix<T> data1, Matrix<T> data2)
        {
                if (ValidateArguments(data1, data2) && ValidateDimansion(data1,data2))
                {
                    T[,] newArr = new T[data1.sizeColumn, data1.sizeRow];

                    for (int i = 0; i < data1.sizeRow; i++)
                    {
                        for (int j = 0; j < data1.sizeColumn; j++)
                        {
                            dynamic tmp1 = data1[i, j];
                            dynamic tmp2 = data2[i, j];
                            newArr[i, j] = tmp1 + tmp2;
                        }
                    }

                    return new Matrix<T>(newArr, data1.sizeRow, data1.sizeColumn);
                }
                return null;
        }
        public static Matrix<T> operator +(Matrix<T> data,T value)
        {
                if (ValidateArguments(data, data))
                {
                    T[,] newArr = new T[data.sizeColumn, data.sizeRow];

                    for (int i = 0; i < data.sizeRow; i++)
                    {
                        for (int j = 0; j < data.sizeColumn; j++)
                        {
                            dynamic tempRes = data[i, j];
                            newArr[i,j] = tempRes + value;
                        }
                    }

                    return new Matrix<T>(newArr, data.sizeRow, data.sizeColumn);
                }
                return null;
        }
        public static Matrix<T> operator +(T value, Matrix<T> data)
        {
            return data + value;
        }
        public static Matrix<T> operator -(Matrix<T> data1, Matrix<T> data2)
        {
                if(ValidateArguments(data1,data2) && ValidateDimansion(data1,data2))
                {
                    T[,] newArr = new T[data1.sizeColumn, data1.sizeRow];

                    for (int i = 0; i < data1.sizeRow; i++)
                    {
                        for (int j = 0; j < data1.sizeColumn; j++)
                        {
                            dynamic temp1 = data1[i, j];
                            dynamic temp2 = data2[i, j];
                            newArr[i, j] = temp1 - temp2;
                        }
                    }

                    return new Matrix<T>(newArr, data1.sizeRow, data1.sizeColumn);
                }
                return null;
        }
        public static Matrix<T> operator -(Matrix<T> data,T value)
        {
                if(ValidateArguments(data, data))
                {
                    T[,] newArr = new T[data.sizeColumn, data.sizeRow];

                    for (int i = 0; i < data.sizeRow; i++)
                    {
                        for (int j = 0; j < data.sizeColumn; j++)
                        {
                            dynamic tempRes = data[i, j];
                            newArr[i,j] = tempRes - value;
                        }
                    }

                    return new Matrix<T>(newArr,data.sizeRow,data.sizeColumn);
                }
                return null;
        }
        public static Matrix<T> operator -(T value, Matrix<T> data)
        {
                if (ValidateArguments(data, data))
                {
                    T[,] newArr = new T[data.sizeColumn, data.sizeRow];

                    for (int i = 0; i < data.sizeRow; i++)
                    {
                        for (int j = 0; j < data.sizeColumn; j++)
                        {
                            dynamic tempRes = data[i, j];
                            newArr[i, j] = value - tempRes;
                        }
                    }

                    return new Matrix<T>(newArr, data.sizeRow, data.sizeColumn);
                }
                return null;
        }
        public static Matrix<T> operator *(Matrix<T> data1, Matrix<T> data2)
        {
            if (data1.sizeColumn != data2.sizeRow)
                throw new MatrixServiceException("DimensionException!");
            if(ValidateArguments(data1,data2))
            {
                T[,] newArr = new T[data1.sizeRow,data2.sizeColumn];

                for (int i = 0; i < data1.sizeRow; i++)
                {
                    for (int k = 0; k < data2.sizeColumn; k++)
                    {
                        for (int j = 0; j < data1.sizeColumn; j++)
                        {
                            dynamic value1 = data1[i, j];
                            dynamic value2 = data2[k, j];
                            newArr[i, k] += value1 * value2;
                        }
                    }
                }

                return new Matrix<T>(newArr, data1.sizeRow, data2.sizeColumn);
            }
            throw new MatrixServiceException("MatrixDimansionException!");
        }
        public static Matrix<T> operator *(Matrix<T> data, T value)
        {
            if(ValidateArguments(data,data))
            {
                T[,] newArr = new T[data.sizeRow, data.sizeColumn];

                for (int i = 0; i < data.sizeRow; i++)
                {
                    for (int j = 0; j < data.sizeColumn; j++)
                    {
                        dynamic temp = data[i, j];
                        newArr[i, j] = temp * value;
                    }
                }

                return new Matrix<T>(newArr, data.sizeRow, data.sizeColumn);
            }
            return null;
        }
        public static Matrix<T> operator *(T value, Matrix<T> data)
        {
            return data * value;
        }
        private static bool ValidateArguments(Matrix<T> data1,Matrix<T> data2)
        {
            if (data1 == null || data2 == null || data1.arr == null || data2.arr == null)
                throw new System.ArgumentNullException("ArgumentNullException!");
            return true;
        }
        private static bool ValidateDimansion(Matrix<T> data1, Matrix<T> data2)
        {
            if ((data1.sizeRow != data2.sizeRow) || (data1.sizeColumn != data2.sizeColumn))
                throw new MatrixServiceException("DimansionException!");
            return true;
        }
    }
}

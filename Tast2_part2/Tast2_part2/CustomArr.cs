using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tast2_part2
{
    public class CustomArr<T> : ICloneable, ICollection<T>
    {
        private T[] data;
        private int size;
        private int startIndex;

        public CustomArr()
        {
            startIndex = 0;
            size = 1;
            data = new T[size];
        }

        public CustomArr(int startIndex, int size)
        {
            this.startIndex = startIndex;
            this.size = size;
            data = new T[size];
        }

        public CustomArr(T[] data)
        {
            size = data.Length;
            this.data = CreateNewArrayToCopy(data);
            startIndex = 0;
        }

        public CustomArr(CustomArr<T> data)
        {
            this.data = CreateNewArrayToCopy(data.data);
            size = data.size;
            startIndex = data.startIndex;
        }
        public T this[int index]
        {
            get
            {
                if(ValidateOnIndex(index))
                    return data[index];
                return default(T);
            }
            set
            {
                if(ValidateOnIndex(index))
                    data[index] = value;
            }
        }
        public int Count
        {
            get
            {
                return size;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public void Add(T item)
        {
            for (int i = 0; i < size; i++)
            {
                if(data[i].Equals(default(T)))
                {
                    data[i] = item;
                    return;
                }
            }
        }
        public void Clear()
        {
            for (int i = 0; i < size; i++)
            {
                data[i] = default(T);
            }
        }
        public bool Contains(T item)
        {
            for (int i = 0; i < size; i++)
            {
                if (data[i].Equals(item))
                    return true;
            }
            return false;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex > size) throw new IndexOutOfRangeException();
            for (int i = arrayIndex; i < size; i++)
            {
                data[i] = array[i];
            }
        }
        public bool Remove(T item)
        {
            for (int i = 0; i < size; i++)
            {
                if (data[i].Equals(item))
                {
                    data[i] = default(T);
                    return true;
                }
            }
            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return data[i];
            }
        }
        public object Clone()
        {
            return new CustomArr<T>(this);
        }
        private T[] CreateNewArrayToCopy(T[] data)
        {
            if (data.Length == 0) return null;

            T []newArr = new T[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                newArr[i] = data[i];
            }
            return newArr;
        }
        private bool ValidateOnIndex(int index)
        {
            if (index > startIndex + size || index < startIndex - size) throw new IndexOutOfRangeException();
            return true;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

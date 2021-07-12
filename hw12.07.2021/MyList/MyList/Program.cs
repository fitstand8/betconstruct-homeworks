using System;
using System.Collections;
using System.Collections.Generic;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> lst = new MyList<int>();

            for (int i = 0; i <= 10; i++)
            {
                lst.Add(i);
            }

            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("Index of 4 is " + lst.IndexOf(4));
            lst.Insert(4, 69);
            Console.WriteLine();

            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            lst.RemoveAt(4);

            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            //lst.Clear();

            //foreach (var item in lst)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine("Does list contain 6? " + lst.Contains(6));
        }
    }

    public class ListItem<T>
    {
        public ListItem(){ }
        public ListItem(T value, bool hasValue)
        {
            Value = value;
            HasValue = hasValue;
        }

        public T Value { get; set; }
        public bool HasValue { get; set; }
    }

    public class MyList<T> : IEnumerable<T>, IEnumerator<T>, IList<T>
    {
        private ListItem<T>[] _array = new ListItem<T>[10];

        public MyList(){ }
        public MyList(int count)
        {
            if(count >= Capacity)
            {
                ShardArray();
            }
            this.Count = count;
            _array = new ListItem<T>[count];
        }

        public int Capacity { get; private set; } = 10;
        public int Count { get; private set; } = 0;

        public int Position = -1;
        public T Current => _array[Position].Value;
        object IEnumerator.Current => this.Current;
        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                var realIndex = GetRealIndex(index);
                return _array[realIndex].Value;
            }

            set
            {
                var realIndex = GetRealIndex(index);
                _array[realIndex].Value = value;
            }
        }

        private int GetRealIndex(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            for (int realIndex = 0, fakeIndex = 0; realIndex < _array.Length; realIndex++)
            {
                if (_array[realIndex].HasValue)
                {
                    if (fakeIndex == index)
                    {
                        return realIndex;
                    }
                    fakeIndex++;
                }
            }

            throw new IndexOutOfRangeException();
        }

        private void ShardArray()
        {
            Capacity *= 2;

            var tempArray = new ListItem<T>[Capacity];
            int j = 0;

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].HasValue)
                {
                    tempArray[j++] = _array[i];
                }
            }

            Count = j;
            _array = tempArray;
        }

        public void Add(T item)
        {
            if (Count >= Capacity)
            {
                ShardArray();
            }

            _array[Count++] = new ListItem<T>(item, true);
        }
        

        #region implementations

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _array[i].Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        public bool MoveNext()
        {
            if(Position >= Count - 1)
            {
                Reset();
                return false;
            }

            Position++;
            return true;
        }

        public void Reset()
        {
            Position = -1;
        }

        public void Dispose()
        {
            Reset();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(item)) return i;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.Add(default(T));
            T temp;

            for (int i = Count - 1; i > index; i--)
            {
                if(i > 0)
                {
                    temp = this[i];
                    this[i] = this[i - 1];
                    this[i - 1] = temp;
                }
            }

            this[index] = item;
        }

        public void RemoveAt(int index)
        {
            ListItem<T>[] newArray = new ListItem<T>[_array.Length - 2];
            for (int i = 0, j = 0; i < Count; i++, j++)
            {
                if(i == index)
                {
                    newArray[i] = _array[++j];
                    continue;    
                }
                newArray[i] = _array[j];
            }

            _array = newArray;
            Count--;
        }

        public void Clear()
        {
            Capacity = 10;
            _array = new ListItem<T>[Capacity];
            Count = 0;
        }

        public bool Contains(T item)
        {
            foreach(var n in this)
            {
                if (n.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < Count; i++)
            {
                array[i] = this[i];
            }
        }

        public bool Remove(T item)
        {
            bool itemFound = false;
            ListItem<T>[] newArray = new ListItem<T>[_array.Length - 2];

            for (int i = 0, j = 0; i < Count; i++, j++)
            {
                if (this[i].Equals(item) && !itemFound)
                {
                    itemFound = true;
                    newArray[i] = _array[++j];
                    continue;
                }
                newArray[i] = _array[j];
            }

            _array = newArray;
            Count--;

            if (itemFound)
            {
                return true;
            }
            return false;
        }

        #endregion implementations
    }
}

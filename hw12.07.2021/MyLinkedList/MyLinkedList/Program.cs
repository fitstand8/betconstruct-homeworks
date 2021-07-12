using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> lst = new MyLinkedList<int>();
            for (int i = 1; i <= 10; i++)
            {
                lst.Add(i);
            }

            foreach(var n in lst)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();

            Console.WriteLine("Does list contain 9? " + lst.Contains(9));

            Console.WriteLine();

            //lst.Clear();

            //foreach (var n in lst)
            //{
            //    Console.WriteLine(n);
            //}

            Console.WriteLine("Index of 6 is " + lst.IndexOf(6));

            Console.WriteLine();

            lst.Remove(6);
            lst.RemoveAt(1);

            foreach (var n in lst)
            {
                Console.WriteLine(n);
            }
        }
    }

    public class MyLinkedList<T> : IEnumerable<T>, IEnumerator<T>, IList<T>
    {
        protected class Node<T>
        {
            public T Value;
            public Node<T> Next;
            public Node(T value, Node<T> next = null)
            {
                Value = value;
                Next = next;
            }
        }

        protected Node<T> first;
        public bool IsEmpty => first == null;

        public int Count
        {
            get
            {
                int cnt = 0;
                Node<T> temp = first;
                while (temp != null)
                {
                    cnt++;
                    temp = temp.Next;
                }
                return cnt;
            }
        }

        private int Position = -1;
        public T Current => this[Position];
        object IEnumerator.Current => this.Current;
        public bool IsReadOnly => false;

        public T this[int i]
        {
            get
            {
                if (i >= Count || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                Node<T> temp = first;
                for (int j = 0; j < i; j++)
                {
                    temp = temp.Next;
                }
                return temp.Value;
            }

            set
            {
                if (i >= Count || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                Node<T> temp = first;
                for (int j = 0; j < i; j++)
                {
                    temp = temp.Next;
                }
                temp.Value = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }



        public bool MoveNext()
        {
            if (Position >= Count)
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
                if (i > 0)
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
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < Count - 1; i++)
            {
                this[i] = this[i + 1];
            }
            Node<T> temp = first;
            while (temp.Next.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = null;
        }

        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);
            if (IsEmpty)
            {
                first = node;
                return;
            }
            Node<T> temp = first;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = node;
        }

        public void Clear()
        {
            first = null;
        }

        public bool Contains(T item)
        {
            foreach (var n in this)
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
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace MyDictionary
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class MyDictionary<TKey, TValue> : IMyDictionary<TKey, TValue>
    {
        private int Capacity { get; set; } = 10;
        public int Count { get; set; }
        private MyKeyValuePair<TKey, TValue>[] _array;
        public MyDictionary()
        {
            _array = new MyKeyValuePair<TKey, TValue>[10];
        }

        public TValue this[TKey key]
        {
            get
            {
                int hash = key.GetHashCode() % _array.Length;
                if (hash < 0 || hash > Count) throw new IndexOutOfRangeException();
                return _array[hash].Value;
            }
            set
            {
                int hash = key.GetHashCode() % _array.Length;
                _array[hash] = new MyKeyValuePair<TKey, TValue>(key, value);
            }
        }

        private void EnlargeCapacity()
        {
            Capacity *= 2;
            var tempArray = new MyKeyValuePair<TKey, TValue>[Capacity];
            for (int i = 0; i < _array.Length; i++)
            {
                tempArray[i] = _array[i];
            }
            _array = tempArray;
        }

        public void Add(TKey key, TValue value)
        {
            if(Count >= Capacity)
            {
                EnlargeCapacity();
            }
            var item = new MyKeyValuePair<TKey, TValue>(key, value);
            int hash = item.Key.GetHashCode() % _array.Length;
            if (_array[hash] != null) throw new ArgumentException();
            _array[hash] = item;
            Count++;
        }

        public bool ContainsKey(TKey key)
        {
            int hash = key.GetHashCode() % _array.Length;
            if (_array[hash] != null) return true;
            return false;
        }

        public bool ContainsValue(TValue value)
        {
            foreach(var n in _array)
            {
                if (n.Value.Equals(value)) return true;
            }
            return false;
        }

        public IEnumerator<MyKeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _array[i];
            }
        }

        public void Remove(TKey key)
        {
            int hash = key.GetHashCode() % _array.Length;
            _array[hash] = null;
            Count--;
        }

        public bool TryAdd(TKey key, TValue value)
        {
            if (Count >= Capacity)
            {
                EnlargeCapacity();
            }
            var item = new MyKeyValuePair<TKey, TValue>(key, value);
            int hash = item.Key.GetHashCode() % _array.Length;
            if (_array[hash] != null) return false;
            _array[hash] = item;
            Count++;
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int hash = key.GetHashCode() % _array.Length;
            value = _array[hash].Value;
            if (_array[hash] == null) return false;
            return true;
        }

        public bool TryRemove(TKey key)
        {
            int hash = key.GetHashCode() % _array.Length;
            if (_array[hash] == null) return false;
            _array[hash] = null;
            Count--;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

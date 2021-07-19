using System;
using System.Collections.Generic;
using System.Text;

namespace MyDictionary
{
    public class MyKeyValuePair<TKey, TValue>
    {
        public MyKeyValuePair(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }
        public TKey Key { get; }
        public TValue Value { get; }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}

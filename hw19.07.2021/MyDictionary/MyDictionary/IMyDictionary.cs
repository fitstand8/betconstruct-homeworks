using System;
using System.Collections.Generic;
using System.Text;

namespace MyDictionary
{
    public interface IMyDictionary<TKey, TValue> : IEnumerable<MyKeyValuePair<TKey, TValue>>
    {
        void Add(TKey key, TValue value);
        void Remove(TKey key);
        bool TryAdd(TKey key, TValue value);
        bool TryRemove(TKey key);
        bool TryGetValue(TKey key, out TValue value);
        bool ContainsKey(TKey key);
        bool ContainsValue(TValue value);
    }
}

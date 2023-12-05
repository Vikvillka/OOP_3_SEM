using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9_OOP
{
    public class Books<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private List<KeyValuePair<TKey, TValue>> data = new List<KeyValuePair<TKey, TValue>>();

        // методы и свойства из интерфейса
        
        public TValue this[TKey key]
        {
            get
            {
                var pair = data.Find(item => item.Key.Equals(key));
                if (pair.Equals(default(KeyValuePair<TKey, TValue>)))
                {
                    throw new KeyNotFoundException();
                }
                return pair.Value;
            }
            set
            {
                var pair = data.FindIndex(item => item.Key.Equals(key));
                if (pair != -1)
                {
                    data[pair] = new KeyValuePair<TKey, TValue>(key, value);
                }
                else
                {
                    Add(key, value);
                }
            }
        } 

        public ICollection<TKey> Keys
        {
            get { return data.Select(pair => pair.Key).ToList(); }
        }

        public ICollection<TValue> Values
        {
            get { return data.Select(pair => pair.Value).ToList(); }
        }

        public int Count
        {
            get { return data.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(TKey key, TValue value)
        {
            data.Add(new KeyValuePair<TKey, TValue>(key, value));
        }
        
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            data.Add(item);
        }

        public void Clear()
        {
            data.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return data.Contains(item);
        }

        public bool ContainsKey(TKey key)
        {
            return data.Any(pair => pair.Key.Equals(key));
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (array.Length - arrayIndex < data.Count)
            {
                throw new ArgumentException("Array is not large enough.");
            }

            for (int i = 0; i < data.Count; i++)
            {
                array[arrayIndex + i] = data[i];
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            var pair = data.Find(item => item.Key.Equals(key));
            return data.Remove(pair);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return data.Remove(item);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var pair = data.Find(item => item.Key.Equals(key));
            if (pair.Equals(default(KeyValuePair<TKey, TValue>)))
            {
                value = default(TValue);
                return false;
            }
            value = pair.Value;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void RemoveRange(int n, TKey startKey)
        {
            for (int i = 0; i < n; i++)
            {
                if (ContainsKey(startKey))
                {
                    Remove(startKey);
                    startKey = GetNextKey(startKey);
                }
                else
                {
                    Console.WriteLine($"Ключ '{startKey}' не найден.");
                    break;
                }
            }
        }

        private TKey GetNextKey(TKey currentKey)
        {
            if (currentKey is int)
            {
                int nextKey = (int)(object)currentKey + 1;
                return (TKey)(object)nextKey;
            }
            else
            {
                throw new InvalidOperationException("Тип ключа не поддерживается.");
            }
        }

        public void Print()
        {
            foreach(KeyValuePair<TKey,TValue> item in data)
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
        }
    }
}


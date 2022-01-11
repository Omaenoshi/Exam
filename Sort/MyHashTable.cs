#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort
{
    public class MyHashTable<TKey, TValue> where TKey : IConvertible // хеш таблица с разрешением коллизий методом цепочек
    {
        private readonly List<Cell<TKey, TValue>>[] buckets; // массив списков 

        public MyHashTable(int size = 10)
        {
            buckets = new List<Cell<TKey, TValue>>[size];
            for (var i = 0; i < buckets.Length; i++)     // специально прогоняем всю хеш таблицу чтоб инициализировать списки
                buckets[i] = new List<Cell<TKey, TValue>>();
        }

        public void Insert(TKey key, TValue value)
        {
            if (IsHaveKey(key))     //проверка на существует ли уже ключ
                throw new Exception("This key already exists");
            var hash = GetHash(key);
            buckets[hash].Add(new Cell<TKey, TValue>(key, value));
        }

        public TValue Search(TKey key)  //поиск ключа
        {
            var hash = GetHash(key);
            var cells = buckets[hash];
            foreach (var item in cells)
            {
                if (item.Key.Equals(key))
                    return item.Value;
            }

            throw new Exception("This key does not exist");
        }

        public void Remove(TKey key)  //удаление
        {
            if (!IsHaveKey(key))
                throw new Exception("This key does not exist");
            var hash = GetHash(key);
            var cells = buckets[hash];
            for (var i = 0; i < cells.Count; i++)
            {
                if (cells[i].Key.Equals(key))
                    cells[i] = null;
            }
        }

        private int GetHash(TKey key)   //хеш функция
        {
            var value = key.GetHashCode();
            return (value & 0x7fffffff) % buckets.Length;
        }
        
        public bool IsHaveKey(TKey key)   //проверка на существует ли уже такой ключ
        {
            var hash = GetHash(key);   
            var cells = buckets[hash];
            foreach (var item in cells)
                if (item.Key?.Equals(key) ?? false)
                    return true;
            
            return false;
        }
    }

    public class Cell<TKey, TValue>   //чисто ячейка
    {
        public TKey Key { get; set; }                       
                                                            
        public TValue Value { get; set; }                   
                                                            
        public Cell(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    public class MyHashTable2<TKey, TValue>
    {
        private readonly Cell<TKey, TValue>[] buckets;

        public MyHashTable2(int size = 10)
        {
            buckets = new Cell<TKey, TValue>[size];
        }

        public void Insert(TKey key, TValue value)
        {
            if (IsHaveKey(key))
                throw new Exception("This key already exists");
            var hash = GetHash(key);
            buckets[hash] = new Cell<TKey, TValue>(key, value);
        }

        public TValue Search(TKey key)
        {
            if (!IsHaveKey(key))
                throw new Exception("This key does not exist");

            var hash = GetHash(key);
            return buckets[hash].Value;
        }

        public void Remove(TKey key)
        {
            if (!IsHaveKey(key))
                throw new Exception("This key does not exist");

            var hash = GetHash(key);
            buckets[hash] = null;
        }

        private int GetHash(TKey key)
        {
            var hash = (key.GetHashCode() & 0x7fffffff) % buckets.Length;
            var er = Convert.ToInt32(key) / 2;
            if (buckets[hash] == null)
                return hash;
            if (!buckets[hash].Key.Equals(key))
            {
                while (buckets[hash] != null)
                {
                    hash++;
                    if (buckets[hash] == null)
                        return hash;
                    if (buckets[hash].Key.Equals(key))
                        return hash;
                }
            }

            return hash;
        }

        public bool IsHaveKey(TKey key)
        {
            foreach (var item in buckets)
            {
                if (item != null && item.Key.Equals(key))
                    return true;
            }

            return false;
        }
    }
}
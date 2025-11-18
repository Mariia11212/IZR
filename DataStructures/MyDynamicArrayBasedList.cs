using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace lr1.DataStructures
{
    /// <summary>Динамічний масив з автоматичним розширенням.</summary>
    /// <typeparam name="T">Тип елементів.</typeparam>
    public class MyDynamicArrayBasedList<T> : IDataList<T>
    {
        private T?[] _items;
        private int _capacity;

        /// <summary>Кількість елементів у списку.</summary>
        public int Count { get; private set; }

        private const int DefaultCapacity = 4;

        /// <summary>Ініціалізує порожній список.</summary>
        public MyDynamicArrayBasedList()
        {
            _capacity = DefaultCapacity;
            _items = new T?[_capacity];
            Count = 0;
        }

        private void EnsureCapacity()
        {
            if (Count == _capacity)
            {
                _capacity *= 2;
                T?[] newItems = new T?[_capacity];
                Array.Copy(_items, newItems, Count);
                _items = newItems;
            }
        }

        /// <summary>Додає елемент у кінець.</summary>
        /// <param name="item">Елемент.</param>
        public void Add(T item)
        {
            EnsureCapacity();
            _items[Count] = item;
            Count++;
        }

        /// <summary>Вставляє елемент за індексом.</summary>
        /// <param name="item">Елемент.</param>
        /// <param name="index">Індекс вставки.</param>
        /// <exception cref="ArgumentOutOfRangeException">Індекс поза межами.</exception>
        public void InsertAt(T item, int index)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds.");

            EnsureCapacity();
            Array.Copy(_items, index, _items, index + 1, Count - index);
            _items[index] = item;
            Count++;
        }

        /// <summary>Видаляє елемент за індексом.</summary>
        /// <param name="index">Індекс видалення.</param>
        /// <exception cref="ArgumentOutOfRangeException">Індекс поза межами.</exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds.");

            Count--;
            Array.Copy(_items, index + 1, _items, index, Count - index);
            _items[Count] = default;
        }

        /// <summary>Повертає елемент за індексом.</summary>
        /// <param name="index">Індекс елемента.</param>
        /// <returns>Елемент списку.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Індекс поза межами.</exception>
        public T GetAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds.");

            return _items[index]!;
        }

        /// <summary>Повертає індекс першого входження елемента.</summary>
        /// <param name="item">Шуканий елемент.</param>
        /// <returns>Індекс або -1.</returns>
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (EqualityComparer<T?>.Default.Equals(_items[i], item))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>Шукає перший елемент за умовою.</summary>
        /// <param name="predicate">Умова пошуку.</param>
        /// <returns>Елемент або default.</returns>
        public T? FindFirst(Func<T, bool> predicate)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i] != null && predicate(_items[i]!))
                {
                    return _items[i];
                }
            }
            return default;
        }

        /// <summary>Перевіряє наявність елемента.</summary>
        /// <param name="item">Елемент.</param>
        /// <returns>true, якщо знайдено.</returns>
        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        /// <summary>Очищає список.</summary>
        public void Clear()
        {
            Array.Fill(_items, default);
            Count = 0;
        }

        /// <summary>Повертає рядкове представлення списку.</summary>
        /// <returns>Рядок з елементами.</returns>
        public override string ToString()
        {
            List<string> items = new List<string>();
            for (int i = 0; i < Count; i++)
            {
                items.Add(_items[i]?.ToString() ?? "null");
            }
            return $"[{string.Join(", ", items)}]";
        }

        /// <summary>Повертає ітератор колекції.</summary>
        /// <returns>Enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i]!;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
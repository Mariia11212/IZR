using System;
using System.Collections.Generic;

namespace lr1.DataStructures
{
    /// <summary>Інтерфейс списку даних.</summary>
    /// <typeparam name="T">Тип елементів.</typeparam>
    public interface IDataList<T> : IEnumerable<T>
    {
        /// <summary>Кількість елементів.</summary>
        int Count { get; }

        /// <summary>Додає елемент.</summary>
        /// <param name="item">Елемент.</param>
        void Add(T item);

        /// <summary>Видаляє елемент за індексом.</summary>
        /// <param name="index">Індекс.</param>
        void RemoveAt(int index);

        /// <summary>Отримує елемент за індексом.</summary>
        /// <param name="index">Індекс.</param>
        /// <returns>Елемент.</returns>
        T GetAt(int index);

        /// <summary>Повертає індекс елемента.</summary>
        /// <param name="item">Елемент.</param>
        /// <returns>Індекс або -1.</returns>
        int IndexOf(T item);

        /// <summary>Шукає перший елемент за умовою.</summary>
        /// <param name="predicate">Умова.</param>
        /// <returns>Елемент або default.</returns>
        T? FindFirst(Func<T, bool> predicate);

        /// <summary>Перевіряє наявність елемента.</summary>
        /// <param name="item">Елемент.</param>
        /// <returns>true, якщо знайдено.</returns>
        bool Contains(T item);

        /// <summary>Очищає список.</summary>
        void Clear();

        /// <summary>Вставляє елемент за індексом.</summary>
        /// <param name="item">Елемент.</param>
        /// <param name="index">Індекс.</param>
        void InsertAt(T item, int index);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace lr1.DataStructures
{
    /// <summary>Кільцевий зв'язний список.</summary>
    /// <typeparam name="T">Тип елементів.</typeparam>
    public class MyCircularList<T> : IDataList<T>
    {
        private Node<T>? _head;
        private Node<T>? _tail;

        /// <summary>Кількість елементів.</summary>
        public int Count { get; private set; }

        /// <summary>Ініціалізує порожній список.</summary>
        public MyCircularList()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        /// <summary>Додає елемент у кінець.</summary>
        /// <param name="item">Елемент.</param>
        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
                newNode.Next = _head;
            }
            else
            {
                newNode.Next = _head;
                _tail!.Next = newNode;
                _tail = newNode;
            }
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

            if (index == Count)
            {
                Add(item);
                return;
            }

            Node<T> newNode = new Node<T>(item);
            if (index == 0)
            {
                if (_head == null)
                {
                    _head = newNode;
                    _tail = newNode;
                    newNode.Next = _head;
                }
                else
                {
                    newNode.Next = _head;
                    _tail!.Next = newNode;
                    _head = newNode;
                }
            }
            else
            {
                Node<T> current = _head!;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next!;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            Count++;
        }

        /// <summary>Видаляє елемент за індексом.</summary>
        /// <param name="index">Індекс видалення.</param>
        /// <exception cref="ArgumentOutOfRangeException">Індекс поза межами.</exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds.");
            if (_head == null) return;

            if (Count == 1)
            {
                _head = null;
                _tail = null;
            }
            else if (index == 0)
            {
                _head = _head.Next;
                _tail!.Next = _head;
            }
            else
            {
                Node<T> current = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current!.Next;
                }
                current!.Next = current.Next!.Next;
                if (index == Count - 1)
                {
                    _tail = current;
                }
            }
            Count--;
        }

        /// <summary>Отримує елемент за індексом.</summary>
        /// <param name="index">Індекс елемента.</param>
        /// <returns>Елемент списку.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Індекс поза межами.</exception>
        /// <exception cref="InvalidOperationException">Список порожній.</exception>
        public T GetAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds.");
            if (_head == null) throw new InvalidOperationException("List is empty.");

            Node<T> current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }
            return current!.Value;
        }

        /// <summary>Повертає індекс елемента.</summary>
        /// <param name="item">Елемент.</param>
        /// <returns>Індекс або -1.</returns>
        public int IndexOf(T item)
        {
            if (_head == null) return -1;

            Node<T> current = _head;
            for (int i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, item))
                {
                    return i;
                }
                current = current.Next!;
            }
            return -1;
        }

        /// <summary>Шукає перший елемент за умовою.</summary>
        /// <param name="predicate">Умова пошуку.</param>
        /// <returns>Елемент або default.</returns>
        public T? FindFirst(Func<T, bool> predicate)
        {
            if (_head == null) return default;

            Node<T> current = _head;
            for (int i = 0; i < Count; i++)
            {
                if (predicate(current.Value))
                {
                    return current.Value;
                }
                current = current.Next!;
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
            _head = null;
            _tail = null;
            Count = 0;
        }

        /// <summary>Рядкове представлення списку.</summary>
        /// <returns>Рядок з елементами.</returns>
        public override string ToString()
        {
            List<string> items = new List<string>();
            if (_head == null) return "[]";

            Node<T> current = _head;
            for (int i = 0; i < Count; i++)
            {
                items.Add(current.Value?.ToString() ?? "null");
                current = current.Next!;
            }
            return $"[{string.Join(", ", items)}]";
        }

        /// <summary>Повертає ітератор.</summary>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = _head;
            for (int i = 0; i < Count && current != null; i++)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
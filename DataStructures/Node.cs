namespace lr1.DataStructures
{
    /// <summary>Вузол зв'язного списку.</summary>
    /// <typeparam name="T">Тип даних.</typeparam>
    public class Node<T>
    {
        /// <summary>Значення вузла.</summary>
        public T Value { get; set; }

        /// <summary>Посилання на наступний вузол.</summary>
        public Node<T>? Next { get; set; }

        /// <summary>Створює новий вузол.</summary>
        /// <param name="value">Значення.</param>
        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }
}
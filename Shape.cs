using System;

namespace lr1
{
    /// <summary>Абстрактний базовий клас фігури.</summary>
    public abstract class Shape : IShape
    {
        /// <summary>Обчислює площу.</summary>
        /// <returns>Площа.</returns>
        public abstract double GetArea();

        /// <summary>Обчислює периметр.</summary>
        /// <returns>Периметр.</returns>
        public abstract double GetPerimeter();

        /// <summary>Повертає геометричний центр.</summary>
        /// <returns>Точка центру.</returns>
        public abstract Point GetCentroid();

        /// <summary>Застосовує трансформацію.</summary>
        /// <param name="transformation">Об'єкт трансформації.</param>
        public abstract void ApplyTransformation(ITransformation transformation);

        /// <summary>Виводить інформацію в консоль.</summary>
        public void DisplayInfo()
        {
            Console.WriteLine($"Shape Type: {GetType().Name}");
            Console.WriteLine($"  Centroid: {GetCentroid()}");
            Console.WriteLine($"  Area: {GetArea():F2}");
            Console.WriteLine($"  Perimeter: {GetPerimeter():F2}");
        }
    }
}
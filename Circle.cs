using System;

namespace lr1
{
    /// <summary>Представляє коло.</summary>
    public class Circle : Shape
    {
        /// <summary>Центр кола.</summary>
        public Point Center { get; private set; }

        /// <summary>Радіус кола.</summary>
        public double Radius { get; private set; }

        /// <summary>Створює коло.</summary>
        /// <param name="center">Центр.</param>
        /// <param name="radius">Радіус (>0).</param>
        /// <exception cref="ArgumentException">Радіус некоректний.</exception>
        public Circle(Point center, double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius must be positive.");
            Center = center;
            Radius = radius;
        }

        /// <summary>Обчислює площу.</summary>
        /// <returns>Площа кола.</returns>
        public override double GetArea() => Math.PI * Radius * Radius;

        /// <summary>Обчислює довжину кола.</summary>
        /// <returns>Довжина кола.</returns>
        public override double GetPerimeter() => 2 * Math.PI * Radius;

        /// <summary>Повертає центр фігури.</summary>
        /// <returns>Точка центру.</returns>
        public override Point GetCentroid() => Center;

        /// <summary>Застосовує трансформацію.</summary>
        /// <param name="transformation">Об'єкт трансформації.</param>
        public override void ApplyTransformation(ITransformation transformation)
        {
            Center = transformation.Transform(Center);
            if (transformation is Scaling scaling)
            {
                Radius *= scaling.Factor;
            }
        }

        /// <summary>Перевіряє, чи містить коло точку.</summary>
        /// <param name="p">Точка.</param>
        /// <returns>true, якщо точка всередині.</returns>
        public bool ContainsPoint(Point p)
        {
            return Center.GetDistanceTo(p) <= Radius;
        }

        /// <summary>Рядкове представлення.</summary>
        /// <returns>Опис кола.</returns>
        public override string ToString()
        {
            return $"Circle with Center {Center} and Radius {Radius:F2}";
        }
    }
}
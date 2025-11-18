using System.Numerics;

namespace lr1
{
    /// <summary>2D точка.</summary>
    public class Point
    {
        /// <summary>Координата X.</summary>
        public double X { get; private set; }

        /// <summary>Координата Y.</summary>
        public double Y { get; private set; }

        /// <summary>Створює точку.</summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>Обчислює відстань до іншої точки.</summary>
        /// <param name="other">Інша точка.</param>
        /// <returns>Відстань.</returns>
        public double GetDistanceTo(Point other)
        {
            return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
        }

        /// <summary>Зміщує точку на вектор.</summary>
        /// <param name="vector">Вектор зміщення.</param>
        /// <returns>Нова точка.</returns>
        public Point Translate(Vector vector)
        {
            return new Point(X + vector.Dx, Y + vector.Dy);
        }

        /// <summary>Рядкове представлення.</summary>
        /// <returns>Рядок координат.</returns>
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
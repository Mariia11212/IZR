using System;

namespace lr1
{
    /// <summary>Трансформація обертання.</summary>
    public class Rotation : ITransformation
    {
        private double _angleInRadians;
        private Point _pivot;

        /// <summary>Ініціалізує обертання.</summary>
        /// <param name="angleInDegrees">Кут (градуси).</param>
        /// <param name="pivot">Центр обертання.</param>
        public Rotation(double angleInDegrees, Point pivot)
        {
            _angleInRadians = angleInDegrees * Math.PI / 180.0;
            _pivot = pivot;
        }

        /// <summary>Обертає точку.</summary>
        /// <param name="p">Точка.</param>
        /// <returns>Нова координата.</returns>
        public Point Transform(Point p)
        {
            double translatedX = p.X - _pivot.X;
            double translatedY = p.Y - _pivot.Y;

            double rotatedX = translatedX * Math.Cos(_angleInRadians) - translatedY * Math.Sin(_angleInRadians);
            double rotatedY = translatedX * Math.Sin(_angleInRadians) + translatedY * Math.Cos(_angleInRadians);

            return new Point(rotatedX + _pivot.X, rotatedY + _pivot.Y);
        }

        /// <summary>Рядкове представлення.</summary>
        public override string ToString()
        {
            return $"Rotation by {_angleInRadians * 180 / Math.PI:F2} degrees around {_pivot}";
        }
    }
}
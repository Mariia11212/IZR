using System;

namespace lr1
{
    /// <summary>Трансформація масштабування.</summary>
    public class Scaling : ITransformation
    {
        /// <summary>Коефіцієнт масштабування.</summary>
        public double Factor { get; private set; }
        private Point _center;

        /// <summary>Ініціалізує масштабування.</summary>
        /// <param name="factor">Коефіцієнт (>0).</param>
        /// <param name="center">Центр масштабування.</param>
        /// <exception cref="ArgumentException">Коефіцієнт некоректний.</exception>
        public Scaling(double factor, Point center)
        {
            if (factor <= 0)
                throw new ArgumentException("Scaling factor must be positive.");
            Factor = factor;
            _center = center;
        }

        /// <summary>Масштабує точку.</summary>
        /// <param name="p">Точка.</param>
        /// <returns>Нова координата.</returns>
        public Point Transform(Point p)
        {
            double translatedX = p.X - _center.X;
            double translatedY = p.Y - _center.Y;

            double scaledX = translatedX * Factor;
            double scaledY = translatedY * Factor;

            return new Point(scaledX + _center.X, scaledY + _center.Y);
        }

        /// <summary>Рядкове представлення.</summary>
        public override string ToString()
        {
            return $"Scaling by Factor {Factor:F2} around {_center}";
        }
    }
}
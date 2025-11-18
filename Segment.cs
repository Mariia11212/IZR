namespace lr1
{
    /// <summary>Представляє відрізок прямої.</summary>
    public class Segment : Shape
    {
        /// <summary>Початкова точка.</summary>
        public Point StartPoint { get; private set; }

        /// <summary>Кінцева точка.</summary>
        public Point EndPoint { get; private set; }

        /// <summary>Створює відрізок.</summary>
        /// <param name="startPoint">Початок.</param>
        /// <param name="endPoint">Кінець.</param>
        public Segment(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        /// <summary>Повертає 0 (площа відсутня).</summary>
        /// <returns>0.</returns>
        public override double GetArea() => 0;

        /// <summary>Обчислює довжину відрізка.</summary>
        /// <returns>Довжина.</returns>
        public override double GetPerimeter() => StartPoint.GetDistanceTo(EndPoint);

        /// <summary>Повертає середину відрізка.</summary>
        /// <returns>Точка центру.</returns>
        public override Point GetCentroid()
        {
            return new Point(
                (StartPoint.X + EndPoint.X) / 2,
                (StartPoint.Y + EndPoint.Y) / 2
            );
        }

        /// <summary>Застосовує трансформацію.</summary>
        /// <param name="transformation">Об'єкт трансформації.</param>
        public override void ApplyTransformation(ITransformation transformation)
        {
            StartPoint = transformation.Transform(StartPoint);
            EndPoint = transformation.Transform(EndPoint);
        }

        /// <summary>Повертає середину (аліас для GetCentroid).</summary>
        /// <returns>Середина відрізка.</returns>
        public Point GetMidpoint() => GetCentroid();

        /// <summary>Рядкове представлення.</summary>
        /// <returns>Опис відрізка.</returns>
        public override string ToString()
        {
            return $"Segment from {StartPoint} to {EndPoint}";
        }
    }
}
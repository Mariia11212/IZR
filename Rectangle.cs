using System.Collections.Generic;
using lr1.DataStructures;

namespace lr1
{
    /// <summary>Представляє прямокутник.</summary>
    public class Rectangle : Polygon
    {
        /// <summary>Лівий верхній кут.</summary>
        public Point TopLeft { get; private set; }

        /// <summary>Ширина.</summary>
        public double Width { get; private set; }

        /// <summary>Висота.</summary>
        public double Height { get; private set; }

        /// <summary>Створює прямокутник.</summary>
        /// <param name="topLeft">Лівий верхній кут.</param>
        /// <param name="width">Ширина (>0).</param>
        /// <param name="height">Висота (>0).</param>
        /// <exception cref="ArgumentException">Розміри некоректні.</exception>
        public Rectangle(Point topLeft, double width, double height)
            : base(GetRectangleVertices(topLeft, width, height))
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Width and height must be positive.");
            TopLeft = topLeft;
            Width = width;
            Height = height;
        }

        private static MyDynamicArrayBasedList<Point> GetRectangleVertices(Point topLeft, double width, double height)
        {
            MyDynamicArrayBasedList<Point> vertices = new MyDynamicArrayBasedList<Point>();
            vertices.Add(topLeft);
            vertices.Add(new Point(topLeft.X + width, topLeft.Y));
            vertices.Add(new Point(topLeft.X + width, topLeft.Y + height));
            vertices.Add(new Point(topLeft.X, topLeft.Y + height));
            return vertices;
        }

        /// <summary>Обчислює площу.</summary>
        /// <returns>Площа прямокутника.</returns>
        public override double GetArea() => Width * Height;

        /// <summary>Обчислює периметр.</summary>
        /// <returns>Периметр прямокутника.</returns>
        public override double GetPerimeter() => 2 * (Width + Height);

        /// <summary>Застосовує трансформацію.</summary>
        /// <param name="transformation">Об'єкт трансформації.</param>
        public override void ApplyTransformation(ITransformation transformation)
        {
            base.ApplyTransformation(transformation);
            TopLeft = transformation.Transform(TopLeft);
        }

        /// <summary>Рядкове представлення.</summary>
        /// <returns>Опис прямокутника.</returns>
        public override string ToString()
        {
            return $"Rectangle with TopLeft {TopLeft}, Width {Width:F2}, Height {Height:F2}";
        }
    }
}
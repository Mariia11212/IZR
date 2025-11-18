namespace lr1
{
    /// <summary>Трансформація паралельного перенесення.</summary>
    public class Translation : ITransformation
    {
        private Vector _translationVector;

        /// <summary>Ініціалізує переміщення.</summary>
        /// <param name="vector">Вектор зміщення.</param>
        public Translation(Vector vector)
        {
            _translationVector = vector;
        }

        /// <summary>Зміщує точку.</summary>
        /// <param name="p">Точка.</param>
        /// <returns>Нова координата.</returns>
        public Point Transform(Point p)
        {
            return new Point(p.X + _translationVector.Dx, p.Y + _translationVector.Dy);
        }

        /// <summary>Рядкове представлення.</summary>
        public override string ToString()
        {
            return $"Translation by Vector ({_translationVector.Dx}, {_translationVector.Dy})";
        }
    }
}
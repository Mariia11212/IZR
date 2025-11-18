namespace lr1
{
    /// <summary>2D вектор.</summary>
    public class Vector
    {
        /// <summary>Складова X.</summary>
        public double Dx { get; private set; }

        /// <summary>Складова Y.</summary>
        public double Dy { get; private set; }

        /// <summary>Створює вектор.</summary>
        /// <param name="dx">Складова X.</param>
        /// <param name="dy">Складова Y.</param>
        public Vector(double dx, double dy)
        {
            Dx = dx;
            Dy = dy;
        }

        /// <summary>Обчислює довжину вектора.</summary>
        /// <returns>Довжина.</returns>
        public double GetMagnitude()
        {
            return Math.Sqrt(Dx * Dx + Dy * Dy);
        }

        /// <summary>Масштабує вектор.</summary>
        /// <param name="factor">Коефіцієнт.</param>
        /// <returns>Новий вектор.</returns>
        public Vector Scale(double factor)
        {
            return new Vector(Dx * factor, Dy * factor);
        }
    }
}
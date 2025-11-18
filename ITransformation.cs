namespace lr1
{
    /// <summary>Інтерфейс геометричної трансформації.</summary>
    public interface ITransformation
    {
        /// <summary>Трансформує точку.</summary>
        /// <param name="p">Точка.</param>
        /// <returns>Результат трансформації.</returns>
        Point Transform(Point p);
    }
}
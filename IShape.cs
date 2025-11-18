namespace lr1
{
    /// <summary>Інтерфейс геометричної фігури.</summary>
    public interface IShape
    {
        /// <summary>Обчислює площу.</summary>
        /// <returns>Площа фігури.</returns>
        double GetArea();

        /// <summary>Обчислює периметр.</summary>
        /// <returns>Периметр фігури.</returns>
        double GetPerimeter();

        /// <summary>Повертає геометричний центр.</summary>
        /// <returns>Точка центру.</returns>
        Point GetCentroid();

        /// <summary>Застосовує трансформацію.</summary>
        /// <param name="transformation">Об'єкт трансформації.</param>
        void ApplyTransformation(ITransformation transformation);

        /// <summary>Виводить інформацію про фігуру.</summary>
        void DisplayInfo();
    }
}
using System.Collections.Generic;
using lr1.DataStructures;

namespace lr1
{
    /// <summary>Керує застосуванням трансформацій.</summary>
    public static class TransformationManager
    {
        /// <summary>Трансформує стандартний список фігур.</summary>
        /// <typeparam name="T">Тип фігури.</typeparam>
        /// <param name="shapes">Список фігур.</param>
        /// <param name="transformation">Трансформація.</param>
        /// <returns>Список змінених фігур.</returns>
        public static List<T> TransformAll<T>(List<T> shapes, ITransformation transformation) where T : IShape
        {
            List<T> transformedShapes = new List<T>();
            foreach (var shape in shapes)
            {
                shape.ApplyTransformation(transformation);
                transformedShapes.Add(shape);
            }
            return transformedShapes;
        }

        /// <summary>Трансформує користувацьку колекцію фігур.</summary>
        /// <typeparam name="T">Тип фігури.</typeparam>
        /// <param name="shapes">Колекція фігур.</param>
        /// <param name="transformation">Трансформація.</param>
        /// <returns>Колекція змінених фігур.</returns>
        public static IDataList<T> TransformAll<T>(IDataList<T> shapes, ITransformation transformation) where T : IShape
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                shapes.GetAt(i).ApplyTransformation(transformation);
            }
            return shapes;
        }

        /// <summary>Застосовує ланцюжок трансформацій до точки.</summary>
        /// <param name="p">Початкова точка.</param>
        /// <param name="transformations">Набір трансформацій.</param>
        /// <returns>Кінцева точка.</returns>
        public static Point ApplyMultipleTransformations(Point p, params ITransformation[] transformations)
        {
            Point currentPoint = p;
            foreach (var transform in transformations)
            {
                currentPoint = transform.Transform(currentPoint);
            }
            return currentPoint;
        }
    }
}
namespace ShapeArea.Shapes
{
    public class Circle : IShape
    {
        public double Radius { get; private set; }

        // Круг я сделал после треугольника. Тут можно было использовать простой конструктор, но решил сохранить идентичность использования
        private Circle()
        {
        }

        public static Circle Create(double radius)
        {
            return new Circle()
            {
                Radius = radius
            };
        }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}

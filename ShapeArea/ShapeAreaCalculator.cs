namespace ShapeArea
{
    public class ShapeAreaCalculator
    {
        public double Calculate(IShape shape)
        {
            return shape.CalculateArea();
        }
    }
}

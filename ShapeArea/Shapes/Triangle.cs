namespace ShapeArea.Shapes
{
    public class Triangle : IShape
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public double AngleA { get; private set; }
        public double AngleB { get; private set; }
        public double AngleC { get; private set; }

        public double Perimetr => A + B + C;
        public bool IsRightTriangle =>
            A * A + B * B == C * C ||
            A * A + C * C == B * B ||
            C * C + B * B == A * A;
        public bool IsExistTriangle
            => A + B < C && B + C < A && C + A < B;

        // Я немного увлекся и сделал углы из-за чего применение обычного конструктора для инициализации стало невозможно...
        private Triangle()
        {

        }


        public static Triangle CreateBySides(double sideA, double sideB, double sideC)
        {
            var triangle = new Triangle();
            triangle.A = sideA;
            triangle.B = sideB;
            triangle.C = sideC;
            triangle.CalcAngles();
            return triangle;
        }

        public static Triangle CreateByTwoSidesAndAngle(double sideA, double sideB, double angleC)
        {
            var triangle = new Triangle();
            triangle.A = sideA;
            triangle.B = sideB;
            triangle.C = CalcSideByTwoSidesAndAngle(sideA, sideB, angleC);
            // Простота чаще всего важнее оптимизации
            triangle.CalcAngles();
            return triangle;
        }

        public static Triangle CreateByTwoAngleAndSide(double angleA, double angleB, double sideC)
        {

            var triangle = new Triangle();
            var angleC = 180 - (angleA + angleB);
            triangle.A = Math.Sin(angleA) / Math.Sin(angleC) * sideC;
            triangle.B = Math.Sin(angleB) / Math.Sin(angleC) * sideC;
            triangle.C = sideC;
            // Простота чаще всего важнее оптимизации
            triangle.CalcAngles();
            return triangle;
        }


        public double CalculateArea()
        {
            return CalculateAreaByGeron(A, B, C);
        }

        private void CalcAngles()
        {
            AngleA = Math.Acos((B * B + C * C - A * A) / (2 * B * C));
            AngleB = Math.Acos((A * A + C * C - B * B) / (2 * A * C));
            AngleC = Math.Acos((B * B + A * A - C * C) / (2 * B * A));
        }

        private double CalculateAreaByGeron(double a, double b, double c)
        {
            var p = Perimetr / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        private static double CalcSideByTwoSidesAndAngle(double a, double b, double angleC)
        {
            return Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(angleC));
        }
    }
}
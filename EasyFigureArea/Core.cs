namespace EasyFigureArea;

public interface IShape
{
    double GetArea();
}

public class Circle : IShape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius must be greater than zero");
        _radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}

public class Triangle : IShape
{
    private readonly double _a, _b, _c;

    public Triangle(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            throw new ArgumentException("Triangle's sides must be greater than zero");
        
        if (!IsTriangleValid(a, b, c))
            throw new ArgumentException("Triangle does not exist");
        
        _a = a;
        _b = b;
        _c = c;
    }

    public double GetArea()
    {
        double s = (_a + _b + _c) / 2;
        return Math.Sqrt(s * (s - _a) * (s - _b) * (s - _c));
    }
    public bool IsRightAngled()
    {
        double a2 = _a * _a, b2 = _b * _b, c2 = _c * _c;
        return (a2 + b2 == c2) || (a2 + c2 == b2) || (b2 + c2 == a2);
    }
    
    private bool IsTriangleValid(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }
}

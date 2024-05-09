using EasyFigureArea;

namespace Unit_tests;

public class Tests {
    [SetUp]
    public void Setup() {
    }

    [Test]
    public void CircleAreaTest()
    {
        IShape circle = new Circle(10); //Вычисление площади фигуры без знания типа фигуры в compile-time
        Assert.That(circle.GetArea(), Is.EqualTo(314.15926535897933).Within(0.000001));
    }

    [Test]
    public void TriangleAreaTest()
    {
        IShape triangle = new Triangle(3, 4, 5); 
        Assert.That(triangle.GetArea(), Is.EqualTo(6).Within(0.000001));
    }
    
    [Test]
    public void CircleConstructor_NegativeRadius_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Circle(-5));
    }

    [Test]
    public void CircleConstructor_ZeroRadius_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Circle(0));
    }

    [Test]
    public void TriangleConstructor_NegativeSide_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(3, -4, 5));
    }

    [Test]
    public void TriangleConstructor_ZeroSide_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(0, 4, 5));
    }

    [Test]
    public void TriangleConstructor_InvalidSides_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 5));
    }

    [Test]
    public void RightAngledTriangleTest()
    {
        var triangle1 = new Triangle(3, 4, 5);
        Assert.That(triangle1.IsRightAngled(), Is.True);

        var triangle3 = new Triangle(5, 3, 6);
        Assert.That(triangle3.IsRightAngled(), Is.False);
    }
}
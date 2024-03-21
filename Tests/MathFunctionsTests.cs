using Program;

namespace Tests;

public class MathFunctionsTests
{
    
    [Fact]
    public void MathFunctions_ReturnSquare_ReturnsDouble()
    {
        double number = 3;

        double result = MathFunctions.ReturnSquare(number);

        Assert.Equal(9, result);
    }

    [Fact]
    public void MathFunctions_ConvertInchesToMM_ReturnsDouble()
    {
        double number = 3;

        double result = MathFunctions.ConvertInchesToMM(number);

        Assert.Equal(76.2, result);
    }
    
    [Fact]
    public void MathFunctions_ReturnSquareRoot_ReturnsDouble()
    {
        double number = 25;

        double result = MathFunctions.ReturnSquareRoot(number);

        Assert.Equal(5, result);
    }

    [Fact]
    public void MathFunctions_ReturnCube_ReturnsDouble()
    {
        double number = 2;

        double result = MathFunctions.ReturnCube(number);

        Assert.Equal(8, result);
    }
    
    [Fact]
    public void MathFunctions_ReturnAreaOfCircle_ReturnsDouble()
    {
        double number = 10;

        double result = MathFunctions.ReturnAreaOfCircle(number);

        Assert.Equal(314, result);
    }
}
using Program;

namespace Tests;

public class MathFunctionsTests
{
    
    [Fact]
    public void MathFunctions_ReturnSquare_ReturnFloat()
    {
        float number = 3;

        float result = MathFunctions.ReturnSquare(number);

        Assert.Equal(9, result);
    }

    [Fact]
    public void MathFunctions_ConvertInchesToMM_ReturnFloat()
    {
        float number = 3;

        float result = MathFunctions.ConvertInchesToMM(number);

        Assert.Equal(76.2F, result);
    }
    
    [Fact]
    public void MathFunctions_ReturnSquareRoot_ReturnString()
    {
        float number = -25;

        string result = MathFunctions.ReturnSquareRoot(number);

        Assert.Equal("5i", result);
    }

    [Fact]
    public void MathFunctions_ReturnCube_ReturnFloat()
    {
        float number = 2;

        float result = MathFunctions.ReturnCube(number);

        Assert.Equal(8, result);
    }
    
    [Fact]
    public void MathFunctions_ReturnAreaOfCircle_ReturnFloat()
    {
        float number = 10;

        float result = MathFunctions.ReturnAreaOfCircle(number);

        Assert.Equal(314, result);
    }

    [Fact]
    public void MathFunctions_SplitByTens_ReturnIntArray()
    {
        string number = "12345";
        int[] expected = new int[]{12,34,50};

        int[] result = MathFunctions.SplitByTens(number,true);

        Assert.Equal(expected,result);
    }

    [Fact]
    public void MathFunctions_CalculateRoot_ReturnString()
    {
        int[][] numberSets = new int[2][];
        numberSets[0] = new int[]{25};
        numberSets[1] = new int[]{12,50};

        string result = MathFunctions.CalculateRoot(numberSets,false);

        Assert.Equal("5", result);
    }
}
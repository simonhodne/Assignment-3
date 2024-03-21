namespace Program;

public static class MathFunctions
{
    const float ONE_INCH_IN_MM = 25.4F;
    public static float ReturnSquare(float number)
    {
        return number * number;
    }
    public static float ConvertInchesToMM(float number)
    {
        return number * ONE_INCH_IN_MM;
    }
    public static float ReturnSquareRoot(float number)
    {
        float output = 0.0F;
        return output;
    }
    public static float ReturnCube(float number)
    {
        float output = 0.0F;
        return output;
    }
    public static float ReturnAreaOfCircle(float radius)
    {
        float output = 0.0F;
        return output;
    }
    public static int[] SplitByTens(string number)
    {
        int digitAmount = number.Length;
        bool isOdd = false;
        if(digitAmount % 2 != 0)
        {
            isOdd = true;
            digitAmount++;
        }
        int[] output = new int[digitAmount/2];
        if(isOdd)
        {
            digitAmount--;
        }
        while(digitAmount > 0)
        {
            if(digitAmount == 1)
            {
                output[0] = int.Parse(number.Substring(0,1));
            }
            else
            {
                if(isOdd)
                {
                    output[(digitAmount-1)/2] = int.Parse(number.Substring(digitAmount-2,2));
                }
                else
                {
                    output[(digitAmount/2)-1] = int.Parse(number.Substring(digitAmount-2,2));
                }  
            }
            digitAmount += -2;
        }
        return output;
    }
}

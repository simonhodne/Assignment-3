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
    public static string ReturnSquareRoot(float number)
    {
        string output = "";
        bool isReal = true;
        if(number < 0)
        {
            isReal = false;
            number *= -1;
        }

        string numberAsString = number.ToString();
        string[] splitNumbers = new string[2];
        bool hasDecimals = false;
        if(numberAsString.Contains('.'))
        {
            splitNumbers = numberAsString.Split('.');
            hasDecimals = true;
        }
        
        if(hasDecimals)
        {
            int[] nonDecimals = SplitByTens(splitNumbers[0], false);
            int[] decimals = SplitByTens(splitNumbers[1], true);
            int[][] decimalSplitNumbers = new int[2][];
            decimalSplitNumbers[0] = nonDecimals;
            decimalSplitNumbers[1] = decimals;
            output = CalculateRoot(decimalSplitNumbers, hasDecimals);
        }
        else
        {
            int[] numberSplitByTens = SplitByTens(numberAsString, false);
            int[][] reformattedNumbers = new int[2][];
            reformattedNumbers[0] = numberSplitByTens;
            output = CalculateRoot(reformattedNumbers, false);
        }

        if(!isReal)
        {
            output += "i";
        }
        else
        {
            output = "+/-" + output;
        }

        return output;
    }
    public static float ReturnCube(float number)
    {
        return number*number*number;
    }
    public static float ReturnAreaOfCircle(float radius)
    {
        
        return 3.14F*radius*radius;
    }
    public static int[] SplitByTens(string number, bool isDecimal)
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

        if(isDecimal)
        {
            digitAmount = 0;
            while(digitAmount < number.Length)
            {
                if(digitAmount == number.Length-1)
                {
                    output[output.Length-1] = int.Parse(number.Substring(number.Length-1,1)+"0");
                }
                else
                {
                    output[digitAmount/2] = int.Parse(number.Substring(digitAmount,2));
                }
                digitAmount += 2;
            }
        }
        else
        {
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
        }
        return output;
    }
    public static string CalculateRoot(int[][] numberSets, bool hasDecimals)
    {
        string output = "";
        int remainder = 0;
        int dividend;
        int quotient = 0;

        foreach(int number in numberSets[0])
        {
            int divisor = 9;
            quotient *= 10;
            dividend = number + remainder*100;
            if(remainder == 0)
            {
                while(divisor*divisor > dividend)
                {
                    divisor--;
                }
                quotient = divisor;

            }
            else
            {
                while(divisor*(quotient+divisor) > dividend)
                {
                    divisor--;
                }
            }

            remainder = dividend-(divisor*divisor);
            output+= divisor.ToString();
            quotient+= divisor;

        }

        if(remainder != 0 || hasDecimals)
        {
            output+= ".";
        }

        if(hasDecimals)
        {
            foreach(int number in numberSets[1])
            {
                int divisor = 9;
                quotient *= 10;
                dividend = number + remainder*100;

                while(divisor*(quotient+divisor) > dividend)
                {
                    divisor--;
                }

                remainder = dividend-(divisor*divisor);
                output+= divisor.ToString();
                quotient+= divisor;
            }
        }
        int additionalCalcs = 0;
        while(remainder != 0 && additionalCalcs < 3)
        {
                int divisor = 9;
                quotient *= 10;
                dividend = remainder*100;

                while(divisor*(quotient+divisor) > dividend)
                {
                    divisor--;
                }
                if(divisor < 1)
                {
                    break;
                }
                remainder = dividend-(divisor*divisor);
                output+= divisor.ToString();
                quotient+= divisor;
                additionalCalcs++;
        }
        return output;
    }
}

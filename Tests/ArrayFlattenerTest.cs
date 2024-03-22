using Program;

namespace Tests;

public class ArrayFlattenerTest
{
    [Fact]
    public static void ArrayFlattener_FlattenArray_ReturnIntArray()
    {
        object[] arraytest = new object[]
        {435, 2028, new object[] { new object[]{3047, 4910, 8146, 7999, 1433, 7211, 1197, 6002}, 2821, 3508}};

        int[] result = ArrayFlattener.FlattenArray(arraytest);
        int[] expected = {435, 2028, 3047, 4910, 8146, 7999, 1433, 7211, 1197, 6002, 2821, 3508};


        Assert.Equal(expected,result);
    }
    
}

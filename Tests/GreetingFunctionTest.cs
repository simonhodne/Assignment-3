using Program;

namespace Tests;

public class GreetingFunctionTest
{
    [Fact]
    public void GreetingFunction_GreetPerson_ReturnString()
    {
        string name = "John Doe";

        string result = GreetingFunction.GreetPerson(name);

        Assert.Equal("Greetings, John Doe.", result);
    }
}

using Program;

namespace Tests;

public class GreetingFunctionTest
{
    public void GreetingFunction_GreetPerson_ReturnsString()
    {
        string name = "John Doe";

        string result = GreetingFunction.GreetPerson(name);

        Assert.Equal("Greetings, John Doe.", result);
    }
}

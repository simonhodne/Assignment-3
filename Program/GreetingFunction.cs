namespace Program;

public static class GreetingFunction
{
    const string DEFAULT_GREETING = "Greetings, ";
    public static string GreetPerson(string name)
    {
        return DEFAULT_GREETING+name+".";
    }
}

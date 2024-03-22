namespace Program;

public static class ArrayFlattener
{
    static List<int> intList = new List<int>();
    
    public static int[] FlattenArray(object[] array)
    {
        Dig(array);
        
        int[] output = new int[intList.Count];
        int index = 0;
        foreach(int number in intList)
        {
            output[index] = number;
            index++;
        }
        return output;
    }

    public static void Dig(object[] array)
    {
        foreach(object thing in array)
        {
            try
            {
                int number = (int)thing;
                intList.Add(number);
            }
            catch
            {
                Dig((object[])thing);
            }
        }
    }
}



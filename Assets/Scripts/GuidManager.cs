public class GuidManager
{
    private static int guidIndex = int.MinValue;

    public static int GetNextGuid()
    {
        guidIndex++;

        return guidIndex;
    }
}
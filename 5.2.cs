class TaskFiveSolutionTwo
{
    public static void Main()
    {
        string String = "vbf";
        Permutation(String);
    }

    static void Permutation(string String, string? temp = null)
    {
        if (string.IsNullOrEmpty(String)) Console.Write(temp + " "); //when all values have been removed from
                                                                   //temp that fork has beeen exhausted

        for (int i = 0; i < String.Length; i++) //Each recursive call makes
                                                //string length new branches ending in n! endpoints
        {            
            Permutation(String.Remove(i, 1), temp + String[i]); //Each one build apon temp but in a different order
        }
    }
}


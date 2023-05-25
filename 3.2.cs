class TaskThreeSolutionTwo
{
    static void Main()
    {
        List<int> list = new() { 19, 3, 2, 1, 7, 4, 7, 4, 10, 9, 10, 1, 3, 1 };

        list = list.Distinct().ToList(); //Removes any numbers that are repeated

        list.Sort();

        for (int i = 0; i < list.Count - 1; i++) Console.Write(list[i] + ", ");
        Console.Write(list[^1]);
    }
}
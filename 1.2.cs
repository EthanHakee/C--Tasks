class TaskOneSolutionTwo
{
    static void Main()
    {
        List<int> sequence = new() { 89, 42, 65, 18, 73, 15, 6, 89, 71, 17, 11, 51, 55, 91 };
        Averages(sequence);
    }

    static void Averages(List<int> sequence)
    {
        if (sequence.Count == 0)
        {
            Console.WriteLine("Add Items to the list");
            Environment.Exit(0);
        }

        sequence.Sort(); //Using quicksort

        Console.Write("\nCount: ");
        Console.WriteLine(sequence.Count); //outputs number of items in the list

        Console.Write("Mean: ");
        Console.WriteLine(Math.Round(sequence.Average(), 2)); //calculates mean average
                                                              //rounds to 2 decimal points
        Console.Write("Median: ");
        if ((sequence.Count % 2) == 0)
        {
            Console.WriteLine(Convert.ToDouble(sequence.ElementAt(sequence.Count / 2)
                + sequence.ElementAt((sequence.Count - 1) / 2)) / 2); //finds the mean of the two medians
        }
        else Console.WriteLine(sequence.ElementAt(sequence.Count / 2));

        Console.Write("Mode: ");
        Console.WriteLine(sequence.GroupBy(n => n) //Groups duplicate numbers
            .OrderByDescending(g => g.Count()) //Orders based on number of items in each group
            .Select(g => g.Key) //Outputs based on type of number in the group
            .First());//The number in the first group has the most dupliates
    }
}
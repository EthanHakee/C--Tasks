class TaskOneSolutionOne
{
    static void Main()
    {
        List<int> sequence = new() { 89, 42, 65, 18, 73, 15, 6, 89, 71, 17, 11, 51, 55, 91 };

        if (sequence.Count == 0) //Handling an empty list
        {
            Console.WriteLine("Add Items to the list");
            Environment.Exit(0);
        }
        int listLength = 0;
        foreach (int i in sequence) listLength++;

        RecBubbleSort(sequence, listLength - 1);
        Console.WriteLine($"Count: {listLength}");
        Console.WriteLine("Mean: " + Mean(sequence, listLength));
        Console.WriteLine($"Median: {Median(sequence, listLength)}");
        Console.WriteLine($"Mode: {Mode(sequence)}");
    }
    static string Mode(List<int> sequence)
    {
        Dictionary<int, int> frequency = new(); // Contains the number and how many times it appears in the list
        List<int> modes = new(); //store the final modes
        int timesRepeated = 0;
        string result = ""; //build a string using modes in the list

        foreach (var key in sequence)
        {
            if (frequency.ContainsKey(key)) frequency[key]++; //icrementing value if duplicates are found
            else frequency.Add(key, 1); //adding value if it doesnt already exist
        }

        foreach (var number in frequency)
        {
            if (number.Value > timesRepeated) // if there is a numbe repeated more then the current highest
            {
                timesRepeated = number.Value; //make it the value to check against
                modes.Clear(); //clear previous modes
                modes.Add(number.Key); //add the new mode
            }
            else if (number.Value == timesRepeated) modes.Add(number.Key); //adding for multimodel sequences
        }
        foreach (var value in modes) result += $"{value} "; // building a string with all modes
        if (sequence.Count == (modes.Count * timesRepeated)) return "None"; //if all values appear the same amount of times no mode
        return result;
    }

    static double Median(List<int> sequence, int listLength)
    {
        if (listLength % 2 == 0) // for even lists
        {
            return Math.Round((Convert.ToDouble(sequence[(listLength / 2) - 1]) // finding the mean of the two medians
                + Convert.ToDouble(sequence[listLength / 2])) / 2, 2);
        }
        else return sequence[listLength / 2];
    }

    static void RecBubbleSort(List<int> sequence, int listLength)
    {
        int temp;
        int count = 0;
        
        for (int i = 0; i < listLength - 1; i++)
        {
            if (sequence[i] > sequence[i + 1]) //pushes largest value to the end
            {
                temp = sequence[i]; //swapping values
                sequence[i] = sequence[i + 1];
                sequence[i + 1] = temp;
                count++; //logging if a swap has occurred
            }
        }
        if (count == 0) return; // when no swaps have been made it stops
        RecBubbleSort(sequence, listLength - 1); // ignors last value and starts again
    }

    static double Mean(List<int> sequence, int length)
    {
        double mean = 0;
        foreach (int num in sequence) mean += num;
        mean /= length;
        return Math.Round(mean, 2);
    }
}
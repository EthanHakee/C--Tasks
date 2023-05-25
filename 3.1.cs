class TaskThreeSolutionOne
{
    static void Main()
    {
        List<int> list = new() { 19, 3, 2, 1, 7, 4, 7, 4, 10, 9, 10, 1, 3, 1 };

        RemoveDuplicates(list);

        RecBubbleSort(list, Listcount(list)); //sort the list

        for (int i = 0; i < Listcount(list) - 1; i++) Console.Write($"{ list[i]}, ");
        Console.Write(list[^1]);
    }

    static void RemoveDuplicates(List<int> list)
    {
        int listLength = Listcount(list);
        List<int> tempList = new();

        foreach (int i in list) tempList.Add(i);
        list.Clear();

        for (int i = 0; i < listLength; i++)
        {
            bool duplicateFound = false;

            for (int j = 0; j < Listcount(list); j++) //Loop through no duplicate list
                if (list[j] == tempList[i]) duplicateFound = true; //check if duplicate is found

            if (!duplicateFound) list.Add(tempList[i]); //If it was not found in the no duplicate list add it
        }
    }

    static void RecBubbleSort(List<int> list, int listLength)
    {
        int temp;
        int count = 0;

        for (int i = 0; i < listLength - 1; i++)
        {
            if (list[i] > list[i + 1]) //Pushes largest value to the end
            {
                temp = list[i];
                list[i] = list[i + 1];
                list[i + 1] = temp;
                count++;
            }
        }
        if (count == 0) return; // when no swaps have been made it stops

        RecBubbleSort(list, listLength - 1);
    }
    static int Listcount(List<int> list)
    {
        int count = 0;
        foreach (int i in list) count++;
        return count;
    }
}
using System.Collections;

class TaskTwoSolutionOne
{
    static void Main()
    {
        SpecialQueue specialQueue = new();

        for (int i = 1; i < 11; i++)
        {
            specialQueue.Enqueue(i); //Adding numbers 1 to 10 to the queue
        }

        for (int i = 0; i < 10; i++) //Output and remove all items
        {
            Console.Write(specialQueue.Peek() + " ");
            specialQueue.Dequeue();
        }
    }
}

class SpecialQueue
{
    private readonly List<int> elements;
    private int size;

    public SpecialQueue()
    {
        elements = new List<int>();
        size = 0; //For exception handling when the list in empty
    }

    public void Enqueue(int value)
    {
        elements.Add(value); //Adds values to the tail of the queue
        size++;
    }

    public void Dequeue()
    {
        if (size == 0) throw new Exception("The Queue is empty");
        else elements.RemoveAt(0); //Removes the item at item at the head
        size--;
    }

    public int Peek()
    {
        if (size == 0) throw new Exception("The Queue is empty");
        else return elements[0]; //outputs value at address 0
    }

    public IEnumerator GetEnumerator() //Allows looping through elements of the queue
    {
        if (size != 0)
        {
            for (int i = size - 1; i >= 0; i--) //loop decrements in case values are being removed
                yield return elements[i]; 
        }
    }
}

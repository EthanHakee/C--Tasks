class TaskTwoSolutionTwo
{
    static void Main()
    {

        Queue<int> queue = new();

        for (int i = 1; i < 11; i++)
        {
            queue.Enqueue(i); //Adding numbers 1 to 10 to the queue
        }

        for (int i = 0; i < 10; i++)
        {
            Console.Write(queue.Peek() + " "); //output the item at the front of the queue
            queue.Dequeue(); //Remove the item at the front of the queue
        }
    }
}
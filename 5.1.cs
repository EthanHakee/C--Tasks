public class TaskFiveSolutionOne
{
    static readonly bool LEFT_TO_RIGHT = true;
    static readonly bool RIGHT_TO_LEFT = false;
    static void Main()
    {
        string sentence = "abc";
        int SequenceSize = sentence.Length;

        sentence = BubbleSort(sentence);      //Sorted so that all elements 
        Permutations(SequenceSize, sentence);//are bigger than the element they face
    }

    static string BubbleSort(string sentence)
    {
        List<char> characters = new();
        string result = "";

        foreach (char c in sentence) characters.Add(c);

        for (int i = 0; i < characters.Count - 1; i++)
        {
            for (int j = 0; j < characters.Count - i - 1; j++)
            {
                if (characters[j] > characters[j + 1])
                {
                    (characters[j + 1], characters[j]) =
                        (characters[j], characters[j + 1]);
                }
            }
        }

        foreach (char letter in characters) result += letter;

        return result;
    }

    static void Permutations(int SequenceSize, string sentence)
    {
        List<char> Letters = new();
        List<bool> Directions = new();

        for (int i = 0; i < SequenceSize; i++)
        {
            Letters.Add(sentence[i]);
            Console.Write(Letters[i]);
        }
        Console.Write(" ");

        for (int i = 0; i < SequenceSize; i++) //Initialising all elements as right to left
            Directions.Add(RIGHT_TO_LEFT);

        for (int i = 1; i < Factorial(SequenceSize); i++) // there are n! of any given permutaion
            OnePermutation(Letters, Directions, SequenceSize);
    }

    static void OnePermutation(List<char> Letters, List<bool> Directions, int SequenceSize)
    {
        char mobileChar = MobileChar(Letters, Directions, SequenceSize);
        int MobilePosition = 0;

        for (int i = 0; i < SequenceSize; i++)
            if (Letters[i] == mobileChar) MobilePosition = i; //Finding the direction the mobile char is facing

        if (Directions[MobilePosition] == RIGHT_TO_LEFT)
        {
            (Letters[MobilePosition - 1], Letters[MobilePosition]) =
                (Letters[MobilePosition], Letters[MobilePosition - 1]);  //Pushing mobile element across the list

            (Directions[MobilePosition - 1], Directions[MobilePosition]) = //Changing the address of the direction
                (Directions[MobilePosition], Directions[MobilePosition - 1]);
        }
        else if (Directions[MobilePosition] == LEFT_TO_RIGHT)
        {
            (Letters[MobilePosition + 1], Letters[MobilePosition]) =
                (Letters[MobilePosition], Letters[MobilePosition + 1]);

            (Directions[MobilePosition + 1], Directions[MobilePosition]) =
                (Directions[MobilePosition], Directions[MobilePosition + 1]);
        }

        for (int i = 0; i < SequenceSize - 1; i++)
        {
            if (Letters[i] > mobileChar) //Flipping the direction of all elements bigger then the mobile element
            {
                if (Directions[i] == LEFT_TO_RIGHT) Directions[i] = RIGHT_TO_LEFT;
                else if (Directions[i] == RIGHT_TO_LEFT) Directions[i] = LEFT_TO_RIGHT;
            }
        }

        for (int i = 0; i < SequenceSize; i++)
            Console.Write(Letters[i]); //Outputs a single permutaion

        Console.Write(" ");
    }

    static char MobileChar(List<char> Letters, List<bool> Direction, int SentenceSize)
    {
        char Currentmobile = '\0';

        for (int i = 0; i < SentenceSize; i++)
        {
            if (Direction[i] == RIGHT_TO_LEFT && i != 0)
            {
                if (Letters[i] > Letters[i - 1] && Letters[i] > Currentmobile) //becomes the current mobile
                    Currentmobile = Letters[i]; //it is bigger than the element it faces and CurrentMobile
            }

            if (Direction[i] == LEFT_TO_RIGHT && i != SentenceSize - 1)
            {
                if (Letters[i] > Letters[i + 1] && Letters[i] > Currentmobile)
                    Currentmobile = Letters[i];
            }
        }
        return Currentmobile; //Returns the largest element that is bigger then the one it is facing
    }

    static int Factorial(int SentenceLength)
    {
        int factorial = 1;
        for (int i = 1; i <= SentenceLength; i++) factorial *= i;
        return factorial;
    }
}
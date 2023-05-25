class TaskFourSolutionOne
{
    static void Main()
    {
        string sentence = "By Jove my quick study of lexicography won a prize";

        if (Pangram(sentence)) Console.WriteLine("It Is A Pangram");
        else Console.WriteLine("It Is Not A Pangram");
    }

    static bool Pangram(string sentence)
    {
        string theAlphabet = "abcdefghijklmnopqrstuvwxyz";
        int count = 26;

        sentence = sentence.ToLower();

        if (sentence.Length < count) return false;

        foreach (char letter in theAlphabet) //check off each letter of the alphabet
        {
            foreach (char character in sentence)
            {
                if (letter == character)
                {
                    --count;
                    break;  // if a match if found move onto the next
                }
            }
        }
        return count == 0;
    }
}

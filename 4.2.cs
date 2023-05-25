class TaskFourSolutionTwo
{
    static void Main()
    {
        string sentence = "quick study of lexicography won a prize";

        if (Pangram(sentence)) Console.WriteLine("It Is A Pangram");
        else Console.WriteLine("It Is Not A Pangram");
    }

    static bool Pangram(string sentence)
    {
        return sentence.ToLower() //lower case
            .Where(x => char.IsLetter(x)) // is a letter
            .GroupBy(x => x) // make a group of each letter type
            .Count() == 26; // 26 groups of letters
    }
}
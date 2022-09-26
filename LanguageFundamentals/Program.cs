//general naming conventions
    //variables, parameters, and fields are camelCase
    //everything else is PascalCase

// create a new loop that prints 1-100
void PrintNumbers(int start = 1, int inclusiveEnd = 100) 
{
    for (int i = start; i <= inclusiveEnd; i++)
    {
        bool isDivisibleBy3 = i % 3 == 0;
        bool isDivisibleBy5 = i % 5 == 0;
        bool isDivisibleBy3And5 = isDivisibleBy3 && isDivisibleBy5;
        bool isDivisibleBy3Or5 = isDivisibleBy5 || isDivisibleBy3;
        
        //if divisible by 3 & 5, nothing
        //if divisible by 3
        //if divisible by 5

        // ^ is the exclusive or operator, meaning ONLY one can be true
        // if(isDivisibleBy3 ^ isDivisibleBy5)
        // {
        //     Console.WriteLine(i);
        // }

        //if BOTH divisibleBy3 & divisibleBy5 aren't true, check if one is true & log it
        if (isDivisibleBy3Or5 && !isDivisibleBy3And5)
        {
            Console.WriteLine(i);
        }

        // Console.WriteLine($"is {i} divisible by 3? {isDivisibleBy3}");
        // Console.WriteLine($"is {i} divisible by 5? {isDivisibleBy5}");
    }
}

// PrintNumbers(80, 120);


/*
Create a list with the values: Todd, Tiffany, Charlie, Geneva, Sydney
Return a list that only includes names longer than 5 characters
*/
List<string> names1 = new List<string>()
{
    "Todd", "Tiffany", "Charlie", "Geneva", "Sydney"
};

List<string> FilterToLongNames(List<string> names, int minLength = 5)
{

    List<string> longNames = new List<string>();

    foreach (string name in names)
    {
        if (name.Length > minLength)
        {
            longNames.Add(name);
        }
    }

    return longNames;
}

List<string> namesMoreThan5Chars = FilterToLongNames(names1);
List<string> namesMoreThan6Chars = FilterToLongNames(names1, 6);

Console.WriteLine(String.Join(", ", namesMoreThan6Chars));
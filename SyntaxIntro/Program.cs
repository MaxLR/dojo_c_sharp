void FizzBuzz(int range = 100) {
    for (int i = 1; i <= range; i++ ) {
        bool divisibleByThree = i % 3 == 0;
        bool divisibleByFive = i % 5 == 0;
        if (divisibleByThree && !divisibleByFive)
        {
            Console.WriteLine("Fizz");
        }
        else if (divisibleByFive && !divisibleByThree)
        {
            Console.WriteLine("Buzz");
        }
        else if (divisibleByFive && divisibleByThree)
        {
            Console.WriteLine("FizzBuzz");
        }
        else {
            Console.WriteLine(i);
        }
    }
}

// FizzBuzz();
// FizzBuzz(12);



//Create List of flavors & modify / print out data
List<string> flavors = new List<string>() {
    "green bean",
    "chocolate chip cookie dough",
    "dulce de leche",
    "mango habanero",
    "lobster"
};
flavors.Add("ube");
flavors.Add("avocado");

Console.WriteLine(flavors.Count);

Console.WriteLine(flavors[2]);
flavors.RemoveAt(2);
Console.WriteLine(flavors.Count);

foreach(string flavor in flavors) {
    Console.WriteLine(flavor);
}



// Shuffle Numbers in a list
List<int> numbers = new List<int>() {
    19, 21, 33, 44, 5, 6, 7, 8, 9
};

List<int> shuffledNumbers = new List<int>();

Random rand = new Random();
while (numbers.Count > 0)
{
    int randIndex = rand.Next(0, numbers.Count);
    shuffledNumbers.Add(numbers[randIndex]);
    numbers.RemoveAt(randIndex);
}

foreach(int num in shuffledNumbers) {
    Console.WriteLine(num);
}

Dictionary<string, string> mike = new Dictionary<string, string>() {
    {"name", "mike"},
};
Dictionary<string, string> mike2 = new Dictionary<string, string>() {
    {"name", "mike"},
};

Console.WriteLine(mike == mike2);

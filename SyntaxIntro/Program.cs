void FizzBuzz(int range = 100) {
    for (int i = 1; i <= range; i++) {
        bool divisibleByThree = i % 3 == 0;
        bool divisibleByFive = i % 5 == 0;
        
        if (divisibleByFive && divisibleByThree) {
            Console.WriteLine("FizzBuzz");
        }
        else if (divisibleByThree && !divisibleByFive) {
            Console.WriteLine("Fizz");
        }
        else if (divisibleByFive) {
            Console.WriteLine("FizzBuzz");
        }
        else {
            Console.WriteLine(i);
        }
    }
}

FizzBuzz(0);

// int myNum = 15;
// string someString = "Hello";

List<string> flavors = new List<string>() {
    "cherry garcia",
    "mint chocolate chip",
    "chocolate",
    "chocolate chip",
    "lobster"
};

// flavors.Add("caramel");
flavors.RemoveAt(4);
flavors.Insert(2, "caramel");

// Console.WriteLine(flavors.Count);
// Console.WriteLine(flavors[1]);

// foreach (string flavor in flavors)
// {
//     Console.WriteLine(flavor);
// }

// //last element in the list
// Console.WriteLine(flavors[flavors.Count - 1]);

List<int> orderedNums = new List<int>() {
    1, 2, 3, 4, 5, 6, 7, 8, 9, 10
};

List<int> shuffledNums = new List<int>();

Console.WriteLine(orderedNums);

Random rand = new Random();

// Console.WriteLine(rand.Next(0, 15));

while (orderedNums.Count > 0)
{
    int randIdx = rand.Next(0, orderedNums.Count);
    // Console.WriteLine("Removing " + orderedNums[randIdx] + " from ordered nums");
    shuffledNums.Add(orderedNums[randIdx]);
    orderedNums.RemoveAt(randIdx);
}

// foreach (int num in shuffledNums)
// {
//     Console.WriteLine(num);
// }


Dictionary<string, string> someDictionary = new Dictionary<string, string>() {
    {"name", "joseph"},
    {"favorite_color", "purple"},
    {"23", "jonas"}
};

Console.WriteLine(someDictionary["name"]);

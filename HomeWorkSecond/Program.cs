/*
    First task
    Result: 27
    Max Number: 9
*/

GetSumAndMaxFromString("Test1234String980");

Console.WriteLine();

/* 
    Second task
    Result 9 without 4 spaces from start
*/

Console.WriteLine(GetMaxNumIndexFromTextWithSpaces("    string123945Test9"));

Console.WriteLine();

/* 
    Third task
    First, we need to create an array with 100 different int numbers which represents the pages of books, and after, return the max.
    This array is populated with random numbers
*/

int[] books = new int[100];
Random random = new Random();
books = books.Select(i => random.Next(1, 600)).ToArray();

int biggestBook = GetBookWithMaxPages(books);
Console.WriteLine($"Number of pages in the biggest book: {biggestBook}\n");


/*
    Fourth task
    We need to create an array which represents 40 different cars and write in console the indexes of the fastest car, or the first and
    the last car.
 */

int[] cars = new int[40];
cars = cars.Select(i => random.Next(1, 20) + 200).ToArray();
GetCarsWithMaxSpeed(cars);


//First task
void GetSumAndMaxFromString(string text)
{
    int digitsSum = 0;
    int maxNum = 0;

    foreach (char c in text)
    {
        if (Char.IsDigit(c))
        {
            int num = (int)Char.GetNumericValue(c);
            digitsSum += num;
            if (num > maxNum)
            {
                maxNum = num;
            }
        }
    }

    Console.WriteLine($"Sum of numbers from string: {digitsSum}");
    Console.WriteLine($"Max number: {maxNum}");
}

//Second Task
int GetMaxNumIndexFromTextWithSpaces(string text)
{
    int maxNumIndex = -1;
    int maxNum = 0;

    string textTrimmed = text.TrimStart();
    Console.WriteLine(textTrimmed);

    for (int i = 0; i < textTrimmed.Length; i++)
    {
        char c = textTrimmed[i];
        if (Char.IsDigit(c))
        {
            int currentNum = (int)Char.GetNumericValue(c);
            if (currentNum > maxNum)
            {
                maxNum = currentNum;
                maxNumIndex = i;
            }
        }
    }

    return maxNumIndex;
}

//Third task
int GetBookWithMaxPages(int[] books) => books.Max();

//Fourth task
void GetCarsWithMaxSpeed(int[] carsSpeed)
{
    int maxSpeed = carsSpeed.Max();
    int count = carsSpeed.Count(x => x == maxSpeed);

    int firstIndex = Array.IndexOf(carsSpeed, maxSpeed);
    if (count > 1)
    {
        int lastIndex = Array.LastIndexOf(carsSpeed, maxSpeed);
        Console.WriteLine($"The first fastest car has index: {firstIndex}");
        Console.WriteLine($"The last fastest car has index: {lastIndex}");
    }
    else
    {
        Console.WriteLine($"The fastest car has index: {firstIndex}");
    }
}
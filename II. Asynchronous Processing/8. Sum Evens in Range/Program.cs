int sum = 0;
string command = string.Empty;

while (true)
{

    command = Console.ReadLine();

    if (command == "show")
    {
        var result = SumEvenNumbersAsync(1, 1000, sum);
        Console.WriteLine(result);
        return;
    }
}
int SumEvenNumbersAsync(int start, int end, int sum)
{
    for (int i = start + 1; i <= end; i += 2)
    { sum += i; }

    return sum;
}
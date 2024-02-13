using System.Runtime.CompilerServices;

int start = int.Parse(Console.ReadLine());
int finish = int.Parse(Console.ReadLine());

Thread evens = new Thread(() => PrintEvenNumbers(start, finish));

evens.Start();
evens.Join();
Console.WriteLine("Thread finished work");

void PrintEvenNumbers(int start, int finish)
{
    for (int i = start; i <= finish; i++) 
    {
        if (i % 2 == 0) 
        {
            Console.WriteLine(i);
        }
    
    }
}
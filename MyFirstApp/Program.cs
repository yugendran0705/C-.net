static int Factorial(int n)
{
    if (n <= 1)
        return 1;
    return n * Factorial(n - 1);
}
Console.WriteLine("Enter a number to calculate its factorial:");
int number = int.Parse(Console.ReadLine());
Console.WriteLine($"Factorial of {number} is {Factorial(number)}");

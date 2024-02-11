
decimal? money = null;
while (!money.HasValue)
{
    Console.WriteLine("What amount would you like to break down? (dollars and cents in decimal form)");
    string? input = Console.ReadLine();
    if (decimal.TryParse(input, out var result))
    {
        money = result;
    }
    else
    {
        Console.WriteLine("Invalid input, press any key to retry.");
        Console.ReadKey();
    }
}

Run(money.Value);

static void Run(decimal money)
{
    var dollars = (int)Math.Floor(money);
    var cents = (int)(Math.Floor(money * 100) % 100);

    Console.WriteLine($"${money} can be distributed as:");
    foreach (var bill in Enum.GetValues<Dollars>().OrderDescending())
    {
        Console.WriteLine($"{bill}: {dollars / (int)bill}");

        dollars %= (int)bill;
    }

    foreach (var coin in Enum.GetValues<Coins>().OrderDescending())
    {
        Console.WriteLine($"{coin}: {cents / (int)coin}");
        cents %= (int)coin;
    }
}

public enum Dollars
{
    Hundreds = 100,
    Fifties = 50,
    Twenties = 20,
    Tens = 10,
    Fives = 5,
    Ones = 1,
}

public enum Coins
{
    Quarters = 25,
    Dimes = 10,
    Nickels = 5,
    Pennies = 1,
}

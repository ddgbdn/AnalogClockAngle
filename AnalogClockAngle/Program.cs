using Services;

Console.WriteLine("Analog clock angle calculator. \n");

var hours = 0;
var minutes = 0d;

while (true)
{
    while (true)
    {
        Console.Write("Input hours(int): ");

        try
        {
            hours = int.Parse(Console.ReadLine()!);
            break;
        }
        catch
        {
            Console.WriteLine("Wrong input.");
        }
    }

    while (true)
    {
        Console.Write("Input minutes(double): ");

        try
        {
            minutes = double.Parse(Console.ReadLine()!);
            break;
        }
        catch
        {
            Console.WriteLine("Wrong input.");
        }
    }

    try
    {
        Console.WriteLine($"Lesser angle between hour and minute arrow: {new Clock(hours, minutes).Angle}\n");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine(ex.Message + "\n");
    }

    Console.WriteLine("Try again? [y/n]\n");
    var toContinueKey = Console.ReadKey(true);

    if (toContinueKey.KeyChar == 'n')
        break;
}
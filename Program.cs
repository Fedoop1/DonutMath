using DonutMath;

var donut = new Donut();

var xDirection = 1;
var yDirection = 1;

var x = 0;
var y = 0;

foreach (var frame in donut)
{
    var lines = frame
        .Split('\n', StringSplitOptions.RemoveEmptyEntries)
        .Where(l => l.Trim() != string.Empty)
        .ToArray();

    var trimLeft = lines.Min(l => l.Length - l.TrimStart().Length);
    var trimRight = lines.Min(l => l.Length - l.TrimEnd().Length);

    lines = lines.Select(l => l[trimLeft..^(trimRight + 1)]).ToArray();

    var contentWidth = lines.Max(l => l.Length);
    var contentHeight = lines.Length;

    var maxWidth = Console.WindowWidth - contentWidth;
    var maxHeight = Console.WindowHeight - contentHeight - 1;

    Console.Clear();

    if (maxWidth < 0 || maxHeight < 0)
    {
        Console.WriteLine("Window is too small :(");
        continue;
    }

    x += xDirection;
    y += yDirection;

    if (x >= maxWidth)
    {
        x = maxWidth;
        xDirection = -xDirection;
        ChangeColor();
    }
    else if (x <= 0)
    {
        x = 0;
        xDirection = -xDirection;
        ChangeColor();
    }

    if (y >= maxHeight)
    {
        y = maxHeight;
        yDirection = -yDirection;
        ChangeColor();
    }
    else if (y <= 0)
    {
        y = 0;
        yDirection = -yDirection;
        ChangeColor();
    }

    Console.Write(new string('\n', y));
    foreach (var line in lines)
    {
        Console.Write(new string(' ', x));
        Console.Write(line);
        Console.Write('\n');
    }

    Thread.Sleep(25);
}

void ChangeColor() => Console.ForegroundColor = (ConsoleColor) Random.Shared.Next(1, 16);

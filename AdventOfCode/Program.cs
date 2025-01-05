using System.Diagnostics;
using System.Reflection;
using AdventOfCode.Framework;
using Autofac;

var container = BuildContainer();

var days = container.Resolve<IEnumerable<IDay>>();
var day = GetDay();
Console.WriteLine("Year " + day.Year + " Day " + day.Day);
var inputPath = $"Events/{day.Year}/InputFiles/{day.Day}.txt";
DoPart(1, () => day.Part1(inputPath));
DoPart(2, () => day.Part2(inputPath));

IContainer BuildContainer()
{
    var builder = new ContainerBuilder();
    builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
    return builder.Build();
}

IDay GetDay()
{
    if (args.Length == 0)
    {
        var maxDay = days.MaxBy(x => (x.Year, x.Day), Comparer<(int, int)>.Default);
        return maxDay ?? throw new InvalidOperationException();
    }

    return days.Single(x => x.Year == int.Parse(args[0]) && x.Day == int.Parse(args[1]));
}

void DoPart(int partNumber, Func<string> partFunc)
{
    var sw = new Stopwatch();
    sw.Start();

    var result = partFunc();
    
    sw.Stop();
    
    Console.WriteLine($"Part {partNumber}: {result}  ({sw.ElapsedMilliseconds}ms) ({sw.ElapsedTicks} ticks)");
}
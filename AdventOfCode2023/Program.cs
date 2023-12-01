using System.Reflection;
using AdventOfCode2023.Days;
using Autofac;

var container = BuildContainer();

var days = container.Resolve<IEnumerable<IDay>>();
var day = GetDay();
Console.WriteLine("Day " + day.Day);
string inputPath = $"InputFiles/{day.Day}.txt";
Console.WriteLine("Part 1: " + day.Part1(inputPath));
Console.WriteLine("Part 2: " + day.Part2(inputPath));

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
        return days.MaxBy(x => x.Day) ?? throw new InvalidOperationException();
    }

    return days.Single(x => x.Day == int.Parse(args[0]));
}
    
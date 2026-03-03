# Advent of Code - C# Solutions

## Stack

- .NET 9.0, C# latest, Autofac DI
- NUnit 4.5 (test framework), NUnit3TestAdapter, Microsoft.NET.Test.Sdk, coverlet.collector

## Build & Test

```bash
dotnet build AdventOfCode.sln
dotnet test AdventOfCodeTests/AdventOfCodeTests.csproj
dotnet test --filter "FullyQualifiedName~Day5Tests"   # run specific test class
dotnet run --project AdventOfCode 2024 15             # run specific day
```

## Architecture

- `IDay` interface: `Day`, `Year`, `Part1(string path)`, `Part2(string path)` — returns `string`
- `Framework/DayBase` abstract class reads file lines, delegates to `Part1(IEnumerable<string>)` / `Part2(IEnumerable<string>)`
- Each year has its own `DayBase` that sets `Year` (e.g., `Events/_2024/Days/DayBase.cs`)
- Autofac auto-discovers all `IDay` implementations via assembly scanning in `Program.cs`

## File Layout

| Item | Path |
|---|---|
| Solution class | `AdventOfCode/Events/{YEAR}/Days/Day{N}.cs` |
| Year DayBase | `AdventOfCode/Events/{YEAR}/Days/DayBase.cs` |
| Input files | `AdventOfCode/Events/{YEAR}/InputFiles/{N}.txt` |
| Test class | `AdventOfCodeTests/Events/{YEAR}/Days/Day{N}Tests.cs` |
| Test data | `AdventOfCodeTests/Events/{YEAR}/TestData/{N}.txt` |
| Common utils | `AdventOfCode/Common/` (Coordinate, Direction, Vector) |

## Conventions

- Namespaces: `AdventOfCode.Events._{YEAR}.Days` (underscore prefix for numeric year)
- Class names: `Day1`, `Day12` (no leading zeros)
- Test classes: `Day1Tests`, `Day12Tests` with `[TestFixture]` attribute
- Tests instantiate the day directly: `private readonly DayNN _systemUnderTest = new();`
- Test data files use letter suffixes for variants: `12a.txt`, `12b.txt`
- Input/test data files must be added to `.csproj` with `CopyToOutputDirectory: PreserveNewest`
- Both Part1 and Part2 return answers as `string`

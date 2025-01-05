using System.Diagnostics;

namespace AdventOfCode2023.Days;

public class Day15 : DayBase
{
    public override int Day => 15;

    protected override string Part1(IEnumerable<string> inputData)
    {
        return ParseSteps(inputData)
            .Sum(x => RunHashingAlgorithm(x.Summary))
            .ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        var facility = new Facility();
        var steps = ParseSteps(inputData);

        foreach (var step in steps) facility.PerformStep(step);

        return facility.TotalFocusingPower.ToString();
    }

    private static IEnumerable<Step> ParseSteps(IEnumerable<string> inputData)
    {
        return inputData
            .Single()
            .Split(",")
            .Select(summary => new Step(summary));
    }

    public static int RunHashingAlgorithm(string input)
    {
        var currentValue = 0;
        foreach (var asciiCode in input.ToCharArray().Select(Convert.ToInt32))
        {
            currentValue += asciiCode;
            currentValue *= 17;
            currentValue %= 256;
        }

        return currentValue;
    }

    private class Facility
    {
        private readonly IDictionary<int, List<Lens>> _boxes;

        public Facility()
        {
            _boxes = Enumerable.Range(0, 255)
                .ToDictionary(boxNumber => boxNumber, _ => new List<Lens>());
        }

        public int TotalFocusingPower
        {
            get
            {
                var totalFocusingPower = 0;
                for (var boxNumber = 0; boxNumber < _boxes.Count; boxNumber++)
                for (var lensNumber = 0; lensNumber < _boxes[boxNumber].Count; lensNumber++)
                    totalFocusingPower += (boxNumber + 1) * (lensNumber + 1) *
                                          _boxes[boxNumber][lensNumber].FocalLength;

                return totalFocusingPower;
            }
        }

        public void PerformStep(Step step)
        {
            var box = _boxes[RunHashingAlgorithm(step.Label)];
            if (step.Operation == Operation.Remove)
            {
                box.RemoveAll(x => x.Label == step.Label);
            }
            else
            {
                Debug.Assert(step.FocalLength != null, "step.FocalLength != null");
                var existingLens = box.SingleOrDefault(l => l.Label == step.Label);
                if (existingLens == null) 
                    box.Add(new Lens(step.Label, step.FocalLength.Value));
                else
                    existingLens.FocalLength = step.FocalLength.Value;
            }
        }
    }

    private class Lens(string label, int focalLength)
    {
        public string Label { get; } = label;
        public int FocalLength { get; set; } = focalLength;
    }

    private class Step
    {
        public Step(string summary)
        {
            Summary = summary;
            if (summary.EndsWith('-'))
            {
                Operation = Operation.Remove;
                Label = summary[..^1];
            }
            else
            {
                Operation = Operation.Upsert;
                Label = summary[..^2];
                FocalLength = int.Parse(summary.Substring(summary.Length-1,1));
            }
        }

        public string Summary { get; }
        public string Label { get; }
        public Operation Operation { get; }
        public int? FocalLength { get; }
    }

    private enum Operation
    {
        Remove,
        Upsert
    }
}
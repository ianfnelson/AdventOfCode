namespace AdventOfCode.Events._2022.Days;

public class Day02 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        return inputData
            .Select(x => Round.Parse(x,1))
            .Sum(x => x.Score)
            .ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        return inputData
            .Select(x => Round.Parse(x,2))
            .Sum(x => x.Score)
            .ToString();
    }

    public class Round
    {
        private Round(Element opponent, Element mine)
        {
            _opponent = opponent;
            _mine = mine;
            _outcome = DetermineOutcome();
        }

        private Round(Element opponent, Outcome outcome)
        {
            _opponent = opponent;
            _outcome = outcome;
            _mine = DetermineMine();
        }
        
        private readonly Element _opponent;
        private readonly Element _mine;
        private readonly Outcome _outcome;
        
        public int Score => ScoreOutcome + ScoreShape;

        private int ScoreShape
        {
            get
            {
                return _mine switch
                {
                    Element.Rock => 1,
                    Element.Paper => 2,
                    Element.Scissors => 3,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }

        private int ScoreOutcome
        {
            get
            {
                return _outcome switch
                {
                    Outcome.Loss => 0,
                    Outcome.Draw => 3,
                    Outcome.Win => 6,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }

        private Outcome DetermineOutcome()
        {
            return _mine switch
            {
                Element.Rock => _opponent switch
                {
                    Element.Rock => Outcome.Draw,
                    Element.Paper => Outcome.Loss,
                    Element.Scissors => Outcome.Win,
                    _ => throw new ArgumentOutOfRangeException()
                },
                Element.Paper => _opponent switch
                {
                    Element.Rock => Outcome.Win,
                    Element.Paper => Outcome.Draw,
                    Element.Scissors => Outcome.Loss,
                    _ => throw new ArgumentOutOfRangeException()
                },
                Element.Scissors => _opponent switch
                {
                    Element.Rock => Outcome.Loss,
                    Element.Paper => Outcome.Win,
                    Element.Scissors => Outcome.Draw,
                    _ => throw new ArgumentOutOfRangeException()
                },
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        private Element DetermineMine()
        {
            return _outcome switch
            {
                Outcome.Loss => _opponent switch
                {
                    Element.Rock => Element.Scissors,
                    Element.Paper => Element.Rock,
                    Element.Scissors => Element.Paper,
                    _ => throw new ArgumentOutOfRangeException()
                },
                Outcome.Draw => _opponent switch
                {
                    Element.Rock => Element.Rock,
                    Element.Paper => Element.Paper,
                    Element.Scissors => Element.Scissors,
                    _ => throw new ArgumentOutOfRangeException()
                },
                Outcome.Win => _opponent switch
                {
                    Element.Rock => Element.Paper,
                    Element.Paper => Element.Scissors,
                    Element.Scissors => Element.Rock,
                    _ => throw new ArgumentOutOfRangeException()
                },
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static Round Parse(string entry, int part)
        {
            return part switch
            {
                1 => new Round(ParseElement(entry[0]), ParseElement(entry[2])),
                2 => new Round(ParseElement(entry[0]), ParseOutcome(entry[2])),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static Element ParseElement(char letter)
        {
            return letter switch
            {
                'A' or 'X' => Element.Rock,
                'B' or 'Y' => Element.Paper,
                'C' or 'Z' => Element.Scissors,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static Outcome ParseOutcome(char letter)
        {
            return letter switch
            {
                'X' => Outcome.Loss,
                'Y' => Outcome.Draw,
                'Z' => Outcome.Win,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private enum Element
        {
            Rock,
            Paper,
            Scissors
        }

        private enum Outcome
        {
            Loss,
            Draw,
            Win
        }
    }

    public override int Day => 2;
}
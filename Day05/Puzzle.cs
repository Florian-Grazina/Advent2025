using Common;

namespace Day05
{
    public class Puzzle : DayPuzzle
    {
        private List<Range> _ranges = [];
        private readonly HashSet<long> _ids = [];

        public override long SolvePart1()
        {
            LoadInput();
            CreateBetterRanges();

            long result = 0;

            foreach (long id in _ids)
            {
                result += IsNotExpired(id) ? 1 : 0;
            }

            return result;
        }

        public override long SolvePart2()
        {
            LoadInput();
            CreateBetterRanges();

            long result = 0;

            foreach (Range range in _ranges)
            {
                result += range.End - range.Start + 1;
            }

            // high 833668845378374
            // low  312231561602461
            // low  309111495167944
            return result;
        }

        private bool IsNotExpired(long id)
        {
            foreach (Range range in _ranges)
            {
                if (range.Start <= id
                    && range.End >= id)
                    return true;
                continue;
            }
            return false;
        }

        private void LoadInput()
        {
            bool isIds = false;

            foreach (string line in _input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    isIds = true;
                    continue;
                }

                if (!isIds)
                {
                    string[] data = line.Split('-');
                    _ranges.Add(new(long.Parse(data[0]), long.Parse(data[1])));
                }
                else
                {
                    _ids.Add(long.Parse(line));
                }
            }
        }

        private void CreateBetterRanges()
        {
            while (true)
            {
                try
                {
                    _ranges = SquashCollection(_ranges);
                }
                catch
                {
                    break;
                }
            }
        }

        private List<Range> SquashCollection(List<Range> collection)
        {
            collection = [.. collection.OrderBy(r => r.Start)];
            List<Range> newCollection = [];

            bool deleteNext = false;
            bool hasChanges = false;

            for (int i = 0; i < collection.Count; i++)
            {
                if (deleteNext)
                {
                    deleteNext = false;
                    continue;
                }

                if (i == collection.Count - 1)
                {
                    newCollection.Add(collection[i]);
                    continue;
                }

                Range range1 = collection[i];
                Range range2 = collection[i + 1];

                if(range1.Start == range2.Start 
                    && range1.End > range2.End)
                {
                    (range1.End, range2.End) = (range2.End, range1.End);
                }

                if (range1.Start == range2.Start)
                {
                    hasChanges = true;
                    continue;
                }

                else if (range1.End < range2.Start)
                {
                    newCollection.Add(range1);
                }

                else if (range1.End >= range2.Start)
                {
                    long higher = range1.End > range2.End ? range1.End : range2.End;

                    newCollection.Add(new(range1.Start, higher));
                    hasChanges = true;
                    deleteNext = true;
                }

                else if (range1.End >= range2.End)
                {
                    newCollection.Add(range1);
                    hasChanges = true;
                    deleteNext = true;
                }

                else
                    throw new Exception("oopsi");
            }

            if (!hasChanges)
                throw new Exception("no changes");

            return newCollection;
        }
    }
}

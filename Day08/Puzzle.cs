using Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Day08
{
    public class Puzzle : DayPuzzle
    {
        private List<Box> _junctionBoxes = [];
        private readonly HashSet<HashSet<Box>> _groupOfBoxes = [];

        private readonly Dictionary<(Box, Box), float> _distanceDico = [];

        public override long SolvePart1()
        {
            LoadBoxes();
            CreateGroup(_distanceDico);

            long result = 1;

            IEnumerable<int> numberOfGroups = _groupOfBoxes
                .Select(group => group.Count)
                .Order();

            foreach (int count in numberOfGroups.TakeLast(3))
                result *= count;

            return result;

            // high 7783776000
            // low 2145
            // low 22032
        }

        private void CreateGroup(Dictionary<(Box, Box), float> dico)
        {
            int take = 1000;
            //take = 10;

            List<KeyValuePair<(Box, Box), float>> boxesToJoin = dico
                .OrderBy(kvp => kvp.Value)
                .Take(take + 0)
                .ToList();

            foreach (KeyValuePair<(Box, Box), float> kvp in boxesToJoin)
            {
                Box box1 = kvp.Key.Item1;
                Box box2 = kvp.Key.Item2;

                HashSet<Box>? subGroup = _groupOfBoxes.FirstOrDefault(sub => sub.Contains(box1) || sub.Contains(box2));

                if (subGroup != null)
                {
                    subGroup.Add(box1);
                    subGroup.Add(box2);
                }

                else
                {
                    HashSet<Box> newSub = [];
                    _groupOfBoxes.Add(newSub);
                    newSub.Add(box1);
                    newSub.Add(box2);
                }
            }

            // means we need to merge the circuit together
            List<IGrouping<int, Box>> boxesInDouble = GetBoxInDouble(_groupOfBoxes);
            while (boxesInDouble.Count != 0)
            {
                foreach (IGrouping<int, Box> group in boxesInDouble)
                {
                    // we look at all the collection with the same Id inside
                    List<HashSet<Box>> collectionToMerge = _groupOfBoxes.Where(g => g.Contains(group.First())).ToList();
                    HashSet<Box> newMergesCollection = [.. (collectionToMerge.SelectMany(g => g))];
                    _groupOfBoxes.Add(newMergesCollection);

                    foreach (HashSet<Box> collectionToRemove in collectionToMerge)
                        _groupOfBoxes.Remove(collectionToRemove);
                }
                boxesInDouble = GetBoxInDouble(_groupOfBoxes);
            }
        }

        private (Box, Box) GetLastLink(Dictionary<(Box, Box), float> dico)
        {
            List<KeyValuePair<(Box, Box), float>> boxesToJoin = dico
                .OrderBy(kvp => kvp.Value)
                .ToList();

            (Box, Box) last = new();
            int total = boxesToJoin.Count;
            int index = 0;

            return last;

            foreach (KeyValuePair<(Box, Box), float> kvp in boxesToJoin)
            {
                Console.WriteLine($"Processing {index++}/{total} ...");
                Box box1 = kvp.Key.Item1;
                Box box2 = kvp.Key.Item2;

                last = kvp.Key;

                HashSet<Box>? subGroup = _groupOfBoxes.FirstOrDefault(sub => sub.Contains(box1) || sub.Contains(box2));

                if (subGroup != null)
                {
                    subGroup.Add(box1);
                    subGroup.Add(box2);
                }

                else
                {
                    HashSet<Box> newSub = [];
                    _groupOfBoxes.Add(newSub);
                    newSub.Add(box1);
                    newSub.Add(box2);
                }

                // means we need to merge the circuit together
                var boxesInDouble = GetBoxInDouble(_groupOfBoxes);
                foreach (IGrouping<int, Box> group in boxesInDouble)
                {
                    // we look at all the collection with the same Id inside
                    IEnumerable<HashSet<Box>> collectionToMerge = _groupOfBoxes.Where(g => g.Contains(group.First()));

                    foreach (HashSet<Box> set in collectionToMerge.TakeLast(boxesInDouble.Count - 2))
                    {
                        foreach (Box box in set)
                        {
                            collectionToMerge.First().Add(box);
                        }
                        _groupOfBoxes.Remove(set);
                    }
                }

                if (_groupOfBoxes.First().Count == 1000)
                    break;
            }
            return last;
        }

        public override long SolvePart2()
        {
            LoadBoxes();
            var lastLink = GetLastLink(_distanceDico);

            long result = (long)lastLink.Item1.X * (long)lastLink.Item2.X;
            // low 73276500
            // low 2143597401
            // low 2143597401
            // low 2185817796
            return result;
        }

        private List<IGrouping<int, Box>> GetBoxInDouble(HashSet<HashSet<Box>> boxes)
        {
            var boxesInDouble = boxes
                    .SelectMany(group => group)
                    .GroupBy(g => g.Id)
                    .Where(g => g.Count() > 1)
                    .ToList();

            return boxesInDouble;
        }


        private void LoadBoxes()
        {
            foreach (string line in _input)
                _junctionBoxes.Add(new Box(line));

            foreach (var box in _junctionBoxes)
                box.CalculcateDistance(_junctionBoxes, _distanceDico);
        }
    }
}

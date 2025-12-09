using System.Numerics;

namespace Day08
{
    internal class Box
    {
        private static int _globalId = 0;

        public int Id { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Box(string line)
        {
            string[] data = line.Split(',');
            X = int.Parse(data[0]);
            Y = int.Parse(data[1]);
            Z = int.Parse(data[2]);

            Vector = new(X, Y, Z);

            Id = _globalId++;
        }

        public Vector3 Vector { get; }

        public void CalculcateDistance(List<Box> boxes, Dictionary<(Box, Box), float> dico)
        {
            foreach (Box box in boxes)
            {
                if (box == this)
                    continue;

                float distance = Vector3.Distance(Vector, box.Vector);

                if (IsHigher(box))
                    dico.TryAdd((box, this), distance);
                else
                    dico.TryAdd((this, box), distance);
            }
        }

        public override string ToString()
        {
            return $"{Id} - {X},{Y},{Z}";
        }

        public bool IsHigher(Box box)
        {
            if (X != box.X)
                return X > box.X;
            if (Y != box.Y)
                return Y > box.Y;
            if (Z != box.Z)
                return Z > box.Z;
            return true;
        }
    }
}


namespace Day07
{
    internal class Tile
    {
        private char _char;
        public char Char
        {
            get => _char;
            set
            {
                _char = value;
                if (value == '|')
                {
                    Number++;
                }
            }
        }
        public long Number { get; set; }

        public Tile(char c)
        {
            Char = c;
            Number = 0;
        }

        internal void FillLine(long nb)
        {
            _char = '|';
            Number += nb;
        }

        public override string ToString()
        {
            return Char.ToString();
        }
    }
}

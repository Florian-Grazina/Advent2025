namespace Day02
{
    internal class ProductRange
    {
        public long IdStart { get; private set; }
        public long IdEnd { get; private set; }

        public ProductRange(string productRange)
        {
            SetProductRange(productRange);
        }

        private void SetProductRange(string productRange)
        {
            var range = productRange.Split('-');
            IdStart = long.Parse(range[0]);
            IdEnd = long.Parse(range[1]);
        }
    }
}

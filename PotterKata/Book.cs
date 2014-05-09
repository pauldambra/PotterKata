namespace PotterKata
{
    public class Book
    {
        protected bool Equals(Book other)
        {
            return PositionInSet == other.PositionInSet;
        }

        public override bool Equals(object that)
        {
            if (ReferenceEquals(null, that)) return false;
            return that is Book && Equals((Book) that);
        }

        public override int GetHashCode()
        {
            return PositionInSet;
        }

        private Book(int positionInSet)
        {
            PositionInSet = positionInSet;
        }

        public int PositionInSet { get; private set; }

        public override string ToString()
        {
            return string.Format("Book at {0} in set", PositionInSet);
        }

        public static Book AtPositionInSet(int positionInSet)
        {
            return new Book(positionInSet);
        }
    }
}
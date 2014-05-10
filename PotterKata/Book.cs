namespace PotterKata
{
    public class Book
    {
        #region overriden methods
        private bool Equals(Book other)
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

        public override string ToString()
        {
            return string.Format("Book at {0} in set", PositionInSet);
        }
        #endregion

        public int PositionInSet { get; private set; }

        private Book(int positionInSet)
        {
            PositionInSet = positionInSet;
        }
        
        public static Book CreateAtPositionInSet(int positionInSet)
        {
            return new Book(positionInSet);
        }
    }
}
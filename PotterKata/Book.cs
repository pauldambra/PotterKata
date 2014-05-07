namespace PotterKata
{
    public class Book
    {
        public bool Equals(Book other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object that)
        {
            if (ReferenceEquals(null, that)) return false;
            return that is Book && Equals((Book) that);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public Book(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
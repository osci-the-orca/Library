namespace Library
{
    public enum MediaCategory
    {
        Novel, Magazine, AudioBook
    }

    class Book
    {
        MediaCategory _category;
        string _title;
        string _author;
        int _year;

        public MediaCategory Category { get { return _category; } set { _category = value; } }

        public string Title { get { return _title; } set { _title = value; } }

        public string Author { get { return _author; } set { _author = value; } }

        public int Year { get { return _year; } set { _year = value; } }

        public Book()
        {
        }

        public override string ToString()
        {
            return ($"{_category} ".PadRight(17) + $"{_title}".PadRight(25) + $"{_author}".PadRight(25) + $"{_year}");
        }
    }
}
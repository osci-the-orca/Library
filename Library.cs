using System;
using System.Collections.Generic;

namespace Library
{
    class Library
    {
        IDataManager _dataManager;
        private List<Book> books = new List<Book>();

        // public Library()
        // { }

        public Library(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            _dataManager.Save(books, "library.json");
            // UseJson.SaveChanges(books, "library.json");
        }

        public void LoadLibrary()
        {
            List<Book> library = _dataManager.Load("library.json");
            books.AddRange(library);
            // List<Book> booksInLibrary = UseJson.LoadDataFromDisk("Library.json");
        }

        public IList<Book> GetListOfBooks()
        {
            IList<Book> listOfBooks = books.AsReadOnly();
            return listOfBooks;
        }

        public List<Book> SearchBook(string searchString)
        {
            return books.FindAll(book => book.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    class Menu
    {
        public void ShowMenu()
        {

            DataManager dataManager = new();
            Library library = new Library(dataManager);
            library.LoadLibrary();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("--Library--\n");
                Console.WriteLine("[1] Add Book to library");
                Console.WriteLine("[2] Show all books in library");
                Console.WriteLine("[3] Search Library");
                Console.WriteLine("[ESC] Exit Program");

                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                while (true)
                {
                    if (keyPressed.Key == ConsoleKey.D1) // Add book to library
                    {
                        Console.Clear();
                        Book book = CreateBook();
                        library.AddBook(book);

                        Console.WriteLine($"You added: {book}");
                        Utilities.ReadString("\nPress any key to go back to menu\n", true);
                        break;
                    }
                    else if (keyPressed.Key == ConsoleKey.D2) // Show all books 
                    {
                        Console.Clear();
                        ShowHeader();

                        foreach (var item in library.GetListOfBooks().OrderBy(b => b.Author))
                        {
                            Console.WriteLine(item);
                        }

                        Utilities.ReadString("\nPress any key to go back to menu\n", true);
                        break;
                    }
                    else if (keyPressed.Key == ConsoleKey.D3) // Search
                    {
                        Console.Clear();
                        string output = Utilities.ReadString("Search:");

                        List<Book> searchResult = library.SearchBook(output);

                        if (searchResult.Count == 0)
                        {
                            Console.WriteLine("No books matches your search");
                        }
                        else
                        {
                            ShowHeader();

                            foreach (var item in searchResult.OrderBy(b => b.Author))
                            {
                                Console.WriteLine(item);
                            }
                        }

                        Utilities.ReadString("\nPress any key to go back to menu\n", true);
                        break;
                    }
                    else if (keyPressed.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void ShowHeader()
        {
            Console.WriteLine("{0,0} {1,13} {2, 25} {3, 22}\n", "Category", "Title", "Author", "Year");
        }

        private Book CreateBook()
        {
            Book newBook = new Book();

            Console.WriteLine("Category\n");
            Console.WriteLine("1. Novel");
            Console.WriteLine("2. Magazine");
            Console.WriteLine("3. Audio book\n");

            while (true)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                if (keyPressed.Key == ConsoleKey.D1)
                {
                    newBook.Category = MediaCategory.Novel;
                    break;
                }
                else if (keyPressed.Key == ConsoleKey.D2)
                {
                    newBook.Category = MediaCategory.Magazine;
                    break;
                }
                else if (keyPressed.Key == ConsoleKey.D3)
                {
                    newBook.Category = MediaCategory.AudioBook;
                    break;
                }
                else
                    Console.WriteLine("You need to pick category (1, 2 or 3)");
            }

            newBook.Title = Utilities.ReadString("Title:");
            newBook.Author = Utilities.ReadString("Author:");
            newBook.Year = Utilities.ReadIntYear("Year:");

            return newBook;
        }
    }
}
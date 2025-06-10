using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryCatalog
{
    class BookItem
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
    }

    class LibraryApp
    {
        static List<BookItem> bookCollection = new List<BookItem>
        {
            new BookItem { BookId = 1, BookTitle = "Mastering C# Essentials" },
            new BookItem { BookId = 2, BookTitle = "Java Programming Advanced" },
            new BookItem { BookId = 3, BookTitle = "C# Fundamentals for Beginners" },
            new BookItem { BookId = 4, BookTitle = "Data Structures and Algorithms" },
            new BookItem { BookId = 5, BookTitle = "The Art of Clean Code" }
        };

        static void Main()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("====== Library Catalog ======");
                Console.WriteLine("1. Find books with 'C#' in the title");
                Console.WriteLine("2. Get book with the longest title");
                Console.WriteLine("3. View books sorted alphabetically");
                Console.WriteLine("4. Quit");
                Console.Write("Select an option: ");

                var userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        DisplayBooksWithCSharp();
                        break;
                    case "2":
                        DisplayLongestBookTitle();
                        break;
                    case "3":
                        DisplaySortedBooks();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                if (keepRunning)
                {
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                }
            }
        }

        static void DisplayBooksWithCSharp()
        {
            var filteredBooks = bookCollection
                .Where(book => book.BookTitle.IndexOf("C#", StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            Console.WriteLine("\nBooks related to C#:");
            if (filteredBooks.Any())
                filteredBooks.ForEach(book => Console.WriteLine($"{book.BookId}: {book.BookTitle}"));
            else
                Console.WriteLine("No matches found.");
        }

        static void DisplayLongestBookTitle()
        {
            var longestBook = bookCollection
                .OrderByDescending(book => book.BookTitle.Length)
                .FirstOrDefault();

            Console.WriteLine("\nBook with the longest title:");
            if (longestBook != null)
                Console.WriteLine($"{longestBook.BookId}: {longestBook.BookTitle}");
            else
                Console.WriteLine("No books available.");
        }

        static void DisplaySortedBooks()
        {
            var orderedBooks = bookCollection.OrderBy(book => book.BookTitle).ToList();

            Console.WriteLine("\nBooks sorted alphabetically:");
            orderedBooks.ForEach(book => Console.WriteLine($"{book.BookId}: {book.BookTitle}"));
        }
    }
}
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace LibraryManagementSystem
{
    internal class Program
    {

        struct Book
        {
            public string name;
            public string author;
        }
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            string choice;
            string repeat;

            List<Book> bookList = new List<Book>();

            Book book = new Book();
            do
            {
                Console.WriteLine("Welcome to SmashedFrenzy16's Library, home to all the books you love and enjoy!");

                Console.WriteLine("Here is a list of options to choose: ");
                Console.WriteLine("A - Register a new book");
                Console.WriteLine("B - Explore our library of books");
                Console.WriteLine("C - Delete a book from the catalogue");

                Console.Write("Enter in your option (A, B or C): ");

                choice = Console.ReadLine();

                if (choice == "A" || choice == "a")
                {

                    string input;
                    bool regTrue = true;
                    string aInput;
                    string regChoice; 

                    while (regTrue == true)
                    {

                        Console.Write("Enter in the name of the book: ");

                        input = Console.ReadLine();

                        Console.Write("Enter in the author of the book: ");

                        aInput = Console.ReadLine();

                        book.name = input;
                        book.author = aInput;

                        bookList.Add(book);

                        Console.Write("Do you want to register a new book (y/n)?: ");

                        regChoice = Console.ReadLine();

                        if (regChoice == "N" || regChoice == "n")
                        {
                            regTrue = false;
                        }

                    }

                    string path = @"book_list.txt";

                    for (int i = 0; i < bookList.Count; i++)
                    {

                        string text = $"{i + 1}. ID: {i} Book: {bookList[i].name} Author: {bookList[i].author}" + Environment.NewLine;

                        File.AppendAllText(path, text);

                    }

                } else if (choice == "B" || choice == "b")
                {

                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                    for (int i = 0; i < bookList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. ID: {i} Book: {bookList[i].name} Author: {bookList[i].author}");
                    }

                } else if (choice == "C" || choice == "c")
                {

                    Console.ForegroundColor = ConsoleColor.DarkBlue;

                    int ID;
                    string stringID;
                    try
                    {
                        Console.Write("Enter in the ID of the book you want to remove: ");

                        stringID = Console.ReadLine();

                        ID = (int)Convert.ToInt64(stringID);

                        bookList.RemoveAt(ID);

                    } catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.Write("Do you want to do another action (y/n)?: ");

                repeat = Console.ReadLine();

            } while (repeat == "Y" || repeat == "y");
        }
    }
}

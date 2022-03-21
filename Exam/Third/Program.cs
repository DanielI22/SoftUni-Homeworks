using System;
using System.Collections.Generic;
using System.Linq;

namespace Third
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> bookList = Console.ReadLine().Split('&', StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();

            while(command !="Done")
            {
                string[] tokens = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                string mainCom = tokens[0];

                if(mainCom == "Add Book")
                {
                    string book = tokens[1];
                    if(!bookList.Contains(book)) {
                        bookList.Insert(0, book);
                    }
                }
                else if(mainCom == "Take Book")
                {
                    string book = tokens[1];
                    if (bookList.Contains(book))
                    {
                        bookList.Remove(book);
                    }
                }
                else if(mainCom == "Swap Books")
                {
                    string book1 = tokens[1];
                    string book2 = tokens[2];
                    
                    if(bookList.Contains(book1) && bookList.Contains(book2))
                    {
                        int indexOne = bookList.IndexOf(book1);
                        int indexTwo = bookList.IndexOf(book2);
                        bookList[indexOne] = book2;
                        bookList[indexTwo] = book1;

                    }

                }
                else if(mainCom == "Insert Book")
                {
                    string book = tokens[1];
                    if (!bookList.Contains(book))
                    {
                        bookList.Add(book);
                    }

                }
                else if(mainCom == "Check Book")
                {
                    int index = int.Parse(tokens[1]);
                    if(index >= 0 && index < bookList.Count)
                    Console.WriteLine(bookList[index]);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", bookList));
        }
    }
}

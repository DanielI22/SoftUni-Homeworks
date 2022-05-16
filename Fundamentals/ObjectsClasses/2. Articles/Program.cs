using System;
using System.Collections.Generic;

namespace _2._Articles
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }
        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }
        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string title = tokens[0];
            string content = tokens[1];
            string author = tokens[2];

            Article myArticle = new Article(title, content, author);
            int n = int.Parse(Console.ReadLine());

            for(int i =0; i<n; i++)
            {
                string[] commands = Console.ReadLine().Split(": ");
                if(commands[0] == "Edit")
                {
                    myArticle.Edit(commands[1]);
                }
                else if(commands[0] == "ChangeAuthor")
                {
                    myArticle.ChangeAuthor(commands[1]);
                }
                else if(commands[0] == "Rename")
                {
                    myArticle.Rename(commands[1]);
                }
                
            }

            Console.WriteLine(myArticle.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Articles_2._0
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
            int n = int.Parse(Console.ReadLine());
            List<Article> articlesList = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string title = tokens[0];
                string content = tokens[1];
                string author = tokens[2];

                Article myArticle = new Article(title, content, author);
                articlesList.Add(myArticle);
            }
            string sortby = Console.ReadLine();
            List<Article> orderList = new List<Article>();
            if (sortby == "title")
            {
                orderList = articlesList.OrderBy(article => article.Title).ToList();
            }
            else if(sortby == "content")
            {
                orderList = articlesList.OrderBy(article => article.Content).ToList();
            }
            else if (sortby == "author")
            {
                orderList = articlesList.OrderBy(article => article.Author).ToList();
            }
            Console.WriteLine(String.Join("\n", orderList));
        }
    }
}

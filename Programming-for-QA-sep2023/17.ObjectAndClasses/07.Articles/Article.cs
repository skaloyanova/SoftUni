using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace _07.Articles
{
    internal class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public void Edit (string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor (string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename (string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}

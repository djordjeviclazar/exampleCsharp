using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortObjects
{
    public class Post: IComparable
    {
        private int id;
        private string title;
        private string author;
        private string content;
        private DateTime date;

        public string Title { get { return title; } set { title = value; } }
        public string Author { get { return author; } set { author = value; } }
        public string Content { get { return content; } set { content = value; } }
        public DateTime Date { get { return date; } set { date = value; } }

        public Post(int id, string title, string author, string content, DateTime dateTime)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.content = content;
            this.date = dateTime;
        }

        public int CompareTo(object obj)
        {
            if(obj is Post post)
            {
                return this.Date.CompareTo(post.Date);
            }

            return 1;
        }

        public bool Identify(int ID)
        {
            return this.id == ID;
        }

        override public string ToString()
        {
            return "ID = " + id + "; Title: " + title + "; Author: " + author + "; Date: " + date + "\r\n";
        }
    }

    class Program
    {
        static void findPost(Post[] posts, int id , out string title, out string author, out DateTime date)
        {

            foreach(var post in posts)
            {
                if(post.Identify(id))
                {
                    title = post.Title;
                    author = post.Author;
                    date = post.Date;
                    return;
                }
            }

            title = null;
            author = null;
            date = new DateTime();
        }


        static void sortPosts(ref Post[] posts, bool ascending)
        {
            // pravljenje heap-a
            for (int i = (posts.Length - 1) / 2; i >= 0; i--)
            {
                DownHeap(ref posts, i, posts.Length - 1, ascending);
            }

            for (int i = (posts.Length - 1); i > 0; i--)
            {
                // brisanje korena:
                Post p = posts[i];
                posts[i] = posts[0];
                posts[0] = p;
                DownHeap(ref posts, 0, i - 1, ascending);
            }
        }

        static void DownHeap(ref Post[] heap, int ind, int lastElement, bool maxHeap)
        {
            while (ind < lastElement)
            {
                int k = (ind + 1) * 2;
                if (k - 1 > lastElement) { return; }
                if (k - 1 == lastElement)
                {
                    int comp = heap[ind].CompareTo(heap[k - 1]);
                    if ((comp < 0 && maxHeap) || (comp > 0 && !maxHeap))
                    {
                        Post pom = heap[ind];
                        heap[ind] = heap[k - 1];
                        heap[k - 1] = pom;
                    }
                    return;
                }

                int c1 = heap[ind].CompareTo(heap[k - 1]);
                int c2 = heap[ind].CompareTo(heap[k]);
                if ((c1 > 0 && c2 > 0 && maxHeap) || (c1 < 0 && c2 < 0 && !maxHeap))
                {
                    return;
                }

                Post p = heap[ind];
                int c3 = heap[k].CompareTo(heap[k - 1]);
                if ((maxHeap && c3 > 0) || (!maxHeap && c3 < 0))
                {
                    heap[ind] = heap[k];
                    heap[k] = p;
                    ind = k;
                }
                else
                {
                    heap[ind] = heap[k - 1];
                    heap[k - 1] = p;
                    ind = k - 1;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Generated Posts:");
            Random random = new Random();
            Post[] posts = new Post[10];
            for(int i = 0; i < 10; i++)
            {
                posts[i] = new Post(i,
                    "Title" + (i),
                    "Author" + (i),
                    "Content",
                    DateTime.Now.AddDays((random.NextDouble() > 0.5 ? 1 : -1) * random.Next(10)));

                Console.WriteLine(posts[i]);
            }

            Console.WriteLine("Sorted by date:");
            sortPosts(ref posts, true);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(posts[i]);
            }

            
            int idToFind = random.Next(posts.Length);
            Console.WriteLine("Post with id: " + idToFind);
            findPost(posts, idToFind, out string titleRes, out string authorRes, out DateTime dateRes);
            Console.WriteLine("Title: " + titleRes + "; Author: " + authorRes + "; Date:" + dateRes);

            Console.ReadLine();
        }
    }
}

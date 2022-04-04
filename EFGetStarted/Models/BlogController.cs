using System;
using System.Collections.Generic;
using System.Linq;

namespace EFGetStarted.Models
{
    public class BlogController
    {
        public static void ListPosts(int blogId)
        {
            using (var db = new DataContext())
            {
                var blog = db.Blogs.FirstOrDefault(x => x.BlogId == blogId);

                Console.WriteLine($"Posts for Blog {blog.Name}");
                var posts = db.Posts.Where(x => x.BlogId == blogId);
                foreach (var post in posts)
                {
                   Console.WriteLine($"\tPost {post.PostId} {post.Title}");
                }
            }
        }

        public static void AddPost(int blogId)
        {
            Console.WriteLine("Enter your Post title");
            var postTitle = Console.ReadLine();
            
            Console.WriteLine("Enter your Post content");
            var postContent = Console.ReadLine();
        
            var post = new Post();
            post.Title = postTitle;
            post.Content = postContent;
            post.BlogId = blogId;
        
            using (var db = new DataContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }

        public static void ListBlogs()
        {
            using (var db = new DataContext()) 
            {
                Console.WriteLine("Here is the list of blogs");
                foreach (var b in db.Blogs) {
                    Console.WriteLine($"Blog: {b.BlogId}: {b.Name}");
                }
            }
        }

        public static void AddBlog()
        {
            Console.WriteLine("Enter your Blog name");
            var blogName = Console.ReadLine();
        
            // Create new Blog
            var blog = new Blog();
            blog.Name = blogName;
                    
            // Save blog object to database
            using (var db = new DataContext()) 
            {
                db.Add(blog);
                db.SaveChanges();
            }
        }
        
    }
}
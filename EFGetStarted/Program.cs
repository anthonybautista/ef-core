using System;
using EFGetStarted.Models;


namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            bool more = true;

            while (more)
            {
                int entry = 0;
                int blog = 0;
                PrintMenu();
                entry = Convert.ToInt32(Console.ReadLine());
                
                switch (entry)
                {
                    case 1:
                        BlogController.ListBlogs();
                        break;
                    case 2:
                        BlogController.AddBlog();
                        break;
                    case 3:
                        blog = SelectBlog();
                        BlogController.ListPosts(blog);
                        break;
                    case 4:
                        blog = SelectBlog();
                        BlogController.AddPost(blog);
                        break;
                    case 5:
                        more = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Entry!");
                        break;
                }
            }
        }
        
        static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Blog Interface\n" +
                              "1. Display Blogs\n" +
                              "2. Add New Blog\n" +
                              "3. Display Posts\n" +
                              "4. Add New Post\n" +
                              "5. Exit\n");
            Console.Write("Select an option: ");
        }

        static int SelectBlog()
        {
            Console.WriteLine();
            BlogController.ListBlogs();
            Console.Write("Enter Blog ID: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
    
    
}
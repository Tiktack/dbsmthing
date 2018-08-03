using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp2
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Param> Params { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDb;Trusted_Connection=True;");
        }
    }

    public class Book
    {
        [Key]
        public int id { get; set; }

        public string url { get; set; }

        public double price { get; set; }

        public double oldprice { get; set; }

        public string currencyId { get; set; }

        public int categoryId { get; set; }

        public ICollection<Picture> picture { get; set; } = new List<Picture>();

        public bool store { get; set; }

        public bool pickup { get; set; }

        public bool delivery { get; set; }

        public uint local_delivery_cost { get; set; }

        public string author { get; set; }

        public string name { get; set; }

        public string publisher { get; set; }

        public string series { get; set; }

        public string year { get; set; }

        public string iSBN { get; set; }

        public string language { get; set; }

        public string binding { get; set; }

        public string page_extent { get; set; }

        public string description { get; set; }

        public string sales_notes { get; set; }

        public bool manufacturer_warranty { get; set; }

        public ulong barcode { get; set; }

        public decimal weight { get; set; }

        public string dimensions { get; set; }

        public bool available { get; set; }

        public string type { get; set; }

        public int group_id { get; set; }

        public ICollection<Param> _params { get; set; }
    }

    public class Param
    {
        public int Id { get; set; }

        public string paramName { get; set; }

        public string paramUnit { get; set; }

        public string paramValue { get; set; }
    }

    public class Picture
    {
        public int Id { get; set; }

        public string pictureUrl { get; set; }
    }
    public class Author
    {
        public int Id { get; set; }

        public string name { get; set; }
    }
    public class Language
    {
        public int Id { get; set; }

        public string name { get; set; }
    }
    public class Sales_notes
    {
        public int Id { get; set; }

        public string name { get; set; }
    }
    public class Publisher
    {
        public int Id { get; set; }

        public string name { get; set; }
    }
    public class Series
    {
        public int Id { get; set; }

        public string name { get; set; }
    }
}

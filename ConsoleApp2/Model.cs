using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleApp2
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Param> Params { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Sales_note> Sales_Notes { get; set; }
        public DbSet<Series> Series { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDb;Trusted_Connection=True;");
        }
    }

    public class Book
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string url { get; set; }

        public double price { get; set; }

        public double oldprice { get; set; }
        [MaxLength(10)]
        public string currencyId { get; set; }

        public int categoryId { get; set; }
        
        public ICollection<Picture> picture { get; set; } = new List<Picture>();

        public bool store { get; set; }

        public bool pickup { get; set; }

        public bool delivery { get; set; }

        public uint local_delivery_cost { get; set; }

        public Author Author { get; set; }

        public string name { get; set; }

        public Publisher publisher { get; set; }

        public Series series { get; set; }

        [MaxLength(10)]
        public string year { get; set; }
        [MaxLength(200)]
        public string iSBN { get; set; }

        public Language language { get; set; }

        [MaxLength(20)]
        public string binding { get; set; }
        [MaxLength(100)]
        public string page_extent { get; set; }

        public string description { get; set; }

        public Sales_note sales_notes { get; set; }

        public bool manufacturer_warranty { get; set; }

        public ulong barcode { get; set; }

        public decimal weight { get; set; }
        [MaxLength(40)]
        public string dimensions { get; set; }

        public bool available { get; set; }
        [MaxLength(10)]
        public string type { get; set; }

        public int group_id { get; set; }

        public ICollection<Param> _params { get; set; }
    }

    public class Param
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string paramName { get; set; }
         [MaxLength(10)]
        public string paramUnit { get; set; }
        public string paramValue { get; set; }
    }

    public class Picture
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string pictureUrl { get; set; }
    }
    public class Author : IDictionaries
    {
        public int Id { get; set; }
         [MaxLength(500)]
        public string name { get; set; }
        public List<Book> Books { get; set; }
    }
    public class Language : IDictionaries
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string name { get; set; }
        public List<Book> Books { get; set; }
    }
    public class Sales_note : IDictionaries
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string name { get; set; }
        public List<Book> Books { get; set; }
    }
    public class Publisher : IDictionaries
    {
        public int Id { get; set; }
       [MaxLength(200)]
        public string name { get; set; }
        public List<Book> Books { get; set; }
    }
    public class Series : IDictionaries
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string name { get; set; }
        public List<Book> Books { get; set; }

    }
    public interface IDictionaries
    {
        int Id { get; set; }
        string name { get; set; }
    }
}

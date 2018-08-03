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
        public int idField { get; set; }

        public string urlField { get; set; }

        public double priceField { get; set; }

        public double oldpriceField { get; set; }

        public string currencyIdField { get; set; }

        public int categoryIdField { get; set; }

        public ICollection<Picture> pictureField { get; set; } = new List<Picture>();

        public bool storeField { get; set; }

        public bool pickupField { get; set; }

        public bool deliveryField { get; set; }

        public uint local_delivery_costField { get; set; }

        public string authorField { get; set; }

        public string nameField { get; set; }

        public string publisherField { get; set; }

        public string seriesField { get; set; }

        public string yearField { get; set; }

        public string iSBNField { get; set; }

        public string languageField { get; set; }

        public string bindingField { get; set; }

        public string page_extentField { get; set; }

        public string descriptionField { get; set; }

        public string sales_notesField { get; set; }

        public bool manufacturer_warrantyField { get; set; }

        public ulong barcodeField { get; set; }

        public decimal weightField { get; set; }

        public string dimensionsField { get; set; }

        public bool availableField { get; set; }

        public string typeField { get; set; }

        public int group_idField { get; set; }

        public ICollection<Param> paramsField { get; set; }
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
}

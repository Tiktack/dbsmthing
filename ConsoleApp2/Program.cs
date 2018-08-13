using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            using (BookContext context = new BookContext())
            {
                //get all books
                var getbooks = Logic.getBooks();

                context.AddRange(Logic.GetAuthors(getbooks));
                context.AddRange(Logic.GetLanguages(getbooks));
                context.AddRange(Logic.GetSales_note(getbooks));
                context.AddRange(Logic.GetPublishers(getbooks));
                context.AddRange(Logic.GetSeries(getbooks));
                //save dictionaries to db
                context.SaveChanges();
                //create books for context
                var converted = Logic.ConvertOffersToBooks(getbooks, context);
                getbooks = null;
                context.AddRange(converted);
                //save books to db
                context.SaveChanges();
            }
            stopWatch.Stop();
            Debug.WriteLine(stopWatch.ElapsedMilliseconds);
        }
    }

}

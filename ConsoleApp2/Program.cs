using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public void checkLength()
        {
            var getbooks = Logic.getBooks();
            var maxAuthor = getbooks.offer.Max(x => x.author?.Length);
            var url = getbooks.offer.Max(x => x.url?.Length);
            var currencyId = getbooks.offer.Max(x => x.currencyId?.Length);
            var year = getbooks.offer.Max(x => x.year?.Length);
            var iSBN = getbooks.offer.Max(x => x.ISBN?.Length);
            var binding = getbooks.offer.Max(x => x.binding?.Length);
            var page_extent = getbooks.offer.Max(x => x.page_extent?.Length);
            var description = getbooks.offer.Max(x => x.description?.Length);
            var dimensions = getbooks.offer.Max(x => x.dimensions?.Length);
            var type = getbooks.offer.Max(x => x.type?.Length);
            var paramName = getbooks.offer.Max(x => x.param.Max(t => t.name?.Length));
            var paramUnit = getbooks.offer.Max(x => x.param.Max(t => t.unit?.Length));
            var paramValue = getbooks.offer.Max(x => x.param.Max(t => t.Value?.Length));
            var pictureUrl = getbooks.offer.Max(x => x.picture.Max(t => t?.Length));
            var Language = getbooks.offer.Max(x => x.language?.Length);
            var Sales_note = getbooks.offer.Max(x => x.sales_notes?.Length);
            var Publisher = getbooks.offer.Max(x => x.publisher?.Length);
            var series = getbooks.offer.Max(x => x.series?.Length);
        }
    }

}

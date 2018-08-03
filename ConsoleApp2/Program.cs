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
            
            var getbooks = Logic.getBooks();
            var converted = Logic.convertOffersToBooks(getbooks);
            getbooks = null;
            using (BookContext context = new BookContext())
            {
                foreach (var item in converted)
                {

                    context.Add(item);
                }
                context.SaveChanges();
            }
            stopWatch.Stop();
            Debug.WriteLine(stopWatch.ElapsedMilliseconds); 
        }
    }

}

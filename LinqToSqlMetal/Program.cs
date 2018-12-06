using System;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Xml.Linq;
using System.Collections.Generic;

namespace LinqToSqlMetal
{
    class Program
    {

        /// <summary>
        /// 1) SQLMetal /Server:(localdb)\MSSQLLocalDB /Database:BookLibrary /Namespace:LinqToSqlMetal /Code:BookLibrary.CS /Map:BookLibrary.XML /Pluralize /Functions /Sprocs /Views
        ///     this command generate sqlmetal files to work with database it has all required syntaxes and create according to it
        ///     for more :  http://msdn2.microsoft.com/en-us/library/bb386987.aspx.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=BookLibrary;Integrated Security=True";
            //Creating xml mapping
            XmlMappingSource mappingSource = XmlMappingSource.FromUrl(@"C:\Users\Sumitkiran.Gaurav\source\repos\LinqToSqlMetal\LinqToSqlMetal\BookLibrary.XML");

            // creating datacontext
            BookLibrary bookLibraryContext = new BookLibrary(connectionString, mappingSource);

            IEnumerable<Bookdata> result = from book in bookLibraryContext.Bookdatas
                                           where book.Title.Contains("India")
                                         select book;

            foreach(Bookdata book in result)
            {
                Console.WriteLine(book);
            }

        }
    }
}

using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.IO;

namespace SortingVisualizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Book book = new Book();
            //ISerializers<Book> xmlSerializer = new XMLSerializer<Book>();
            //xmlSerializer.Serialize(book, "C:\\SerializedObjects", false);

            ISerializers<Book> txtSerializer = new JSONSerializer<Book>();
            Book book = new Book();
            
                txtSerializer.Serialize(book.name, "‪C:\\Users\\Viggo\\Desktop\\TESTING.txt", false);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Start());


        }
    }
}

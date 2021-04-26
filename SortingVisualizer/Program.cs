using SortingVisualizer.Draw;
using System;
using System.Windows.Forms;


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
            //ISerializers<Book> txtSerializer = new JSONSerializer<Book>();
            //Book book = new Book();
            //txtSerializer.Serialize(book.name, "‪C:\\Users\\Viggo\\Desktop\\TESTING.txt", false);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Start());


        }
    }
}

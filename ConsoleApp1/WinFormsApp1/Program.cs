using WinFormsApp1.interface_test;
using WinFormsApp1.delegate_test;
using WinFormsApp1.Indexer;
using WinFormsApp1.thread_test;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Application.Run(new Form1());
            // Application.Run(new Form2());
            // Application.Run(new Form3());
            //Application.Run(new Form4());
            // Application.Run(new Form5());
            // Application.Run(new Mouse_event_form());
            // Application.Run(new Form6());
            //Application.Run(new Form7());
            //Application.Run(new Form8());
            //Application.Run(new Form9());
            //Application.Run(new Form10());
            //Application.Run(new Randoms());
            //Application.Run(new DateTimes());
            //Application.Run(new Strings());
            //Application.Run(new StringBuilders());
            //Application.Run(new bubble_sort());
            //Application.Run(new arrays());
            //Application.Run(new enum_flag());
            //Application.Run(new array_sort());
            //Application.Run(new form_int1());
            //Application.Run(new Form_explicit_or_without());
            //Application.Run(new form_delegrate1());
            //Application.Run(new Multicast_delegate());
            //Application.Run(new Indexer1());
            //Application.Run(new MultiIndexer());
            //Application.Run(new thread1());
            //Application.Run(new thread2());
            Application.Run(new thread_life());
        }
    }
}
using System;
using System.Net;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using Challenges.cnTableAdapters;

namespace Challenges
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            LookUp();
            /*cn test = new cn();
            test.Manga.AddMangaRow(2, "test", "test", "test");
            test.Manga.AcceptChanges();
            test.Manga.FindById(0);
            Console.WriteLine("Here");
            var t = test.Manga.FindById(0);
            Console.WriteLine(t.ToString());
            Console.WriteLine("Here");*/
        }

        static void Hello()
        {
            Console.WriteLine("Hello World!");
        }

        static void Test()
        {
            int test = 2;
            int test2 = 2;
            test = test + test2;
            return;
        }
        private static void Testing()
        {
            cn test = new cn();
            test.Manga.AddMangaRow(2, "test", "test", "test");
            test.Manga.FindById(0);
            Console.WriteLine(test.Manga.FindById(0));
        }
        public static void LookUp()
        {
            WebLookUp("https://manganelo.com/manga/cb923065", "3"); //Crafting Isekai
            WebLookUp("https://manganelo.com/manga/sl921274", "Unknown"); //Became a city Lord
            WebLookUp("https://manganelo.com/manga/tn922327", "39"); //Dungeon Reset
            WebLookUp("https://manganelo.com/manga/upzw279201556843676", "85"); //Skeleton Soilder
            WebLookUp("https://manganelo.com/manga/vy918232", "33"); //Record of Ragnarok
            WebLookUp("https://manganelo.com/manga/kumo_desu_ga_nani_ka", "45.1"); //Spider Isekai
            WebLookUp("https://manganelo.com/manga/uaxz925974686", "65"); //Shield Hero
            WebLookUp("https://manganelo.com/manga/remonster", "62"); //ReMonster
            WebLookUp("https://manganelo.com/manga/tv922828", "Unknown"); //Level up by Eating

        }
        static void WebLookUp(String URL, String Read)
        {
            

            using (WebClient client = new WebClient())
            {
                string htmlCode = client.DownloadString(URL);
                try
                {
                    
                    /* Getting Title */
                    int titleDiv = htmlCode.IndexOf("story-info-right") + 23;
                    int titleClose = htmlCode.IndexOf("<", titleDiv);
                    int titleLength = titleClose - titleDiv;
                    string title = htmlCode.Substring(titleDiv, titleLength);
                    /* Finding Chapter */
                    int rowLocation = htmlCode.IndexOf("<li class=");
                    int firstClose = htmlCode.IndexOf(">", rowLocation);
                    int secondClose = htmlCode.IndexOf(">", firstClose + 1);
                    int thirdClose = htmlCode.IndexOf("<", secondClose);
                    int chapterLength = thirdClose - secondClose - 1;
                    string chapter = htmlCode.Substring(secondClose + 1, chapterLength);
                    Console.WriteLine(title + ": " );
                    Console.WriteLine("Latest Chapter: " + chapter);
                    Console.WriteLine("   Latest Read: " + Read);
                    Console.WriteLine(" ");
                }
                catch
                {
                    Console.WriteLine("Unable to find Manga");
                    Console.WriteLine(" ");
                }
            }
        }
     }

    
}

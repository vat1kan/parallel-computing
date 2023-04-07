using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net;
using System.Threading.Tasks;
namespace ParallelForeachApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> urls = new List<string>() {
                "https://www.youtube.com/",
                "https://www.amazon.com/",
                "https://www.wolframalpha.com/",
                "http://google.com",
                "https://op.edu.ua/"
};
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine("Downloading withoud paralleling\n");
            foreach (string url in urls)
            {
                WebClient client = new WebClient();
                Console.WriteLine("Download content by: {0}", url);
                client.DownloadString(url);
            }

            long elapsed = sw.ElapsedMilliseconds;
            Console.WriteLine("\nTotal time, msec: {0}", elapsed);
            sw.Stop();
            Console.WriteLine("\n------------------------------\n");
            Console.WriteLine("Paralleling download\n");
            sw.Restart();
            Parallel.ForEach(urls, url =>
            {
                WebClient client = new WebClient();
                Console.WriteLine("Download content by: ", url);
                client.DownloadString(url);
            });
            elapsed = sw.ElapsedMilliseconds;
            Console.WriteLine("\nTotal time, msec: {0}", elapsed);
            sw.Stop();
            Console.ReadLine();
        }
    }
}

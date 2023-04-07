using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SimpleMultitaskingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string[]> message = new Task<string[]>(() =>
            {
                var result = new string[3];
                new Task(() => result[0] = printMessage("This string is by the first task"), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[1] = printMessage("The second task is done"), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[2] = printMessage("The third task message"), TaskCreationOptions.AttachedToParent).Start();
                return result;
            });
            var cwt = message.ContinueWith(mes => Array.ForEach(mes.Result, Console.WriteLine));
            message.Start();
            Console.WriteLine("The main methos is done");
            Console.ReadLine();
        }
        private static string printMessage(string message)
        {
            return message.ToUpper();
        }
    }
}

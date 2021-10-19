using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace System.Threading.Tasks.Net20.Test {
    class Program {
        static void Main(string[] args) {
            byte[] buf1 = new byte[1024];
            int index = 0;
            for(int i = 0; i < 16; i++) {
                for(int j = 0; j < 64; j++) {
                    buf1[index] = (byte)j;
                    index++;
                }
            }
            MemoryStream ms1 = new MemoryStream(1024 * 1024 * 100);
            for(int i = 0; i < 1024 * 100; i++) {
                ms1.Write(buf1, 0, buf1.Length);
            }
            ms1.Position = 0;
            Console.WriteLine("do Task start:" + ms1.Length);
            MemoryStream ms2 = new MemoryStream(1024);
            var task = StreamExtensions.CopyToAsync(ms1, ms2, 1024);
            //while(task.IsCompleted == false) {
             Console.WriteLine("do Task:"+ms2.Length);
            //}
            task.Wait();
            Console.WriteLine("do Task end:"+ms2.Length);
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
 
          

                string folderName = @"C:\Folder\";
                string txtName = @"in.txt";

                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
                string path = Path.Combine(folderName, txtName);
                if (!File.Exists(path))
                {
                    var myfile = File.Create(path);
                    myfile.Close();
                }


                string[] cities = new string[] { "Baki", "Tovuz", "Qazax", "Gence", "Agstafa", "Qax", "Quba", "Zengilan", "Cebrayil", "Agdam" };


                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (var city in cities)
                    {
                        writer.WriteLine(city);
                    }
                }
                List<string> list = new List<string>();
                try
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        string Okunan = "";
                        while (!reader.EndOfStream)
                        {
                            Okunan = reader.ReadLine() + " ";
                            list.Add(Okunan);

                        }

                    }
                }

                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
                string path2 = @"C:\Folder\out.txt";
                if (!File.Exists(path))
                {
                    var myfile = File.Create(path2);

                }
                Srv.ReverseServiceClient c = new Srv.ReverseServiceClient();
                try
                {
                    using (StreamWriter writer = new StreamWriter(path2))
                    {
                        foreach (string l in list)
                        {

                            writer.WriteLine(c.ReverseWord(l));
                            
                        }
                    Console.WriteLine("Finished");
                        Console.ReadLine();


                    }
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }

            }
        }
    }



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HuffmanCodeWithCSharp
{
    class Test
    {
        // Test class provide us to test our program.
        static void Main(string[] args)
        {
            Console.WriteLine("1.To compress file");
            Console.WriteLine("2.To de compress file");
            string com1 = Console.ReadLine();
            if (com1 == "1")
            {
                List<HuffmanNode> nodeList; // store nodes on List.

                ProcessMethods pMethods = new ProcessMethods();

                Console.Clear();
                Console.WriteLine("Example file: \"a.txt\"\n");
                Console.Write("Enter the path of the file: ");
                string filename = Console.ReadLine();
                nodeList = pMethods.getListFromFile(filename);
                Console.Clear();
                if (nodeList == null)
                {
                    Console.WriteLine("File cannot be read!");
                    Console.WriteLine("Pressthe any key to continue");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Enter output file 1");
                    string fname1 = Console.ReadLine();
                    Console.WriteLine("Enter output file 2");
                    string fname2 = Console.ReadLine();
                    Console.WriteLine("Number of repeats for each character:");
                    pMethods.PrintInformation(nodeList , fname2);
                    pMethods.getTreeFromList(nodeList);
                    pMethods.setCodeToTheTree("", nodeList[0]);
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Code for each character:");
                    pMethods.PrintfLeafAndCodes(nodeList[0]);
                    pMethods.compressedFile(fname1);
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Press the any key to contunie");
                    Console.ReadLine();

                }
            }
            else
            {
                List<hufmanSigns> hs = new List<hufmanSigns>();
                Console.WriteLine("Example file: \"compress.txt\"\n");
                Console.Write("Enter the path of the compressed file: ");
                string fname1 = Console.ReadLine();
                Console.WriteLine("Example file: \"guid.txt\"\n");
                Console.Write("Enter the path of the gauide file: ");
                string fname2 = Console.ReadLine();
                Console.WriteLine("Example file: \"out.txt\"\n");
                Console.Write("Enter the path of the output file: ");
                string fname3 = Console.ReadLine();
                StreamWriter sw = new StreamWriter(fname3);
                int n = File.ReadLines(fname2).Count();
                var x = File.Create("tmp.txt");
                x.Close();
                StreamWriter swtmp = new StreamWriter("tmp.txt");
                StreamReader sw1 = new StreamReader(fname1);
                StreamReader sw2 = new StreamReader(fname2);
                for (int i = 0; i < n; i++)
                {

                    string stmp = sw2.ReadLine();
                    //Console.WriteLine(stmp);
                    //Console.ReadKey();
                    int reapet = Convert.ToInt16( stmp.Substring(2));
                    for (int j = 0; j < reapet; j++)
                    {
                        swtmp.Write(stmp[0]);
                    }
                    //Console.WriteLine("{0}  {1}", stmp[0], reapet.ToString());
                    //Console.ReadKey();

                }
                swtmp.Close();
                //Console.ReadKey();
                List<HuffmanNode> nodeList;
                ProcessMethods pMethods = new ProcessMethods();
                nodeList = pMethods.getListFromFile("tmp.txt");
                pMethods.getTreeFromList(nodeList);
                pMethods.setCodeToTheTree("", nodeList[0]);
                Console.WriteLine("Code for each character:");
                pMethods.PrintfLeafAndCodes(nodeList[0]);
                try
                {
                    File.Delete("tmp.txt");
                }
                catch { }
                string f = sw1.ReadToEnd();
                //Console.WriteLine(pMethods.hs.Count);
                //Console.ReadKey();
                string tmp = "";
                for (int i = 0; i < f.Length; i++)
                {
                    tmp += f[i];
                    //Console.WriteLine(tmp);
                    foreach (hufmanSigns hs1 in pMethods.hs)
                    {
                        //Console.WriteLine(hs1.code);
                        if (tmp == hs1.code)
                        {
                            //Console.WriteLine("salam");
                            sw.Write(hs1.symbol);
                            Console.Write(hs1.symbol);
                            tmp = "";
                            break;
                        }
                    }
                }

                sw.Close();
                sw1.Close();
                sw2.Close();
                Console.WriteLine("\n\n");
                Console.WriteLine("Press the any key to contunie");
                Console.ReadLine();
            }
        }

    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nyelvtanulas
{
    internal class Szotar
    {
        public Dictionary<string, string> szavak;
        public Szotar()
        {
            szavak=new Dictionary<string, string>();
        }
        public void feltolt(string kulcsnyelv, string[] fajlok)
        {
            if(kulcsnyelv=="angol")
            {
                foreach(string item in fajlok)
                {
                    using (StreamReader sr = new StreamReader(item))
                        while (!sr.EndOfStream)
                    {
                        string[] szopar=sr.ReadLine().Split('=');
                        if (!szavak.ContainsKey(szopar[0]) && szopar.Length == 2)
                        {
                            szavak.Add(szopar[0], szopar[1]);
                        }
                    }
                }
            }
            else if(kulcsnyelv=="magyar")
            {
                foreach (string item in fajlok)
                {
                    using (StreamReader sr = new StreamReader(item))
                        while (!sr.EndOfStream)
                        {
                            string[] szopar = sr.ReadLine().Split('=');
                            if (!szavak.ContainsKey(szopar[1])&&szopar.Length==2)
                            {
                                szavak.Add(szopar[1], szopar[0]);
                            }
                        }
                }
            }
            else
            {
                Console.WriteLine("nem támogatott nyelv");
            }
        }

        public void szoTorles(string kulcs)
        {
            szavak.Remove(kulcs);
        }

        public void temaTorles(string kulcsnyelv, string[] fajlok)
        {
            if (kulcsnyelv == "angol")
            {
                
                foreach (string item in fajlok)
                {
                    using (StreamReader sr = new StreamReader(item))
                        while (!sr.EndOfStream)
                    {
                        string[] szopar = sr.ReadLine().Split(' ');
                        szavak.Remove(szopar[0]);
                    }
                }
            }
            else if (kulcsnyelv == "magyar")
            {
                foreach (string item in fajlok)
                {
                    using (StreamReader sr = new StreamReader(item))
                        while (!sr.EndOfStream)
                        {
                            string[] szopar = sr.ReadLine().Split(' ');
                            szavak.Remove(szopar[1]);
                        }
                }
            }
            else
            {
                throw new Exception("nem támogatott nyelv: "+kulcsnyelv);
            }
        }

    }
}

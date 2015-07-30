using System.Xml.Linq;
using PivotApp1.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PivotApp1
{
    internal class DataLoader
    {
        public static bool error = false;

        public static Dictionary<string,Recipe> Stews = new Dictionary<string, Recipe>();
        public static Dictionary<string, Recipe> kebabs = new Dictionary<string, Recipe>();
        public static Dictionary<string, Recipe> rices = new Dictionary<string, Recipe>();
        public static Dictionary<string, Recipe> soups = new Dictionary<string, Recipe>();
        public static Dictionary<string, Recipe> others = new Dictionary<string, Recipe>();
        public static Dictionary<string, Recipe> torshi = new Dictionary<string, Recipe>();
        public static Dictionary<string, Recipe> deserts = new Dictionary<string, Recipe>();
        
        public static void LoadData()
        {
            List<string> files = new List<string>();
            files.Add("stew.txt");
            files.Add("kebab.txt");
            files.Add("rice.txt");
            files.Add("soup.txt");
            files.Add("others.txt");
            files.Add("torshi.txt");
            files.Add("desert.txt");

            
            foreach (string file in files)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        String line = sr.ReadLine();
                        while (true)
                        {
                            Recipe rec;

                            if (line.Trim() == "##T" || line.Trim().Contains("##T"))
                            {
                                // read title
                                rec = new Recipe();
                                rec.title = sr.ReadLine().Trim();

                                // read ingridiants
                                if (sr.ReadLine().Trim() == "##ING")
                                {
                                    line = sr.ReadLine();
                                    while (line.Trim() != "##Rec")
                                    {
                                        if (string.IsNullOrEmpty(line.Trim()))
                                            continue;
                                        
                                        string[] separators = { "$" };
                                        string[] words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                                        rec.ingridiants.Add(words[0].Trim(), words[1].Trim());

                                        line = sr.ReadLine();
                                    }

                                }

                                line = sr.ReadLine();

                                while (!line.Trim().Contains("##T"))
                                {
                                    if (line.Trim() == "#$&")
                                        break;
                                    //line = sr.ReadLine();
                                    rec.rec = rec.rec + line.Trim() + "\n";
                                    line = sr.ReadLine();
                                }
                                if (file.Contains("stew"))
                                {
                                    Stews.Add(rec.title,rec);
                                    //kebabs.Add(rec.title, rec);
                                }
                                else if (file.Contains("kebab"))
                                {
                                    kebabs.Add(rec.title, rec);
                                }
                                else if (file.Contains("rice"))
                                {
                                    rices.Add(rec.title, rec);
                                }
                                else if (file.Contains("soup"))
                                {
                                    soups.Add(rec.title, rec);
                                }
                                else if (file.Contains("other"))
                                {
                                    others.Add(rec.title, rec);
                                }
                                else if (file.Contains("torshi"))
                                {
                                    torshi.Add(rec.title, rec);
                                }
                                else if (file.Contains("desert"))
                                {
                                    deserts.Add(rec.title, rec);
                                }
                            }
                            

                            if (line.Trim() == "#$&")
                                break;
                        }
                    }
                }

                catch (Exception e)
                {
                    Console.Write(e.Data);
                }
            }

        }

        

        public static ObservableCollection<ItemViewModel> menuItems(string name)
        {
            ObservableCollection<ItemViewModel> items = new ObservableCollection<ItemViewModel>();
            if (name.Contains("stew"))
            {
                foreach (string s in Stews.Keys)
                {
                    items.Add(new ItemViewModel() {LineOne = s, LineTwo = "", LineThree = ""});
                }
            }
            else if (name.Contains("kebab"))
            {
                foreach (string s in kebabs.Keys)
                {
                    items.Add(new ItemViewModel() {LineOne = s, LineTwo = "", LineThree = ""});
                }
            }
            else if (name.Contains("rice"))
            {
                foreach (string s in rices.Keys)
                {
                    items.Add(new ItemViewModel() {LineOne = s, LineTwo = "", LineThree = ""});
                }
            }
            else if (name.Contains("soup"))
            {
                foreach (string s in soups.Keys)
                {
                    items.Add(new ItemViewModel() { LineOne = s, LineTwo = "", LineThree = "" });
                }
            }
            else if (name.Contains("other"))
            {
                foreach (string s in others.Keys)
                {
                    items.Add(new ItemViewModel() { LineOne = s, LineTwo = "", LineThree = "" });
                }
            }
            else if (name.Contains("torshi"))
            {
                foreach (string s in torshi.Keys)
                {
                    items.Add(new ItemViewModel() { LineOne = s, LineTwo = "", LineThree = "" });
                }
            }
            else if (name.Contains("desert"))
            {
                foreach (string s in deserts.Keys)
                {
                    items.Add(new ItemViewModel() { LineOne = s, LineTwo = "", LineThree = "" });
                }
            }

            
            return items;
        }





    }




}

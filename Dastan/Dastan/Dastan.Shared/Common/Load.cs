using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Dastan.Common
{
    class Load
    {
        public static Dictionary<string, string> dastans = new Dictionary<string, string>();
        public static CurrentItem currentItem = new CurrentItem();
        public static void loadData()
        {
            // Create an XML reader for this file.
            using (XmlReader reader = XmlReader.Create("DataModel\\dastans.xml"))
            {
                while (reader.Read())
                {
                    // Only detect start elements.
                    if (reader.IsStartElement())
                    {
                        // Get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "start":
                                // Detect this element.
                                
                                break;
                            case "article":
                                // Detect this article element.
                                
                                // Search for the attribute name on this current node.
                                string attribute = reader["name"];
                                /*
                                if (attribute == null)
                                {
                                    
                                }
                                */
                                // Next read will contain text.
                                if (reader.Read())
                                {
                                    dastans.Add(attribute, reader.Value.Trim());
                                    
                                }
                                break;
                        }
                    }
                }
            }
        }
    }


    
}

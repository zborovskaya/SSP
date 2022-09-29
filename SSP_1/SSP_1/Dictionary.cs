using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace SSP_1
{
    class Translator
    {
        private List<Item> items;
        private XmlSerializer xmlSerializer;
        private string path = "translator.xml";
        private bool blocked = false;
        public Translator()
        {
            
        }

        public List<Item> getTranslation(String word, int key)
        {
            List<Item> translations = new List<Item>();
            if (key==0) {
                foreach (Item item in items)
                {
                    if (compare(word, item.getRussianWord()))
                    {
                        translations.Add(item);
                    }
                }
            }else
            {
                foreach (Item item in items)
                {
                    if (compare(word, item.getEnglishWord()))
                    {
                        translations.Add(item);
                    }
                }
            }
            return translations;
        }

         public bool compare(String word1, String word2)
        {
            int lenth1 = word1.Length;
            int lenth2 = word2.Length;
            bool exception = false;
            if (Math.Abs(lenth1 - lenth2) > 1)
            {
                return false;
            }else
            {
                int i = 0;
                int j = 0;
                char [] characters1 = word1.ToLower().ToCharArray();
                char[] characters2 = word2.ToLower().ToCharArray();
                while (i < lenth1 && j < lenth2)
                {
                    if (characters1[i] == characters2[j])
                    {
                        i++;
                        j++;
                    }else
                    {
                        if (!exception)
                        {
                            if (lenth2 > lenth1)
                            {
                                j++;
                            }
                            else if(lenth2 < lenth1)
                            {
                                i++;
                            }
                            else
                            {
                                i++;
                                j++;
                            }
                            exception = true;
                        }else
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        } 

        public void readXmlFile()
        {
            xmlSerializer = new XmlSerializer(typeof(List<Item>));
            if (File.Exists(path))
            {
                blocked = false;
                using (FileStream fs = new FileStream("translator.xml", FileMode.Open))
                {
                    try
                    {
                        items = xmlSerializer.Deserialize(fs) as List<Item>;
                    }
                    catch
                    {
                        items = null;
                    }
                  
                }
            }
            else
            {
                blocked = true;
            }
        }

        public void addWord(Item item)
        {
            try
            {
               XmlDocument xDoc = new XmlDocument();
               xDoc.Load("translator.xml");

               XmlElement xmlItem = xDoc.CreateElement("Item");
               XmlElement englishElem = xDoc.CreateElement("englishWord");
               XmlElement russianElem = xDoc.CreateElement("russianWord");

               XmlText englishText = xDoc.CreateTextNode(item.getEnglishWord());
               XmlText russianText = xDoc.CreateTextNode(item.getRussianWord());

               englishElem.AppendChild(englishText);
               russianElem.AppendChild(russianText);

               xmlItem.AppendChild(englishElem);
               xmlItem.AppendChild(russianElem);

               XmlElement xRoot = xDoc.DocumentElement;
               xRoot.AppendChild(xmlItem);
               xDoc.Save("translator.xml");
                  
            }
            catch
            {
                throw new Exception("Server error");
            }
            
        }

        public bool isBlocked()
        {
            return blocked;
        }

        public List<Item> getItem()
        {
            return items;
        }

    }
}

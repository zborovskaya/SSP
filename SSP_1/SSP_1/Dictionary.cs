using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSP_1
{
    class Dictionary
    {
        private List<Item> items = new List<Item>();
        public Dictionary()
        {
            items.Add(new Item("red", "красный"));
            items.Add(new Item("cat", "кот"));
            items.Add(new Item("rat", "крыса"));
            items.Add(new Item("house", "дом"));
            items.Add(new Item("home", "дом"));
            items.Add(new Item("building", "дом"));
        }
        // true russianToEnglish
        // false englishToRussian
        public List<String> getTranslation(String word, bool lang)
        {
            List<String> translations = new List<string>();
            if (lang) {
                foreach (Item item in items)
                {
                    if (compare(word, item.getRussianWord()))
                    {
                        translations.Add(item.getEnglishWord());
                    }
                }
            }else
            {
                foreach (Item item in items)
                {
                    if (compare(word, item.getEnglishWord()))
                    {
                        translations.Add(item.getRussianWord());
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

    }


}

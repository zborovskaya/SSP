using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSP_1
{
    public class Item
    {
        public String englishWord ;
        public String russianWord ;

        public Item(String englishWord, String russianWord)
        {
            this.englishWord = englishWord;
            this.russianWord = russianWord;
        }

        public Item()
        {
        }

        public String getEnglishWord()
        {
            return englishWord;
        }

        public String getRussianWord()
        {
            return russianWord;
        }
        public void setEnglishWord(String english)
        {
            englishWord=english;
        }

        public void setRussianWord(String russian)
        {
            russianWord = russian;
        }
    }

}

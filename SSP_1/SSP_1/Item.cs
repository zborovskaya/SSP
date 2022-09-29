using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSP_1
{
    public class Item
    {
        public String englishWord;
        public String russianWord;

        public Item(String englishWord, String russianWord)
        {
            this.englishWord = englishWord;
            this.russianWord = russianWord;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Item);
        }

        public bool Equals(Item other)
        {
            return other != null &&
                   englishWord.Equals(other.englishWord) &&
                   russianWord.Equals(other.russianWord);
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

        public void setEnglishWord(String englishWord)
        {
            this.englishWord =  englishWord;
        }

        public void setRussianWord(String russianWord)
        {
            this.russianWord = russianWord;
        }
    }

}

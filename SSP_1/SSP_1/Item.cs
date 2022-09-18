using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSP_1
{
    class Item
    {
        private String englishWord;
        private String russianWord;

        public Item(String englishWord, String russianWord)
        {
            this.englishWord = englishWord;
            this.russianWord = russianWord;
        }

        public String getEnglishWord()
        {
            return englishWord;
        }

        public String getRussianWord()
        {
            return russianWord;
        }

    
    }

}

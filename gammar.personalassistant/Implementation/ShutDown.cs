using gammar.personalassistant.Interfaces;
using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Text;

namespace gammar.personalassistant.Implementation
{
    public class ShutDown : IGrammar
    {

        private const string _triggerWord = "Shut down";
        private string[] _choiceWords = { "Shut down" };        

        public Grammar BuildGrammar()
        {
            var grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append("_triggerWord");

            return new Grammar(grammarBuilder);
        }


        public bool CanProcess(string triggerWord)
        {
            return triggerWord.Equals(_triggerWord);
        }

        public string Execute()
        {

            return _triggerWord;
        }

        public Choices GetChoice()
        {
            return new Choices(_choiceWords);
        }
    }
}


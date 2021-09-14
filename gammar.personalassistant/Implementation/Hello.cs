using gammar.personalassistant.Interfaces;
using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Text;

namespace gammar.personalassistant.Implementation
{
    public class Hello : IGrammar
    {
        private const string _triggerWord = "Hello";
        private string [] _choiceWords = { "Hello" };

        public Grammar BuildGrammar()
        {
            var grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(_triggerWord);

            return new Grammar(grammarBuilder);
        }

        public bool CanProcess(string triggerWord)
        {
            return triggerWord.Equals(_triggerWord);
        }

        public string Execute()
        {
            return "Hello, my name is Jarvis.  How can I help you today?";
        }
        
        public Choices GetChoice()
        {
            return new Choices(_choiceWords);
        }
    }
}

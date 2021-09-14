using gammar.personalassistant.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Humanizer;
using System.Speech.Recognition;

namespace gammar.personalassistant.Implementation
{    
    public class Time : IGrammar
    {

        private const string _triggerWord = "What time is it";
        private string[] _choiceWords = { "What time is it" };
        private const string _timeResponse = @"The current time is {0}";

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
            var humanizedTime = DateTime.Now.Humanize();

            return String.Format(_timeResponse, DateTime.Now);
        }

        public Choices GetChoice()
        {
            return new Choices(_choiceWords);
        }
    }
}

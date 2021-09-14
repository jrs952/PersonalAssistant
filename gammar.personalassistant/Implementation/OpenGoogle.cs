using gammar.personalassistant.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Speech.Recognition;
using System.Text;

namespace gammar.personalassistant.Implementation
{
    public class OpenGoogle : IGrammar
    {
        private const string _triggerWord = "Open Google";
        private string[] _choiceWords = { "Open Google" };

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
            Process.Start(new ProcessStartInfo("https://www.google.com") { UseShellExecute = true });
            return "Opening Google";
        }

        public Choices GetChoice()
        {
            return new Choices(_choiceWords);
        }
    }
}

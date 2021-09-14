using System;
using System.Collections.Generic;
using System.Text;
using System.Speech;
using System.Speech.Recognition;

namespace gammar.personalassistant.Interfaces
{
    public interface IGrammar
    {
        bool CanProcess(string triggerWord);
        string Execute();
        Choices GetChoice();
        Grammar BuildGrammar();
    }
}

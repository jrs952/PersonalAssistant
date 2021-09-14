using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using gammar.personalassistant.Interfaces;
using gammar.personalassistant.Implementation;
using Vlc.DotNet.Core;
using System.Diagnostics;

namespace desktop.personalassistant
{
    public partial class Form1 : Form
    {

        SpeechRecognitionEngine _rEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer _speechSynth = new SpeechSynthesizer();
        System.Media.SoundPlayer musicPlayer = new System.Media.SoundPlayer();

        //VlcMediaPlayer vlcPlayer = new VlcMediaPlayer(new DirectoryInfo(Environment.CurrentDirectory));

        List<IGrammar> _grammars = new List<IGrammar>();


        public Form1()
        {
            InitializeComponent();

            Choices choices = new Choices();


            _rEngine.SetInputToDefaultAudioDevice();

            _grammars.Add(new Hello());
            _grammars.Add(new Time());
            _grammars.Add(new ShutDown());            

            foreach (var item in _grammars)
            {
                choices.Add(item.GetChoice());                
            }

            Grammar grammar = new Grammar(new GrammarBuilder(choices));
            _rEngine.LoadGrammar(grammar);
            _rEngine.RecognizeAsync(RecognizeMode.Multiple);            

            _rEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rEngine_SpeechRecognized);
            _speechSynth.SelectVoiceByHints(VoiceGender.Male);
        }

        private void rEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string result = e.Result.Text;

            List<IGrammar> executableGrammars = _grammars.Where(x => x.CanProcess(result)).ToList<IGrammar>(); ;
            if (executableGrammars.Count > 1)
            {
                result = "There are too many options";
            }
            else if (executableGrammars.Count == 1)
            {
                result = executableGrammars.First().Execute();
            }                                        

            // needs to live here to not pass application references around
            if (result == "Shut down")
            {
                Application.Exit();
            }


            label3.Text = e.Result.Confidence.ToString();
            _speechSynth.SpeakAsync(result);
            label2.Text = result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}

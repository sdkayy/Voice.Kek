using System;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Voice
{
    public class Kek
    {
        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <param name="commands">String Array of Commands</param>
        /// <param name="handler">SpeechRecognizedEventArgs Handler</param>
        public Kek(string[] commands, EventHandler<SpeechRecognizedEventArgs> handler)
        {
            SpeechSynthesizer sSynth = new SpeechSynthesizer();
            PromptBuilder pBuilder = new PromptBuilder();
            SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();

            Choices choices = new Choices();
            choices.Add(commands);
            Grammar grammar = new Grammar(new GrammarBuilder(choices));
            try
            {
                sRecognize.RequestRecognizerUpdate();
                sRecognize.InitialSilenceTimeout = TimeSpan.FromMilliseconds(3600000);
                sRecognize.LoadGrammar(grammar);
                sRecognize.SpeechRecognized += handler;
                sRecognize.SetInputToDefaultAudioDevice();
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);
                sRecognize.Recognize();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}

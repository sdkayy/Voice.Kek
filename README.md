# Voice.Kek
Voice.Kek is a easy to use integration of System.Speech

# How to use
```
private void Form1_Load(object sender, EventArgs e)
{
  Voice.Kek kek = new Voice.Kek(new string[] { "hello" }, kekReciognizer_SpeechRecognized);
}

private void kekReciognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
{
  Console.WriteLine(e.Result.Text);
}
```

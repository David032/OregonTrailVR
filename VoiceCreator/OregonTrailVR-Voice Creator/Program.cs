using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.IO;

namespace OregonTrailVR
{
    class Program
    {
        static string path = "Output";
        static string fileName;
        static string fileContents;
        public static async Task SynthesisToAudioFileAsync()
        {
            var config = SpeechConfig.FromSubscription("7a21490acf47414aa0d79dfb5f483183", "westeurope");

            var audioFileName = fileName;
            using (var fileOutput = AudioConfig.FromWavFileOutput(audioFileName))
            {
                using (var synthesizer = new SpeechSynthesizer(config, fileOutput))
                {
                    var text = fileContents;
                    var result = await synthesizer.SpeakTextAsync(text);

                    if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                    {
                        Console.WriteLine($"Speech synthesized to [{audioFileName}] for text [{text}]");
                        File.Copy(audioFileName, path + "/" + audioFileName);
                        Console.WriteLine("Press 'y' to create another file, else press 'n' to quit");
                        string input = Console.ReadLine();
                        if (input == "y")
                        {
                            fileName = null;
                            fileContents = null;
                            createAudioFile();
                        }
                    }
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                        Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                        if (cancellation.Reason == CancellationReason.Error)
                        {
                            Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                            Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                            Console.WriteLine($"CANCELED: Did you update the subscription info?");
                        }
                    }
                }
            }
        }

        private static void createDirectory()
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine("Directory already exists, woopsie!");
            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
        }

        public static void getInput() 
        {
            Console.WriteLine("Enter File Name:");
            fileName = Console.ReadLine();
            fileName += ".wav";
            Console.WriteLine("Enter File Contents:");
            fileContents = Console.ReadLine();
        }

        static void Main()
        {
            createDirectory();

            createAudioFile();
        }

        private static void createAudioFile()
        {
            getInput();
            SynthesisToAudioFileAsync().Wait();
        }
    }
}

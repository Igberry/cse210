using System;
using System.Collections.Generic;
using System.IO;

namespace ScriptureMemorizationProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load scriptures from a file
            List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

            // Randomly select a scripture to present to the user
            Random random = new Random();
            Scripture randomScripture = scriptures[random.Next(scriptures.Count)];

            ScriptureMemorizer memorizer = new ScriptureMemorizer(randomScripture);
            memorizer.StartMemorizationSession();
        }

        static List<Scripture> LoadScripturesFromFile(string filename)
        {
            List<Scripture> scriptures = new List<Scripture>();

            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 2)
                        {
                            scriptures.Add(new Scripture(parts[0], parts[1]));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error reading from file: {e.Message}");
            }

            return scriptures;
        }
    }
}
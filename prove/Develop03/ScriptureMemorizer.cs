class ScriptureMemorizer
    {
        private readonly Scripture _scripture;
        private HashSet<int> _hiddenWordsIndices;

        public ScriptureMemorizer(Scripture scripture)
        {
            _scripture = scripture;
            _hiddenWordsIndices = new HashSet<int>();
        }

        public void StartMemorizationSession()
        {
            Console.WriteLine($"Scripture Reference: {_scripture.Reference}");
            Console.WriteLine($"Scripture Text: {_scripture.Text}");

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            while (input.ToLower() != "quit")
            {
                HideRandomWords();
                Console.WriteLine("\nPress Enter to continue hiding words or type 'quit' to exit:");
                input = Console.ReadLine();
            }
        }

        private void HideRandomWords()
        {
            Console.Clear();
            Console.WriteLine($"Scripture Reference: {_scripture.Reference}");

            string[] words = _scripture.Text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!_hiddenWordsIndices.Contains(i))
                {
                    Console.Write($"{words[i]} ");
                }
                else
                {
                    Console.Write("______ ");
                }
            }

            // Hide a few random words
            Random random = new Random();
            int wordsToHide = random.Next(1, words.Length); // hide 1 to total words - 1
            for (int i = 0; i < wordsToHide; i++)
            {
                int index = random.Next(words.Length);
                _hiddenWordsIndices.Add(index);
            }
        }
    }

class Scripture
    {
        public string Reference { get; private set; }
        public string Text { get; private set; }

        public Scripture(string reference, string text)
        {
            Reference = reference;
            Text = text;
        }
    }
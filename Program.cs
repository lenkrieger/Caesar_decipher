namespace DecoderCesar
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true) // safe loop for serving as main manu
            {
                Alphabet alphabet = new Alphabet(); // Create an instance of the Alphabet class
                TextToLetters textToLetters = new TextToLetters(); // Create an instance of the TextToLetters class
                // alphabet.Printer();
                Console.WriteLine("Welcome to Decoder /// Use it to Encrypt and Decrypt Caesar cipher"); //menu
                Console.WriteLine("--------------------");
                Console.WriteLine("1. Encrypt");
                Console.WriteLine("2. Bruteforce");
                Console.WriteLine("3. Exit");
                var choice = Console.ReadLine();
                Console.WriteLine("--------------------");
                switch (choice)
                {
                    case "1":
                        Encrypt(textToLetters, alphabet);
                        break;

                    case "2":
                        Decrypt(textToLetters, alphabet);
                        break;

                    case "3":
                        return;
                }
            }
        }

        public static void Encrypt(TextToLetters textToLetters, Alphabet alphabet)
        {
            List<char> letters = alphabet.Letters; // copies a reference to the list of characters from the alphabet object
            List<char> letters2 = textToLetters.Letters2; // same but from textToLetters object
            Console.WriteLine("What you want to encrypt: ");
            string text = Console.ReadLine();
            textToLetters.AddText(text);
            Console.WriteLine("How many letters do you want to shift: (for exapmle if you type '1': 'a' will become 'b'");
            int.TryParse(Console.ReadLine(), out int shift);
            int All = letters2.Count;
            for (int i = 0; i < All; i++)
            {
                char tempLetters2 = letters2[i];
                int j = 0;
                int tempShift = shift + 1; // correction for ' ' in #0 list 
                do
                {
                    if (tempLetters2 == ' ')
                    {
                        letters2[i] = ' ';
                        string lettersAsString = textToLetters.GetLettersAsString();
                        Console.WriteLine($"{lettersAsString}");
                        break;
                    }
                    else
                    {
                        if (tempLetters2 == letters[j])
                        {
                            if (j == 0) // for first 'a' in text
                            {
                                letters2[i] = letters[j + tempShift - 1];
                                string lettersAsString = textToLetters.GetLettersAsString();
                                Console.WriteLine($"{lettersAsString}");
                                break;
                            }
                            else
                            {
                                letters2[i] = letters[j + tempShift];
                                string lettersAsString = textToLetters.GetLettersAsString();
                                Console.WriteLine($"{lettersAsString}");
                                break;
                            }
                        }
                        else
                        {
                            letters2[i] = letters[j + tempShift];
                            string lettersAsString = textToLetters.GetLettersAsString();
                            Console.WriteLine($"{lettersAsString}");
                        }
                    }
                    j = j + 1;
                }
                while (tempLetters2 != letters[j]);
            }
        }

        public static void Decrypt(TextToLetters textToLetters, Alphabet alphabet)
        {
            List<char> letters = alphabet.Letters; // copies a reference to the list of characters from the alphabet object
            List<char> letters2 = textToLetters.Letters2; // same but from textToLetters object
            List<char> TempLetters = new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', }; // buffer list, used for display purpise only
            Console.WriteLine("What you want to decrypt: ");
            string text = Console.ReadLine();
            textToLetters.AddText(text);
            int All = letters2.Count;
            int shift = 0;
            do
            {
                for (int i = 0; i < All; i++)
                {
                    char tempLetters2 = letters2[i];
                    int j = 0;
                    do
                    {
                        if (tempLetters2 == ' ')
                        {
                            TempLetters[i] = ' ';
                            break;
                        }
                        else
                        {
                            if (tempLetters2 == letters[j])
                            {
                                if (j == 0) // for first 'a' in text
                                {
                                    TempLetters[i] = letters[j + shift - 1];
                                    break;
                                }
                                else
                                {
                                    TempLetters[i] = letters[j + shift];
                                    break;
                                }
                            }
                            else
                            {
                                TempLetters[i] = letters[j + shift];
                            }
                        }
                        j = j + 1;
                    }
                    while (tempLetters2 != letters[j]);
                }
                string convert = string.Concat(TempLetters);
                int numb = 27 - shift;
                Console.WriteLine(numb + " >> " + convert);
                shift++;
            } while (shift < 27);
        }

        internal class Alphabet // class with Alphabet <List> creation
        {
            public List<char> Letters { get; private set; }

            public Alphabet()
            {
                Letters = new List<char>(); // creation of <List>
                AlphabetBuilder();
            }

            public void AlphabetBuilder() // add letters in alphabetical order in list
            {
                int i = 0;
                Letters.Add(' ');
                do
                {
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        Letters.Add(c);
                    }
                    i++;
                } while (i < 2);
                i = 0;
                do
                {
                    for (char C = 'A'; C <= 'Z'; C++)
                    {
                        Letters.Add(C);
                    }
                    i++ ;
                } while (i < 2);
            }

            public void Printer()
            {
                int count = 0;
                foreach (char c in Letters)
                {
                    Console.WriteLine(count + " == " + c + " "); // debug purpose only, print all <List>
                    count++;
                }
            }
        }

        internal class TextToLetters // class with TextToLetters <List> creation
        {
            public List<char> Letters2 { get; private set; }

            public TextToLetters()
            {
                Letters2 = new List<char>(); // creation of <List>
            }

            public void AddText(string text) // add letters from text in <List>
            {
                foreach (char c2 in text)
                {
                    Letters2.Add(c2);
                }
            }

            public void Printer()
            {
                foreach (char c in Letters2)
                {
                    Console.WriteLine(c + " "); // debug purpose only, print all letters from imputed word
                }
            }

            public string GetLettersAsString()
            {
                return new string(Letters2.ToArray());
            }
        }
    }
}
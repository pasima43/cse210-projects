using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is the scripture memorizer project.");
            // Scripture Memorizer Program
            // Exceeding requirements: See comments at the end of this file for details.

            // Example scripture: Proverbs 3:5-6
            var reference = new Reference("Proverbs", 3, 5, 6);
            var text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
            var scripture = new Scripture(reference, text);

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (string.Equals(input.Trim(), "quit", StringComparison.OrdinalIgnoreCase))
                    break;

                if (scripture.AllWordsHidden())
                    break;

                scripture.HideRandomWords(3); // Hide 3 random words each time
            }

            // Final display
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nAll words are hidden. Program ended.");
        }
    }

    // Reference class
    public class Reference
    {
        private readonly string _book;
        private readonly int _chapter;
        private readonly int _verseStart;
        private readonly int? _verseEnd;

        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verseStart = verse;
            _verseEnd = null;
        }

        public Reference(string book, int chapter, int verseStart, int verseEnd)
        {
            _book = book;
            _chapter = chapter;
            _verseStart = verseStart;
            _verseEnd = verseEnd;
        }

        public string GetDisplayText()
        {
            if (_verseEnd.HasValue)
                return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
            else
                return $"{_book} {_chapter}:{_verseStart}";
        }
    }

    // Word class
    public class Word
    {
        private readonly string _text;
        private bool _hidden;

        public Word(string text)
        {
            _text = text;
            _hidden = false;
        }

        public bool IsHidden() => _hidden;

        public void Hide() => _hidden = true;

        public string GetDisplayText()
        {
            if (_hidden && _text.Length > 0 && char.IsLetter(_text[0]))
                return new string('_', _text.Length);
            else
                return _text;
        }
    }

    // Scripture class
    public class Scripture
    {
        private readonly Reference _reference;
        private readonly List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ')
                .Select(w => new Word(w))
                .ToList();
        }

        public string GetDisplayText()
        {
            return $"{_reference.GetDisplayText()} {string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
        }

        public void HideRandomWords(int count)
        {
            var notHidden = _words.Where(w => !w.IsHidden()).ToList();
            if (notHidden.Count == 0) return;

            var rand = new Random();
            for (int i = 0; i < count && notHidden.Count > 0; i++)
            {
                int idx = rand.Next(notHidden.Count);
                notHidden[idx].Hide();
                notHidden.RemoveAt(idx);
            }
        }

        public bool AllWordsHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }
}

// --- Classes below ---

        // --- Classes below ---

// Reference class
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int? _verseEnd;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = null;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    public string GetDisplayText()
    {
        if (_verseEnd.HasValue)
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
        else
            return $"{_book} {_chapter}:{_verseStart}";
    }
}

// Word class
public class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public string GetDisplayText()
    {
        if (_hidden && _text.Length > 0 && Char.IsLetter(_text[0]))
            return new string('_', _text.Length);
        else
            return _text;
    }
}

// Scripture class
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
            .Select(w => new Word(w))
            .ToList();
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()} {string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }

    public void HideRandomWords(int count)
    {
        var notHidden = _words.Where(w => !w.IsHidden()).ToList();
        if (notHidden.Count == 0) return;

        Random rand = new Random();
        for (int i = 0; i < count && notHidden.Count > 0; i++)
        {
            int idx = rand.Next(notHidden.Count);
            notHidden[idx].Hide();
            notHidden.RemoveAt(idx);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
        // --- End of classes ---
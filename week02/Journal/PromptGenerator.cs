using System;
using System.Collections.Generic;

namespace Journal
{
    /// <summary>
    /// Owns the list of journal prompts and knows how to pick one at
    /// random. Keeping this logic in its own class (rather than inline
    /// in Program.cs) means the prompt list can be extended or loaded
    /// from a file later without touching any other class.
    /// </summary>
    public class PromptGenerator
    {
        private readonly List<string> _prompts;
        private readonly Random _random;

        public PromptGenerator()
        {
            _random = new Random();
            _prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "What is one thing I learned today that I want to remember?",
                "What challenge did I face today, and how did I respond to it?",
                "Who could I have shown more kindness to today?"
            };
        }

        public string GetRandomPrompt()
        {
            int index = _random.Next(_prompts.Count);
            return _prompts[index];
        }
    }
}

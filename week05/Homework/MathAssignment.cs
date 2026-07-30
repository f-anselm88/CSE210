using System;

namespace Homework
{
    // Derived class adding math-specific data on top of Assignment.
    public class MathAssignment : Assignment
    {
        private readonly string _section;
        private readonly string _problems;

        public MathAssignment(string studentName, string topic, string section, string problems)
            : base(studentName, topic)
        {
            _section = section;
            _problems = problems;
        }

        public string GetHomeworkList()
        {
            return $"Section {_section} Problems {_problems}";
        }
    }
}
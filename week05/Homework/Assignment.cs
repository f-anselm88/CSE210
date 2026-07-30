using System;

namespace Homework
{
    // Base class representing common assignment data and behavior.
    // MathAssignment and WritingAssignment will inherit from this.
    public class Assignment
    {
        private readonly string _studentName;
        private readonly string _topic;

        public Assignment(string studentName, string topic)
        {
            _studentName = studentName;
            _topic = topic;
        }

        // Returns a one-line summary shared by every assignment type.
        public string GetSummary()
        {
            return $"{_studentName} - {_topic}";
        }

        // Protected getter so derived classes can access the name
        // without exposing it publicly outside the hierarchy.
        protected string GetStudentName()
        {
            return _studentName;
        }
    }
}
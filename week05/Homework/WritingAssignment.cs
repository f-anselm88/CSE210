using System;

namespace Homework
{
    // Derived class adding writing-specific data on top of Assignment.
    public class WritingAssignment : Assignment
    {
        private readonly string _title;

        public WritingAssignment(string studentName, string topic, string title)
            : base(studentName, topic)
        {
            _title = title;
        }

        public string GetWritingInformation()
        {
            // Uses the protected getter from the base class since
            // _studentName itself is private there.
            return $"{_title} by {GetStudentName()}";
        }
    }
}
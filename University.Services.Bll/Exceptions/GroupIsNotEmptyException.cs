using System;

namespace University.Services.Exceptions
{
    public class GroupIsNotEmptyException : Exception
    {
        public GroupIsNotEmptyException()
        {
        }

        public GroupIsNotEmptyException(int? courseId)
            : base("Group is not empty")
        {
            CourseId = courseId;
        }

        public GroupIsNotEmptyException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public int? CourseId { get; }
    }
}
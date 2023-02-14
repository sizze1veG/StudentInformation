using System;

namespace StudentInformation
{
    class PersonException : Exception
    {
        public PersonException(string message)
            : base(message) { }
    }
}
using System;

namespace core.rarecarat
{
    public class ValidationItem
    {
        public string PropertyName { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }
    }
}
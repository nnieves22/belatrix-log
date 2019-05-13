using System;
using System.Runtime.Serialization;

namespace Log.Exceptions
{
    [Serializable]
    public class InvalidConfigurationException : Exception
    {
        public InvalidConfigurationException() : base("Invalid configuration")
        {
        }
    }
}

using Log;
using Log.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void ConsoleInfoLog()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                var jobLogger = new JobLogger(false, true, false, LogLevel.Info);

                jobLogger.LogMessage("This is an information message", LogLevel.Info);

                Assert.IsTrue(sw.ToString().Contains("This is an information message"));
            }
        }

        [TestMethod]
        public void ConsoleInfoLogNotShowed()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                var jobLogger = new JobLogger(false, true, false, LogLevel.Warning);

                jobLogger.LogMessage("This is an information message", LogLevel.Info);

                Assert.IsFalse(sw.ToString().Contains("This is an information message"));
            }
        }

        [TestMethod]
        public void ConsoleWarningLog()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                var jobLogger = new JobLogger(false, true, false, LogLevel.Info);

                jobLogger.LogMessage("This is an warning message", LogLevel.Warning);

                Assert.IsTrue(sw.ToString().Contains("This is an warning message"));
            }
        }

        [TestMethod]
        public void ConsoleWarningLogNotShowed()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                var jobLogger = new JobLogger(false, true, false, LogLevel.Error);

                jobLogger.LogMessage("This is an warning message", LogLevel.Warning);

                Assert.IsFalse(sw.ToString().Contains("This is an warning message"));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidConfigurationException))]
        public void InvalidConfigurationException()
        {
            var jobLogger = new JobLogger(false, false, false, LogLevel.Info);
        }
    }
}

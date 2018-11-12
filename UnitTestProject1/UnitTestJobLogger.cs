using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Belatrix.Interfaces;
using Belatrix.Clases;
using Belatrix;

namespace UnitTestBelatrix
{
    [TestClass]
    public class UnitTestJobLogger
    {
        [TestMethod]
        public void ExceptionMessageCantBeNullEmpty()
        {
            try
            {
                CJobLogger _jobLogger = new CJobLogger(new DJobLogger());
                _jobLogger.LogMessage(null, Enumerations.LogType.message);
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, "Message can't be null or empty");
                return;
            }

            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void ExceptionTypeMessageMustBeEspecified()
        {
            try
            {
                CJobLogger _jobLogger = new CJobLogger(new DJobLogger(false, false, false, true, true, true));
                _jobLogger.LogMessage("test", Enumerations.LogType.message);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Error or Warning or Message must be specified");
                return;
            }
            
            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void ExceptionTypeWasntConfiguredToSaveMessage()
        {
            try
            {
                CJobLogger _jobLogger = new CJobLogger(new DJobLogger(true, true, true, false, true, true));
                _jobLogger.LogMessage("test", Enumerations.LogType.message);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "JobLogger is not configured to save this type of log");
                return;
            }

            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void ExceptionTypeWasntConfiguredToSaveWarning()
        {
            try
            {
                CJobLogger _jobLogger = new CJobLogger(new DJobLogger(true, true, true, true, false, true));
                _jobLogger.LogMessage("test", Enumerations.LogType.warning);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "JobLogger is not configured to save this type of log");
                return;
            }

            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void ExceptionTypeWasntConfiguredToSaveError()
        {
            try
            {
                CJobLogger _jobLogger = new CJobLogger(new DJobLogger(true, true, true, true, true, false));
                _jobLogger.LogMessage("test", Enumerations.LogType.error);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "JobLogger is not configured to save this type of log");
                return;
            }

            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void SuccessSaveLogToFile()
        {
            try
            {
                DJobLogger _DJobLogger = new DJobLogger(true, false, false, true, true, true);
                var mockILogToFile = new Mock<ILogToFile>();
                mockILogToFile.Setup(x => x.LogMessageToFile(It.IsAny<string>()));
                _DJobLogger.LogMsgToFile = mockILogToFile.Object;

                _DJobLogger.LogMessage("test", Enumerations.LogType.message);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                return;
            }
        }

        [TestMethod]
        public void ExceptionLogToFile()
        {
            DJobLogger _DJobLogger = new DJobLogger(true, false, false, true, true, true);
            var mockILogToFile = new Mock<ILogToFile>();
            mockILogToFile.Setup(x => x.LogMessageToFile(It.IsAny<string>())).Throws(new Exception("Exception when trying to write to log file"));
            _DJobLogger.LogMsgToFile = mockILogToFile.Object;

            try
            {
                _DJobLogger.LogMessage("test", Enumerations.LogType.message);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Excepcion al intentar registrar el mensaje");
                return;
            }

            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void SuccessSaveLogToDataBase()
        {
            try
            {
                DJobLogger _DJobLogger = new DJobLogger(false, true, false, true, true, true);
                var mockILogToDataBase = new Mock<ILogToDataBase>();
                mockILogToDataBase.Setup(x => x.LogMessageToDataBase(It.IsAny<string>(), It.IsAny<int>())).Returns(1);
                _DJobLogger.LogMsgToDataBase = mockILogToDataBase.Object;

                _DJobLogger.LogMessage("test", Enumerations.LogType.message);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                return;
            }
        }

        [TestMethod]
        public void ExceptionLogToDataBase()
        {
            try
            {
                DJobLogger _DJobLogger = new DJobLogger(false, true, false, true, true, true);
                var mockILogToDataBase = new Mock<ILogToDataBase>();
                mockILogToDataBase.Setup(x => x.LogMessageToDataBase(It.IsAny<string>(), It.IsAny<int>())).Throws(new Exception("An Exception occurs when try to save message to DataBase"));
                _DJobLogger.LogMsgToDataBase = mockILogToDataBase.Object;

                _DJobLogger.LogMessage("test", Enumerations.LogType.message);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Excepcion al intentar registrar el mensaje"); ;
                return;
            }
        }


    }
}

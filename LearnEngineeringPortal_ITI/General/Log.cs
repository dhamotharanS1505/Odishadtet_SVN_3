using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Collections.ObjectModel;
using System.Collections;


namespace Odishadtet.General
{
    public class Log
    {
        private static log4net.ILog logger  = log4net.LogManager.GetLogger("File");

        public static void WriteLogMessage(string pagename,string functionality, string funcName, string Message, string LogType)
        {
            try
            {
                string Logfilepath = ConfigurationManager.AppSettings["logpath"];
                string tmp = Logfilepath + pagename ;

                //Directory.CreateDirectory(tmp);

                if (!Directory.Exists(Logfilepath + pagename)) // Check the Directory is Exists
                {
                    Directory.CreateDirectory(Logfilepath + pagename);
                }

                SetLogFileName(tmp + @"\Log_" + functionality + ".txt");

                string logMsg = DateTime.Now.ToString("yyyy-MMM-dd HH:mm:ss") + " ERROR File - " + pagename + "- (Event Handler) " + funcName + " error is - " + Message;
               
                if (LogType.Trim().ToLower() == "info")
                {
                    logger.Info(Message);
                }
                else if (LogType.Trim().ToLower() == "error")
                {
                    Logfile(tmp + @"\Log_" + functionality + ".txt", logMsg);
                    logger.Error(Message);
                }
                else
                {
                    logger.Warn(Message);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void SetLogFileName(string logFileName)
        {
            try
            {
                ChangeLogFileName("RollingFileAppender", logFileName);
            }
            catch
            {
            }
        }

        public static void Logfile(string logpath, string MsgInfo)
        {
            string[] LogInfo = new string[] { MsgInfo };


            //Session["dumpfile"] = Server.MapPath("~/dumpfiles/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "/" + _spotCenter + "/" + UpFileUpload1.FileName);
           
            using (StreamWriter sw = File.AppendText(logpath))
            {
                foreach (string s in LogInfo)
                {
                    sw.WriteLine(s);
                    sw.Close();
                    sw.Dispose();

                }
            }
        }

        public static bool ChangeLogFileName(string AppenderName, string NewFilename)
        {

            Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/") as System.Configuration.Configuration;
            log4net.Repository.ILoggerRepository RootRep;
            RootRep = log4net.LogManager.GetRepository();

            foreach (log4net.Appender.IAppender iApp in RootRep.GetAppenders())
            {
                if (iApp.Name.CompareTo(AppenderName) == 0
                                       && iApp is log4net.Appender.RollingFileAppender)
                {
                    log4net.Appender.RollingFileAppender fApp = (log4net.Appender.RollingFileAppender)iApp;
                    fApp.File = NewFilename;
                    fApp.ActivateOptions();
                    return true;  // Appender found and name changed to NewFilename
                }
            }

            return false; // appender not found
        }
    }
}
using Odishadtet.DAL;
using System;
using System.Diagnostics;
using Odishadtet.DAL;

namespace LearnEngineeringPortalService_ITI
{

    public class propErrorDetails
    {
        /// <summary>
        /// Return exception description.
        /// </summary>
        public string errorName { get; set; }
        /// <summary>
        /// Return system error code.
        /// </summary>
        public Int32 errorCode { get; set; }
        /// <summary>
        /// Return current process whether is error or not.
        /// </summary>
        public bool isError { get; set; }
        /// <summary>
        /// Return error category.ex INFORMATION,SUCCESS
        /// </summary>
        public string errorCategory { get; set; }
        /// <summary>
        /// Return error title.
        /// </summary>
        public string errorTitle { get; set; }
        /// <summary>
        /// Return error page name.
        /// </summary>
        public string errorPage { get; set; }
        /// <summary>
        /// Return error function name.
        /// </summary>
        public string errorFunction { get; set; }
        /// <summary>
        /// Return error line at the function.
        /// </summary>
        public Int32 errorLine { get; set; }

        /// <summary>
        /// Return error column at the function.
        /// </summary>
        public Int32 errorColumn { get; set; }

        /// <summary>
        /// Return error type.ex. null pointer exception,arthematic exception,etc.
        /// </summary>
        public string errorType { get; set; }

        /// <summary>
        /// Return error stacktrace.full details about the error
        /// </summary>
        public string StackTrace { get; set; }

       
       
    }

     
    public class ExceptionStorage
    {
       
        public static string saveExceptionFromService(Exception excep,string pageName,string methodName)
        {
            propErrorDetails returnStatus = new propErrorDetails();
            //Get a StackTrace object for the exception
            learnengg_payment_portal_entities sdce = new learnengg_payment_portal_entities();
            try
            {
                StackTrace st = new StackTrace(excep, true);
                //Get the first stack frame
                StackFrame frame = st.GetFrame(0);
                returnStatus.isError = true;
                returnStatus.errorName = excep.InnerException == null ? excep.Message : excep.InnerException.Message;
                returnStatus.errorType = excep.GetType().Name;
                returnStatus.errorFunction = methodName == null ? frame.GetMethod().Name : methodName;
                returnStatus.errorPage = pageName + " -->" + returnStatus.errorFunction;
                returnStatus.errorCode = System.Runtime.InteropServices.Marshal.GetExceptionCode();
                returnStatus.errorColumn = frame.GetFileColumnNumber();
                returnStatus.errorLine = frame.GetFileLineNumber();
                returnStatus.StackTrace = excep.StackTrace;
                //Save Exception Details
                               
                 string Source = excep.Source.ToString();
                 string TargetSiteName = excep.TargetSite.Name;
                 string TargetSiteModule = excep.TargetSite.Module.Name;
                 string HelpLink = excep.HelpLink;
                 //sdce.InsertException(returnStatus.errorType, returnStatus.errorName, Source, returnStatus.errorPage, TargetSiteModule, TargetSiteName, returnStatus.StackTrace, HelpLink, false, returnStatus.errorColumn, returnStatus.errorLine);
            }
            catch
            {
                return "Failed to Store Exception in DataBase";  
            }
            return "Exception Stored in DataBase";
        }


        public static string saveException(string errorType, string errorMessage, string errorFunction, string errorPage, int errorColumn, int errorLine, string StackTrace, string Source, string TargetSiteName, string TargetSiteModule, string HelpLink)
        {
            propErrorDetails returnStatus = new propErrorDetails();
            //Get a StackTrace object for the exception
            learnengg_payment_portal_entities sdce = new learnengg_payment_portal_entities();
            try
            {
               // sdce.InsertException(errorType, errorMessage, Source, errorPage, TargetSiteModule, TargetSiteName, StackTrace, HelpLink, true, errorColumn, errorLine);
            }
            catch
            {
                return "Failed to Store Exception in DataBase";
            }
            return "Exception Stored in DataBase";
        }
    }
}
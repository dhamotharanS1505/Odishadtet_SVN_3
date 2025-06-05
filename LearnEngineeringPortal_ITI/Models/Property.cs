using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Odishadtet.Models
{
    public class Property
    {
    }

    public class propErrorDetails
    {
        /// <summary>
        /// Return current process whether is error or not.
        /// </summary>
        public bool isError { get; set; }

        /// <summary>
        /// Return error title.
        /// </summary>
        public string errorTitle { get; set; }


        /// <summary>
        /// Return exception description.
        /// </summary>
        public string errorMessage { get; set; }


        /// <summary>
        /// Return single integer value.
        /// </summary>
        public Int32 returnIntValue { get; set; }

        /// <summary>
        /// Return single string value.
        /// </summary>
        public string returnStringValue { get; set; }

        /// <summary>
        /// Return single bool value.
        /// </summary>
        public bool returnBoolValue { get; set; }
    }
    
}
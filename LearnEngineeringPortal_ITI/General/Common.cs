using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Odishadtet.General
{
    public class Common
    {
        public static string CroppedImageserverUpload_New(string img, string UserID)
        {
            //ApplicationUserLoginDefaultValues loggedInDetails = new ApplicationUserLoginDefaultValues();
            //getting the image url
            string imageDataURL = string.Format("data:image/png;base64,{0}", img);

            string subpath = "~/Content/img/ProfileImg";
            string returnpath = "../Content/img/ProfileImg";
            bool exists = System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(subpath));

            if (!exists)
            {
                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(subpath));
            }

            string base64 = img.Substring(img.IndexOf(',') + 1);
            base64 = base64.Trim('\0');
            byte[] chartData = Convert.FromBase64String(base64);

            System.Drawing.Image newImage;
            string imageName = "/" + UserID + ".jpg";
            string strFileName = HttpContext.Current.Server.MapPath(subpath) + imageName;
            if (chartData != null)
            {
                using (MemoryStream stream = new MemoryStream(chartData))
                {
                    newImage = System.Drawing.Image.FromStream(stream);

                    if (File.Exists(strFileName))
                    {
                        File.Delete(strFileName);
                    }

                    newImage.Save(strFileName);
                }
            }
            // before return save it to DB

            //
            return (returnpath + imageName);
        }
    }

    static class StringDateParseExt
    {
        /// <summary>
        /// Safes the parse.
        /// </summary>
        /// <param name="any">Any.</param>
        /// <returns></returns>
        public static DateTime SafeParse(this string any)
        {
            try
            {
                DateTime parsedDate;
                DateTime.TryParseExact(any,
                      "dd-mm-yyyy",
                      System.Globalization.CultureInfo.InvariantCulture,
                      System.Globalization.DateTimeStyles.None,
                      out parsedDate);
                return parsedDate;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
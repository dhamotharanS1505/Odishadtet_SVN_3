using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace LearnEnggPaymentPortal
{
    public class EncryptionDecryption
    {

        public string encrptpwd(string pwd, bool hasing)
        {
            byte[] keyarray;
            byte[] encryptarray = UTF8Encoding.UTF8.GetBytes(pwd);
            AppSettingsReader settingsReader = new AppSettingsReader();

            string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));

            if (hasing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyarray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
            {
                keyarray = UTF8Encoding.UTF8.GetBytes(key);
            }
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyarray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform ctransform = tdes.CreateEncryptor();
            byte[] resultarray = ctransform.TransformFinalBlock(encryptarray, 0, encryptarray.Length);
            tdes.Clear();

            return Convert.ToBase64String(resultarray, 0, resultarray.Length);
        }

        public string Decryptpwd(string pwd, bool hasing)
        {
            byte[] keyarray;
            byte[] encryptarray = Convert.FromBase64String(pwd);
            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
            if (hasing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyarray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
            {
                keyarray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyarray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform ctransform = tdes.CreateDecryptor();
            byte[] resultarray = ctransform.TransformFinalBlock(encryptarray, 0, encryptarray.Length);
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultarray);
        }


        //public string AecDecrypt(string encryptedBase64, string passphrase)
        //{
        //    byte[] encryptedBytes = Convert.FromBase64String(encryptedBase64);

        //    // Check if the string starts with "Salted__" (8 bytes)
        //    byte[] saltHeader = new byte[8];
        //    Array.Copy(encryptedBytes, 0, saltHeader, 0, 8);
        //    string header = Encoding.ASCII.GetString(saltHeader);
        //    if (header != "Salted__")
        //        throw new Exception("Invalid format: no Salted__ header.");

        //    byte[] salt = new byte[8];
        //    Array.Copy(encryptedBytes, 8, salt, 0, 8);

        //    byte[] key, iv;
        //    DeriveKeyAndIV(Encoding.UTF8.GetBytes(passphrase), salt, out key, out iv);

        //    byte[] cipherText = new byte[encryptedBytes.Length - 16];
        //    Array.Copy(encryptedBytes, 16, cipherText, 0, cipherText.Length);

        //    using (Aes aes = Aes.Create())
        //    {
        //        aes.Key = key;
        //        aes.IV = iv;
        //        aes.Mode = CipherMode.CBC;
        //        aes.Padding = PaddingMode.PKCS7;

        //        using (MemoryStream ms = new MemoryStream(cipherText))
        //        using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
        //        using (StreamReader reader = new StreamReader(cs))
        //        {
        //            return reader.ReadToEnd();
        //        }
        //    }
        //}

        //private void DeriveKeyAndIV(byte[] password, byte[] salt, out byte[] key, out byte[] iv)
        //{
        //    List<byte> keyIv = new List<byte>();
        //    byte[] previous = Array.Empty<byte>();
        //    using (var md5 = MD5.Create())
        //    {
        //        while (keyIv.Count < 32) // 16 bytes for key + 16 bytes for IV
        //        {
        //            byte[] combined = new byte[previous.Length + password.Length + salt.Length];
        //            Buffer.BlockCopy(previous, 0, combined, 0, previous.Length);
        //            Buffer.BlockCopy(password, 0, combined, previous.Length, password.Length);
        //            Buffer.BlockCopy(salt, 0, combined, previous.Length + password.Length, salt.Length);

        //            previous = md5.ComputeHash(combined);
        //            keyIv.AddRange(previous);
        //        }
        //    }

        //    byte[] keyIvBytes = keyIv.ToArray();
        //    key = new byte[16];
        //    iv = new byte[16];
        //    Array.Copy(keyIvBytes, 0, key, 0, 16);
        //    Array.Copy(keyIvBytes, 16, iv, 0, 16);
        //}
    }
}
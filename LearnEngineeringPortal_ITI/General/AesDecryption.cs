using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Modes;

namespace Odishadtet.General
{
    public class AesDecryption
    {
        public string DecryptCryptoJsAes(string encryptedBase64, string passphrase)
        {
            byte[] encrypted = Convert.FromBase64String(encryptedBase64);

            // Read salt from encrypted data (OpenSSL format: Salted__ + 8 bytes of salt)
            byte[] saltHeader = new byte[8];
            Array.Copy(encrypted, 0, saltHeader, 0, 8);
            string saltHeaderStr = Encoding.ASCII.GetString(saltHeader);

            if (saltHeaderStr != "Salted__")
                throw new ArgumentException("Invalid salt header");

            byte[] salt = new byte[8];
            Array.Copy(encrypted, 8, salt, 0, 8);

            // Derive key and IV
            byte[] keyIv = new byte[32 + 16]; // 32 bytes key + 16 bytes IV for AES-256
            byte[] passBytes = Encoding.UTF8.GetBytes(passphrase);
            byte[] prev = new byte[0];
            int i = 0;
            while (i < keyIv.Length)
            {
                byte[] data = new byte[prev.Length + passBytes.Length + salt.Length];
                Buffer.BlockCopy(prev, 0, data, 0, prev.Length);
                Buffer.BlockCopy(passBytes, 0, data, prev.Length, passBytes.Length);
                Buffer.BlockCopy(salt, 0, data, prev.Length + passBytes.Length, salt.Length);

                using (MD5 md5 = MD5.Create())
                {
                    prev = md5.ComputeHash(data);
                }

                Buffer.BlockCopy(prev, 0, keyIv, i, prev.Length);
                i += prev.Length;
            }

            byte[] key = new byte[32];
            byte[] iv = new byte[16];
            Buffer.BlockCopy(keyIv, 0, key, 0, 32);
            Buffer.BlockCopy(keyIv, 32, iv, 0, 16);

            // Decrypt
            byte[] ciphertextBytes = new byte[encrypted.Length - 16]; // Exclude Salted__ + salt
            Buffer.BlockCopy(encrypted, 16, ciphertextBytes, 0, ciphertextBytes.Length);

            IBufferedCipher cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(new AesEngine()));
            cipher.Init(false, new ParametersWithIV(new KeyParameter(key), iv));

            byte[] output = new byte[cipher.GetOutputSize(ciphertextBytes.Length)];
            int len = cipher.ProcessBytes(ciphertextBytes, 0, ciphertextBytes.Length, output, 0);
            len += cipher.DoFinal(output, len);

            return Encoding.UTF8.GetString(output, 0, len);
        }
    }
    }
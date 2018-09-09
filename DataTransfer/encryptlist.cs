using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    class EncryptList
    {
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="encryptionStr"></param>
        /// <returns></returns>
        public string Des3Encryption(string encryptionStr, string key)
        {
            TripleDESCryptoServiceProvider _pTripDes = new TripleDESCryptoServiceProvider();
            _pTripDes.Key = Encoding.UTF8.GetBytes(key);       //"P29fp2Ob439YeoHKbtrtQ50V"
            _pTripDes.Mode = CipherMode.ECB;
            _pTripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            try
            {
                ICryptoTransform ery = _pTripDes.CreateEncryptor();
                byte[] buffer = Encoding.UTF8.GetBytes(encryptionStr);
                return Convert.ToBase64String(ery.TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="decryptioStr"></param>
        /// <returns></returns>
        public string Des3Decryption(string decryptioStr, string key)
        {
            TripleDESCryptoServiceProvider _pTripDes = new TripleDESCryptoServiceProvider();
            _pTripDes.Key = Encoding.UTF8.GetBytes(key);       //"P29fp2Ob439YeoHKbtrtQ50V"
            _pTripDes.Mode = CipherMode.ECB;
            _pTripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            try
            {
                ICryptoTransform cry = _pTripDes.CreateDecryptor();
                byte[] buffer = Convert.FromBase64String(decryptioStr);
                byte[] tempBuffer = cry.TransformFinalBlock(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(tempBuffer, 0, tempBuffer.Length);
            }
            catch
            {
                return string.Empty;
            }
        }
        public string DesEncryption(string encryptionStr, string key)
        {
            DESCryptoServiceProvider _pTripDes = new DESCryptoServiceProvider();
            _pTripDes.Key = Encoding.UTF8.GetBytes(key);
            _pTripDes.Mode = CipherMode.ECB;
            _pTripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            try
            {
                ICryptoTransform ery = _pTripDes.CreateEncryptor();
                byte[] buffer = Encoding.UTF8.GetBytes(encryptionStr);
                return Convert.ToBase64String(ery.TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch
            {
                return string.Empty;
            }
        }
        public string DesDecryption(string decryptioStr, string key)
        {
            DESCryptoServiceProvider _pTripDes = new DESCryptoServiceProvider();
            _pTripDes.Key = Encoding.UTF8.GetBytes(key);
            _pTripDes.Mode = CipherMode.ECB;
            _pTripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            try
            {
                ICryptoTransform cry = _pTripDes.CreateDecryptor();
                byte[] buffer = Convert.FromBase64String(decryptioStr);
                byte[] tempBuffer = cry.TransformFinalBlock(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(tempBuffer, 0, tempBuffer.Length);
            }
            catch
            {
                return string.Empty;
            }
        }
        public string AesEncryption(string toEncrypt, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public string AesDecryption(string toDecrypt, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}

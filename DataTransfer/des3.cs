using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    class des3
    {
        //TripleDESCryptoServiceProvider _pTripDes = new TripleDESCryptoServiceProvider();
        //public des3(string key)
        //{
        //    _pTripDes.Key = Encoding.UTF8.GetBytes(key);
        //    _pTripDes.Mode = CipherMode.ECB;
        //    _pTripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
        //}

        ///// <summary>
        ///// 加密字符串
        ///// </summary>
        ///// <param name="encryptionStr"></param>
        ///// <returns></returns>
        //public string Encryption(string encryptionStr)
        //{
        //    try
        //    {
        //        ICryptoTransform ery = _pTripDes.CreateEncryptor();
        //        byte[] buffer = Encoding.UTF8.GetBytes(encryptionStr);
        //        return Convert.ToBase64String(ery.TransformFinalBlock(buffer, 0, buffer.Length));
        //    }
        //    catch (Exception ex)
        //    {
        //        return string.Empty;
        //    }
        //}

        ///// <summary>
        ///// 解密字符串
        ///// </summary>
        ///// <param name="decryptioStr"></param>
        ///// <returns></returns>
        //public string Decryption(string decryptioStr)
        //{
        //    try
        //    {
        //        ICryptoTransform cry = _pTripDes.CreateDecryptor();
        //        byte[] buffer = Convert.FromBase64String(decryptioStr);
        //        byte[] tempBuffer = cry.TransformFinalBlock(buffer, 0, buffer.Length);
        //        return Encoding.UTF8.GetString(tempBuffer, 0, tempBuffer.Length);
        //    }
        //    catch (Exception ex)
        //    {
        //        return string.Empty;
        //    }
        //}


//"cabf0ESZ1PRoCikPB9QM1YvZmTd2yRawKeVzQHkzTz25om2kLWijWT9djWAzPTIOvMLHOXEtwDEbYRXzbHjtfHmBoArUkgEaTlX/lcrMnfwqe9Xcji8BGWsXcg2foO1fHJRqKvzxrjOXsYbZd7N4IUSFLwDQ+OTe"
        TripleDESCryptoServiceProvider _pTripDes = new TripleDESCryptoServiceProvider();
        public des3()
        {
            _pTripDes.Key = Encoding.UTF8.GetBytes("P29fp2Ob439YeoHKbtrtQ50V");//"P29fp2Ob439YeoHKbtrtQ50V" // "iUh7gY7BfOiaopQavb51E48G"
            _pTripDes.Mode = CipherMode.ECB;
            _pTripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

        }
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="encryptionStr"></param>
        /// <returns></returns>
        public string Encryption(string encryptionStr)
        {
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
        public string Decryption(string decryptioStr)
        {
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
        /*
        private System.Text.Encoding encoding;
        private string Key = "01234567";
        public void Crypto3DES(string key)
        {
            this.Key = key;
        }
            public void Crypto3DES()
        {
        }
        public System.Text.Encoding Encoding
        {
            get
            {
                if (encoding == null)
                {
                    encoding = System.Text.Encoding.UTF8;
                }
                return encoding;        
            }
            set
            {
                encoding = value;
            }
        }
        public string Encrypt3DES(string strString)
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.KeySize = 2;
            DES.Key = Encoding.GetBytes(this.Key);
            DES.Mode = CipherMode.ECB;
            DES.Padding = PaddingMode.Zeros;
            ICryptoTransform DESEncrypt = DES.CreateEncryptor();
            byte[] Buffer = encoding.GetBytes(strString);
            return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }
        public string Decrypt3DES(string strString)
        {
            try
            {
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = Encoding.UTF8.GetBytes(this.Key);
                DES.Mode = CipherMode.ECB;
                DES.Padding = PaddingMode.Zeros;
                ICryptoTransform DESDecrypt = DES.CreateDecryptor();
                byte[] Buffer = Convert.FromBase64String(strString);
                return UTF8Encoding.UTF8.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch
            {
                return string.Empty;
            }
        }*/
    }
}

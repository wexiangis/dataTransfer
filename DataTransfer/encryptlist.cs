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

        private void CopyDirectory(string srcPath, string desPath)
        {
            string folderName = srcPath.Substring(srcPath.LastIndexOf("\\") + 1);

            string desfolderdir = desPath + "\\" + folderName;

            if (srcPath.LastIndexOf("\\") == (desPath.Length - 1))
                desfolderdir = desPath + folderName;

            string[] filenames = Directory.GetFileSystemEntries(srcPath);

            foreach (string file in filenames)
            {
                if (Directory.Exists(file))
                {

                    string currentdir = desfolderdir + "\\" + file.Substring(file.LastIndexOf("\\") + 1);
                    if (!Directory.Exists(currentdir))
                    {
                        Directory.CreateDirectory(currentdir);
                    }

                    CopyDirectory(file, desfolderdir);
                }

                else
                {
                    string srcfileName = file.Substring(file.LastIndexOf("\\") + 1);

                    srcfileName = desfolderdir + "\\" + srcfileName;


                    if (!Directory.Exists(desfolderdir))
                    {
                        Directory.CreateDirectory(desfolderdir);
                    }


                    File.Copy(file, srcfileName);
                }
            }
        }

        /// <summary>

        /// DES3

        /// </summary>

        /// <param name="encryptionStr"></param>

        /// <param name="key"></param>

        /// <returns></returns>

        public string Des3Encryption(string encryptionStr, string key)
        {

            TripleDESCryptoServiceProvider _pTripDes = new TripleDESCryptoServiceProvider();

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

        public byte[] Des3Encryption(byte[] encryptionArray, string key)
        {

            TripleDESCryptoServiceProvider _pTripDes = new TripleDESCryptoServiceProvider();

            _pTripDes.Key = Encoding.UTF8.GetBytes(key);

            _pTripDes.Mode = CipherMode.ECB;

            _pTripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            try
            {

                ICryptoTransform ery = _pTripDes.CreateEncryptor();

                return ery.TransformFinalBlock(encryptionArray, 0, encryptionArray.Length);

            }

            catch
            {

                return null;

            }

        }

        public string Des3Decryption(string decryptionStr, string key)
        {

            TripleDESCryptoServiceProvider _pTripDes = new TripleDESCryptoServiceProvider();

            _pTripDes.Key = Encoding.UTF8.GetBytes(key);

            _pTripDes.Mode = CipherMode.ECB;

            _pTripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            try
            {

                ICryptoTransform cry = _pTripDes.CreateDecryptor();

                byte[] buffer = Convert.FromBase64String(decryptionStr);

                byte[] tempBuffer = cry.TransformFinalBlock(buffer, 0, buffer.Length);

                return Encoding.UTF8.GetString(tempBuffer, 0, tempBuffer.Length);

            }

            catch
            {

                return string.Empty;

            }

        }

        public byte[] Des3Decryption(byte[] decryptionArray, string key)
        {

            TripleDESCryptoServiceProvider _pTripDes = new TripleDESCryptoServiceProvider();

            _pTripDes.Key = Encoding.UTF8.GetBytes(key);

            _pTripDes.Mode = CipherMode.ECB;

            _pTripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            try
            {

                ICryptoTransform cry = _pTripDes.CreateDecryptor();

                return cry.TransformFinalBlock(decryptionArray, 0, decryptionArray.Length);

            }

            catch
            {

                return null;

            }

        }

        public int Des3EncryptionFile(string filePath, string ditPath, string key, bool isEncrypt)
        {

            int len = 1024 * 1024;    // 每次 "读-解密-写" 1M数据

            byte[] des_tail = Des3Encryption(new byte[0], key);

            byte[] read_byte;

            byte[] dpt_byte = null;

            int ret = len;

            int rC = 0, rCL = 0, len2 = 0;

            try
            {

                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);

                if (fileInfo.Length == 0)
                {

                    File.Delete(ditPath);

                    File.Create(ditPath);

                    return 0;
                }

                if (isEncrypt)
                {

                    if (fileInfo.Length < len)

                        len = (int)(fileInfo.Length);

                    //

                    read_byte = new byte[len];

                }

                else
                {

                    if (fileInfo.Length % 8 != 0)

                        return -1;

                    //

                    if (fileInfo.Length % len == 0)
                    {

                        rCL = (int)(fileInfo.Length / len - 1);

                        len2 = len;

                    }

                    else
                    {

                        rCL = (int)(fileInfo.Length / len);

                        len2 = (int)(fileInfo.Length % len);

                    }

                    //

                    read_byte = new byte[len + des_tail.Length];

                    Buffer.BlockCopy(des_tail, 0, read_byte, len, des_tail.Length);   //1M数据缓冲区 加尾巴

                }

                //

                ret = len;

                //

                FileStream write_fileStream = new FileStream(ditPath, FileMode.Create, FileAccess.Write);

                FileStream read_fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                if (isEncrypt)
                {

                    while (ret == len)
                    {

                        //读数据

                        ret = read_fileStream.Read(read_byte, 0, len);

                        //

                        if (ret == len)

                            dpt_byte = this.Des3Encryption(read_byte, key);

                        else if (ret < len && ret > 0)
                        {

                            byte[] temp_byte = new byte[ret];

                            Buffer.BlockCopy(read_byte, 0, temp_byte, 0, ret);

                            dpt_byte = this.Des3Encryption(temp_byte, key);

                        }

                        else

                            break;

                        //

                        if (dpt_byte == null)

                            break;  //"err"

                        //写数据

                        write_fileStream.Write(dpt_byte, 0, dpt_byte.Length);

                    }

                }

                else
                {

                    while (rC < rCL)
                    {

                        //读数据

                        ret = read_fileStream.Read(read_byte, 0, len);

                        //

                        if (ret == len)
                        {

                            rC += 1;

                            //解密数据

                            dpt_byte = this.Des3Decryption(read_byte, key);

                            //

                            if (dpt_byte == null)

                                break;  //"err"

                            //写数据

                            write_fileStream.Write(dpt_byte, 0, ret);

                        }

                        else

                            break;

                    }

                }

                //

                if (len2 > 0)
                {

                    ret = read_fileStream.Read(read_byte, 0, len2);

                    //解密

                    if (ret > 0 && ret % 8 == 0)
                    {

                        //自带尾巴?

                        byte[] temp_byte = new byte[ret];

                        Buffer.BlockCopy(read_byte, 0, temp_byte, 0, ret);

                        dpt_byte = this.Des3Decryption(temp_byte, key);

                        //

                        if (dpt_byte == null)
                        {

                            //补上尾巴 再次尝试

                            temp_byte = new byte[ret + des_tail.Length];

                            Buffer.BlockCopy(read_byte, 0, temp_byte, 0, ret);

                            Buffer.BlockCopy(des_tail, 0, temp_byte, ret, des_tail.Length);

                            dpt_byte = this.Des3Decryption(temp_byte, key);

                        }

                        //

                        if (dpt_byte != null)

                            write_fileStream.Write(dpt_byte, 0, dpt_byte.Length);

                    }

                }

                //

                read_fileStream.Close();

                write_fileStream.Close();

            }

            catch (IOException)
            {

                return -2;  //"err"

            }

            return 0;

        }

        /// <summary>

        /// DES

        /// </summary>

        /// <param name="encryptionStr"></param>

        /// <param name="key"></param>

        /// <returns></returns>

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

        public byte[] DesEncryption(byte[] encryptionArray, string key)
        {

            DESCryptoServiceProvider _pTripDes = new DESCryptoServiceProvider();

            _pTripDes.Key = Encoding.UTF8.GetBytes(key);

            _pTripDes.Mode = CipherMode.ECB;

            _pTripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            try
            {

                ICryptoTransform ery = _pTripDes.CreateEncryptor();

                return ery.TransformFinalBlock(encryptionArray, 0, encryptionArray.Length);

            }

            catch
            {

                return null;

            }

        }

        public string DesDecryption(string decryptionStr, string key)
        {

            DESCryptoServiceProvider _pTripDes = new DESCryptoServiceProvider();

            _pTripDes.Key = Encoding.UTF8.GetBytes(key);

            _pTripDes.Mode = CipherMode.ECB;

            _pTripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            try
            {

                ICryptoTransform cry = _pTripDes.CreateDecryptor();

                byte[] buffer = Convert.FromBase64String(decryptionStr);

                byte[] tempBuffer = cry.TransformFinalBlock(buffer, 0, buffer.Length);

                return Encoding.UTF8.GetString(tempBuffer, 0, tempBuffer.Length);

            }

            catch
            {

                return string.Empty;

            }

        }

        public byte[] DesDecryption(byte[] decryptionArray, string key)
        {

            DESCryptoServiceProvider _pTripDes = new DESCryptoServiceProvider();

            _pTripDes.Key = Encoding.UTF8.GetBytes(key);

            _pTripDes.Mode = CipherMode.ECB;

            _pTripDes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            try
            {

                ICryptoTransform cry = _pTripDes.CreateDecryptor();

                return cry.TransformFinalBlock(decryptionArray, 0, decryptionArray.Length);

            }

            catch
            {

                return null;

            }

        }

        public int DesEncryptionFile(string filePath, string ditPath, string key, bool isEncrypt)
        {

            int len = 1024 * 1024;    // 每次 "读-解密-写" 1M数据

            byte[] des_tail = DesEncryption(new byte[0], key);

            byte[] read_byte;

            byte[] dpt_byte = null;

            int ret = len;

            int rC = 0, rCL = 0, len2 = 0;

            try
            {

                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);

                if (fileInfo.Length == 0)
                {
                    File.Delete(ditPath);

                    File.Create(ditPath);

                    return 0;
                }

                if (isEncrypt)
                {

                    if (fileInfo.Length < len)

                        len = (int)(fileInfo.Length);

                    //

                    read_byte = new byte[len];

                }

                else
                {

                    if (fileInfo.Length % 8 != 0)

                        return -1;

                    //

                    if (fileInfo.Length % len == 0)
                    {

                        rCL = (int)(fileInfo.Length / len - 1);

                        len2 = len;

                    }

                    else
                    {

                        rCL = (int)(fileInfo.Length / len);

                        len2 = (int)(fileInfo.Length % len);

                    }

                    //

                    read_byte = new byte[len + des_tail.Length];

                    Buffer.BlockCopy(des_tail, 0, read_byte, len, des_tail.Length);   //1M数据缓冲区 加尾巴

                }

                //

                ret = len;

                //

                FileStream write_fileStream = new FileStream(ditPath, FileMode.Create, FileAccess.Write);

                FileStream read_fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                if (isEncrypt)
                {

                    while (ret == len)
                    {

                        //读数据

                        ret = read_fileStream.Read(read_byte, 0, len);

                        //

                        if (ret == len)

                            dpt_byte = this.DesEncryption(read_byte, key);

                        else if (ret < len && ret > 0)
                        {

                            byte[] temp_byte = new byte[ret];

                            Buffer.BlockCopy(read_byte, 0, temp_byte, 0, ret);

                            dpt_byte = this.DesEncryption(temp_byte, key);

                        }

                        else

                            break;

                        //

                        if (dpt_byte == null)

                            break;  //"err"

                        //写数据

                        write_fileStream.Write(dpt_byte, 0, dpt_byte.Length);

                    }

                }

                else
                {

                    while (rC < rCL)
                    {

                        //读数据

                        ret = read_fileStream.Read(read_byte, 0, len);

                        //

                        if (ret == len)
                        {

                            rC += 1;

                            //解密数据

                            dpt_byte = this.DesDecryption(read_byte, key);

                            //

                            if (dpt_byte == null)

                                break;  //"err"

                            //写数据

                            write_fileStream.Write(dpt_byte, 0, ret);

                        }

                        else

                            break;

                    }

                }

                //

                if (len2 > 0)
                {

                    ret = read_fileStream.Read(read_byte, 0, len2);

                    //解密

                    if (ret > 0 && ret % 8 == 0)
                    {

                        //自带尾巴?

                        byte[] temp_byte = new byte[ret];

                        Buffer.BlockCopy(read_byte, 0, temp_byte, 0, ret);

                        dpt_byte = this.DesDecryption(temp_byte, key);

                        //

                        if (dpt_byte == null)
                        {

                            //补上尾巴 再次尝试

                            temp_byte = new byte[ret + des_tail.Length];

                            Buffer.BlockCopy(read_byte, 0, temp_byte, 0, ret);

                            Buffer.BlockCopy(des_tail, 0, temp_byte, ret, des_tail.Length);

                            dpt_byte = this.DesDecryption(temp_byte, key);

                        }

                        //

                        if (dpt_byte != null)

                            write_fileStream.Write(dpt_byte, 0, dpt_byte.Length);

                    }

                }

                //

                read_fileStream.Close();

                write_fileStream.Close();

            }

            catch (IOException)
            {

                return -2;  //"err"

            }

            return 0;

        }

        /// <summary>

        /// AES

        /// </summary>

        /// <param name="toEncrypt"></param>

        /// <param name="key"></param>

        /// <returns></returns>

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

        public byte[] AesEncryption(byte[] toEncryptArray, string key)
        {

            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);



            RijndaelManaged rDel = new RijndaelManaged();

            rDel.Key = keyArray;

            rDel.Mode = CipherMode.ECB;

            rDel.Padding = PaddingMode.PKCS7;

            byte[] resultArray = new byte[1] { 0 };

            try
            {

                ICryptoTransform cTransform = rDel.CreateEncryptor();

                resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return resultArray;

            }

            catch { }

            return null;

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

        public byte[] AesDecryption(byte[] toEncryptArray, string key)
        {

            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);

            RijndaelManaged rDel = new RijndaelManaged();

            rDel.Key = keyArray;

            rDel.Mode = CipherMode.ECB;

            rDel.Padding = PaddingMode.PKCS7;

            byte[] resultArray = new byte[1] { 0 };

            try
            {

                ICryptoTransform cTransform = rDel.CreateDecryptor();

                resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return resultArray;

            }

            catch { }

            return null;

        }

        public int AesEncryptionFile(string filePath, string ditPath, string key, bool isEncrypt)
        {

            int len = 1024 * 1024;    // 每次 "读-解密-写" 1M数据

            byte[] aes_tail = AesEncryption(new byte[0], key);

            byte[] read_byte;

            byte[] dpt_byte = null;

            int ret = len;

            int rC = 0, rCL = 0, len2 = 0;

            try
            {

                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);

                if (fileInfo.Length == 0)
                {
                    File.Delete(ditPath);

                    File.Create(ditPath);

                    return 0;
                }

                if (isEncrypt)
                {

                    if (fileInfo.Length < len)

                        len = (int)(fileInfo.Length);

                    //

                    read_byte = new byte[len];

                }

                else
                {

                    if (fileInfo.Length % 16 != 0)

                        return -1;

                    //

                    if (fileInfo.Length % len == 0)
                    {

                        rCL = (int)(fileInfo.Length / len - 1);

                        len2 = len;

                    }

                    else
                    {

                        rCL = (int)(fileInfo.Length / len);

                        len2 = (int)(fileInfo.Length % len);

                    }

                    //

                    read_byte = new byte[len + aes_tail.Length];

                    Buffer.BlockCopy(aes_tail, 0, read_byte, len, aes_tail.Length);   //1M数据缓冲区 加尾巴

                }

                //

                ret = len;

                //

                FileStream write_fileStream = new FileStream(ditPath, FileMode.Create, FileAccess.Write);

                FileStream read_fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                if (isEncrypt)
                {

                    while (ret == len)
                    {

                        //读数据

                        ret = read_fileStream.Read(read_byte, 0, len);

                        //

                        if (ret == len)

                            dpt_byte = this.AesEncryption(read_byte, key);

                        else if (ret < len && ret > 0)
                        {

                            byte[] temp_byte = new byte[ret];

                            Buffer.BlockCopy(read_byte, 0, temp_byte, 0, ret);

                            dpt_byte = this.AesEncryption(temp_byte, key);

                        }

                        else

                            break;

                        //

                        if (dpt_byte == null)

                            break;  //"err"

                        //写数据

                        write_fileStream.Write(dpt_byte, 0, dpt_byte.Length);

                    }

                }

                else
                {

                    while (rC < rCL)
                    {

                        //读数据

                        ret = read_fileStream.Read(read_byte, 0, len);

                        //

                        if (ret == len)
                        {

                            rC += 1;

                            //解密数据

                            dpt_byte = this.AesDecryption(read_byte, key);

                            //

                            if (dpt_byte == null)

                                break;  //"err"

                            //写数据

                            write_fileStream.Write(dpt_byte, 0, ret);

                        }

                        else

                            break;

                    }

                }

                if (len2 > 0)
                {

                    ret = read_fileStream.Read(read_byte, 0, len2);

                    //解密

                    if (ret > 0 && ret % 16 == 0)
                    {

                        //自带尾巴?

                        byte[] temp_byte = new byte[ret];

                        Buffer.BlockCopy(read_byte, 0, temp_byte, 0, ret);

                        dpt_byte = this.AesDecryption(temp_byte, key);

                        if (dpt_byte == null)
                        {

                            //补上尾巴 再次尝试

                            temp_byte = new byte[ret + aes_tail.Length];

                            Buffer.BlockCopy(read_byte, 0, temp_byte, 0, ret);

                            Buffer.BlockCopy(aes_tail, 0, temp_byte, ret, aes_tail.Length);

                            dpt_byte = this.AesDecryption(temp_byte, key);

                        }

                        if (dpt_byte != null)

                            write_fileStream.Write(dpt_byte, 0, dpt_byte.Length);

                    }

                }

                read_fileStream.Close();

                write_fileStream.Close();

            }

            catch (IOException)
            {

                return -2;  //"err"

            }

            return 0;

        }

        /// <summary> https://github.com/kenro/File_Md5_Generator

        /// Md5

        /// </summary>

        /// <param name="encryptionStr"></param>

        /// <returns></returns>

        public string Md5EncryptionFile(string fileName)
        {

            try
            {

                using (FileStream file = new FileStream(fileName, FileMode.Open))
                {

                    System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

                    byte[] hash = md5.ComputeHash(file);

                    StringBuilder result = new StringBuilder();

                    for (int i = 0; i < hash.Length; i++)
                    {

                        result.Append(hash[i].ToString("x2"));

                    }

                    return result.ToString();

                }

            }

            catch
            {

                return "Md5 calculate failed !!";

            }

        }

        /*
         *  srcPath、distPath 结尾不带'\'
         *  
         *  返回: 转换文件总数(不包括文件夹)
         */
        public int EncryptDirectory(string srcPath, string distPath, string key, bool isEncrypt, Func<string, string, string, bool, int> fun)
        {
            //是文件,直接转换
            if (File.Exists(srcPath))
            {
                fun(srcPath, distPath, key, isEncrypt);

                return 1;
            }
            //是文件夹,递归遍历
            else if (Directory.Exists(srcPath))
            {
                int ret = 0;

                //创建目标文件夹
                Directory.CreateDirectory(distPath);

                //遍历源文件夹下的文件
                string[] fileList = Directory.GetFileSystemEntries(srcPath);

                foreach (string file in fileList)
                {
                    //是文件，直接转换
                    if (File.Exists(file))
                    {
                        //目标文件夹 + 当前文件名
                        string distFile = distPath + "\\" + file.Substring(file.LastIndexOf("\\") + 1);

                        fun(file, distFile, key, isEncrypt);

                        ret += 1;
                    }

                    //是文件夹，递归遍历
                    else if (Directory.Exists(file))
                    {
                        //目标文件夹 + 当前文件夹
                        string distDir = distPath + "\\" + file.Substring(file.LastIndexOf("\\") + 1);

                        //递归
                        ret += EncryptDirectory(file, distDir, key, isEncrypt, fun);
                    }
                }

                return ret;
            }
            return 0;
        }

    }

}


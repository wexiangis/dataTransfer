using System;
using System.Text;
namespace DataTransfer
{
    public class Data_transfer
    {
        private bool is_ascii = false;
        private bool is_hex16 = false;
        private bool is_hex10 = false;
        private bool is_hex2 = false;
        private bool is_insertSpace = true;
        private bool is_warmming = false;
        //
        public void setAsciiOn()
        {
            this.is_ascii = true;
            this.is_hex16 = false;
            this.is_hex10 = false;
            this.is_hex2 = false;
        }
        public void setHex16On()
        {
            this.is_ascii = false;
            this.is_hex16 = true;
            this.is_hex10 = false;
            this.is_hex2 = false;
        }
        public void setHex10On()
        {
            this.is_ascii = false;
            this.is_hex16 = false;
            this.is_hex10 = true;
            this.is_hex2 = false;
        }
        public void setHex2On()
        {
            this.is_ascii = false;
            this.is_hex16 = false;
            this.is_hex10 = false;
            this.is_hex2 = true;
        }
        //
        public void setAsciiOff()
        {
            this.is_ascii = false;
        }
        public void setHex16Off()
        {
            this.is_hex16 = false;
        }
        public void setHex10Off()
        {
            this.is_hex10 = false;
        }
        public void setHex2Off()
        {
            this.is_hex2 = false;
        }
        //
        public void setInsertSpaceOn()
        {
            this.is_insertSpace = true;
        }
        public void setInsertSpaceOff()
        {
            this.is_insertSpace = false;
        }
        //
        public void setWarmmingOn()
        {
            this.is_warmming = true;
        }
        public void setWarmmingOff()
        {
            this.is_warmming = false;
        }
        //
        public bool getAscii()
        {
            return is_ascii;
        }
        public bool getHex16()
        {
            return is_hex16;
        }
        public bool getHex10()
        {
            return is_hex10;
        }
        public bool getHex2()
        {
            return is_hex2;
        }
        public bool getInsertSpace()
        {
            return is_insertSpace;
        }
        public bool getWarmming()
        {
            return is_warmming;
        }
        //
        public string asciiToHex16(string input)
        {
            byte[] tempByte = System.Text.Encoding.ASCII.GetBytes(input);
            string tempString = "";
            for (int i = 0; i < tempByte.Length; i++ )
            {
                if (tempByte[i] < 0x80)
                    tempString += tempByte[i].ToString("X");
                else
                {
                    tempString += (tempByte[i] / 16).ToString("X");
                    tempString += (tempByte[i] % 16).ToString("X");
                }
                if (is_insertSpace)
                    tempString += " ";
            }
            return tempString;
        }
        public string asciiToHex10(string input)
        {
            byte[] tempByte = System.Text.Encoding.ASCII.GetBytes(input);
            string tempString = "";
            for (int i = 0; i < tempByte.Length; i++)
            {
                tempString += Convert.ToString(tempByte[i], 10);
                if (is_insertSpace)
                    tempString += " ";
            }
            return tempString;
        }
        public string asciiToHex2(string input)
        {
            byte[] tempByte = System.Text.Encoding.ASCII.GetBytes(input);
            string tempString = "";
            for (int i = 0; i < tempByte.Length; i++)
            {
                tempString += Convert.ToString((UInt16)tempByte[i], 2);
                if (is_insertSpace)
                    tempString += " ";
            }
            return tempString;
        }
        public string asciiToHex16_2(byte[] tempByte)
        {
            string tempString = "";
            for (int i = 0; i < tempByte.Length; i++)
            {
                if (tempByte[i] < 0x80)
                    tempString += tempByte[i].ToString("X");
                else
                {
                    tempString += (tempByte[i] / 16).ToString("X");
                    tempString += (tempByte[i] % 16).ToString("X");
                }
                if (is_insertSpace)
                    tempString += " ";
            }
            return tempString;
        }
        public string asciiToHex10_2(byte[] tempByte)
        {
            string tempString = "";
            for (int i = 0; i < tempByte.Length; i++)
            {
                if (tempByte[i] < 0x80)
                    tempString += Convert.ToString(tempByte[i], 10);
                else
                {
                    tempString += Convert.ToString((tempByte[i] / 16), 10);
                    tempString += Convert.ToString((tempByte[i] % 16), 10);
                }
                if (is_insertSpace)
                    tempString += " ";
            }
            return tempString;
        }
        public string asciiToHex2_2(byte[] tempByte)
        {
            string tempString = "";
            for (int i = 0; i < tempByte.Length; i++)
            {
                if (tempByte[i] < 0x80)
                    tempString += Convert.ToString(tempByte[i], 2);
                else
                {
                    tempString += Convert.ToString((tempByte[i] / 16), 2);
                    tempString += Convert.ToString((tempByte[i] % 16), 2);
                }
                if (is_insertSpace)
                    tempString += " ";
            }
            return tempString;
        }
        public string hex16ToAscii(string input)
        {
            byte[] temp_byte = System.Text.Encoding.ASCII.GetBytes(input);
            string tempString = "";
            UInt32 temp_uint32 = 0;
            byte[] temp_ubyte = new byte[1];
            int i = 0;
            while (i < temp_byte.Length)
            {
                temp_uint32 = 0;
                if ((temp_byte[i] >= 48 && temp_byte[i] <= 57) ||
                    (temp_byte[i] >= 65 && temp_byte[i] <= 70) ||
                    (temp_byte[i] >= 97 && temp_byte[i] <= 102))
                {
                    while ((temp_byte[i] >= 48 && temp_byte[i] <= 57) ||
                           (temp_byte[i] >= 65 && temp_byte[i] <= 70) ||
                           (temp_byte[i] >= 97 && temp_byte[i] <= 102))
                    {

                        if (temp_byte[i] >= 48 && temp_byte[i] <= 57)
                            temp_uint32 = temp_uint32 * 16 + temp_byte[i] - 48;
                        else if (temp_byte[i] >= 65 && temp_byte[i] <= 70)
                            temp_uint32 = temp_uint32 * 16 + temp_byte[i] - 65 + 10;
                        else if (temp_byte[i] >= 97 && temp_byte[i] <= 102)
                            temp_uint32 = temp_uint32 * 16 + temp_byte[i] - 97 + 10;
                        else
                        {
                            i += 1;
                            break;
                        }
                        i += 1;
                        if (i >= temp_byte.Length)
                            break;
                    }
                    if ((temp_uint32 >= 32 && temp_uint32 <= 126) || temp_uint32 == 0x0A || temp_uint32 == 0x0D)
                        tempString += (char)temp_uint32;
                    else
                        tempString += "\\x" + (temp_uint32 == 0 ? "00" : (temp_uint32 < 16 ? ("0" + temp_uint32.ToString("X")) : temp_uint32.ToString("X")));
                    
                    //if (is_insertSpace)
                    //    tempString += " ";
                    continue;
                }
                else
                    i += 1;
            }
            //
            return tempString;
        }
        public byte[] hex16ToAscii2(string input)
        {
            byte[] temp_byte = System.Text.Encoding.ASCII.GetBytes(input);
            UInt32 temp_uint32 = 0;
            //
            byte[] temp_ubyte = new byte[input.Length];
            int i = 0, ubCount = 0;
            //
            while (i < temp_byte.Length)
            {
                temp_uint32 = 0;
                if ((temp_byte[i] >= 48 && temp_byte[i] <= 57) ||
                    (temp_byte[i] >= 65 && temp_byte[i] <= 70) ||
                    (temp_byte[i] >= 97 && temp_byte[i] <= 102))
                {
                    while ((temp_byte[i] >= 48 && temp_byte[i] <= 57) ||
                           (temp_byte[i] >= 65 && temp_byte[i] <= 70) ||
                           (temp_byte[i] >= 97 && temp_byte[i] <= 102))
                    {

                        if (temp_byte[i] >= 48 && temp_byte[i] <= 57)
                            temp_uint32 = temp_uint32 * 16 + temp_byte[i] - 48;
                        else if (temp_byte[i] >= 65 && temp_byte[i] <= 70)
                            temp_uint32 = temp_uint32 * 16 + temp_byte[i] - 65 + 10;
                        else if (temp_byte[i] >= 97 && temp_byte[i] <= 102)
                            temp_uint32 = temp_uint32 * 16 + temp_byte[i] - 97 + 10;
                        else
                        {
                            i += 1;
                            break;
                        }
                        i += 1;
                        if (i >= temp_byte.Length)
                            break;
                    }
                    //
                    temp_ubyte[ubCount++] = (byte)temp_uint32;
                    //if (is_insertSpace)
                    //    temp_ubyte[ubCount++] = " ";
                    continue;
                }
                else
                    i += 1;
            }
            //
            byte[] result = new byte[ubCount];
            Array.Copy(temp_ubyte, 0, result, 0, ubCount);
            //
            return result;
        }
        public string hex16ToHex10(string input)
        {
            byte[] temp_byte = System.Text.Encoding.ASCII.GetBytes(input);
            string tempString = "";
            UInt32 temp_uint32 = 0;
            int i = 0;
            while(i < temp_byte.Length)
            {
                temp_uint32 = 0;
                if ((temp_byte[i] >= 48 && temp_byte[i] <= 57) ||
                    (temp_byte[i] >= 65 && temp_byte[i] <= 70) ||
                    (temp_byte[i] >= 97 && temp_byte[i] <= 102))
                {
                    while ((temp_byte[i] >= 48 && temp_byte[i] <= 57) ||
                           (temp_byte[i] >= 65 && temp_byte[i] <= 70) ||
                           (temp_byte[i] >= 97 && temp_byte[i] <= 102))
                    {

                        if (temp_byte[i] >= 48 && temp_byte[i] <= 57)
                            temp_uint32 = temp_uint32 * 16 + temp_byte[i] - 48;
                        else if (temp_byte[i] >= 65 && temp_byte[i] <= 70)
                            temp_uint32 = temp_uint32 * 16 + temp_byte[i] - 65 + 10;
                        else if (temp_byte[i] >= 97 && temp_byte[i] <= 102)
                            temp_uint32 = temp_uint32 * 16 + temp_byte[i] - 97 + 10;
                        else
                        {
                            i += 1;
                            break;
                        }
                        i += 1;
                        if (i >= temp_byte.Length)
                            break;
                    }
                    tempString += Convert.ToString(temp_uint32, 10);
                    if (is_insertSpace)
                        tempString += " ";
                    continue;
                }
                else
                    i += 1;
            }
            //
            return tempString;
        }
        public string hex16ToHex2(string input)
        {
            byte[] temp_byte = System.Text.Encoding.ASCII.GetBytes(input);
            string tempString = "";
            UInt32 temp_uint32 = 0;
            int i = 0;
            while (i < temp_byte.Length)
            {
                temp_uint32 = 0;
                if ((temp_byte[i] >= 48 && temp_byte[i] <= 57) ||
                    (temp_byte[i] >= 65 && temp_byte[i] <= 70) ||
                    (temp_byte[i] >= 97 && temp_byte[i] <= 102))
                {
                    while ((temp_byte[i] >= 48 && temp_byte[i] <= 57) ||
                           (temp_byte[i] >= 65 && temp_byte[i] <= 70) ||
                           (temp_byte[i] >= 97 && temp_byte[i] <= 102))
                    {

                        if (temp_byte[i] >= 48 && temp_byte[i] <= 57)
                            temp_uint32 = temp_uint32 * 16 + temp_byte[i] - 48;
                        else if (temp_byte[i] >= 65 && temp_byte[i] <= 70)
                            temp_uint32 = temp_uint32 * 16 + temp_byte[i] - 65 + 10;
                        else if (temp_byte[i] >= 97 && temp_byte[i] <= 102)
                            temp_uint32 = temp_uint32 * 16 + temp_byte[i] - 97 + 10;
                        else
                        {
                            i += 1;
                            break;
                        }
                        i += 1;
                        if (i >= temp_byte.Length)
                            break;
                    }
                    tempString += Convert.ToString(temp_uint32, 2);
                    if (is_insertSpace)
                        tempString += " ";
                    continue;
                }
                else
                    i += 1;
            }
            //
            return tempString;
        }
        public string hex10ToAscii(string input)
        {
            byte[] temp_byte = System.Text.Encoding.ASCII.GetBytes(input);
            string tempString = "";
            UInt32 temp_uint32 = 0;
            int i = 0;
            while (i < temp_byte.Length)
            {
                temp_uint32 = 0;
                if (temp_byte[i] >= 48 && temp_byte[i] <= 57)
                {
                    while (temp_byte[i] >= 48 && temp_byte[i] <= 57)
                    {

                        temp_uint32 = temp_uint32 * 10 + temp_byte[i] - 48;
                        i += 1;
                        if (i >= temp_byte.Length)
                            break;
                    }
                    if ((temp_uint32 >= 32 && temp_uint32 <= 126) || temp_uint32 == 0x0A || temp_uint32 == 0x0D)
                        tempString += (char)temp_uint32;
                    else
                        tempString += "\\x" + (temp_uint32 == 0 ? "00" : (temp_uint32 < 16 ? ("0" + temp_uint32.ToString("X")) : temp_uint32.ToString("X")));
                    
                    //if (is_insertSpace)
                    //    tempString += " ";
                    continue;
                }
                else
                    i += 1;
            }
            //
            return tempString;
        }
        public byte[] hex10ToAscii2(string input)
        {
            byte[] temp_byte = System.Text.Encoding.ASCII.GetBytes(input);
            UInt32 temp_uint32 = 0;
            //
            byte[] temp_ubyte = new byte[input.Length];
            int i = 0, ubCount = 0;
            //
            while (i < temp_byte.Length)
            {
                temp_uint32 = 0;
                if (temp_byte[i] >= 48 && temp_byte[i] <= 57)
                {
                    while (temp_byte[i] >= 48 && temp_byte[i] <= 57)
                    {

                        temp_uint32 = temp_uint32 * 10 + temp_byte[i] - 48;
                        i += 1;
                        if (i >= temp_byte.Length)
                            break;
                    }
                    //
                    temp_ubyte[ubCount++] = (byte)temp_uint32;
                    //if (is_insertSpace)
                    //    temp_ubyte[ubCount++] = " ";
                    continue;
                }
                else
                    i += 1;
            }
            //
            byte[] result = new byte[ubCount];
            Array.Copy(temp_ubyte, 0, result, 0, ubCount);
            //
            return result;
        }
        public string hex10ToHex16(string input)
        {
            byte[] temp_byte = System.Text.Encoding.ASCII.GetBytes(input);
            string tempString = "";
            UInt32 temp_uint32 = 0;
            int i = 0;
            while (i < temp_byte.Length)
            {
                temp_uint32 = 0;
                if (temp_byte[i] >= 48 && temp_byte[i] <= 57)
                {
                    while (temp_byte[i] >= 48 && temp_byte[i] <= 57)
                    {

                        temp_uint32 = temp_uint32 * 10 + temp_byte[i] - 48;
                        i += 1;
                        if (i >= temp_byte.Length)
                            break;
                    }
                    tempString += Convert.ToString(temp_uint32, 16);
                    if (is_insertSpace)
                        tempString += " ";
                    continue;
                }
                else
                    i += 1;
            }
            //
            return tempString;
        }
        public string hex10ToHex2(string input)
        {
            byte[] temp_byte = System.Text.Encoding.ASCII.GetBytes(input);
            string tempString = "";
            UInt32 temp_uint32 = 0;
            int i = 0;
            while (i < temp_byte.Length)
            {
                temp_uint32 = 0;
                if (temp_byte[i] >= 48 && temp_byte[i] <= 57)
                {
                    while (temp_byte[i] >= 48 && temp_byte[i] <= 57)
                    {

                        temp_uint32 = temp_uint32 * 10 + temp_byte[i] - 48;
                        i += 1;
                        if (i >= temp_byte.Length)
                            break;
                    }
                    tempString += Convert.ToString(temp_uint32, 2);
                    if (is_insertSpace)
                        tempString += " ";
                    continue;
                }
                else
                    i += 1;
            }
            //
            return tempString;
        }
        public string hex2ToAscii(string input)
        {
            byte[] temp_byte = System.Text.Encoding.ASCII.GetBytes(input);
            string tempString = "";
            UInt32 temp_uint32 = 0;
            int i = 0;
            while (i < temp_byte.Length)
            {
                temp_uint32 = 0;
                if (temp_byte[i] == 48 || temp_byte[i] == 49)
                {
                    while (temp_byte[i] == 48 || temp_byte[i] == 49)
                    {

                        temp_uint32 = temp_uint32 * 2 + temp_byte[i] - 48;
                        i += 1;
                        if (i >= temp_byte.Length)
                            break;
                    }
                    if ((temp_uint32 >= 32 && temp_uint32 <= 126) || temp_uint32 == 0x0A || temp_uint32 == 0x0D)
                        tempString += (char)temp_uint32;
                    else
                        tempString += "\\x" + (temp_uint32 == 0 ? "00" : (temp_uint32 < 16 ? ("0" + temp_uint32.ToString("X")) : temp_uint32.ToString("X")));
                    
                    //if (is_insertSpace)
                    //    tempString += " ";
                    continue;
                }
                else
                    i += 1;
            }
            //
            return tempString;
        }
        public byte[] hex2ToAscii2(string input)
        {
            byte[] temp_byte = System.Text.Encoding.ASCII.GetBytes(input);
            UInt32 temp_uint32 = 0;
            //
            byte[] temp_ubyte = new byte[input.Length];
            int i = 0, ubCount = 0;
            //
            while (i < temp_byte.Length)
            {
                temp_uint32 = 0;
                if (temp_byte[i] == 48 || temp_byte[i] == 49)
                {
                    while (temp_byte[i] == 48 || temp_byte[i] == 49)
                    {

                        temp_uint32 = temp_uint32 * 2 + temp_byte[i] - 48;
                        i += 1;
                        if (i >= temp_byte.Length)
                            break;
                    }
                    //
                    temp_ubyte[ubCount++] = (byte)temp_uint32;
                    //if (is_insertSpace)
                    //    temp_ubyte[ubCount++] = " ";
                    continue;
                }
                else
                    i += 1;
            }
            //
            byte[] result = new byte[ubCount];
            Array.Copy(temp_ubyte, 0, result, 0, ubCount);
            //
            return result;
        }
        public string hex2ToHex16(string input)
        {
            byte[] temp_byte = System.Text.Encoding.ASCII.GetBytes(input);
            string tempString = "";
            UInt32 temp_uint32 = 0;
            int i = 0;
            while (i < temp_byte.Length)
            {
                temp_uint32 = 0;
                if (temp_byte[i] == 48 || temp_byte[i] == 49)
                {
                    while (temp_byte[i] == 48 || temp_byte[i] == 49)
                    {

                        temp_uint32 = temp_uint32 * 2 + temp_byte[i] - 48;
                        i += 1;
                        if (i >= temp_byte.Length)
                            break;
                    }
                    tempString += Convert.ToString(temp_uint32, 16);
                    if (is_insertSpace)
                        tempString += " ";
                    continue;
                }
                else
                    i += 1;
            }
            //
            return tempString;
        }
        public string hex2ToHex10(string input)
        {
            byte[] temp_byte = System.Text.Encoding.ASCII.GetBytes(input);
            string tempString = "";
            UInt32 temp_uint32 = 0;
            int i = 0;
            while (i < temp_byte.Length)
            {
                temp_uint32 = 0;
                if (temp_byte[i] == 48 || temp_byte[i] == 49)
                {
                    while (temp_byte[i] == 48 || temp_byte[i] == 49)
                    {

                        temp_uint32 = temp_uint32 * 2 + temp_byte[i] - 48;
                        i += 1;
                        if (i >= temp_byte.Length)
                            break;
                    }
                    tempString += Convert.ToString(temp_uint32, 10);
                    if (is_insertSpace)
                        tempString += " ";
                    continue;
                }
                else
                    i += 1;
            }
            //
            return tempString;
        }
        //
    }

    partial class main_menu
    {
        private EncryptList encryptList = new EncryptList();

        private Data_transfer dataTransfer1 = new Data_transfer();
        private Data_transfer dataTransfer2 = new Data_transfer();
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_menu));
            this.text_2 = new System.Windows.Forms.TextBox();
            this.text_1 = new System.Windows.Forms.TextBox();
            this.check_ascii_1 = new System.Windows.Forms.CheckBox();
            this.check_ascii_2 = new System.Windows.Forms.CheckBox();
            this.check_hex16_1 = new System.Windows.Forms.CheckBox();
            this.check_hex16_2 = new System.Windows.Forms.CheckBox();
            this.check_hex10_1 = new System.Windows.Forms.CheckBox();
            this.check_hex10_2 = new System.Windows.Forms.CheckBox();
            this.check_hex2_1 = new System.Windows.Forms.CheckBox();
            this.check_hex2_2 = new System.Windows.Forms.CheckBox();
            this.check_space_1 = new System.Windows.Forms.CheckBox();
            this.check_3desEncode = new System.Windows.Forms.CheckBox();
            this.check_3desDecode = new System.Windows.Forms.CheckBox();
            this.check_enbase64 = new System.Windows.Forms.CheckBox();
            this.check_debase64 = new System.Windows.Forms.CheckBox();
            this.check_aesEncode = new System.Windows.Forms.CheckBox();
            this.check_aesDecode = new System.Windows.Forms.CheckBox();
            this.check_desEncode = new System.Windows.Forms.CheckBox();
            this.check_desDecode = new System.Windows.Forms.CheckBox();
            this.textKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // text_2
            // 
            this.text_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_2.Location = new System.Drawing.Point(12, 390);
            this.text_2.Multiline = true;
            this.text_2.Name = "text_2";
            this.text_2.ReadOnly = true;
            this.text_2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_2.Size = new System.Drawing.Size(600, 220);
            this.text_2.TabIndex = 1;
            // 
            // text_1
            // 
            this.text_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_1.Location = new System.Drawing.Point(12, 12);
            this.text_1.Multiline = true;
            this.text_1.Name = "text_1";
            this.text_1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_1.Size = new System.Drawing.Size(600, 320);
            this.text_1.TabIndex = 0;
            this.text_1.TextChanged += new System.EventHandler(this.text_1_TextChanged);
            // 
            // check_ascii_1
            // 
            this.check_ascii_1.AutoSize = true;
            this.check_ascii_1.Location = new System.Drawing.Point(12, 338);
            this.check_ascii_1.Name = "check_ascii_1";
            this.check_ascii_1.Size = new System.Drawing.Size(53, 20);
            this.check_ascii_1.TabIndex = 2;
            this.check_ascii_1.Text = "ASCII";
            this.check_ascii_1.UseVisualStyleBackColor = true;
            this.check_ascii_1.CheckedChanged += new System.EventHandler(this.check_ascii_1_CheckedChanged);
            // 
            // check_ascii_2
            // 
            this.check_ascii_2.AutoSize = true;
            this.check_ascii_2.Location = new System.Drawing.Point(12, 364);
            this.check_ascii_2.Name = "check_ascii_2";
            this.check_ascii_2.Size = new System.Drawing.Size(53, 20);
            this.check_ascii_2.TabIndex = 3;
            this.check_ascii_2.Text = "ASCII";
            this.check_ascii_2.UseVisualStyleBackColor = true;
            this.check_ascii_2.CheckedChanged += new System.EventHandler(this.check_ascii_2_CheckedChanged);
            // 
            // check_hex16_1
            // 
            this.check_hex16_1.AutoSize = true;
            this.check_hex16_1.Location = new System.Drawing.Point(63, 338);
            this.check_hex16_1.Name = "check_hex16_1";
            this.check_hex16_1.Size = new System.Drawing.Size(59, 20);
            this.check_hex16_1.TabIndex = 6;
            this.check_hex16_1.Text = "HEX16";
            this.check_hex16_1.UseVisualStyleBackColor = true;
            this.check_hex16_1.CheckedChanged += new System.EventHandler(this.check_hex16_1_CheckedChanged);
            // 
            // check_hex16_2
            // 
            this.check_hex16_2.AutoSize = true;
            this.check_hex16_2.Location = new System.Drawing.Point(63, 364);
            this.check_hex16_2.Name = "check_hex16_2";
            this.check_hex16_2.Size = new System.Drawing.Size(59, 20);
            this.check_hex16_2.TabIndex = 7;
            this.check_hex16_2.Text = "HEX16";
            this.check_hex16_2.UseVisualStyleBackColor = true;
            this.check_hex16_2.CheckedChanged += new System.EventHandler(this.check_hex16_2_CheckedChanged);
            // 
            // check_hex10_1
            // 
            this.check_hex10_1.AutoSize = true;
            this.check_hex10_1.Location = new System.Drawing.Point(120, 338);
            this.check_hex10_1.Name = "check_hex10_1";
            this.check_hex10_1.Size = new System.Drawing.Size(59, 20);
            this.check_hex10_1.TabIndex = 10;
            this.check_hex10_1.Text = "HEX10";
            this.check_hex10_1.UseVisualStyleBackColor = true;
            this.check_hex10_1.CheckedChanged += new System.EventHandler(this.check_hex10_1_CheckedChanged);
            // 
            // check_hex10_2
            // 
            this.check_hex10_2.AutoSize = true;
            this.check_hex10_2.Location = new System.Drawing.Point(120, 364);
            this.check_hex10_2.Name = "check_hex10_2";
            this.check_hex10_2.Size = new System.Drawing.Size(59, 20);
            this.check_hex10_2.TabIndex = 11;
            this.check_hex10_2.Text = "HEX10";
            this.check_hex10_2.UseVisualStyleBackColor = true;
            this.check_hex10_2.CheckedChanged += new System.EventHandler(this.check_hex10_2_CheckedChanged);
            // 
            // check_hex2_1
            // 
            this.check_hex2_1.AutoSize = true;
            this.check_hex2_1.Location = new System.Drawing.Point(173, 338);
            this.check_hex2_1.Name = "check_hex2_1";
            this.check_hex2_1.Size = new System.Drawing.Size(53, 20);
            this.check_hex2_1.TabIndex = 12;
            this.check_hex2_1.Text = "HEX2";
            this.check_hex2_1.UseVisualStyleBackColor = true;
            this.check_hex2_1.CheckedChanged += new System.EventHandler(this.check_hex2_1_CheckedChanged);
            // 
            // check_hex2_2
            // 
            this.check_hex2_2.AutoSize = true;
            this.check_hex2_2.Location = new System.Drawing.Point(173, 364);
            this.check_hex2_2.Name = "check_hex2_2";
            this.check_hex2_2.Size = new System.Drawing.Size(59, 20);
            this.check_hex2_2.TabIndex = 13;
            this.check_hex2_2.Text = "HEX2 (";
            this.check_hex2_2.UseVisualStyleBackColor = true;
            this.check_hex2_2.CheckedChanged += new System.EventHandler(this.check_hex2_2_CheckedChanged);
            // 
            // check_space_1
            // 
            this.check_space_1.AutoSize = true;
            this.check_space_1.Checked = true;
            this.check_space_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_space_1.Location = new System.Drawing.Point(226, 364);
            this.check_space_1.Name = "check_space_1";
            this.check_space_1.Size = new System.Drawing.Size(92, 20);
            this.check_space_1.TabIndex = 14;
            this.check_space_1.Text = "insert space )";
            this.check_space_1.UseVisualStyleBackColor = true;
            this.check_space_1.CheckedChanged += new System.EventHandler(this.check_space_1_CheckedChanged);
            // 
            // check_3desEncode
            // 
            this.check_3desEncode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.check_3desEncode.AutoSize = true;
            this.check_3desEncode.Location = new System.Drawing.Point(548, 338);
            this.check_3desEncode.Name = "check_3desEncode";
            this.check_3desEncode.Size = new System.Drawing.Size(64, 20);
            this.check_3desEncode.TabIndex = 15;
            this.check_3desEncode.Text = "Des3En";
            this.check_3desEncode.UseVisualStyleBackColor = true;
            this.check_3desEncode.CheckedChanged += new System.EventHandler(this.check_3desEncode_CheckedChanged);
            // 
            // check_3desDecode
            // 
            this.check_3desDecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.check_3desDecode.AutoSize = true;
            this.check_3desDecode.Location = new System.Drawing.Point(548, 364);
            this.check_3desDecode.Name = "check_3desDecode";
            this.check_3desDecode.Size = new System.Drawing.Size(66, 20);
            this.check_3desDecode.TabIndex = 16;
            this.check_3desDecode.Text = "Des3De";
            this.check_3desDecode.UseVisualStyleBackColor = true;
            this.check_3desDecode.CheckedChanged += new System.EventHandler(this.check_3desDecode_CheckedChanged);
            // 
            // check_enbase64
            // 
            this.check_enbase64.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.check_enbase64.AutoSize = true;
            this.check_enbase64.Location = new System.Drawing.Point(350, 338);
            this.check_enbase64.Name = "check_enbase64";
            this.check_enbase64.Size = new System.Drawing.Size(74, 20);
            this.check_enbase64.TabIndex = 17;
            this.check_enbase64.Text = "Base64En";
            this.check_enbase64.UseVisualStyleBackColor = true;
            this.check_enbase64.CheckedChanged += new System.EventHandler(this.check_enbase64_CheckedChanged);
            // 
            // check_debase64
            // 
            this.check_debase64.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.check_debase64.AutoSize = true;
            this.check_debase64.Location = new System.Drawing.Point(350, 364);
            this.check_debase64.Name = "check_debase64";
            this.check_debase64.Size = new System.Drawing.Size(76, 20);
            this.check_debase64.TabIndex = 18;
            this.check_debase64.Text = "Base64De";
            this.check_debase64.UseVisualStyleBackColor = true;
            this.check_debase64.CheckedChanged += new System.EventHandler(this.check_debase64_CheckedChanged);
            // 
            // check_aesEncode
            // 
            this.check_aesEncode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.check_aesEncode.AutoSize = true;
            this.check_aesEncode.Location = new System.Drawing.Point(428, 338);
            this.check_aesEncode.Name = "check_aesEncode";
            this.check_aesEncode.Size = new System.Drawing.Size(57, 20);
            this.check_aesEncode.TabIndex = 19;
            this.check_aesEncode.Text = "AesEn";
            this.check_aesEncode.UseVisualStyleBackColor = true;
            this.check_aesEncode.CheckedChanged += new System.EventHandler(this.check_aesEncode_CheckedChanged);
            // 
            // check_aesDecode
            // 
            this.check_aesDecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.check_aesDecode.AutoSize = true;
            this.check_aesDecode.Location = new System.Drawing.Point(428, 364);
            this.check_aesDecode.Name = "check_aesDecode";
            this.check_aesDecode.Size = new System.Drawing.Size(59, 20);
            this.check_aesDecode.TabIndex = 20;
            this.check_aesDecode.Text = "AesDe";
            this.check_aesDecode.UseVisualStyleBackColor = true;
            this.check_aesDecode.CheckedChanged += new System.EventHandler(this.check_aesDecode_CheckedChanged);
            // 
            // check_desEncode
            // 
            this.check_desEncode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.check_desEncode.AutoSize = true;
            this.check_desEncode.Location = new System.Drawing.Point(486, 338);
            this.check_desEncode.Name = "check_desEncode";
            this.check_desEncode.Size = new System.Drawing.Size(58, 20);
            this.check_desEncode.TabIndex = 21;
            this.check_desEncode.Text = "DesEn";
            this.check_desEncode.UseVisualStyleBackColor = true;
            this.check_desEncode.CheckedChanged += new System.EventHandler(this.check_desEncode_CheckedChanged);
            // 
            // check_desDecode
            // 
            this.check_desDecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.check_desDecode.AutoSize = true;
            this.check_desDecode.Location = new System.Drawing.Point(486, 364);
            this.check_desDecode.Name = "check_desDecode";
            this.check_desDecode.Size = new System.Drawing.Size(60, 20);
            this.check_desDecode.TabIndex = 22;
            this.check_desDecode.Text = "DesDe";
            this.check_desDecode.UseVisualStyleBackColor = true;
            this.check_desDecode.CheckedChanged += new System.EventHandler(this.check_desDecode_CheckedChanged);
            // 
            // textKey
            // 
            this.textKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textKey.ForeColor = System.Drawing.Color.Red;
            this.textKey.Location = new System.Drawing.Point(226, 338);
            this.textKey.MaxLength = 32;
            this.textKey.Name = "textKey";
            this.textKey.Size = new System.Drawing.Size(118, 21);
            this.textKey.TabIndex = 23;
            this.textKey.Text = "0123456789012345";
            this.textKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // main_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(624, 622);
            this.Controls.Add(this.textKey);
            this.Controls.Add(this.check_desDecode);
            this.Controls.Add(this.check_desEncode);
            this.Controls.Add(this.check_aesDecode);
            this.Controls.Add(this.check_aesEncode);
            this.Controls.Add(this.check_debase64);
            this.Controls.Add(this.check_enbase64);
            this.Controls.Add(this.check_3desDecode);
            this.Controls.Add(this.check_3desEncode);
            this.Controls.Add(this.check_space_1);
            this.Controls.Add(this.check_hex2_2);
            this.Controls.Add(this.check_hex2_1);
            this.Controls.Add(this.check_hex10_2);
            this.Controls.Add(this.check_hex10_1);
            this.Controls.Add(this.check_hex16_2);
            this.Controls.Add(this.check_hex16_1);
            this.Controls.Add(this.check_ascii_2);
            this.Controls.Add(this.check_ascii_1);
            this.Controls.Add(this.text_2);
            this.Controls.Add(this.text_1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(640, 660);
            this.Name = "main_menu";
            this.Text = "DataTransfer V1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_2;
        private System.Windows.Forms.TextBox text_1;
        private System.Windows.Forms.CheckBox check_ascii_1;
        private System.Windows.Forms.CheckBox check_ascii_2;
        private System.Windows.Forms.CheckBox check_hex16_1;
        private System.Windows.Forms.CheckBox check_hex16_2;
        private System.Windows.Forms.CheckBox check_hex10_1;
        private System.Windows.Forms.CheckBox check_hex10_2;
        private System.Windows.Forms.CheckBox check_hex2_1;
        private System.Windows.Forms.CheckBox check_hex2_2;
        private System.Windows.Forms.CheckBox check_space_1;
        private System.Windows.Forms.CheckBox check_3desEncode;
        private System.Windows.Forms.CheckBox check_3desDecode;
        private System.Windows.Forms.CheckBox check_enbase64;
        private System.Windows.Forms.CheckBox check_debase64;
        private System.Windows.Forms.CheckBox check_aesEncode;
        private System.Windows.Forms.CheckBox check_aesDecode;
        private System.Windows.Forms.CheckBox check_desEncode;
        private System.Windows.Forms.CheckBox check_desDecode;
        private System.Windows.Forms.TextBox textKey;
    }
}


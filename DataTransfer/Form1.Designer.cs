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
                tempString += (tempByte[i] / 16).ToString("X");
                tempString += (tempByte[i] % 16).ToString("X");
                
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
                //tempString += Convert.ToString((UInt16)tempByte[i], 2);
                byte tb = tempByte[i];
                for (int c = 0; c < 8; c++) {
                    if ((tb & 0x80) == 0)
                        tempString += "0";
                    else
                        tempString += "1";
                    tb <<= 1;
                }
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
                tempString += (tempByte[i] / 16).ToString("X");
                tempString += (tempByte[i] % 16).ToString("X");

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
                byte tb = tempByte[i];
                for (int c = 0; c < 8; c++)
                {
                    if ((tb & 0x80) == 0)
                        tempString += "0";
                    else
                        tempString += "1";
                    tb <<= 1;
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
            int i = 0, byteCount;
            while (i < temp_byte.Length)
            {
                temp_uint32 = 0;
                if ((temp_byte[i] >= 48 && temp_byte[i] <= 57) ||
                    (temp_byte[i] >= 65 && temp_byte[i] <= 70) ||
                    (temp_byte[i] >= 97 && temp_byte[i] <= 102))
                {
                    byteCount = 0;
                    temp_uint32 = 0;
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
                        //每2个字符组成一个ascii码
                        byteCount += 1;
                        if (byteCount == 2)
                            break;
                    }
                    if (temp_uint32 >= 32 && temp_uint32 <= 126)
                        tempString += (char)temp_uint32;
                    else if (temp_uint32 == 0x0A)
                        tempString += "\n";
                    else if (temp_uint32 == 0x0D)
                        tempString += "\r";
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
                    if (temp_uint32 >= 32 && temp_uint32 <= 126)
                        tempString += (char)temp_uint32;
                    else if (temp_uint32 == 0x0A)
                        tempString += '\r';
                    else if (temp_uint32 == 0x0D)
                        tempString += '\n';
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
                    if (temp_uint32 >= 32 && temp_uint32 <= 126)
                        tempString += (char)temp_uint32;
                    else if (temp_uint32 == 0x0A)
                        tempString += '\r';
                    else if (temp_uint32 == 0x0D)
                        tempString += '\n';
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
            this.text_key = new System.Windows.Forms.TextBox();
            this.list_encrption = new System.Windows.Forms.ComboBox();
            this.button_en = new System.Windows.Forms.Button();
            this.button_de = new System.Windows.Forms.Button();
            this.check_file = new System.Windows.Forms.CheckBox();
            this.text_file = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.check_dir = new System.Windows.Forms.CheckBox();
            this.label_len_src = new System.Windows.Forms.Label();
            this.label_len_dist = new System.Windows.Forms.Label();
            this.label_length = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // text_2
            // 
            this.text_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_2.Location = new System.Drawing.Point(12, 316);
            this.text_2.Multiline = true;
            this.text_2.Name = "text_2";
            this.text_2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_2.Size = new System.Drawing.Size(658, 250);
            this.text_2.TabIndex = 1;
            this.text_2.TextChanged += new System.EventHandler(this.text_2_TextChanged);
            this.text_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_2_KeyDown);
            // 
            // text_1
            // 
            this.text_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_1.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_1.Location = new System.Drawing.Point(12, 11);
            this.text_1.Multiline = true;
            this.text_1.Name = "text_1";
            this.text_1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_1.Size = new System.Drawing.Size(658, 250);
            this.text_1.TabIndex = 0;
            this.text_1.TextChanged += new System.EventHandler(this.text_1_TextChanged);
            this.text_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_1_KeyDown);
            // 
            // check_ascii_1
            // 
            this.check_ascii_1.AutoSize = true;
            this.check_ascii_1.Location = new System.Drawing.Point(12, 265);
            this.check_ascii_1.Name = "check_ascii_1";
            this.check_ascii_1.Size = new System.Drawing.Size(65, 23);
            this.check_ascii_1.TabIndex = 2;
            this.check_ascii_1.Text = "ASCII";
            this.check_ascii_1.UseVisualStyleBackColor = true;
            this.check_ascii_1.CheckedChanged += new System.EventHandler(this.check_ascii_1_CheckedChanged);
            // 
            // check_ascii_2
            // 
            this.check_ascii_2.AutoSize = true;
            this.check_ascii_2.Location = new System.Drawing.Point(12, 291);
            this.check_ascii_2.Name = "check_ascii_2";
            this.check_ascii_2.Size = new System.Drawing.Size(65, 23);
            this.check_ascii_2.TabIndex = 3;
            this.check_ascii_2.Text = "ASCII";
            this.check_ascii_2.UseVisualStyleBackColor = true;
            this.check_ascii_2.CheckedChanged += new System.EventHandler(this.check_ascii_2_CheckedChanged);
            // 
            // check_hex16_1
            // 
            this.check_hex16_1.AutoSize = true;
            this.check_hex16_1.Location = new System.Drawing.Point(63, 265);
            this.check_hex16_1.Name = "check_hex16_1";
            this.check_hex16_1.Size = new System.Drawing.Size(72, 23);
            this.check_hex16_1.TabIndex = 6;
            this.check_hex16_1.Text = "HEX16";
            this.check_hex16_1.UseVisualStyleBackColor = true;
            this.check_hex16_1.CheckedChanged += new System.EventHandler(this.check_hex16_1_CheckedChanged);
            // 
            // check_hex16_2
            // 
            this.check_hex16_2.AutoSize = true;
            this.check_hex16_2.Location = new System.Drawing.Point(63, 291);
            this.check_hex16_2.Name = "check_hex16_2";
            this.check_hex16_2.Size = new System.Drawing.Size(72, 23);
            this.check_hex16_2.TabIndex = 7;
            this.check_hex16_2.Text = "HEX16";
            this.check_hex16_2.UseVisualStyleBackColor = true;
            this.check_hex16_2.CheckedChanged += new System.EventHandler(this.check_hex16_2_CheckedChanged);
            // 
            // check_hex10_1
            // 
            this.check_hex10_1.AutoSize = true;
            this.check_hex10_1.Location = new System.Drawing.Point(120, 265);
            this.check_hex10_1.Name = "check_hex10_1";
            this.check_hex10_1.Size = new System.Drawing.Size(72, 23);
            this.check_hex10_1.TabIndex = 10;
            this.check_hex10_1.Text = "HEX10";
            this.check_hex10_1.UseVisualStyleBackColor = true;
            this.check_hex10_1.CheckedChanged += new System.EventHandler(this.check_hex10_1_CheckedChanged);
            // 
            // check_hex10_2
            // 
            this.check_hex10_2.AutoSize = true;
            this.check_hex10_2.Location = new System.Drawing.Point(120, 291);
            this.check_hex10_2.Name = "check_hex10_2";
            this.check_hex10_2.Size = new System.Drawing.Size(72, 23);
            this.check_hex10_2.TabIndex = 11;
            this.check_hex10_2.Text = "HEX10";
            this.check_hex10_2.UseVisualStyleBackColor = true;
            this.check_hex10_2.CheckedChanged += new System.EventHandler(this.check_hex10_2_CheckedChanged);
            // 
            // check_hex2_1
            // 
            this.check_hex2_1.AutoSize = true;
            this.check_hex2_1.Location = new System.Drawing.Point(178, 265);
            this.check_hex2_1.Name = "check_hex2_1";
            this.check_hex2_1.Size = new System.Drawing.Size(64, 23);
            this.check_hex2_1.TabIndex = 12;
            this.check_hex2_1.Text = "HEX2";
            this.check_hex2_1.UseVisualStyleBackColor = true;
            this.check_hex2_1.CheckedChanged += new System.EventHandler(this.check_hex2_1_CheckedChanged);
            // 
            // check_hex2_2
            // 
            this.check_hex2_2.AutoSize = true;
            this.check_hex2_2.Location = new System.Drawing.Point(178, 291);
            this.check_hex2_2.Name = "check_hex2_2";
            this.check_hex2_2.Size = new System.Drawing.Size(72, 23);
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
            this.check_space_1.Location = new System.Drawing.Point(234, 291);
            this.check_space_1.Name = "check_space_1";
            this.check_space_1.Size = new System.Drawing.Size(76, 23);
            this.check_space_1.TabIndex = 14;
            this.check_space_1.Text = "Space )";
            this.check_space_1.UseVisualStyleBackColor = true;
            this.check_space_1.CheckedChanged += new System.EventHandler(this.check_space_1_CheckedChanged);
            // 
            // text_key
            // 
            this.text_key.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_key.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_key.ForeColor = System.Drawing.Color.Red;
            this.text_key.Location = new System.Drawing.Point(467, 263);
            this.text_key.MaxLength = 32;
            this.text_key.Name = "text_key";
            this.text_key.Size = new System.Drawing.Size(203, 27);
            this.text_key.TabIndex = 23;
            this.text_key.Text = "0123456789012345";
            this.text_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // list_encrption
            // 
            this.list_encrption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.list_encrption.FormattingEnabled = true;
            this.list_encrption.Items.AddRange(new object[] {
            "BASE64",
            "AES",
            "DES",
            "DES3",
            "MD5"});
            this.list_encrption.Location = new System.Drawing.Point(351, 264);
            this.list_encrption.Name = "list_encrption";
            this.list_encrption.Size = new System.Drawing.Size(84, 25);
            this.list_encrption.TabIndex = 25;
            this.list_encrption.SelectedIndexChanged += new System.EventHandler(this.list_encrption_SelectedIndexChanged);
            // 
            // button_en
            // 
            this.button_en.Enabled = false;
            this.button_en.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_en.Location = new System.Drawing.Point(351, 291);
            this.button_en.Name = "button_en";
            this.button_en.Size = new System.Drawing.Size(38, 23);
            this.button_en.TabIndex = 26;
            this.button_en.Text = "EN";
            this.button_en.UseVisualStyleBackColor = true;
            this.button_en.Click += new System.EventHandler(this.button_en_Click);
            // 
            // button_de
            // 
            this.button_de.Enabled = false;
            this.button_de.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_de.Location = new System.Drawing.Point(397, 291);
            this.button_de.Name = "button_de";
            this.button_de.Size = new System.Drawing.Size(38, 23);
            this.button_de.TabIndex = 27;
            this.button_de.Text = "DE";
            this.button_de.UseVisualStyleBackColor = true;
            this.button_de.Click += new System.EventHandler(this.button_de_Click);
            // 
            // check_file
            // 
            this.check_file.AutoSize = true;
            this.check_file.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.check_file.Location = new System.Drawing.Point(436, 292);
            this.check_file.Name = "check_file";
            this.check_file.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_file.Size = new System.Drawing.Size(56, 24);
            this.check_file.TabIndex = 28;
            this.check_file.Text = "File";
            this.check_file.UseVisualStyleBackColor = true;
            this.check_file.CheckedChanged += new System.EventHandler(this.check_file_CheckedChanged);
            // 
            // text_file
            // 
            this.text_file.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_file.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_file.Location = new System.Drawing.Point(547, 290);
            this.text_file.Name = "text_file";
            this.text_file.Size = new System.Drawing.Size(123, 27);
            this.text_file.TabIndex = 29;
            this.text_file.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_file_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(437, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Key";
            // 
            // check_dir
            // 
            this.check_dir.AutoSize = true;
            this.check_dir.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.check_dir.Location = new System.Drawing.Point(489, 291);
            this.check_dir.Name = "check_dir";
            this.check_dir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_dir.Size = new System.Drawing.Size(52, 24);
            this.check_dir.TabIndex = 31;
            this.check_dir.Text = "Dir";
            this.check_dir.UseVisualStyleBackColor = true;
            this.check_dir.CheckedChanged += new System.EventHandler(this.check_dir_CheckedChanged);
            // 
            // label_len_src
            // 
            this.label_len_src.AutoSize = true;
            this.label_len_src.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_len_src.Location = new System.Drawing.Point(296, 266);
            this.label_len_src.MaximumSize = new System.Drawing.Size(50, 20);
            this.label_len_src.MinimumSize = new System.Drawing.Size(50, 20);
            this.label_len_src.Name = "label_len_src";
            this.label_len_src.Size = new System.Drawing.Size(50, 20);
            this.label_len_src.TabIndex = 32;
            this.label_len_src.Text = "0";
            this.label_len_src.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_len_dist
            // 
            this.label_len_dist.AutoSize = true;
            this.label_len_dist.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_len_dist.Location = new System.Drawing.Point(296, 292);
            this.label_len_dist.MaximumSize = new System.Drawing.Size(50, 20);
            this.label_len_dist.MinimumSize = new System.Drawing.Size(50, 20);
            this.label_len_dist.Name = "label_len_dist";
            this.label_len_dist.Size = new System.Drawing.Size(50, 20);
            this.label_len_dist.TabIndex = 33;
            this.label_len_dist.Text = "0";
            this.label_len_dist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_length
            // 
            this.label_length.AutoSize = true;
            this.label_length.Location = new System.Drawing.Point(249, 266);
            this.label_length.Name = "label_length";
            this.label_length.Size = new System.Drawing.Size(55, 19);
            this.label_length.TabIndex = 34;
            this.label_length.Text = "Length:";
            // 
            // main_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(682, 578);
            this.Controls.Add(this.label_length);
            this.Controls.Add(this.label_len_dist);
            this.Controls.Add(this.label_len_src);
            this.Controls.Add(this.text_key);
            this.Controls.Add(this.check_dir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_file);
            this.Controls.Add(this.check_file);
            this.Controls.Add(this.button_de);
            this.Controls.Add(this.button_en);
            this.Controls.Add(this.list_encrption);
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
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MinimumSize = new System.Drawing.Size(700, 625);
            this.Name = "main_menu";
            this.Text = "DataTransfer V1.3 - 2020.05.09";
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
        private System.Windows.Forms.TextBox text_key;
        private System.Windows.Forms.ComboBox list_encrption;
        private System.Windows.Forms.Button button_en;
        private System.Windows.Forms.Button button_de;
        private System.Windows.Forms.CheckBox check_file;
        private System.Windows.Forms.TextBox text_file;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox check_dir;
        private System.Windows.Forms.Label label_len_src;
        private System.Windows.Forms.Label label_len_dist;
        private System.Windows.Forms.Label label_length;
    }
}


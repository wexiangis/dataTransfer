using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTransfer
{
    public partial class main_menu : Form
    {
        public void checkBox1Flash()
        {
            check_ascii_1.CheckState = dataTransfer1.getAscii() == true ? CheckState.Checked : CheckState.Unchecked;
            check_hex16_1.CheckState = dataTransfer1.getHex16() == true ? CheckState.Checked : CheckState.Unchecked;
            check_hex10_1.CheckState = dataTransfer1.getHex10() == true ? CheckState.Checked : CheckState.Unchecked;
            check_hex2_1.CheckState = dataTransfer1.getHex2() == true ? CheckState.Checked : CheckState.Unchecked;
            check_space_1.CheckState = dataTransfer1.getInsertSpace() == true ? CheckState.Checked : CheckState.Unchecked;
        }
        public void checkBox2Flash()
        {
            check_ascii_2.CheckState = dataTransfer2.getAscii() == true ? CheckState.Checked : CheckState.Unchecked;
            check_hex16_2.CheckState = dataTransfer2.getHex16() == true ? CheckState.Checked : CheckState.Unchecked;
            check_hex10_2.CheckState = dataTransfer2.getHex10() == true ? CheckState.Checked : CheckState.Unchecked;
            check_hex2_2.CheckState = dataTransfer2.getHex2() == true ? CheckState.Checked : CheckState.Unchecked;
        }
        public void textSwitch1(string input)
        {
            if (dataTransfer1.getAscii())
            {
                if (dataTransfer2.getHex16())
                    text_2.Text = dataTransfer1.asciiToHex16(input);
                else if (dataTransfer2.getHex10())
                    text_2.Text = dataTransfer1.asciiToHex10(input);
                else if (dataTransfer2.getHex2())
                    text_2.Text = dataTransfer1.asciiToHex2(input);
                else
                    text_2.Text = input;
            }
            else if (dataTransfer1.getHex16())
            {
                if (dataTransfer2.getAscii())
                    text_2.Text = dataTransfer1.hex16ToAscii(input);
                else if (dataTransfer2.getHex10())
                    text_2.Text = dataTransfer1.hex16ToHex10(input);
                else if (dataTransfer2.getHex2())
                    text_2.Text = dataTransfer1.hex16ToHex2(input);
                else
                    text_2.Text = input;
            }
            else if (dataTransfer1.getHex10())
            {
                if (dataTransfer2.getAscii())
                    text_2.Text = dataTransfer1.hex10ToAscii(input);
                else if (dataTransfer2.getHex16())
                    text_2.Text = dataTransfer1.hex10ToHex16(input);
                else if (dataTransfer2.getHex2())
                    text_2.Text = dataTransfer1.hex10ToHex2(input);
                else
                    text_2.Text = input;
            }
            else if (dataTransfer1.getHex2())
            {
                if (dataTransfer2.getAscii())
                    text_2.Text = dataTransfer1.hex2ToAscii(input);
                else if (dataTransfer2.getHex16())
                    text_2.Text = dataTransfer1.hex2ToHex16(input);
                else if (dataTransfer2.getHex10())
                    text_2.Text = dataTransfer1.hex2ToHex10(input);
                else
                    text_2.Text = input;
            }else
                text_2.Text = "未指定转换类型";
        }
        public void textSwitch2(string input)
        {
            if (dataTransfer2.getAscii())
            {
                if (dataTransfer1.getHex16())
                    this.text_1.Text = dataTransfer2.asciiToHex16(input);
                else if (dataTransfer1.getHex10())
                    this.text_1.Text = dataTransfer2.asciiToHex10(input);
                else if (dataTransfer1.getHex2())
                    this.text_1.Text = dataTransfer2.asciiToHex2(input);
                else
                    this.text_1.Text = input;
            }
            else if (dataTransfer2.getHex16())
            {
                if (dataTransfer1.getAscii())
                    this.text_1.Text = dataTransfer2.hex16ToAscii(input);
                else if (dataTransfer1.getHex10())
                    this.text_1.Text = dataTransfer2.hex16ToHex10(input);
                else if (dataTransfer1.getHex2())
                    this.text_1.Text = dataTransfer2.hex16ToHex2(input);
                else
                    this.text_1.Text = input;
            }
            else if (dataTransfer2.getHex10())
            {
                if (dataTransfer1.getAscii())
                    this.text_1.Text = dataTransfer2.hex10ToAscii(input);
                else if (dataTransfer1.getHex16())
                    this.text_1.Text = dataTransfer2.hex10ToHex16(input);
                else if (dataTransfer1.getHex2())
                    this.text_1.Text = dataTransfer2.hex10ToHex2(input);
                else
                    this.text_1.Text = input;
            }
            else if (dataTransfer2.getHex2())
            {
                if (dataTransfer1.getAscii())
                    this.text_1.Text = dataTransfer2.hex2ToAscii(input);
                else if (dataTransfer1.getHex16())
                    this.text_1.Text = dataTransfer2.hex2ToHex16(input);
                else if (dataTransfer1.getHex10())
                    this.text_1.Text = dataTransfer2.hex2ToHex10(input);
                else
                    this.text_1.Text = input;
            }else
                this.text_1.Text = "未指定转换类型";
        }
        public main_menu()
        {
            InitializeComponent();
            this.list_encrption.SelectedIndex = 0;
        }
        private void text_1_TextChanged(object sender, EventArgs e)
        {
            textSwitch1(this.text_1.Text);
            checkBox1Flash();
        }
        private void check_ascii_1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_ascii_1.CheckState == CheckState.Checked)
                dataTransfer1.setAsciiOn();
            else if (check_ascii_1.CheckState == CheckState.Unchecked)
                dataTransfer1.setAsciiOff();
            else
                dataTransfer1.setAsciiOff();
            checkBox1Flash();
            textSwitch1(this.text_1.Text);
        }
        private void check_ascii_2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_ascii_2.CheckState == CheckState.Checked)
                dataTransfer2.setAsciiOn();
            else if (check_ascii_2.CheckState == CheckState.Unchecked)
                dataTransfer2.setAsciiOff();
            else
                dataTransfer2.setAsciiOff();
            checkBox2Flash();
            textSwitch1(this.text_1.Text);
        }
        private void check_hex16_1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_hex16_1.CheckState == CheckState.Checked)
                dataTransfer1.setHex16On();
            else if (check_hex16_1.CheckState == CheckState.Unchecked)
                dataTransfer1.setHex16Off();
            else
                dataTransfer1.setHex16Off();
            checkBox1Flash();
            textSwitch1(this.text_1.Text);
        }
        private void check_hex16_2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_hex16_2.CheckState == CheckState.Checked)
                dataTransfer2.setHex16On();
            else if (check_hex16_2.CheckState == CheckState.Unchecked)
                dataTransfer2.setHex16Off();
            else
                dataTransfer2.setHex16Off();
            checkBox2Flash();
            textSwitch1(this.text_1.Text);
        }
        private void check_hex10_1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_hex10_1.CheckState == CheckState.Checked)
                dataTransfer1.setHex10On();
            else if (check_hex10_1.CheckState == CheckState.Unchecked)
                dataTransfer1.setHex10Off();
            else
                dataTransfer1.setHex10Off();
            checkBox1Flash();
            textSwitch1(this.text_1.Text);
        }
        private void check_hex10_2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_hex10_2.CheckState == CheckState.Checked)
                dataTransfer2.setHex10On();
            else if (check_hex10_2.CheckState == CheckState.Unchecked)
                dataTransfer2.setHex10Off();
            else
                dataTransfer2.setHex10Off();
            checkBox2Flash();
            textSwitch1(this.text_1.Text);
        }
        private void check_hex2_1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_hex2_1.CheckState == CheckState.Checked)
                dataTransfer1.setHex2On();
            else if (check_hex2_1.CheckState == CheckState.Unchecked)
                dataTransfer1.setHex2Off();
            else
                dataTransfer1.setHex2Off();
            checkBox1Flash();
            textSwitch1(this.text_1.Text);
        }
        private void check_hex2_2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_hex2_2.CheckState == CheckState.Checked)
                dataTransfer2.setHex2On();
            else if (check_hex2_2.CheckState == CheckState.Unchecked)
                dataTransfer2.setHex2Off();
            else
                dataTransfer2.setHex2Off();
            checkBox2Flash();
            textSwitch1(this.text_1.Text);
        }
        private void check_space_1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_space_1.CheckState == CheckState.Checked)
                dataTransfer1.setInsertSpaceOn();
            else if (check_space_1.CheckState == CheckState.Unchecked)
                dataTransfer1.setInsertSpaceOff();
            else
                dataTransfer1.setInsertSpaceOff();
            checkBox1Flash();
            textSwitch1(this.text_1.Text);
        }

        private void button_en_Click(object sender, EventArgs e)
        {
            int ret = -1;
            this.text_2.Text = "处理中 ...\r\n";
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;//鼠标为忙碌状态

            if(this.check_file.Checked && this.text_file.Text.Length > 0)
            {
                switch (this.list_encrption.SelectedIndex)
                {
                    case 0: //BASE64
                        text_2.Text = "不支持 BASE64 处理文件\r\n";
                        break;
                    case 1: //AES
                        ret = this.encryptList.AesEncryptionFile(this.text_file.Text, this.text_file.Text+".AesEncode.bin", this.text_key.Text, true);
                        if(ret == 0)
                            this.text_2.Text = this.text_file.Text + ".AesEncode.bin" + "\r\n";
                        else if (ret == -2)
                            this.text_2.Text = this.text_file.Text + " open failed\r\n";
                        else
                            this.text_2.Text = "aesEncode failed !\r\n";
                        break;
                    case 2: //DES
                        ret = this.encryptList.DesEncryptionFile(this.text_file.Text, this.text_file.Text + ".DesEncode.bin", this.text_key.Text, true);
                        if (ret == 0)
                            this.text_2.Text = this.text_file.Text + ".DesEncode.bin" + "\r\n";
                        else if (ret == -2)
                            this.text_2.Text = this.text_file.Text + " open failed\r\n";
                        else
                            this.text_2.Text = "desEncode failed !\r\n";
                        break;
                    case 3: //DES3
                        ret = this.encryptList.Des3EncryptionFile(this.text_file.Text, this.text_file.Text + ".Des3Encode.bin", this.text_key.Text, true);
                        if (ret == 0)
                            this.text_2.Text = this.text_file.Text + ".Des3Encode.bin" + "\r\n";
                        else if (ret == -2)
                            this.text_2.Text = this.text_file.Text + " open failed\r\n";
                        else
                            this.text_2.Text = "des3Encode failed !\r\n";
                        break;
                    case 4: //MD5
                        this.text_2.Text = this.encryptList.Md5EncryptionFile(this.text_file.Text);
                        break;
                    default:
                        text_2.Text = "请选择加密方式";
                        break;
                }
            }
            else
            {
                switch(this.list_encrption.SelectedIndex)
                {
                    case 0: //BASE64
                        try
                        {
                            string result;
                            if (this.check_hex16_1.Checked)
                                result = Convert.ToBase64String(this.dataTransfer1.hex16ToAscii2(text_1.Text));
                            else if (this.check_hex10_1.Checked)
                                result = Convert.ToBase64String(this.dataTransfer1.hex10ToAscii2(text_1.Text));
                            else if (this.check_hex2_1.Checked)
                                result = Convert.ToBase64String(this.dataTransfer1.hex2ToAscii2(text_1.Text));
                            else
                                result = Convert.ToBase64String(Encoding.UTF8.GetBytes(text_1.Text));
                            //
                            if (this.check_hex16_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex16(result);
                            else if (this.check_hex10_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex10(result);
                            else if (this.check_hex2_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex2(result);
                            else
                                text_2.Text = result;
                        }
                        catch { text_2.Text = "enBase64 failed !\r\n"; }
                        break;
                    case 1: //AES
                        try
                        {
                            string result;
                            if (this.check_hex16_1.Checked)
                                result = encryptList.AesEncryption(Encoding.ASCII.GetString(this.dataTransfer1.hex16ToAscii2(text_1.Text)), this.text_key.Text);
                            else if (this.check_hex10_1.Checked)
                                result = encryptList.AesEncryption(Encoding.ASCII.GetString(this.dataTransfer1.hex10ToAscii2(text_1.Text)), this.text_key.Text);
                            else if (this.check_hex2_1.Checked)
                                result = encryptList.AesEncryption(Encoding.ASCII.GetString(this.dataTransfer1.hex2ToAscii2(text_1.Text)), this.text_key.Text);
                            else
                                result = encryptList.AesEncryption(text_1.Text, this.text_key.Text);
                            //
                            if (this.check_hex16_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex16(result);
                            else if (this.check_hex10_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex10(result);
                            else if (this.check_hex2_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex2(result);
                            else
                                text_2.Text = result;
                        }
                        catch { text_2.Text = "key len should be 16/24/32 bytes !\r\n"; }
                        break;
                    case 2: //DES
                        try
                        {
                            string result;
                            if (this.check_hex16_1.Checked)
                                result = encryptList.DesEncryption(Encoding.ASCII.GetString(this.dataTransfer1.hex16ToAscii2(text_1.Text)), this.text_key.Text);
                            else if (this.check_hex10_1.Checked)
                                result = encryptList.DesEncryption(Encoding.ASCII.GetString(this.dataTransfer1.hex10ToAscii2(text_1.Text)), this.text_key.Text);
                            else if (this.check_hex2_1.Checked)
                                result = encryptList.DesEncryption(Encoding.ASCII.GetString(this.dataTransfer1.hex2ToAscii2(text_1.Text)), this.text_key.Text);
                            else
                                result = encryptList.DesEncryption(text_1.Text, this.text_key.Text);
                            //
                            if (this.check_hex16_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex16(result);
                            else if (this.check_hex10_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex10(result);
                            else if (this.check_hex2_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex2(result);
                            else
                                text_2.Text = result;
                        }
                        catch { text_2.Text = "key len must be 8 bytes !\r\n"; ; }
                        break;
                    case 3: //DES3
                        try
                        {
                            string result;
                            if (this.check_hex16_1.Checked)
                                result = encryptList.Des3Encryption(Encoding.ASCII.GetString(this.dataTransfer1.hex16ToAscii2(text_1.Text)), this.text_key.Text);
                            else if (this.check_hex10_1.Checked)
                                result = encryptList.Des3Encryption(Encoding.ASCII.GetString(this.dataTransfer1.hex10ToAscii2(text_1.Text)), this.text_key.Text);
                            else if (this.check_hex2_1.Checked)
                                result = encryptList.Des3Encryption(Encoding.ASCII.GetString(this.dataTransfer1.hex2ToAscii2(text_1.Text)), this.text_key.Text);
                            else
                                result = encryptList.Des3Encryption(text_1.Text, this.text_key.Text);
                            //
                            if (this.check_hex16_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex16(result);
                            else if (this.check_hex10_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex10(result);
                            else if (this.check_hex2_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex2(result);
                            else
                                text_2.Text = result;
                        }
                        catch { text_2.Text = "密匙长度要求24位 或 密匙过于简单\r\n"; }
                        break;
                    case 4: //MD5
                        text_2.Text = "";
                        break;
                    default:
                        text_2.Text = "请选择加密方式";
                        break;
                }
            }
            this.Cursor = System.Windows.Forms.Cursors.Arrow;//设置鼠标为正常状态
        }

        private void button_de_Click(object sender, EventArgs e)
        {
            int ret = -1;
            this.text_2.Text = "处理中 ...\r\n";
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;//鼠标为忙碌状态

            if (this.check_file.Checked && this.text_file.Text.Length > 0)
            {
                switch (this.list_encrption.SelectedIndex)
                {
                    case 0: //BASE64
                        text_2.Text = "不支持 BASE64 处理文件\r\n";
                        break;
                    case 1: //AES
                        ret = this.encryptList.AesEncryptionFile(this.text_file.Text, this.text_file.Text+".AesDecode.bin", this.text_key.Text, false);
                        if(ret == 0)
                            this.text_2.Text = this.text_file.Text + ".AesDecode.bin" + "\r\n";
                        else if (ret == -2)
                            this.text_2.Text = this.text_file.Text + " open failed\r\n";
                        else
                            this.text_2.Text = "aesDecode failed !\r\n";
                        break;
                    case 2: //DES
                        ret = this.encryptList.DesEncryptionFile(this.text_file.Text, this.text_file.Text + ".DesDecode.bin", this.text_key.Text, false);
                        if (ret == 0)
                            this.text_2.Text = this.text_file.Text + ".DesDecode.bin" + "\r\n";
                        else if (ret == -2)
                            this.text_2.Text = this.text_file.Text + " open failed\r\n";
                        else
                            this.text_2.Text = "desDecode failed !\r\n";
                        break;
                    case 3: //DES3
                        ret = this.encryptList.Des3EncryptionFile(this.text_file.Text, this.text_file.Text + ".Des3Decode.bin", this.text_key.Text, false);
                        if (ret == 0)
                            this.text_2.Text = this.text_file.Text + ".Des3Decode.bin" + "\r\n";
                        else if (ret == -2)
                            this.text_2.Text = this.text_file.Text + " open failed\r\n";
                        else
                            this.text_2.Text = "des3Decode failed !\r\n";
                        break;
                    case 4: //MD5
                        this.text_2.Text = this.encryptList.Md5EncryptionFile(this.text_file.Text);
                        break;
                    default:
                        text_2.Text = "请选择加密方式";
                        break;
                }
            }
            else
            {
                switch (this.list_encrption.SelectedIndex)
                {
                    case 0: //BASE64
                        try
                        {
                            byte[] result;
                            if (this.check_hex16_1.Checked)
                                result = Convert.FromBase64String(Encoding.ASCII.GetString(this.dataTransfer1.hex16ToAscii2(text_1.Text)));
                            else if (this.check_hex10_1.Checked)
                                result = Convert.FromBase64String(Encoding.ASCII.GetString(this.dataTransfer1.hex10ToAscii2(text_1.Text)));
                            else if (this.check_hex2_1.Checked)
                                result = Convert.FromBase64String(Encoding.ASCII.GetString(this.dataTransfer1.hex2ToAscii2(text_1.Text)));
                            else
                                result = Convert.FromBase64String(text_1.Text);
                            //
                            if (this.check_hex16_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex16_2(result);
                            else if (this.check_hex10_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex10_2(result);
                            else if (this.check_hex2_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex2_2(result);
                            else
                                text_2.Text = Encoding.ASCII.GetString(result);
                        }
                        catch { text_2.Text = "deBase64 failed !\r\n"; }
                        break;
                    case 1: //AES
                        try
                        {
                            string result;
                            if (this.check_hex16_1.Checked)
                                result = encryptList.AesDecryption(Encoding.ASCII.GetString(this.dataTransfer1.hex16ToAscii2(text_1.Text)), this.text_key.Text);
                            else if (this.check_hex10_1.Checked)
                                result = encryptList.AesDecryption(Encoding.ASCII.GetString(this.dataTransfer1.hex10ToAscii2(text_1.Text)), this.text_key.Text);
                            else if (this.check_hex2_1.Checked)
                                result = encryptList.AesDecryption(Encoding.ASCII.GetString(this.dataTransfer1.hex2ToAscii2(text_1.Text)), this.text_key.Text);
                            else
                                result = encryptList.AesDecryption(text_1.Text, this.text_key.Text);
                            //
                            if (this.check_hex16_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex16(result);
                            else if (this.check_hex10_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex10(result);
                            else if (this.check_hex2_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex2(result);
                            else
                                text_2.Text = result;
                        }
                        catch { text_2.Text = "aesDecode failed !\r\n"; }
                        break;
                    case 2: //DES
                        try
                        {
                            string result;
                            if (this.check_hex16_1.Checked)
                                result = encryptList.DesDecryption(Encoding.ASCII.GetString(this.dataTransfer1.hex16ToAscii2(text_1.Text)), this.text_key.Text);
                            else if (this.check_hex10_1.Checked)
                                result = encryptList.DesDecryption(Encoding.ASCII.GetString(this.dataTransfer1.hex10ToAscii2(text_1.Text)), this.text_key.Text);
                            else if (this.check_hex2_1.Checked)
                                result = encryptList.DesDecryption(Encoding.ASCII.GetString(this.dataTransfer1.hex2ToAscii2(text_1.Text)), this.text_key.Text);
                            else
                                result = encryptList.DesDecryption(text_1.Text, this.text_key.Text);
                            //
                            if (this.check_hex16_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex16(result);
                            else if (this.check_hex10_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex10(result);
                            else if (this.check_hex2_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex2(result);
                            else
                                text_2.Text = result;
                        }
                        catch { text_2.Text = "desDecode failed !\r\n"; }
                        break;
                    case 3: //DES3
                        try
                        {
                            string result;
                            if (this.check_hex16_1.Checked)
                                result = encryptList.Des3Decryption(Encoding.ASCII.GetString(this.dataTransfer1.hex16ToAscii2(text_1.Text)), this.text_key.Text);
                            else if (this.check_hex10_1.Checked)
                                result = encryptList.Des3Decryption(Encoding.ASCII.GetString(this.dataTransfer1.hex10ToAscii2(text_1.Text)), this.text_key.Text);
                            else if (this.check_hex2_1.Checked)
                                result = encryptList.Des3Decryption(Encoding.ASCII.GetString(this.dataTransfer1.hex2ToAscii2(text_1.Text)), this.text_key.Text);
                            else
                                result = encryptList.Des3Decryption(text_1.Text, this.text_key.Text);
                            //
                            if (this.check_hex16_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex16(result);
                            else if (this.check_hex10_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex10(result);
                            else if (this.check_hex2_2.Checked)
                                text_2.Text = this.dataTransfer2.asciiToHex2(result);
                            else
                                text_2.Text = result;
                        }
                        catch { text_2.Text = "3desDecode failed !\r\n"; }
                        break;
                    case 4: //MD5
                        text_2.Text = "";
                        break;
                    default:
                        text_2.Text = "请选择加密方式";
                        break;
                }
            }
            this.Cursor = System.Windows.Forms.Cursors.Arrow;//设置鼠标为正常状态
        }

        private void check_file_CheckedChanged(object sender, EventArgs e)
        {
            if (this.check_file.CheckState == CheckState.Checked)
            {
                OpenFileDialog openfiledialig = new OpenFileDialog();
                if (openfiledialig.ShowDialog() == DialogResult.OK)
                {
                    this.text_file.Text = openfiledialig.FileName;
                }
                else
                    this.check_file.Checked = false;
            }
        }

        private void text_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                this.text_1.SelectAll();
        }

        private void text_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                this.text_2.SelectAll();
        }

        private void text_file_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                this.text_file.SelectAll();
        }

        private void list_encrption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.list_encrption.SelectedIndex < 0)
            {
                this.button_en.Enabled = this.button_de.Enabled = false;
            }
            else if (this.list_encrption.SelectedIndex == 4)
            {
                this.button_en.Enabled = true;
                this.button_de.Enabled = false;
            }
            else
            {
                this.button_en.Enabled = this.button_de.Enabled = true;
            }
        }

    }
}

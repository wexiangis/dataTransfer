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
                    this.text_2.Text = dataTransfer1.asciiToHex16(input);
                else if (dataTransfer2.getHex10())
                    this.text_2.Text = dataTransfer1.asciiToHex10(input);
                else if (dataTransfer2.getHex2())
                    this.text_2.Text = dataTransfer1.asciiToHex2(input);
                else
                    this.text_2.Text = input;
            }
            else if (dataTransfer1.getHex16())
            {
                if (dataTransfer2.getAscii())
                    this.text_2.Text = dataTransfer1.hex16ToAscii(input);
                else if (dataTransfer2.getHex10())
                    this.text_2.Text = dataTransfer1.hex16ToHex10(input);
                else if (dataTransfer2.getHex2())
                    this.text_2.Text = dataTransfer1.hex16ToHex2(input);
                else
                    this.text_2.Text = input;
            }
            else if (dataTransfer1.getHex10())
            {
                if (dataTransfer2.getAscii())
                    this.text_2.Text = dataTransfer1.hex10ToAscii(input);
                else if (dataTransfer2.getHex16())
                    this.text_2.Text = dataTransfer1.hex10ToHex16(input);
                else if (dataTransfer2.getHex2())
                    this.text_2.Text = dataTransfer1.hex10ToHex2(input);
                else
                    this.text_2.Text = input;
            }
            else if (dataTransfer1.getHex2())
            {
                if (dataTransfer2.getAscii())
                    this.text_2.Text = dataTransfer1.hex2ToAscii(input);
                else if (dataTransfer2.getHex16())
                    this.text_2.Text = dataTransfer1.hex2ToHex16(input);
                else if (dataTransfer2.getHex10())
                    this.text_2.Text = dataTransfer1.hex2ToHex10(input);
                else
                    this.text_2.Text = input;
            }else
                this.text_2.Text = "未指定转换类型";
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

        private void check_3desEncode_CheckedChanged(object sender, EventArgs e)
        {
            if (check_3desEncode.CheckState == CheckState.Checked)
            {
                try
                {
                    string result;
                    if (this.check_hex16_1.Checked)
                        result = encryptList.Des3Encryption(Encoding.ASCII.GetString(this.dataTransfer1.hex16ToAscii2(text_1.Text)), this.textKey.Text);
                    else if (this.check_hex10_1.Checked)
                        result = encryptList.Des3Encryption(Encoding.ASCII.GetString(this.dataTransfer1.hex10ToAscii2(text_1.Text)), this.textKey.Text);
                    else if (this.check_hex2_1.Checked)
                        result = encryptList.Des3Encryption(Encoding.ASCII.GetString(this.dataTransfer1.hex2ToAscii2(text_1.Text)), this.textKey.Text);
                    else
                        result = encryptList.Des3Encryption(text_1.Text, this.textKey.Text);
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
                check_3desEncode.CheckState = CheckState.Unchecked;
            }
        }

        private void check_3desDecode_CheckedChanged(object sender, EventArgs e)
        {
            if (check_3desDecode.CheckState == CheckState.Checked)
            {
                try
                {
                    string result;
                    if (this.check_hex16_1.Checked)
                        result = encryptList.Des3Decryption(Encoding.ASCII.GetString(this.dataTransfer1.hex16ToAscii2(text_1.Text)), this.textKey.Text);
                    else if (this.check_hex10_1.Checked)
                        result = encryptList.Des3Decryption(Encoding.ASCII.GetString(this.dataTransfer1.hex10ToAscii2(text_1.Text)), this.textKey.Text);
                    else if (this.check_hex2_1.Checked)
                        result = encryptList.Des3Decryption(Encoding.ASCII.GetString(this.dataTransfer1.hex2ToAscii2(text_1.Text)), this.textKey.Text);
                    else
                        result = encryptList.Des3Decryption(text_1.Text, this.textKey.Text);
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
                check_3desDecode.CheckState = CheckState.Unchecked;
            }
        }

        private void check_enbase64_CheckedChanged(object sender, EventArgs e)
        {
            if (check_enbase64.CheckState == CheckState.Checked)
            {
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
                check_enbase64.CheckState = CheckState.Unchecked;
            }
        }

        private void check_debase64_CheckedChanged(object sender, EventArgs e)
        {
            if (check_debase64.CheckState == CheckState.Checked)
            {
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
                check_debase64.CheckState = CheckState.Unchecked;
            }
        }

        private void check_aesEncode_CheckedChanged(object sender, EventArgs e)
        {
            if (check_aesEncode.CheckState == CheckState.Checked)
            {
                try
                {
                    string result;
                    if (this.check_hex16_1.Checked)
                        result = encryptList.AesEncryption(Encoding.ASCII.GetString(this.dataTransfer1.hex16ToAscii2(text_1.Text)), this.textKey.Text);
                    else if (this.check_hex10_1.Checked)
                        result = encryptList.AesEncryption(Encoding.ASCII.GetString(this.dataTransfer1.hex10ToAscii2(text_1.Text)), this.textKey.Text);
                    else if (this.check_hex2_1.Checked)
                        result = encryptList.AesEncryption(Encoding.ASCII.GetString(this.dataTransfer1.hex2ToAscii2(text_1.Text)), this.textKey.Text);
                    else
                        result = encryptList.AesEncryption(text_1.Text, this.textKey.Text);
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
                check_aesEncode.CheckState = CheckState.Unchecked;
            }
        }

        private void check_aesDecode_CheckedChanged(object sender, EventArgs e)
        {
            if (check_aesDecode.CheckState == CheckState.Checked)
            {
                try
                {
                    string result;
                    if (this.check_hex16_1.Checked)
                        result = encryptList.AesDecryption(Encoding.ASCII.GetString(this.dataTransfer1.hex16ToAscii2(text_1.Text)), this.textKey.Text);
                    else if (this.check_hex10_1.Checked)
                        result = encryptList.AesDecryption(Encoding.ASCII.GetString(this.dataTransfer1.hex10ToAscii2(text_1.Text)), this.textKey.Text);
                    else if (this.check_hex2_1.Checked)
                        result = encryptList.AesDecryption(Encoding.ASCII.GetString(this.dataTransfer1.hex2ToAscii2(text_1.Text)), this.textKey.Text);
                    else
                        result = encryptList.AesDecryption(text_1.Text, this.textKey.Text);
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
                check_aesDecode.CheckState = CheckState.Unchecked;
            }
        }

        private void check_desEncode_CheckedChanged(object sender, EventArgs e)
        {
            if (check_desEncode.CheckState == CheckState.Checked)
            {
                try
                {
                    string result;
                    if (this.check_hex16_1.Checked)
                        result = encryptList.DesEncryption(Encoding.ASCII.GetString(this.dataTransfer1.hex16ToAscii2(text_1.Text)), this.textKey.Text);
                    else if (this.check_hex10_1.Checked)
                        result = encryptList.DesEncryption(Encoding.ASCII.GetString(this.dataTransfer1.hex10ToAscii2(text_1.Text)), this.textKey.Text);
                    else if (this.check_hex2_1.Checked)
                        result = encryptList.DesEncryption(Encoding.ASCII.GetString(this.dataTransfer1.hex2ToAscii2(text_1.Text)), this.textKey.Text);
                    else
                        result = encryptList.DesEncryption(text_1.Text, this.textKey.Text);
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
                check_desEncode.CheckState = CheckState.Unchecked;
            }
        }

        private void check_desDecode_CheckedChanged(object sender, EventArgs e)
        {
            if (check_desDecode.CheckState == CheckState.Checked)
            {
                try
                {
                    string result;
                    if (this.check_hex16_1.Checked)
                        result = encryptList.DesDecryption(Encoding.ASCII.GetString(this.dataTransfer1.hex16ToAscii2(text_1.Text)), this.textKey.Text);
                    else if (this.check_hex10_1.Checked)
                        result = encryptList.DesDecryption(Encoding.ASCII.GetString(this.dataTransfer1.hex10ToAscii2(text_1.Text)), this.textKey.Text);
                    else if (this.check_hex2_1.Checked)
                        result = encryptList.DesDecryption(Encoding.ASCII.GetString(this.dataTransfer1.hex2ToAscii2(text_1.Text)), this.textKey.Text);
                    else
                        result = encryptList.DesDecryption(text_1.Text, this.textKey.Text);
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
                check_desDecode.CheckState = CheckState.Unchecked;
            }
        }

    }
}

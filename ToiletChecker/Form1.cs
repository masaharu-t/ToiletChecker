using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToiletChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_small_Click(object sender, EventArgs e)
        {
            DateTime dtTime = DateTime.Now;
            label1.Text = dtTime.ToString() + "に小をしました。";
            WriteTextToiletTime( dtTime, "小" );


        }

        private void button_big_Click(object sender, EventArgs e)
        {
            DateTime dtTime = DateTime.Now;
            label1.Text = dtTime.ToString() + "に大をしました。";
            WriteTextToiletTime( dtTime, "大" );
        }

        private void button_big_small_Click(object sender, EventArgs e)
        {
            DateTime dtTime = DateTime.Now;
            label1.Text = dtTime.ToString() + "に大小をしました。";
            WriteTextToiletTime( dtTime , "大小" );
        }

        private void WriteTextToiletTime( DateTime dtTime , string str )
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            StreamWriter writer =
              new StreamWriter(@"ToiletChecker.txt", true, sjisEnc);
            writer.WriteLine( dtTime.ToShortDateString() + " " + dtTime.ToLongTimeString() + "," + str );
            writer.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dtTime;
            string str;
            string str2;
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            StreamReader reader =
              new StreamReader(@"ToiletChecker.txt", sjisEnc);
            str = reader.ReadLine();
            reader.Close();

            int iLen;
            int iCount;
            string str1char;

            iLen = str.Length;
            for( iCount = iLen - 1; iCount >= 0; iCount-- )
            {
                str1char = str.Substring(iCount, 1);
                if(str1char == ",")
                {
                    break;
                }
            }

            str2 = str.Substring(0, 19);
            dtTime = DateTime.Parse( str2 );

            label1.Text = dtTime.ToString();
        }
    }
}

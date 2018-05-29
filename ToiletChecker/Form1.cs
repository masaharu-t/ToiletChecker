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
        DateTime PrevdtTime;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_small_Click(object sender, EventArgs e)
        {
            DateTime dtTime = DateTime.Now;
            TimeSpan DifftmSpan = dtTime.Subtract(PrevdtTime);

            if (IsSameRecordTime( dtTime ) )
            {
                return;
            }
            label1.Text = dtTime.ToString() + "に小をしました。";
            WriteTextToiletTime( dtTime, "小" );
            SetRecordTime( dtTime );
            //dtTime.DayOfWeek
            string[] item1 = { dtTime.ToString(), "月","小", DifftmSpan.ToString() };
            listView1.Items.Add(new ListViewItem(item1));
        }

        private void button_big_Click(object sender, EventArgs e)
        {
            DateTime dtTime = DateTime.Now;
            TimeSpan DifftmSpan = dtTime.Subtract(PrevdtTime);
            if (IsSameRecordTime(dtTime) )
            {
                return;
            }
            label1.Text = dtTime.ToString() + "に大をしました。";
            WriteTextToiletTime( dtTime, "大" );
            SetRecordTime(dtTime);
            string[] item1 = { dtTime.ToString(), "月","大", DifftmSpan.ToString() };
            listView1.Items.Add(new ListViewItem(item1));
        }

        private void button_big_small_Click(object sender, EventArgs e)
        {
            DateTime dtTime = DateTime.Now;
            TimeSpan DifftmSpan = dtTime.Subtract(PrevdtTime);
            if (IsSameRecordTime(dtTime))
            {
                return;
            }
            label1.Text = dtTime.ToString() + "に大小をしました。";
            WriteTextToiletTime( dtTime , "大小" );
            SetRecordTime(dtTime);
            string[] item1 = { dtTime.ToString(), "月", "大小", DifftmSpan.ToString() };
            listView1.Items.Add(new ListViewItem(item1));
        }

        private bool IsSameRecordTime(DateTime dtTime)
        {
            bool bRetSameRecordTime;

            //if( (dtTime.Year == PrevdtTime.Year) &&
            //    (dtTime.Month == PrevdtTime.Month) &&
            //    (dtTime.Day == PrevdtTime.Day) &&
            //    (dtTime.Hour == PrevdtTime.Hour) &&
            //    (dtTime.Minute == PrevdtTime.Minute) )
            //{
            //    label1.Text = "記録してから１分以上経過していません。";
            //    bRetSameRecordTime = true;
            //}
            //else
            //{
            //    bRetSameRecordTime = false;
            //}
            DateTime dtTimeLocal;
            int iRet;
            dtTimeLocal = PrevdtTime;
//            dtTimeLocal = dtTimeLocal.AddMinutes(1.0);
            iRet = dtTimeLocal.CompareTo(dtTime);
            if (dtTimeLocal.CompareTo(dtTime) > 0)
            {
                label1.Text = "記録してから１分以上経過していません。";
                bRetSameRecordTime = true;
            }
            else
            {
                bRetSameRecordTime = false;
            }
            return ( bRetSameRecordTime );
        }

        private void SetRecordTime( DateTime dtTime)
        {
            PrevdtTime = dtTime;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            ColumnHeader columnTime;
            ColumnHeader columnWeekDay;
            ColumnHeader columnText;
            ColumnHeader columnPrevDiff;

            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.View = View.Details;
            listView1.Sorting = SortOrder.Ascending;
            

            // listView1.Columns.Add("トイレ時刻",120);
            // listView1.Columns.Add("曜日", 30);
            // listView1.Columns.Add("トイレ種別",70);
            columnTime = new ColumnHeader();
            columnWeekDay = new ColumnHeader();
            columnText = new ColumnHeader();
            columnPrevDiff = new ColumnHeader();

            columnTime.Text = "トイレ時刻";
            columnTime.Width = 120;
            columnWeekDay.Text = "曜日";
            columnWeekDay.Width = 50;
            columnText.Text = "トイレ種別";
            columnText.Width = 70;
            columnPrevDiff.Text = "前回からの経過時間";
            columnPrevDiff.Width = 120;

            ColumnHeader[] colHeaderRegValue =
            { columnTime, columnWeekDay, columnText, columnPrevDiff };
            listView1.Columns.AddRange(colHeaderRegValue);
        }
    }
}

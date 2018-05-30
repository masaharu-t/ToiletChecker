﻿using System;
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
            TimeSpan DiffTmSpan;
            DayOfWeek stDayOfWeek = dtTime.DayOfWeek;
            string ssPrevTimeSpan;

            PrevdtTime = GetPrevDateTime();
            if (IsSameRecordTime( dtTime ) )
            {
                return;
            }
            label1.Text = dtTime.ToString() + "に小をしました。";
            WriteTextToiletTime( dtTime, "小" );
            //SetRecordTime( dtTime );
            DiffTmSpan = dtTime.Subtract(PrevdtTime);
            ssPrevTimeSpan = MakeStringPrevTimeSpan( DiffTmSpan );
            SetListViewItem( dtTime, "小", ssPrevTimeSpan, "-" );
        }

        private void button_big_Click(object sender, EventArgs e)
        {
            DateTime dtTime = DateTime.Now;
            TimeSpan DiffTimeSpan;
            TimeSpan DiffBigTimeSpan;
            DateTime PrevBigDateTime;
            string ssPrevTimeSpan;
            string ssPrevBigTimeSpan;

            PrevdtTime = GetPrevDateTime();
            if (IsSameRecordTime(dtTime) )
            {
                return;
            }
            label1.Text = dtTime.ToString() + "に大をしました。";
            WriteTextToiletTime( dtTime, "大" );
            //SetRecordTime(dtTime);
            PrevBigDateTime = DateTime.Now;
            GetPrevBigDateTime(ref PrevBigDateTime);
            DiffTimeSpan = dtTime.Subtract(PrevdtTime);
            DiffBigTimeSpan = dtTime.Subtract(PrevBigDateTime);
            ssPrevTimeSpan = MakeStringPrevTimeSpan(DiffTimeSpan);
            ssPrevBigTimeSpan = MakeStringPrevTimeSpan(DiffBigTimeSpan);
            SetListViewItem(dtTime, "大", ssPrevTimeSpan, ssPrevBigTimeSpan);
        }

        private void button_big_small_Click(object sender, EventArgs e)
        {
            DateTime dtTime = DateTime.Now;
            TimeSpan DiffTimeSpan;
            TimeSpan DiffBigTimeSpan;
            DateTime PrevBigDateTime;
            string ssPrevTimeSpan;
            string ssPrevBigTimeSpan;

            PrevdtTime = GetPrevDateTime();
            if (IsSameRecordTime(dtTime))
            {
                return;
            }
            label1.Text = dtTime.ToString() + "に大小をしました。";
            WriteTextToiletTime( dtTime , "大小" );
            //SetRecordTime(dtTime);
            PrevBigDateTime = DateTime.Now;
            GetPrevBigDateTime(ref PrevBigDateTime);
            DiffTimeSpan = dtTime.Subtract(PrevdtTime);
            DiffBigTimeSpan = dtTime.Subtract(PrevBigDateTime);
            ssPrevTimeSpan = MakeStringPrevTimeSpan(DiffTimeSpan);
            ssPrevBigTimeSpan = MakeStringPrevTimeSpan(DiffBigTimeSpan);
            SetListViewItem(dtTime, "大小", ssPrevTimeSpan, ssPrevBigTimeSpan);
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
            dtTimeLocal = dtTimeLocal.AddMinutes(1.0);
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
            writer.WriteLine( dtTime.ToString(@"yyyy/MM/dd") + " " + dtTime.ToString(@"HH:mm:ss") + "," + str );
            writer.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ReadToiletCheckData();
            // 全リストを取得し、選択されているアイテムをリストビューから削除する
            foreach (ListViewItem item in listView1.Items)
            {
                // 選択されているか確認する
                if (item.Selected)
                {
                    listView1.Items.Remove(item);
                }
            }
        }

        private string MakeStringPrevTimeSpan(TimeSpan DiffTmSpan)
        {
            string ssPrevTimeSpan;

            if ((DiffTmSpan.Days == 0) && (DiffTmSpan.Hours == 0))
            {
                ssPrevTimeSpan = string.Format("{0}分 ", DiffTmSpan.Minutes);
            }
            else if (DiffTmSpan.Days == 0)
            {
                ssPrevTimeSpan = string.Format("{0}時間{1}分 ", DiffTmSpan.Hours, DiffTmSpan.Minutes);
            }
            else
            {
                ssPrevTimeSpan = string.Format( "{0}日{1}時間{2}分 ", DiffTmSpan.Days, DiffTmSpan.Hours, DiffTmSpan.Minutes );
            }
            return ( ssPrevTimeSpan );
        }

        private void ReadToiletCheckData()
        {
            DateTime dtTime;
            DateTime PrevDtTime;
            DateTime BigPrevDtTime;
            TimeSpan DiffTmSpan;
            TimeSpan DiffBigTmSpan;
            int iReadCnt;
            int iBigCnt;
            string str;
            string str2;
            string str3 = null;
            string ssTimeSpan;
            string ssBigTimeSpan;
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            if( File.Exists(@"ToiletChecker.txt") == false )
            {
                return;
            }

            StreamReader reader =
              new StreamReader(@"ToiletChecker.txt", sjisEnc);
            str = reader.ReadLine();
            if (str == null)
            {
                reader.Close();
                return;
            }
            iReadCnt = 0;
            iBigCnt = 0;
            PrevDtTime = DateTime.Now;
            BigPrevDtTime = DateTime.Now;
            while (str.Length != 0)
            {
                int iLen;
                int iCount;
                string str1char;

                iReadCnt++;
                iLen = str.Length;
                for (iCount = 0; iCount < iLen; iCount++)
                {
                    str1char = str.Substring(iCount, 1);
                    if (str1char == ",")
                    {
                        break;
                    }
                }

                str2 = str.Substring(0, 19);
                dtTime = DateTime.Parse(str2);

                str3 = null;
                for (iCount += 1; iCount < iLen; iCount++)
                {
                    str1char = str.Substring(iCount, 1);
                    str3 += str1char;
                }

                DiffTmSpan = dtTime.Subtract(PrevDtTime);
                //ssTimeSpan = DiffTmSpan.ToString(@"hh\:mm\:ss");
                //ssTimeSpan = "";
                ssTimeSpan = MakeStringPrevTimeSpan( DiffTmSpan );
                PrevDtTime = dtTime;

                if ( str3.Contains("大") ) {
                    iBigCnt++;
                    DiffBigTmSpan = dtTime.Subtract(BigPrevDtTime);
                    BigPrevDtTime = dtTime;
                    
                    if ( iBigCnt != 1)
                    {
                        ssBigTimeSpan = "";
                        ssBigTimeSpan = string.Format("{0}日{1}時間{2}分 ", DiffBigTmSpan.Days, DiffBigTmSpan.Hours, DiffBigTmSpan.Minutes);
                    }
                    else
                    {
                        ssBigTimeSpan = "-";
                    }
                }
                else
                {
                    ssBigTimeSpan = "-";
                }

                SetListViewItem(dtTime, str3.ToString(), ssTimeSpan, ssBigTimeSpan );


                str = reader.ReadLine();
                if (str == null)
                {
                    break;
                }
            }
            reader.Close();
        }

        private DateTime GetPrevDateTime()
        {
            DateTime dtTime;
            string ssDate;

            if (listView1.Items.Count > 0)
            {
                ssDate = listView1.Items[0].SubItems[0].Text;
                dtTime = DateTime.Parse(ssDate);
            }
            else
            {
                dtTime = DateTime.Now;
            }
            return (dtTime);
        }

        private bool GetPrevBigDateTime( ref DateTime dtTime )
        {
            bool bRetExistBigTime;
            string ssDate;
            string ssKind;
            int iListCnt;
            int iCnt;

            bRetExistBigTime = false;
            iListCnt = listView1.Items.Count;
            for (iCnt = 0; iCnt < iListCnt; iCnt++)
            {
                ssKind = listView1.Items[iCnt].SubItems[2].Text;
                if (ssKind.Contains("大"))
                {
                    bRetExistBigTime = true;
                    ssDate = listView1.Items[iCnt].SubItems[0].Text;
                    dtTime = DateTime.Parse(ssDate);
                    break;
                }
            }
            return ( bRetExistBigTime );
        }

        private void SetPrevBigPassedTime()
        {
            DateTime dtTimeNow;
            DateTime dtTimeBig;
            TimeSpan BigTmSpan;

            dtTimeNow = DateTime.Now;
            dtTimeBig = dtTimeNow;

            if( GetPrevBigDateTime(ref dtTimeBig) )
            {
                BigTmSpan = dtTimeNow.Subtract(dtTimeBig);
                label2.Text = "前回の大から" + MakeStringPrevTimeSpan(BigTmSpan) + "経過！";
            }
            else
            {
                label2.Text = "-";
            }
        }

        private string GetStringWeekDay(DateTime dtTime)
        {
            string ssDayOfWeek;

            ssDayOfWeek = ("日月火水木金土").Substring(int.Parse(dtTime.DayOfWeek.ToString("d")), 1);

            return (ssDayOfWeek);
        }

        private void SetListViewItem(DateTime dtTime, string ToiletKind, string ssDiffTimeSpan, string ssBigDiffTimeSpan)
        {
            if (listView1.Items.Count > 0)
            {
                string[] item1 = { dtTime.ToString(@"yyyy/MM/dd HH:mm:ss"), GetStringWeekDay(dtTime), ToiletKind, ssDiffTimeSpan, ssBigDiffTimeSpan };
                listView1.Items.Add(new ListViewItem(item1));
            }
            else
            {
                string[] item1 = { dtTime.ToString(@"yyyy/MM/dd HH:mm:ss"), GetStringWeekDay(dtTime), ToiletKind, "-", "-" };
                listView1.Items.Add(new ListViewItem(item1));
            }
        }

        private void SetListViewColumnInfo()
        {
            ColumnHeader columnTime;
            ColumnHeader columnWeekDay;
            ColumnHeader columnText;
            ColumnHeader columnPrevDiff;
            ColumnHeader columnBigPrevDiff;

            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.View = View.Details;
            listView1.Sorting = SortOrder.Ascending;

            columnTime = new ColumnHeader();
            columnWeekDay = new ColumnHeader();
            columnText = new ColumnHeader();
            columnPrevDiff = new ColumnHeader();
            columnBigPrevDiff = new ColumnHeader();

            columnTime.Text = "トイレ時刻";
            columnTime.Width = 120;

            columnWeekDay.Text = "曜日";
            columnWeekDay.Width = 36;
            columnWeekDay.TextAlign = HorizontalAlignment.Center;

            columnText.Text = "種別";
            columnText.Width = 36;
            columnText.TextAlign = HorizontalAlignment.Center;

            columnPrevDiff.Text = "前回からの経過時間";
            columnPrevDiff.Width = 120;

            columnBigPrevDiff.Text = "前回からの大経過時間";
            columnBigPrevDiff.Width = 136;

            ColumnHeader[] colHeaderRegValue =
            { columnTime, columnWeekDay, columnText, columnPrevDiff, columnBigPrevDiff };
            listView1.Columns.AddRange(colHeaderRegValue);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetListViewColumnInfo();
            ReadToiletCheckData();
            SetPrevBigPassedTime();
        }
    }
}

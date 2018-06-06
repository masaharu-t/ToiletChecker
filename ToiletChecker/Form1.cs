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
        Timer g_timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_small_Click(object sender, EventArgs e)
        {
            DateTime dtTime = DateTime.Now;

            PrevdtTime = GetPrevDateTime();
            if (IsSameRecordTime( dtTime ) )
            {
                return;
            }
            label1.Text = dtTime.ToString() + "に小をしました。";
            WriteTextToiletTime( dtTime, "小" );
            SetListViewItem( dtTime, "小", "-", "-" );
            CalcToiletSpan();
            SetPrevBigPassedTime();
        }

        private void button_big_Click(object sender, EventArgs e)
        {
            DateTime dtTime = DateTime.Now;

            PrevdtTime = GetPrevDateTime();
            if (IsSameRecordTime(dtTime) )
            {
                return;
            }
            label1.Text = dtTime.ToString() + "に大をしました。";
            WriteTextToiletTime( dtTime, "大" );
            SetListViewItem(dtTime, "大", "-", "-");
            CalcToiletSpan();
            SetPrevBigPassedTime();
        }

        private void button_big_small_Click(object sender, EventArgs e)
        {
            DateTime dtTime = DateTime.Now;

            PrevdtTime = GetPrevDateTime();
            if (IsSameRecordTime(dtTime))
            {
                return;
            }
            label1.Text = dtTime.ToString() + "に大小をしました。";
            WriteTextToiletTime( dtTime , "大小" );
            SetListViewItem(dtTime, "大小", "-", "-");
            CalcToiletSpan();
            SetPrevBigPassedTime();
        }

        private bool IsSameRecordTime(DateTime dtTime)
        {
            bool bRetSameRecordTime;
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
            //foreach (ListViewItem item in listView1.Items)
            //{
            //    // 選択されているか確認する
            //    if (item.Selected)
            //    {
            //        listView1.Items.Remove(item);
            //    }
            //}
            AboutBox1 AboutBox = new AboutBox1();
            
            // AboutForm1 をモーダルで表示する
            AboutBox.ShowDialog();
            // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
            AboutBox.Dispose();
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
            int iReadCnt;
            string str;
            string ToiletDateTime;
            string ToiletKind;
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

                ToiletDateTime = null;
                ToiletDateTime = str.Substring(0, 19);
                dtTime = DateTime.Parse(ToiletDateTime);

                ToiletKind = null;
                for (iCount += 1; iCount < iLen; iCount++)
                {
                    str1char = str.Substring(iCount, 1);
                    ToiletKind += str1char;
                }

                SetListViewItem(dtTime, ToiletKind.ToString(), "-", "-" );

                str = reader.ReadLine();
                if (str == null)
                {
                    break;
                }
            }
            reader.Close();
        }

        private DateTime GetToiletTime( int iItemNo )
        {
            DateTime dtRetDateTime;

            dtRetDateTime = GetListViewDateTime( iItemNo );

            return ( dtRetDateTime );
        }

        private DateTime GetPrevToiletTime( int iItemNo )
        {
            DateTime dtRetDateTime;

            dtRetDateTime = GetListViewDateTime( iItemNo - 1 );

            return ( dtRetDateTime );
        }

        private DateTime CalcPrevBigToiletTime()
        {
            return DateTime.Now;
        }

        private void AllCalcPrevBigToiletTime()
        {

        }

        private void CalcPrevToiletTime()
        {

        }

        private void AllCalcPrevToiletTime()
        {

        }

        private void SaveToiletData()
        {
            int iCnt;
            string ss1LineData;

            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            StreamWriter writer =
              new StreamWriter(@"ToiletChecker.txt", true, sjisEnc);

            for (iCnt = listView1.Items.Count-1; iCnt >= 0; iCnt--)
            {
                ss1LineData = string.Format(listView1.Items[iCnt].SubItems[0].Text + "," 
                                            + listView1.Items[iCnt].SubItems[2].Text);
                writer.WriteLine(ss1LineData);
            }
            writer.Close();
        }

        private void SaveNewToiletData()
        {
            int iCnt;
            string ss1LineData;

            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            StreamWriter writer =
              new StreamWriter(@"ToiletChecker.txt", false, sjisEnc);

            for (iCnt = listView1.Items.Count - 1; iCnt >= 0; iCnt--)
            {
                ss1LineData = string.Format(listView1.Items[iCnt].SubItems[0].Text + ","
                                            + listView1.Items[iCnt].SubItems[2].Text);
                writer.WriteLine(ss1LineData);
            }
            writer.Close();
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
                dtTime = dtTime.AddMinutes( -5.0 );
            }
            return (dtTime);
        }

        private DateTime GetListViewDateTime(int iIndex)
        {
            DateTime dtTime;
            string ssDate;

            if (listView1.Items.Count > 0)
            {
                ssDate = listView1.Items[iIndex].SubItems[0].Text;
                dtTime = DateTime.Parse(ssDate);
            }
            else
            {
                dtTime = DateTime.Now;
            }
            return (dtTime);
        }

        private string GetListViewToiletKind(int iIndex)
        {
            string ssRetToiletKind;

            if (listView1.Items.Count > 0)
            {
                ssRetToiletKind = listView1.Items[iIndex].SubItems[2].Text;
            }
            else
            {
                ssRetToiletKind = "小";
            }
            return (ssRetToiletKind);
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

        private void CreateTimer()
        {
            // タイマー生成
            g_timer = new Timer();
            g_timer.Tick += new EventHandler(this.OnTick_FormsTimer);
            g_timer.Interval = 60000;

            // タイマーを開始
            g_timer.Start();
        }

        public void OnTick_FormsTimer(object sender, EventArgs e)
        {
            SetPrevBigPassedTime();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetListViewColumnInfo();
            ReadToiletCheckData();
            CalcToiletSpan();
            SetPrevBigPassedTime();
            CreateTimer();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // タイマーを停止
            g_timer.Stop();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int iSelectedIndex;

            iSelectedIndex = listView1.SelectedItems[0].Index;

            // Form2 の新しいインスタンスを生成する
            Form2 cForm2 = new Form2();
            DateTime dtEditDateTime;
            string ssToiletKind;

            cForm2.SetEditDateTime(iSelectedIndex, GetListViewDateTime(iSelectedIndex));
            cForm2.SetToiletKind(GetListViewToiletKind(iSelectedIndex));
            // Form1 をモーダルで表示する
            cForm2.ShowDialog();

            if (cForm2.DialogResult == DialogResult.OK) {
                dtEditDateTime = cForm2.GetEditDateTime();
                ssToiletKind = cForm2.GetToiletKind();

                listView1.Items[iSelectedIndex].SubItems[0].Text = dtEditDateTime.ToString(@"yyyy/MM/dd HH:mm:ss");
                listView1.Items[iSelectedIndex].SubItems[2].Text = ssToiletKind.ToString();

                listView1.Sort();
                CalcToiletSpan();

                SaveNewToiletData();
            }
            // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
            cForm2.Dispose();
        }

        private void buttonAddData_Click(object sender, EventArgs e)
        {
            // Form2 の新しいインスタンスを生成する
            Form2 cForm2 = new Form2();
            DateTime dtNow;
            string ssString;
            DateTime dtInitialDate;
            DateTime dtEditDateTime;
            string ssToiletKind;

            dtNow = DateTime.Now;
            ssString = dtNow.ToString(@"yyyy/MM/dd HH:mm:00");
            dtInitialDate = DateTime.Parse(ssString);
            cForm2.SetEditDateTime(1, dtInitialDate);
            cForm2.SetInitialToiletKind();
            cForm2.SetInitialToiletPlace();
            cForm2.SetModifyButtonText("追加");
            // Form1 をモーダルで表示する
            cForm2.ShowDialog();

            if (cForm2.DialogResult == DialogResult.OK)
            {
                dtEditDateTime = cForm2.GetEditDateTime();
                ssToiletKind   = cForm2.GetToiletKind();

                string[] item1 = { dtEditDateTime.ToString(@"yyyy/MM/dd HH:mm:ss"), GetStringWeekDay(dtEditDateTime), ssToiletKind, "-"/*ssDiffTimeSpan*/, "-"/*ssBigDiffTimeSpan*/ };
                listView1.Items.Add(new ListViewItem(item1));

                CalcToiletSpan();

                SaveNewToiletData();
            }

            // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
            cForm2.Dispose();
        }

        private void CalcToiletSpanAll()
        {
            int iCnt;
            DateTime dtTime;
            DateTime PrevDtTime;
            TimeSpan DiffTmSpan;
            string ssTimeSpan;

            if(listView1.Items.Count == 0)
            {
                return;
            }

            if (listView1.Items.Count < 2)
            {
                listView1.Items[0].SubItems[3].Text = "-";
                return;
            }
            else
            {
                listView1.Items[listView1.Items.Count - 1].SubItems[3].Text = "-";
            }

            for (iCnt = listView1.Items.Count - 2; iCnt >= 0; iCnt--)
            {
                dtTime     = DateTime.Parse(listView1.Items[iCnt].SubItems[0].Text);
                PrevDtTime = DateTime.Parse(listView1.Items[iCnt + 1].SubItems[0].Text);

                DiffTmSpan = dtTime.Subtract(PrevDtTime);
                ssTimeSpan = MakeStringPrevTimeSpan( DiffTmSpan );
                listView1.Items[iCnt].SubItems[3].Text = ssTimeSpan;
            }
        }

        private void CalcToiletSpanBig()
        {
            int iCnt;
            DateTime dtTime;
            DateTime PrevDtTime;
            TimeSpan DiffTmSpan;
            string ssTimeSpan;
            string ssToiletKind;
            int iBigCnt;

            if( listView1.Items.Count == 0 )
            {
                return;
            }

            if (listView1.Items.Count < 2)
            {
                listView1.Items[0].SubItems[4].Text = "-";
                return;
            }
            else
            {
                listView1.Items[listView1.Items.Count - 1].SubItems[4].Text = "-";
            }

            iBigCnt = 0;
            PrevDtTime = DateTime.Now;
            for (iCnt = listView1.Items.Count - 1; iCnt >= 0; iCnt--)
            {
                ssToiletKind = listView1.Items[iCnt].SubItems[2].Text;
                dtTime = DateTime.Parse(listView1.Items[iCnt].SubItems[0].Text);
                if( ssToiletKind.Contains("大") )
                {
                    iBigCnt++;
                    if (iBigCnt == 1)
                    {
                        listView1.Items[iCnt].SubItems[4].Text = "-";
                    }
                    else
                    {
                        DiffTmSpan = dtTime.Subtract(PrevDtTime);
                        ssTimeSpan = MakeStringPrevTimeSpan(DiffTmSpan);
                        listView1.Items[iCnt].SubItems[4].Text = ssTimeSpan;
                    }
                    PrevDtTime = dtTime;
                }
            }
        }

        private void DrawBigLineBkgnd()
        {
            int iCnt;
            string ssToiletKind;

            for (iCnt = 0; iCnt < listView1.Items.Count; iCnt++ )
            {
                ssToiletKind = listView1.Items[iCnt].SubItems[2].Text;
                if (ssToiletKind.Contains("大"))
                {
                    listView1.Items[iCnt].BackColor = Color.SandyBrown;
                }
                else
                {
                    listView1.Items[iCnt].BackColor = Color.Empty;
                }
            }
        }

        private void CalcToiletSpan()
        {
            CalcToiletSpanAll();
            CalcToiletSpanBig();
            DrawBigLineBkgnd();
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Delete ) // データの削除はDeleteキーのみ受け付ける。
            {
                int iCnt;
                int iSelectedIndex;
                int iSelectedItemCount;
                int iAfterDeletedItemIndex;
                DialogResult Result;

                Result = MessageBox.Show("トイレ時刻データを削除しますか？", "データ削除確認",
                    MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                if( Result == DialogResult.No )
                {
                    return;
                }

                iSelectedItemCount = listView1.SelectedItems.Count;
                if (iSelectedItemCount > 0)
                {
                    iAfterDeletedItemIndex = 0;
                    for ( iCnt = 0; iCnt < iSelectedItemCount; iCnt++ ) {
                        iSelectedIndex = listView1.SelectedItems[0].Index;
                        listView1.Items[iSelectedIndex].Remove();
                        if ( iCnt == 0 )
                        {
                            iAfterDeletedItemIndex = iSelectedIndex;
                        }
                    }
                    if ( iAfterDeletedItemIndex != 0)
                    {
                        if (listView1.Items.Count == iAfterDeletedItemIndex)
                        {
                            iAfterDeletedItemIndex--;
                        }
                    }
                    if (listView1.Items.Count != 0)
                    {
                        listView1.Items[iAfterDeletedItemIndex].Focused = true;
                        listView1.Items[iAfterDeletedItemIndex].Selected = true;
                    }
                    CalcToiletSpan();
                    SaveNewToiletData();
                }
            }
        }
    }
}

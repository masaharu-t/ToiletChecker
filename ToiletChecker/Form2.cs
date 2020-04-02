using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToiletChecker
{
    public partial class Form2 : Form
    {
        int g_iListViewLineNo;
        DateTime g_dtListView;

        public Form2()
        {
            InitializeComponent();
        }

        public void SetEditDateTime( int iLineNo, DateTime dtListView)
        {
            g_iListViewLineNo = iLineNo;
            g_dtListView = dtListView;
        }

        public DateTime GetEditDateTime()
        {
            string ssDateTime;
            DateTime dtEditDateTime;

            //ssDateTime = string.Format( "{0]/{1}/{2} {3}:{4}:{5}",
            //                comboBoxYear.Text, comboBoxMonth.Text, comboBoxDay.Text,
            //                comboBoxHour.Text, comboBoxMinute.Text, comboBoxSecond.Text);
            ssDateTime = string.Format(comboBoxYear.Text + "/" + comboBoxMonth.Text  + "/" + comboBoxDay.Text + " " +
                                       comboBoxHour.Text + ":" + comboBoxMinute.Text + ":" + comboBoxSecond.Text);
            //ssDateTime = DateTime.Parse(ssDateTime);
            dtEditDateTime = DateTime.Parse( ssDateTime );

            return (dtEditDateTime);
        }

        public string GetToiletKind()
        {
            string ssRetToiletKind;

            if( radioButton1.Checked )
            {
                ssRetToiletKind = "大";
            }
            else if (radioButton2.Checked)
            {
                ssRetToiletKind = "小";
            }
            else
            {
                ssRetToiletKind = "大小";
            }

            return (ssRetToiletKind);
        }

        public void SetInitialToiletKind()
        {
            radioButton2.Checked = true;
        }

        public void SetToiletKind(string ssToiletKind)
        {
            if( ssToiletKind == "大" )
            {
                radioButton1.Checked = true;
            }
            else if (ssToiletKind == "小")
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton3.Checked = true;
            }

        }

        public void SetInitialToiletPlace()
        {
            // トイレの場所は自宅を規定値にする
            radioButton4.Checked = true;
        }

        public void SetModifyButtonText( string ssButtonText )
        {
            button1.Text = ssButtonText;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // コンボボックスの初期化
            int iCnt;

            // 年の項目設定
            for( iCnt = 2010; iCnt <= 2050; iCnt++)
            {
                comboBoxYear.Items.Add(iCnt.ToString());
            }

            // 月の項目設定
            for (iCnt = 1; iCnt <= 12; iCnt++)
            {
                comboBoxMonth.Items.Add(iCnt.ToString());
            }

            //日の項目設定
            for (iCnt = 1; iCnt <= 31; iCnt++)
            {
                comboBoxDay.Items.Add(iCnt.ToString());
            }

            //時の項目設定
            for (iCnt = 0; iCnt <= 23; iCnt++)
            {
                comboBoxHour.Items.Add(iCnt.ToString());
            }

            //分の項目設定
            for (iCnt = 0; iCnt <= 59; iCnt++)
            {
                comboBoxMinute.Items.Add(iCnt.ToString());
            }

            //秒の項目設定
            for (iCnt = 0; iCnt <= 59; iCnt++)
            {
                comboBoxSecond.Items.Add(iCnt.ToString());
            }

            comboBoxYear.SelectedIndex   = g_dtListView.Year - 2010;
            comboBoxMonth.SelectedIndex  = g_dtListView.Month - 1;
            comboBoxDay.SelectedIndex    = g_dtListView.Day - 1;
            comboBoxHour.SelectedIndex   = g_dtListView.Hour;
            comboBoxMinute.SelectedIndex = g_dtListView.Minute;
            comboBoxSecond.SelectedIndex = g_dtListView.Second;
        }
    }
}

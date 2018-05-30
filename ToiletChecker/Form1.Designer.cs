namespace ToiletChecker
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_big = new System.Windows.Forms.Button();
            this.button_small = new System.Windows.Forms.Button();
            this.button_big_small = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // button_big
            // 
            this.button_big.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_big.Location = new System.Drawing.Point(30, 65);
            this.button_big.Name = "button_big";
            this.button_big.Size = new System.Drawing.Size(120, 75);
            this.button_big.TabIndex = 0;
            this.button_big.Text = "大";
            this.button_big.UseVisualStyleBackColor = true;
            this.button_big.Click += new System.EventHandler(this.button_big_Click);
            // 
            // button_small
            // 
            this.button_small.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_small.Location = new System.Drawing.Point(196, 65);
            this.button_small.Name = "button_small";
            this.button_small.Size = new System.Drawing.Size(119, 75);
            this.button_small.TabIndex = 1;
            this.button_small.Text = "小";
            this.button_small.UseVisualStyleBackColor = true;
            this.button_small.Click += new System.EventHandler(this.button_small_Click);
            // 
            // button_big_small
            // 
            this.button_big_small.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_big_small.Location = new System.Drawing.Point(361, 65);
            this.button_big_small.Name = "button_big_small";
            this.button_big_small.Size = new System.Drawing.Size(120, 75);
            this.button_big_small.TabIndex = 2;
            this.button_big_small.Text = "大小";
            this.button_big_small.UseVisualStyleBackColor = true;
            this.button_big_small.Click += new System.EventHandler(this.button_big_small_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(20, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "ボタンを押してください。";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(20, 230);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(471, 327);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 569);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_big);
            this.Controls.Add(this.button_small);
            this.Controls.Add(this.button_big_small);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toilet Checker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_big;
        private System.Windows.Forms.Button button_small;
        private System.Windows.Forms.Button button_big_small;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
    }
}


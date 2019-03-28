using System;

namespace DIP.Childform.Graylevel
{
    partial class limitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.labeltopic = new System.Windows.Forms.Label();
            this.textBoxb = new System.Windows.Forms.TextBox();
            this.textBoxa = new System.Windows.Forms.TextBox();
            this.labelb = new System.Windows.Forms.Label();
            this.label_one = new System.Windows.Forms.Label();
            this.groupBox_limit = new System.Windows.Forms.GroupBox();
            this.radioButton_two = new System.Windows.Forms.RadioButton();
            this.radioButton_one = new System.Windows.Forms.RadioButton();
            this.groupBox_double_method = new System.Windows.Forms.GroupBox();
            this.radioButton_255_0_255 = new System.Windows.Forms.RadioButton();
            this.radioButton_0_255_0 = new System.Windows.Forms.RadioButton();
            this.groupBox_limit.SuspendLayout();
            this.groupBox_double_method.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.buttonCancel.Location = new System.Drawing.Point(237, 300);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 28);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.buttonConfirm.Location = new System.Drawing.Point(60, 300);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(80, 28);
            this.buttonConfirm.TabIndex = 12;
            this.buttonConfirm.Text = "确定";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // labeltopic
            // 
            this.labeltopic.AutoSize = true;
            this.labeltopic.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.labeltopic.Location = new System.Drawing.Point(29, 30);
            this.labeltopic.Name = "labeltopic";
            this.labeltopic.Size = new System.Drawing.Size(328, 65);
            this.labeltopic.TabIndex = 9;
            this.labeltopic.Text = "固定阈值变换";
            // 
            // textBoxb
            // 
            this.textBoxb.Location = new System.Drawing.Point(166, 220);
            this.textBoxb.Name = "textBoxb";
            this.textBoxb.Size = new System.Drawing.Size(150, 25);
            this.textBoxb.TabIndex = 17;
            this.textBoxb.Visible = false;
            // 
            // textBoxa
            // 
            this.textBoxa.Location = new System.Drawing.Point(166, 183);
            this.textBoxa.Name = "textBoxa";
            this.textBoxa.Size = new System.Drawing.Size(150, 25);
            this.textBoxa.TabIndex = 16;
            // 
            // labelb
            // 
            this.labelb.AutoSize = true;
            this.labelb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelb.Location = new System.Drawing.Point(57, 220);
            this.labelb.Name = "labelb";
            this.labelb.Size = new System.Drawing.Size(52, 20);
            this.labelb.TabIndex = 15;
            this.labelb.Text = "阈值 2";
            this.labelb.Visible = false;
            // 
            // label_one
            // 
            this.label_one.AutoSize = true;
            this.label_one.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_one.Location = new System.Drawing.Point(57, 185);
            this.label_one.Name = "label_one";
            this.label_one.Size = new System.Drawing.Size(52, 20);
            this.label_one.TabIndex = 14;
            this.label_one.Text = "阈值 1";
            // 
            // groupBox_limit
            // 
            this.groupBox_limit.Controls.Add(this.radioButton_two);
            this.groupBox_limit.Controls.Add(this.radioButton_one);
            this.groupBox_limit.Location = new System.Drawing.Point(40, 117);
            this.groupBox_limit.Name = "groupBox_limit";
            this.groupBox_limit.Size = new System.Drawing.Size(301, 46);
            this.groupBox_limit.TabIndex = 18;
            this.groupBox_limit.TabStop = false;
            // 
            // radioButton_two
            // 
            this.radioButton_two.AutoSize = true;
            this.radioButton_two.Location = new System.Drawing.Point(189, 21);
            this.radioButton_two.Name = "radioButton_two";
            this.radioButton_two.Size = new System.Drawing.Size(103, 19);
            this.radioButton_two.TabIndex = 1;
            this.radioButton_two.Text = "双固定阈值";
            this.radioButton_two.UseVisualStyleBackColor = true;
            this.radioButton_two.CheckedChanged += new System.EventHandler(this.radioButton_two_CheckedChanged);
            // 
            // radioButton_one
            // 
            this.radioButton_one.AutoSize = true;
            this.radioButton_one.Checked = true;
            this.radioButton_one.Location = new System.Drawing.Point(6, 21);
            this.radioButton_one.Name = "radioButton_one";
            this.radioButton_one.Size = new System.Drawing.Size(88, 19);
            this.radioButton_one.TabIndex = 0;
            this.radioButton_one.TabStop = true;
            this.radioButton_one.Text = "固定阈值";
            this.radioButton_one.UseVisualStyleBackColor = true;
            this.radioButton_one.CheckedChanged += new System.EventHandler(this.radioButton_one_CheckedChanged);
            // 
            // groupBox_double_method
            // 
            this.groupBox_double_method.Controls.Add(this.radioButton_255_0_255);
            this.groupBox_double_method.Controls.Add(this.radioButton_0_255_0);
            this.groupBox_double_method.Location = new System.Drawing.Point(40, 248);
            this.groupBox_double_method.Name = "groupBox_double_method";
            this.groupBox_double_method.Size = new System.Drawing.Size(301, 46);
            this.groupBox_double_method.TabIndex = 19;
            this.groupBox_double_method.TabStop = false;
            this.groupBox_double_method.Visible = false;
            // 
            // radioButton_255_0_255
            // 
            this.radioButton_255_0_255.AutoSize = true;
            this.radioButton_255_0_255.Location = new System.Drawing.Point(189, 21);
            this.radioButton_255_0_255.Name = "radioButton_255_0_255";
            this.radioButton_255_0_255.Size = new System.Drawing.Size(100, 19);
            this.radioButton_255_0_255.TabIndex = 1;
            this.radioButton_255_0_255.Text = "255-0-255";
            this.radioButton_255_0_255.UseVisualStyleBackColor = true;
            // 
            // radioButton_0_255_0
            // 
            this.radioButton_0_255_0.AutoSize = true;
            this.radioButton_0_255_0.Checked = true;
            this.radioButton_0_255_0.Location = new System.Drawing.Point(6, 21);
            this.radioButton_0_255_0.Name = "radioButton_0_255_0";
            this.radioButton_0_255_0.Size = new System.Drawing.Size(84, 19);
            this.radioButton_0_255_0.TabIndex = 0;
            this.radioButton_0_255_0.TabStop = true;
            this.radioButton_0_255_0.Text = "0-255-0";
            this.radioButton_0_255_0.UseVisualStyleBackColor = true;
            // 
            // limitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.groupBox_double_method);
            this.Controls.Add(this.groupBox_limit);
            this.Controls.Add(this.textBoxb);
            this.Controls.Add(this.textBoxa);
            this.Controls.Add(this.labelb);
            this.Controls.Add(this.label_one);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.labeltopic);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "limitForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "固定阈值变换";
            this.groupBox_limit.ResumeLayout(false);
            this.groupBox_limit.PerformLayout();
            this.groupBox_double_method.ResumeLayout(false);
            this.groupBox_double_method.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label labeltopic;
        public System.Windows.Forms.TextBox textBoxb;
        public System.Windows.Forms.TextBox textBoxa;
        private System.Windows.Forms.Label labelb;
        private System.Windows.Forms.Label label_one;
        private System.Windows.Forms.GroupBox groupBox_limit;
        private System.Windows.Forms.RadioButton radioButton_two;
        private System.Windows.Forms.RadioButton radioButton_one;
        private System.Windows.Forms.GroupBox groupBox_double_method;
        private System.Windows.Forms.RadioButton radioButton_255_0_255;
        private System.Windows.Forms.RadioButton radioButton_0_255_0;
    }
}
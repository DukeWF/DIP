using System;

namespace DIP.Childform.Smooth
{
    partial class aveForm
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
            this.textBox_value = new System.Windows.Forms.TextBox();
            this.label_one = new System.Windows.Forms.Label();
            this.radioButton_black = new System.Windows.Forms.RadioButton();
            this.radioButton_color = new System.Windows.Forms.RadioButton();
            this.groupBox_limit = new System.Windows.Forms.GroupBox();
            this.groupBox_limit.SuspendLayout();
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
            this.labeltopic.Location = new System.Drawing.Point(73, 30);
            this.labeltopic.Name = "labeltopic";
            this.labeltopic.Size = new System.Drawing.Size(228, 65);
            this.labeltopic.TabIndex = 9;
            this.labeltopic.Text = "均值滤波";
            // 
            // textBox_value
            // 
            this.textBox_value.Location = new System.Drawing.Point(166, 199);
            this.textBox_value.Name = "textBox_value";
            this.textBox_value.Size = new System.Drawing.Size(150, 25);
            this.textBox_value.TabIndex = 16;
            // 
            // label_one
            // 
            this.label_one.AutoSize = true;
            this.label_one.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_one.Location = new System.Drawing.Point(57, 201);
            this.label_one.Name = "label_one";
            this.label_one.Size = new System.Drawing.Size(69, 20);
            this.label_one.TabIndex = 14;
            this.label_one.Text = "模板基数";
            // 
            // radioButton_black
            // 
            this.radioButton_black.AutoSize = true;
            this.radioButton_black.Location = new System.Drawing.Point(6, 21);
            this.radioButton_black.Name = "radioButton_black";
            this.radioButton_black.Size = new System.Drawing.Size(88, 19);
            this.radioButton_black.TabIndex = 0;
            this.radioButton_black.Text = "黑白图像";
            this.radioButton_black.UseVisualStyleBackColor = true;
            this.radioButton_black.CheckedChanged += new System.EventHandler(this.radioButton_one_CheckedChanged);
            // 
            // radioButton_color
            // 
            this.radioButton_color.AutoSize = true;
            this.radioButton_color.Checked = true;
            this.radioButton_color.Location = new System.Drawing.Point(189, 21);
            this.radioButton_color.Name = "radioButton_color";
            this.radioButton_color.Size = new System.Drawing.Size(88, 19);
            this.radioButton_color.TabIndex = 1;
            this.radioButton_color.TabStop = true;
            this.radioButton_color.Text = "彩色图像";
            this.radioButton_color.UseVisualStyleBackColor = true;
            this.radioButton_color.CheckedChanged += new System.EventHandler(this.radioButton_two_CheckedChanged);
            // 
            // groupBox_limit
            // 
            this.groupBox_limit.Controls.Add(this.radioButton_color);
            this.groupBox_limit.Controls.Add(this.radioButton_black);
            this.groupBox_limit.Location = new System.Drawing.Point(40, 117);
            this.groupBox_limit.Name = "groupBox_limit";
            this.groupBox_limit.Size = new System.Drawing.Size(301, 46);
            this.groupBox_limit.TabIndex = 18;
            this.groupBox_limit.TabStop = false;
            // 
            // aveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.groupBox_limit);
            this.Controls.Add(this.textBox_value);
            this.Controls.Add(this.label_one);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.labeltopic);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "aveForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "均值滤波";
            this.groupBox_limit.ResumeLayout(false);
            this.groupBox_limit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label labeltopic;
        public System.Windows.Forms.TextBox textBox_value;
        private System.Windows.Forms.Label label_one;
        private System.Windows.Forms.RadioButton radioButton_black;
        private System.Windows.Forms.RadioButton radioButton_color;
        private System.Windows.Forms.GroupBox groupBox_limit;
    }
}
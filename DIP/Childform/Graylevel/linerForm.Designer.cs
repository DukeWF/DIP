using System;

namespace DIP.Childform.Graylevel
{
    partial class linerForm
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
            this.labela = new System.Windows.Forms.Label();
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
            this.labeltopic.Location = new System.Drawing.Point(77, 30);
            this.labeltopic.Name = "labeltopic";
            this.labeltopic.Size = new System.Drawing.Size(228, 65);
            this.labeltopic.TabIndex = 9;
            this.labeltopic.Text = "线性变换";
            // 
            // textBoxb
            // 
            this.textBoxb.Location = new System.Drawing.Point(166, 196);
            this.textBoxb.Name = "textBoxb";
            this.textBoxb.Size = new System.Drawing.Size(150, 25);
            this.textBoxb.TabIndex = 17;
            // 
            // textBoxa
            // 
            this.textBoxa.Location = new System.Drawing.Point(166, 153);
            this.textBoxa.Name = "textBoxa";
            this.textBoxa.Size = new System.Drawing.Size(150, 25);
            this.textBoxa.TabIndex = 16;
            // 
            // labelb
            // 
            this.labelb.AutoSize = true;
            this.labelb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelb.Location = new System.Drawing.Point(57, 201);
            this.labelb.Name = "labelb";
            this.labelb.Size = new System.Drawing.Size(55, 20);
            this.labelb.TabIndex = 15;
            this.labelb.Text = "参数-b";
            // 
            // labela
            // 
            this.labela.AutoSize = true;
            this.labela.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labela.Location = new System.Drawing.Point(57, 155);
            this.labela.Name = "labela";
            this.labela.Size = new System.Drawing.Size(53, 20);
            this.labela.TabIndex = 14;
            this.labela.Text = "参数-a";
            // 
            // liner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.textBoxb);
            this.Controls.Add(this.textBoxa);
            this.Controls.Add(this.labelb);
            this.Controls.Add(this.labela);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.labeltopic);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "liner";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "线性变换";
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
        private System.Windows.Forms.Label labela;
    }
}
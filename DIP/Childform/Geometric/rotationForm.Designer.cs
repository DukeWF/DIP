namespace DIP.Childform
{
    partial class rotationForm
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
            this.textBox_degree = new System.Windows.Forms.TextBox();
            this.labeltopic = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.label_degeree = new System.Windows.Forms.Label();
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
            // textBox_degree
            // 
            this.textBox_degree.Location = new System.Drawing.Point(166, 153);
            this.textBox_degree.Name = "textBox_degree";
            this.textBox_degree.Size = new System.Drawing.Size(150, 25);
            this.textBox_degree.TabIndex = 10;
            this.textBox_degree.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labeltopic
            // 
            this.labeltopic.AutoSize = true;
            this.labeltopic.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.labeltopic.Location = new System.Drawing.Point(77, 30);
            this.labeltopic.Name = "labeltopic";
            this.labeltopic.Size = new System.Drawing.Size(228, 65);
            this.labeltopic.TabIndex = 9;
            this.labeltopic.Text = "旋转变换";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX.Location = new System.Drawing.Point(57, 155);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(69, 20);
            this.labelX.TabIndex = 7;
            this.labelX.Text = "旋转度数";
            // 
            // label_degeree
            // 
            this.label_degeree.AutoSize = true;
            this.label_degeree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_degeree.Location = new System.Drawing.Point(322, 155);
            this.label_degeree.Name = "label_degeree";
            this.label_degeree.Size = new System.Drawing.Size(15, 20);
            this.label_degeree.TabIndex = 14;
            this.label_degeree.Text = "°";
            // 
            // rotationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.label_degeree);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.textBox_degree);
            this.Controls.Add(this.labeltopic);
            this.Controls.Add(this.labelX);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rotationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "旋转";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirm;
        public System.Windows.Forms.TextBox textBox_degree;
        private System.Windows.Forms.Label labeltopic;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label label_degeree;
    }
}
namespace DIP.Childform
{
    partial class zoomForm
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
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.labeltopic = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
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
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(166, 196);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(150, 25);
            this.textBoxY.TabIndex = 11;
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(166, 153);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(150, 25);
            this.textBoxX.TabIndex = 10;
            // 
            // labeltopic
            // 
            this.labeltopic.AutoSize = true;
            this.labeltopic.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.labeltopic.Location = new System.Drawing.Point(77, 30);
            this.labeltopic.Name = "labeltopic";
            this.labeltopic.Size = new System.Drawing.Size(228, 65);
            this.labeltopic.TabIndex = 9;
            this.labeltopic.Text = "缩放变换";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelY.Location = new System.Drawing.Point(57, 201);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(84, 20);
            this.labelY.TabIndex = 8;
            this.labelY.Text = "缩放倍数-Y";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX.Location = new System.Drawing.Point(57, 155);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(85, 20);
            this.labelX.TabIndex = 7;
            this.labelX.Text = "缩放倍数-X";
            // 
            // zoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.labeltopic);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "zoomForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "缩放";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirm;
        public System.Windows.Forms.TextBox textBoxY;
        public System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Label labeltopic;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
    }
}
namespace WindowsFormsApp1
{
    partial class frmTest
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
            this.btn_guardar_logs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_guardar_logs
            // 
            this.btn_guardar_logs.Location = new System.Drawing.Point(87, 30);
            this.btn_guardar_logs.Name = "btn_guardar_logs";
            this.btn_guardar_logs.Size = new System.Drawing.Size(109, 23);
            this.btn_guardar_logs.TabIndex = 1;
            this.btn_guardar_logs.Text = "Guardar Logs";
            this.btn_guardar_logs.UseVisualStyleBackColor = true;
            this.btn_guardar_logs.Click += new System.EventHandler(this.btn_guardar_logs_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 79);
            this.Controls.Add(this.btn_guardar_logs);
            this.Name = "frmTest";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_guardar_logs;
    }
}
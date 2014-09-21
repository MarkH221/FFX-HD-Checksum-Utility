namespace FFX
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fixbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fixbtn
            // 
            this.fixbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fixbtn.BackColor = System.Drawing.Color.Transparent;
            this.fixbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fixbtn.Location = new System.Drawing.Point(59, 18);
            this.fixbtn.Name = "fixbtn";
            this.fixbtn.Size = new System.Drawing.Size(95, 42);
            this.fixbtn.TabIndex = 0;
            this.fixbtn.Text = "Fix Checksum";
            this.fixbtn.UseVisualStyleBackColor = false;
            this.fixbtn.Click += new System.EventHandler(this.OpenSave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FFX.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(166, 78);
            this.Controls.Add(this.fixbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FFX/2 HD Save Utility";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button fixbtn;
    }
}


namespace Porject_NAQASH_IMS2020
{
    partial class restore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(restore));
            this.btnrestore = new System.Windows.Forms.Button();
            this.btn_browse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pathtext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnrestore
            // 
            this.btnrestore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnrestore.BackColor = System.Drawing.Color.SteelBlue;
            this.btnrestore.Enabled = false;
            this.btnrestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrestore.ForeColor = System.Drawing.Color.White;
            this.btnrestore.Location = new System.Drawing.Point(268, 188);
            this.btnrestore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnrestore.Name = "btnrestore";
            this.btnrestore.Size = new System.Drawing.Size(85, 38);
            this.btnrestore.TabIndex = 7;
            this.btnrestore.Text = "Restore";
            this.btnrestore.UseVisualStyleBackColor = false;
            this.btnrestore.Click += new System.EventHandler(this.btnrestore_Click);
            // 
            // btn_browse
            // 
            this.btn_browse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_browse.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_browse.ForeColor = System.Drawing.Color.White;
            this.btn_browse.Location = new System.Drawing.Point(490, 148);
            this.btn_browse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(83, 30);
            this.btn_browse.TabIndex = 6;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = false;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 153);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select path";
            // 
            // pathtext
            // 
            this.pathtext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pathtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathtext.Location = new System.Drawing.Point(122, 152);
            this.pathtext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pathtext.Name = "pathtext";
            this.pathtext.Size = new System.Drawing.Size(355, 26);
            this.pathtext.TabIndex = 4;
            // 
            // restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnrestore);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathtext);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "restore";
            this.Text = "restore";
            this.Load += new System.EventHandler(this.restore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnrestore;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathtext;
    }
}
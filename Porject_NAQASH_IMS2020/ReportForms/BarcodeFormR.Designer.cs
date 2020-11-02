namespace Porject_NAQASH_IMS2020.ReportForms
{
    partial class BarcodeFormR
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
            this.buttonReset = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dtPurchaseDateReport = new System.Windows.Forms.DateTimePicker();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.tbSearchBarcode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX27 = new DevComponents.DotNetBar.LabelX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reportViewerBarcode = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupPanel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonReset
            // 
            this.buttonReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonReset.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(1049, 10);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(153, 44);
            this.buttonReset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            // 
            // groupPanel4
            // 
            this.groupPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel4.BackColor = System.Drawing.Color.White;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.dtPurchaseDateReport);
            this.groupPanel4.Controls.Add(this.labelX10);
            this.groupPanel4.Controls.Add(this.buttonReset);
            this.groupPanel4.Controls.Add(this.tbSearchBarcode);
            this.groupPanel4.Controls.Add(this.labelX27);
            this.groupPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel4.Location = new System.Drawing.Point(10, 2);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(1211, 81);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2 = System.Drawing.Color.AliceBlue;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor;
            this.groupPanel4.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Center;
            this.groupPanel4.Style.BorderColor = System.Drawing.Color.Transparent;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 70;
            this.groupPanel4.Text = "Search Panel";
            this.groupPanel4.Click += new System.EventHandler(this.groupPanel4_Click);
            // 
            // dtPurchaseDateReport
            // 
            this.dtPurchaseDateReport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtPurchaseDateReport.CustomFormat = "dddd, dd MMMM yyyy";
            this.dtPurchaseDateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPurchaseDateReport.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPurchaseDateReport.Location = new System.Drawing.Point(667, 18);
            this.dtPurchaseDateReport.Name = "dtPurchaseDateReport";
            this.dtPurchaseDateReport.Size = new System.Drawing.Size(315, 29);
            this.dtPurchaseDateReport.TabIndex = 44;
            // 
            // labelX10
            // 
            this.labelX10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX10.ForeColor = System.Drawing.Color.Black;
            this.labelX10.Location = new System.Drawing.Point(528, 19);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(136, 26);
            this.labelX10.TabIndex = 45;
            this.labelX10.Text = "Purchase Date:";
            // 
            // tbSearchBarcode
            // 
            this.tbSearchBarcode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSearchBarcode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbSearchBarcode.Border.Class = "TextBoxBorder";
            this.tbSearchBarcode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbSearchBarcode.DisabledBackColor = System.Drawing.Color.White;
            this.tbSearchBarcode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchBarcode.ForeColor = System.Drawing.Color.Black;
            this.tbSearchBarcode.Location = new System.Drawing.Point(109, 21);
            this.tbSearchBarcode.Name = "tbSearchBarcode";
            this.tbSearchBarcode.PreventEnterBeep = true;
            this.tbSearchBarcode.Size = new System.Drawing.Size(348, 26);
            this.tbSearchBarcode.TabIndex = 42;
            this.tbSearchBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearchBarcode_KeyPress);
            // 
            // labelX27
            // 
            this.labelX27.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX27.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX27.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX27.ForeColor = System.Drawing.Color.Black;
            this.labelX27.Location = new System.Drawing.Point(28, 22);
            this.labelX27.Name = "labelX27";
            this.labelX27.Size = new System.Drawing.Size(74, 23);
            this.labelX27.TabIndex = 41;
            this.labelX27.Text = "Barcode:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.reportViewerBarcode);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(7, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1211, 616);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoices Report";
            // 
            // reportViewerBarcode
            // 
            this.reportViewerBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewerBarcode.AutoSize = true;
            this.reportViewerBarcode.LocalReport.ReportEmbeddedResource = "Porject_NAQASH_IMS2020.Reports.ReportBarcode.rdlc";
            this.reportViewerBarcode.Location = new System.Drawing.Point(3, 18);
            this.reportViewerBarcode.Name = "reportViewerBarcode";
            this.reportViewerBarcode.Size = new System.Drawing.Size(1205, 595);
            this.reportViewerBarcode.TabIndex = 0;
            // 
            // BarcodeFormR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 711);
            this.Controls.Add(this.groupPanel4);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "BarcodeFormR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MetroFormBarcode";
            this.Load += new System.EventHandler(this.DailyInvoiceFormR_Load);
            this.groupPanel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX buttonReset;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbSearchBarcode;
        private DevComponents.DotNetBar.LabelX labelX27;
        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerBarcode;
        private System.Windows.Forms.DateTimePicker dtPurchaseDateReport;
        private DevComponents.DotNetBar.LabelX labelX10;
    }
}
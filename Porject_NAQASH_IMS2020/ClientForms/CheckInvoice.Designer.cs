namespace Porject_NAQASH_IMS2020.ClientForms
{
    partial class CheckInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInvoice));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridViewCheckInvoice = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cateogry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelSalesOrderID = new DevComponents.DotNetBar.LabelX();
            this.labelCustomerID = new DevComponents.DotNetBar.LabelX();
            this.rtbDetails = new System.Windows.Forms.RichTextBox();
            this.lblDetails = new DevComponents.DotNetBar.LabelX();
            this.dtDueDate = new System.Windows.Forms.DateTimePicker();
            this.dtCurrentDate = new System.Windows.Forms.DateTimePicker();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.tbContact = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.tbCustomerName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbGrandTotal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            this.tbAdvance = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX25 = new DevComponents.DotNetBar.LabelX();
            this.labelX26 = new DevComponents.DotNetBar.LabelX();
            this.tbBalance = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonReset = new DevComponents.DotNetBar.ButtonX();
            this.buttonUpdateInvoice = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX29 = new DevComponents.DotNetBar.LabelX();
            this.tSearchContact = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX28 = new DevComponents.DotNetBar.LabelX();
            this.tbSearchInvocie = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX27 = new DevComponents.DotNetBar.LabelX();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCheckInvoice)).BeginInit();
            this.groupPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.gridViewCheckInvoice);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(7, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1211, 389);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Products Dipslay";
            // 
            // gridViewCheckInvoice
            // 
            this.gridViewCheckInvoice.AllowUserToAddRows = false;
            this.gridViewCheckInvoice.AllowUserToDeleteRows = false;
            this.gridViewCheckInvoice.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewCheckInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridViewCheckInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewCheckInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Cateogry,
            this.Type,
            this.Brand,
            this.Size,
            this.Color,
            this.UnitPrice,
            this.Qty,
            this.TotalPrice,
            this.BarCode});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewCheckInvoice.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridViewCheckInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewCheckInvoice.EnableHeadersVisualStyles = false;
            this.gridViewCheckInvoice.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.gridViewCheckInvoice.Location = new System.Drawing.Point(3, 18);
            this.gridViewCheckInvoice.MultiSelect = false;
            this.gridViewCheckInvoice.Name = "gridViewCheckInvoice";
            this.gridViewCheckInvoice.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewCheckInvoice.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridViewCheckInvoice.Size = new System.Drawing.Size(1205, 368);
            this.gridViewCheckInvoice.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Cateogry
            // 
            this.Cateogry.HeaderText = "Category";
            this.Cateogry.Name = "Cateogry";
            this.Cateogry.ReadOnly = true;
            this.Cateogry.Width = 150;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 150;
            // 
            // Brand
            // 
            this.Brand.HeaderText = "Brand";
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            this.Brand.Width = 150;
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            this.Size.Width = 150;
            // 
            // Color
            // 
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            this.Color.Width = 150;
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "UnitPrice";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // TotalPrice
            // 
            this.TotalPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalPrice.HeaderText = "TotalPrice";
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            // 
            // BarCode
            // 
            this.BarCode.HeaderText = "BarCode";
            this.BarCode.Name = "BarCode";
            this.BarCode.ReadOnly = true;
            // 
            // groupPanel3
            // 
            this.groupPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel3.BackColor = System.Drawing.Color.White;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.labelSalesOrderID);
            this.groupPanel3.Controls.Add(this.labelCustomerID);
            this.groupPanel3.Controls.Add(this.rtbDetails);
            this.groupPanel3.Controls.Add(this.lblDetails);
            this.groupPanel3.Controls.Add(this.dtDueDate);
            this.groupPanel3.Controls.Add(this.dtCurrentDate);
            this.groupPanel3.Controls.Add(this.labelX8);
            this.groupPanel3.Controls.Add(this.tbContact);
            this.groupPanel3.Controls.Add(this.labelX7);
            this.groupPanel3.Controls.Add(this.labelX2);
            this.groupPanel3.Controls.Add(this.labelX9);
            this.groupPanel3.Controls.Add(this.tbCustomerName);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(7, 86);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(1211, 121);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2 = System.Drawing.Color.AliceBlue;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor;
            this.groupPanel3.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Center;
            this.groupPanel3.Style.BorderColor = System.Drawing.Color.Transparent;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 65;
            this.groupPanel3.Text = "Customer Information";
            this.groupPanel3.Click += new System.EventHandler(this.groupPanel3_Click);
            // 
            // labelSalesOrderID
            // 
            this.labelSalesOrderID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSalesOrderID.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelSalesOrderID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSalesOrderID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSalesOrderID.ForeColor = System.Drawing.Color.Black;
            this.labelSalesOrderID.Location = new System.Drawing.Point(100, 3);
            this.labelSalesOrderID.Name = "labelSalesOrderID";
            this.labelSalesOrderID.Size = new System.Drawing.Size(65, 23);
            this.labelSalesOrderID.TabIndex = 12;
            this.labelSalesOrderID.Text = "SalesOrderID";
            // 
            // labelCustomerID
            // 
            this.labelCustomerID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCustomerID.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelCustomerID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelCustomerID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomerID.ForeColor = System.Drawing.Color.Black;
            this.labelCustomerID.Location = new System.Drawing.Point(20, 3);
            this.labelCustomerID.Name = "labelCustomerID";
            this.labelCustomerID.Size = new System.Drawing.Size(65, 23);
            this.labelCustomerID.TabIndex = 11;
            this.labelCustomerID.Text = "CustomerID";
            // 
            // rtbDetails
            // 
            this.rtbDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rtbDetails.BackColor = System.Drawing.Color.White;
            this.rtbDetails.ForeColor = System.Drawing.Color.Black;
            this.rtbDetails.Location = new System.Drawing.Point(102, 64);
            this.rtbDetails.Name = "rtbDetails";
            this.rtbDetails.Size = new System.Drawing.Size(1088, 24);
            this.rtbDetails.TabIndex = 10;
            this.rtbDetails.Text = "";
            // 
            // lblDetails
            // 
            this.lblDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDetails.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDetails.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.ForeColor = System.Drawing.Color.Black;
            this.lblDetails.Location = new System.Drawing.Point(21, 63);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(64, 23);
            this.lblDetails.TabIndex = 9;
            this.lblDetails.Text = "Details";
            // 
            // dtDueDate
            // 
            this.dtDueDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtDueDate.BackColor = System.Drawing.Color.White;
            this.dtDueDate.CustomFormat = "dd MMMM yyyy HH:mm";
            this.dtDueDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDueDate.ForeColor = System.Drawing.Color.Black;
            this.dtDueDate.Location = new System.Drawing.Point(363, 27);
            this.dtDueDate.Name = "dtDueDate";
            this.dtDueDate.Size = new System.Drawing.Size(166, 25);
            this.dtDueDate.TabIndex = 7;
            // 
            // dtCurrentDate
            // 
            this.dtCurrentDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtCurrentDate.BackColor = System.Drawing.Color.White;
            this.dtCurrentDate.CustomFormat = "dd MMMM yyyy HH:mm";
            this.dtCurrentDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCurrentDate.ForeColor = System.Drawing.Color.Black;
            this.dtCurrentDate.Location = new System.Drawing.Point(102, 27);
            this.dtCurrentDate.Name = "dtCurrentDate";
            this.dtCurrentDate.Size = new System.Drawing.Size(166, 25);
            this.dtCurrentDate.TabIndex = 1;
            // 
            // labelX8
            // 
            this.labelX8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX8.ForeColor = System.Drawing.Color.Black;
            this.labelX8.Location = new System.Drawing.Point(21, 29);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(77, 23);
            this.labelX8.TabIndex = 4;
            this.labelX8.Text = "C Date:";
            // 
            // tbContact
            // 
            this.tbContact.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbContact.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbContact.Border.Class = "TextBoxBorder";
            this.tbContact.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbContact.DisabledBackColor = System.Drawing.Color.White;
            this.tbContact.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContact.ForeColor = System.Drawing.Color.Black;
            this.tbContact.Location = new System.Drawing.Point(943, 29);
            this.tbContact.Name = "tbContact";
            this.tbContact.PreventEnterBeep = true;
            this.tbContact.Size = new System.Drawing.Size(247, 26);
            this.tbContact.TabIndex = 2;
            // 
            // labelX7
            // 
            this.labelX7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.ForeColor = System.Drawing.Color.Black;
            this.labelX7.Location = new System.Drawing.Point(283, 29);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(81, 23);
            this.labelX7.TabIndex = 5;
            this.labelX7.Text = "Due Date:";
            // 
            // labelX2
            // 
            this.labelX2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(873, 28);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(64, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "Contact:";
            // 
            // labelX9
            // 
            this.labelX9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX9.ForeColor = System.Drawing.Color.Black;
            this.labelX9.Location = new System.Drawing.Point(540, 28);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(65, 23);
            this.labelX9.TabIndex = 4;
            this.labelX9.Text = "C Name:";
            // 
            // tbCustomerName
            // 
            this.tbCustomerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbCustomerName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbCustomerName.Border.Class = "TextBoxBorder";
            this.tbCustomerName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbCustomerName.DisabledBackColor = System.Drawing.Color.White;
            this.tbCustomerName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomerName.ForeColor = System.Drawing.Color.Black;
            this.tbCustomerName.Location = new System.Drawing.Point(611, 28);
            this.tbCustomerName.Name = "tbCustomerName";
            this.tbCustomerName.PreventEnterBeep = true;
            this.tbCustomerName.Size = new System.Drawing.Size(247, 26);
            this.tbCustomerName.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tbGrandTotal);
            this.panel1.Controls.Add(this.labelX19);
            this.panel1.Controls.Add(this.tbAdvance);
            this.panel1.Controls.Add(this.labelX25);
            this.panel1.Controls.Add(this.labelX26);
            this.panel1.Controls.Add(this.tbBalance);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(7, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 97);
            this.panel1.TabIndex = 68;
            // 
            // tbGrandTotal
            // 
            this.tbGrandTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbGrandTotal.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbGrandTotal.Border.Class = "TextBoxBorder";
            this.tbGrandTotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbGrandTotal.DisabledBackColor = System.Drawing.Color.White;
            this.tbGrandTotal.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrandTotal.ForeColor = System.Drawing.Color.Black;
            this.tbGrandTotal.Location = new System.Drawing.Point(283, 47);
            this.tbGrandTotal.Name = "tbGrandTotal";
            this.tbGrandTotal.PreventEnterBeep = true;
            this.tbGrandTotal.Size = new System.Drawing.Size(249, 35);
            this.tbGrandTotal.TabIndex = 0;
            this.tbGrandTotal.Text = "0";
            this.tbGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbGrandTotal.TextChanged += new System.EventHandler(this.tbGrandTotal_TextChanged);
            // 
            // labelX19
            // 
            this.labelX19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX19.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX19.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX19.ForeColor = System.Drawing.Color.Black;
            this.labelX19.Location = new System.Drawing.Point(283, 18);
            this.labelX19.Name = "labelX19";
            this.labelX19.Size = new System.Drawing.Size(249, 23);
            this.labelX19.TabIndex = 3;
            this.labelX19.Text = "Grand Total";
            this.labelX19.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // tbAdvance
            // 
            this.tbAdvance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbAdvance.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbAdvance.Border.Class = "TextBoxBorder";
            this.tbAdvance.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbAdvance.DisabledBackColor = System.Drawing.Color.White;
            this.tbAdvance.Font = new System.Drawing.Font("Arial", 18F);
            this.tbAdvance.ForeColor = System.Drawing.Color.Black;
            this.tbAdvance.Location = new System.Drawing.Point(20, 47);
            this.tbAdvance.Name = "tbAdvance";
            this.tbAdvance.PreventEnterBeep = true;
            this.tbAdvance.Size = new System.Drawing.Size(115, 35);
            this.tbAdvance.TabIndex = 1;
            this.tbAdvance.Text = "0";
            this.tbAdvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbAdvance.TextChanged += new System.EventHandler(this.tbAdvance_TextChanged);
            // 
            // labelX25
            // 
            this.labelX25.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX25.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX25.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX25.ForeColor = System.Drawing.Color.Black;
            this.labelX25.Location = new System.Drawing.Point(151, 18);
            this.labelX25.Name = "labelX25";
            this.labelX25.Size = new System.Drawing.Size(115, 23);
            this.labelX25.TabIndex = 5;
            this.labelX25.Text = "Balance";
            this.labelX25.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX26
            // 
            this.labelX26.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX26.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX26.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX26.ForeColor = System.Drawing.Color.Black;
            this.labelX26.Location = new System.Drawing.Point(19, 18);
            this.labelX26.Name = "labelX26";
            this.labelX26.Size = new System.Drawing.Size(115, 23);
            this.labelX26.TabIndex = 4;
            this.labelX26.Text = "Advance";
            this.labelX26.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // tbBalance
            // 
            this.tbBalance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbBalance.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbBalance.Border.Class = "TextBoxBorder";
            this.tbBalance.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbBalance.DisabledBackColor = System.Drawing.Color.White;
            this.tbBalance.Enabled = false;
            this.tbBalance.Font = new System.Drawing.Font("Arial", 18F);
            this.tbBalance.ForeColor = System.Drawing.Color.Black;
            this.tbBalance.Location = new System.Drawing.Point(153, 47);
            this.tbBalance.Name = "tbBalance";
            this.tbBalance.PreventEnterBeep = true;
            this.tbBalance.Size = new System.Drawing.Size(115, 35);
            this.tbBalance.TabIndex = 2;
            this.tbBalance.Text = "0";
            this.tbBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.buttonReset);
            this.panel2.Controls.Add(this.buttonUpdateInvoice);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(568, 213);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 97);
            this.panel2.TabIndex = 69;
            // 
            // buttonReset
            // 
            this.buttonReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonReset.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(235, 18);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(218, 64);
            this.buttonReset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonUpdateInvoice
            // 
            this.buttonUpdateInvoice.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonUpdateInvoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonUpdateInvoice.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonUpdateInvoice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateInvoice.Location = new System.Drawing.Point(16, 18);
            this.buttonUpdateInvoice.Name = "buttonUpdateInvoice";
            this.buttonUpdateInvoice.Size = new System.Drawing.Size(213, 64);
            this.buttonUpdateInvoice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonUpdateInvoice.TabIndex = 0;
            this.buttonUpdateInvoice.Text = "Update Invoice";
            this.buttonUpdateInvoice.Click += new System.EventHandler(this.buttonUpdateInvoice_Click);
            // 
            // groupPanel4
            // 
            this.groupPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel4.BackColor = System.Drawing.Color.White;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.labelX29);
            this.groupPanel4.Controls.Add(this.tSearchContact);
            this.groupPanel4.Controls.Add(this.labelX28);
            this.groupPanel4.Controls.Add(this.tbSearchInvocie);
            this.groupPanel4.Controls.Add(this.labelX27);
            this.groupPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel4.Location = new System.Drawing.Point(7, 9);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(1211, 71);
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
            // 
            // labelX29
            // 
            this.labelX29.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX29.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX29.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX29.ForeColor = System.Drawing.Color.Black;
            this.labelX29.Location = new System.Drawing.Point(577, 16);
            this.labelX29.Name = "labelX29";
            this.labelX29.Size = new System.Drawing.Size(10, 23);
            this.labelX29.TabIndex = 45;
            this.labelX29.Text = "|";
            this.labelX29.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // tSearchContact
            // 
            this.tSearchContact.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tSearchContact.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tSearchContact.Border.Class = "TextBoxBorder";
            this.tSearchContact.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tSearchContact.DisabledBackColor = System.Drawing.Color.White;
            this.tSearchContact.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSearchContact.ForeColor = System.Drawing.Color.Black;
            this.tSearchContact.Location = new System.Drawing.Point(703, 18);
            this.tSearchContact.Name = "tSearchContact";
            this.tSearchContact.PreventEnterBeep = true;
            this.tSearchContact.Size = new System.Drawing.Size(275, 26);
            this.tSearchContact.TabIndex = 44;
            // 
            // labelX28
            // 
            this.labelX28.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX28.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX28.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX28.ForeColor = System.Drawing.Color.Black;
            this.labelX28.Location = new System.Drawing.Point(604, 17);
            this.labelX28.Name = "labelX28";
            this.labelX28.Size = new System.Drawing.Size(93, 23);
            this.labelX28.TabIndex = 43;
            this.labelX28.Text = "Contact No:";
            this.labelX28.Click += new System.EventHandler(this.labelX28_Click);
            // 
            // tbSearchInvocie
            // 
            this.tbSearchInvocie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSearchInvocie.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbSearchInvocie.Border.Class = "TextBoxBorder";
            this.tbSearchInvocie.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbSearchInvocie.DisabledBackColor = System.Drawing.Color.White;
            this.tbSearchInvocie.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchInvocie.ForeColor = System.Drawing.Color.Black;
            this.tbSearchInvocie.Location = new System.Drawing.Point(285, 17);
            this.tbSearchInvocie.Name = "tbSearchInvocie";
            this.tbSearchInvocie.PreventEnterBeep = true;
            this.tbSearchInvocie.Size = new System.Drawing.Size(275, 26);
            this.tbSearchInvocie.TabIndex = 42;
            this.tbSearchInvocie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearchInvocie_KeyPress);
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
            this.labelX27.Location = new System.Drawing.Point(215, 16);
            this.labelX27.Name = "labelX27";
            this.labelX27.Size = new System.Drawing.Size(64, 23);
            this.labelX27.TabIndex = 41;
            this.labelX27.Text = "Invoice:";
            // 
            // CheckInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 711);
            this.Controls.Add(this.groupPanel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MetroForm";
            this.Load += new System.EventHandler(this.CheckInvoice_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCheckInvoice)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewX gridViewCheckInvoice;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.LabelX lblDetails;
        private System.Windows.Forms.DateTimePicker dtDueDate;
        private System.Windows.Forms.DateTimePicker dtCurrentDate;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX tbContact;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.TextBoxX tbCustomerName;
        private System.Windows.Forms.RichTextBox rtbDetails;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbGrandTotal;
        private DevComponents.DotNetBar.LabelX labelX19;
        private DevComponents.DotNetBar.Controls.TextBoxX tbAdvance;
        private DevComponents.DotNetBar.LabelX labelX25;
        private DevComponents.DotNetBar.LabelX labelX26;
        private DevComponents.DotNetBar.Controls.TextBoxX tbBalance;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ButtonX buttonReset;
        private DevComponents.DotNetBar.ButtonX buttonUpdateInvoice;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.Controls.TextBoxX tSearchContact;
        private DevComponents.DotNetBar.LabelX labelX28;
        private DevComponents.DotNetBar.Controls.TextBoxX tbSearchInvocie;
        private DevComponents.DotNetBar.LabelX labelX27;
        private DevComponents.DotNetBar.LabelX labelX29;
        private DevComponents.DotNetBar.LabelX labelCustomerID;
        private DevComponents.DotNetBar.LabelX labelSalesOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cateogry;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarCode;
    }
}
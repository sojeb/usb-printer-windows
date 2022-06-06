namespace MYPRINTER
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.exitBtn = new System.Windows.Forms.Button();
            this.PrintBtn = new System.Windows.Forms.Button();
            this.previewBtn = new System.Windows.Forms.Button();
            this.addOrderBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.customerName = new System.Windows.Forms.TextBox();
            this.ItemName = new System.Windows.Forms.ComboBox();
            this.Quantity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.TextBox();
            this.totalToPay = new System.Windows.Forms.TextBox();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 95);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(131, 346);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.exitBtn);
            this.panel3.Controls.Add(this.PrintBtn);
            this.panel3.Controls.Add(this.previewBtn);
            this.panel3.Controls.Add(this.addOrderBtn);
            this.panel3.Location = new System.Drawing.Point(2, 96);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(137, 358);
            this.panel3.TabIndex = 1;
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(0, 270);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(137, 72);
            this.exitBtn.TabIndex = 5;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // PrintBtn
            // 
            this.PrintBtn.Location = new System.Drawing.Point(0, 174);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(137, 72);
            this.PrintBtn.TabIndex = 4;
            this.PrintBtn.Text = "Print";
            this.PrintBtn.UseVisualStyleBackColor = true;
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // previewBtn
            // 
            this.previewBtn.Location = new System.Drawing.Point(-2, 84);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(137, 72);
            this.previewBtn.TabIndex = 3;
            this.previewBtn.Text = "Print Preview";
            this.previewBtn.UseVisualStyleBackColor = true;
            this.previewBtn.Click += new System.EventHandler(this.previewBtn_Click);
            // 
            // addOrderBtn
            // 
            this.addOrderBtn.Location = new System.Drawing.Point(0, -1);
            this.addOrderBtn.Name = "addOrderBtn";
            this.addOrderBtn.Size = new System.Drawing.Size(137, 72);
            this.addOrderBtn.TabIndex = 2;
            this.addOrderBtn.Text = "Print All";
            this.addOrderBtn.UseVisualStyleBackColor = true;
            this.addOrderBtn.Click += new System.EventHandler(this.addOrderBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customer Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // customerName
            // 
            this.customerName.Location = new System.Drawing.Point(294, 147);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(207, 27);
            this.customerName.TabIndex = 3;
            this.customerName.TextChanged += new System.EventHandler(this.customerName_TextChanged);
            // 
            // ItemName
            // 
            this.ItemName.FormattingEnabled = true;
            this.ItemName.Items.AddRange(new object[] {
            "Monitor",
            "CPU",
            "Mouse",
            "Mobile",
            "Head phone"});
            this.ItemName.Location = new System.Drawing.Point(294, 193);
            this.ItemName.Name = "ItemName";
            this.ItemName.Size = new System.Drawing.Size(207, 28);
            this.ItemName.TabIndex = 5;
            // 
            // Quantity
            // 
            this.Quantity.FormattingEnabled = true;
            this.Quantity.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.Quantity.Location = new System.Drawing.Point(294, 243);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(207, 28);
            this.Quantity.TabIndex = 6;
            this.Quantity.SelectedIndexChanged += new System.EventHandler(this.Quantity_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Item Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Quantity";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Price";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Total To Pay";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Price
            // 
            this.Price.Location = new System.Drawing.Point(294, 300);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(207, 27);
            this.Price.TabIndex = 10;
            this.Price.TextChanged += new System.EventHandler(this.Price_TextChanged);
            // 
            // totalToPay
            // 
            this.totalToPay.Location = new System.Drawing.Point(294, 349);
            this.totalToPay.Name = "totalToPay";
            this.totalToPay.ReadOnly = true;
            this.totalToPay.Size = new System.Drawing.Size(207, 27);
            this.totalToPay.TabIndex = 11;
            this.totalToPay.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            this.printPreviewDialog.Load += new System.EventHandler(this.printPreviewDialog_Load);
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(921, 515);
            this.Controls.Add(this.totalToPay);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.ItemName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.customerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button PrintBtn;
        private Button previewBtn;
        private Button addOrderBtn;
        private Button exitBtn;
        private Label label1;
        private TextBox customerName;
        private ComboBox ItemName;
        private ComboBox Quantity;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox Price;
        private TextBox totalToPay;
        private PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Drawing.Printing.PrintDocument printDocument2;
    }
}
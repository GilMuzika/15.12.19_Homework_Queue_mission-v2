namespace _15._12._19_Homework_Queue_mission
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
            this.pnlQueue = new System.Windows.Forms.Panel();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.lblSortBy = new System.Windows.Forms.Label();
            this.btnSortByProtection = new System.Windows.Forms.Button();
            this.btnSortByYear = new System.Windows.Forms.Button();
            this.btnSortByTotalPurchases = new System.Windows.Forms.Button();
            this.lblHelp = new System.Windows.Forms.Label();
            this.cmbSortByAnyProperty = new System.Windows.Forms.ComboBox();
            this.pnlCustomerInformation = new _15._12._19_Homework_Queue_mission.ScrollablePanel();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.lblSortByAnyProperty = new System.Windows.Forms.Label();
            this.pnlCustomerInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlQueue
            // 
            this.pnlQueue.Location = new System.Drawing.Point(129, 12);
            this.pnlQueue.Name = "pnlQueue";
            this.pnlQueue.Size = new System.Drawing.Size(640, 426);
            this.pnlQueue.TabIndex = 0;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(13, 13);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(87, 23);
            this.btnAddCustomer.TabIndex = 1;
            this.btnAddCustomer.Text = "Add customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // lblSortBy
            // 
            this.lblSortBy.AutoSize = true;
            this.lblSortBy.Location = new System.Drawing.Point(13, 52);
            this.lblSortBy.Name = "lblSortBy";
            this.lblSortBy.Size = new System.Drawing.Size(43, 13);
            this.lblSortBy.TabIndex = 3;
            this.lblSortBy.Text = "Sort by:";
            // 
            // btnSortByProtection
            // 
            this.btnSortByProtection.Location = new System.Drawing.Point(1, 67);
            this.btnSortByProtection.Name = "btnSortByProtection";
            this.btnSortByProtection.Size = new System.Drawing.Size(67, 22);
            this.btnSortByProtection.TabIndex = 4;
            this.btnSortByProtection.Text = "Protection";
            this.btnSortByProtection.UseVisualStyleBackColor = true;
            this.btnSortByProtection.Click += new System.EventHandler(this.btnSortByProtection_Click);
            // 
            // btnSortByYear
            // 
            this.btnSortByYear.Location = new System.Drawing.Point(75, 66);
            this.btnSortByYear.Name = "btnSortByYear";
            this.btnSortByYear.Size = new System.Drawing.Size(48, 23);
            this.btnSortByYear.TabIndex = 5;
            this.btnSortByYear.Text = "Year";
            this.btnSortByYear.UseVisualStyleBackColor = true;
            this.btnSortByYear.Click += new System.EventHandler(this.btnSortByYear_Click);
            // 
            // btnSortByTotalPurchases
            // 
            this.btnSortByTotalPurchases.Location = new System.Drawing.Point(1, 95);
            this.btnSortByTotalPurchases.Name = "btnSortByTotalPurchases";
            this.btnSortByTotalPurchases.Size = new System.Drawing.Size(99, 20);
            this.btnSortByTotalPurchases.TabIndex = 6;
            this.btnSortByTotalPurchases.Text = "Total purchases";
            this.btnSortByTotalPurchases.UseVisualStyleBackColor = true;
            this.btnSortByTotalPurchases.Click += new System.EventHandler(this.btnSortByTotalPurchases_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.Location = new System.Drawing.Point(1, 336);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(122, 102);
            this.lblHelp.TabIndex = 7;
            this.lblHelp.Text = "label1";
            // 
            // cmbSortByAnyProperty
            // 
            this.cmbSortByAnyProperty.FormattingEnabled = true;
            this.cmbSortByAnyProperty.Location = new System.Drawing.Point(3, 159);
            this.cmbSortByAnyProperty.Name = "cmbSortByAnyProperty";
            this.cmbSortByAnyProperty.Size = new System.Drawing.Size(122, 21);
            this.cmbSortByAnyProperty.TabIndex = 8;
            // 
            // pnlCustomerInformation
            // 
            this.pnlCustomerInformation.AutoScroll = true;
            this.pnlCustomerInformation.AutoScrollHorizontalMaximum = 100;
            this.pnlCustomerInformation.AutoScrollHorizontalMinimum = 0;
            this.pnlCustomerInformation.AutoScrollHPos = 0;
            this.pnlCustomerInformation.AutoScrollVerticalMaximum = 100;
            this.pnlCustomerInformation.AutoScrollVerticalMinimum = 0;
            this.pnlCustomerInformation.AutoScrollVPos = 0;
            this.pnlCustomerInformation.Controls.Add(this.lblCustomerInfo);
            this.pnlCustomerInformation.EnableAutoScrollHorizontal = true;
            this.pnlCustomerInformation.EnableAutoScrollVertical = true;
            this.pnlCustomerInformation.Location = new System.Drawing.Point(775, 13);
            this.pnlCustomerInformation.Name = "pnlCustomerInformation";
            this.pnlCustomerInformation.Size = new System.Drawing.Size(231, 425);
            this.pnlCustomerInformation.TabIndex = 2;
            this.pnlCustomerInformation.VisibleAutoScrollHorizontal = true;
            this.pnlCustomerInformation.VisibleAutoScrollVertical = true;
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.AutoSize = true;
            this.lblCustomerInfo.Location = new System.Drawing.Point(5, 5);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(0, 13);
            this.lblCustomerInfo.TabIndex = 0;
            // 
            // lblSortByAnyProperty
            // 
            this.lblSortByAnyProperty.AutoSize = true;
            this.lblSortByAnyProperty.Location = new System.Drawing.Point(3, 146);
            this.lblSortByAnyProperty.Name = "lblSortByAnyProperty";
            this.lblSortByAnyProperty.Size = new System.Drawing.Size(104, 13);
            this.lblSortByAnyProperty.TabIndex = 9;
            this.lblSortByAnyProperty.Text = "Sort by any property:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 450);
            this.Controls.Add(this.lblSortByAnyProperty);
            this.Controls.Add(this.cmbSortByAnyProperty);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.btnSortByTotalPurchases);
            this.Controls.Add(this.btnSortByYear);
            this.Controls.Add(this.btnSortByProtection);
            this.Controls.Add(this.lblSortBy);
            this.Controls.Add(this.pnlCustomerInformation);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.pnlQueue);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.pnlCustomerInformation.ResumeLayout(false);
            this.pnlCustomerInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlQueue;
        private System.Windows.Forms.Button btnAddCustomer;
        private ScrollablePanel pnlCustomerInformation;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.Label lblSortBy;
        private System.Windows.Forms.Button btnSortByProtection;
        private System.Windows.Forms.Button btnSortByYear;
        private System.Windows.Forms.Button btnSortByTotalPurchases;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.ComboBox cmbSortByAnyProperty;
        private System.Windows.Forms.Label lblSortByAnyProperty;
    }
}


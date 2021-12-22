namespace Warehouse404.View.Dialogs
{
    partial class OrderActionForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clientsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelButton.Location = new System.Drawing.Point(72, 160);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(133, 54);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addButton.Location = new System.Drawing.Point(552, 160);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(133, 54);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.statusComboBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.totalTextBox);
            this.groupBox2.Controls.Add(this.categoryLabel);
            this.groupBox2.Controls.Add(this.dateTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(224, 64);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(307, 142);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // statusComboBox
            // 
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "Nowe/przyjęte",
            "Skompletowane",
            "Wydane/opłacone"});
            this.statusComboBox.Location = new System.Drawing.Point(88, 64);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(184, 24);
            this.statusComboBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Status";
            // 
            // totalTextBox
            // 
            this.totalTextBox.Enabled = false;
            this.totalTextBox.Location = new System.Drawing.Point(88, 96);
            this.totalTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(187, 22);
            this.totalTextBox.TabIndex = 10;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(16, 104);
            this.categoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(64, 16);
            this.categoryLabel.TabIndex = 9;
            this.categoryLabel.Text = "Wartość";
            // 
            // dateTextBox
            // 
            this.dateTextBox.Enabled = false;
            this.dateTextBox.Location = new System.Drawing.Point(88, 32);
            this.dateTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(187, 22);
            this.dateTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data";
            // 
            // clientsComboBox
            // 
            this.clientsComboBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clientsComboBox.FormattingEnabled = true;
            this.clientsComboBox.Location = new System.Drawing.Point(88, 17);
            this.clientsComboBox.Name = "clientsComboBox";
            this.clientsComboBox.Size = new System.Drawing.Size(640, 28);
            this.clientsComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Klient:";
            // 
            // OrderActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 229);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clientsComboBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "OrderActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button cancelButton;
        private Button addButton;
        private GroupBox groupBox2;
        private TextBox totalTextBox;
        private Label categoryLabel;
        private TextBox dateTextBox;
        private Label label2;
        private ComboBox clientsComboBox;
        private Label label1;
        private ComboBox statusComboBox;
        private Label label3;
    }
}
namespace Warehouse404.View.Dialogs
{
    partial class EditOrderProductControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.productTextBox = new System.Windows.Forms.TextBox();
            this.productTotalTextBox = new System.Windows.Forms.TextBox();
            this.orderCountNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.orderCountNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produkt:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ilość";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Wartość";
            // 
            // productTextBox
            // 
            this.productTextBox.Enabled = false;
            this.productTextBox.Location = new System.Drawing.Point(72, 8);
            this.productTextBox.Name = "productTextBox";
            this.productTextBox.Size = new System.Drawing.Size(216, 25);
            this.productTextBox.TabIndex = 3;
            // 
            // productTotalTextBox
            // 
            this.productTotalTextBox.Enabled = false;
            this.productTotalTextBox.Location = new System.Drawing.Point(72, 72);
            this.productTotalTextBox.Name = "productTotalTextBox";
            this.productTotalTextBox.Size = new System.Drawing.Size(216, 25);
            this.productTotalTextBox.TabIndex = 5;
            // 
            // orderCountNumeric
            // 
            this.orderCountNumeric.Location = new System.Drawing.Point(72, 40);
            this.orderCountNumeric.Name = "orderCountNumeric";
            this.orderCountNumeric.Size = new System.Drawing.Size(216, 25);
            this.orderCountNumeric.TabIndex = 6;
            this.orderCountNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // EditOrderProductControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.orderCountNumeric);
            this.Controls.Add(this.productTotalTextBox);
            this.Controls.Add(this.productTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "EditOrderProductControl";
            this.Size = new System.Drawing.Size(301, 105);
            ((System.ComponentModel.ISupportInitialize)(this.orderCountNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        public TextBox productTextBox;
        public TextBox productTotalTextBox;
        public NumericUpDown orderCountNumeric;
    }
}

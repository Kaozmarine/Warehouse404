namespace Warehouse404.View.Dialogs
{
    partial class OrderProductActionForm
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
            this.editOrderProduct = new Warehouse404.View.Dialogs.EditOrderProductControl();
            this.addOrderProduct = new Warehouse404.View.Dialogs.AddOrderProductControl();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelButton.Location = new System.Drawing.Point(8, 184);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(133, 54);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addButton.Location = new System.Drawing.Point(344, 184);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(133, 54);
            this.addButton.TabIndex = 14;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // editOrderProduct
            // 
            this.editOrderProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.editOrderProduct.Location = new System.Drawing.Point(8, 64);
            this.editOrderProduct.Name = "editOrderProduct";
            this.editOrderProduct.Size = new System.Drawing.Size(464, 105);
            this.editOrderProduct.TabIndex = 16;
            // 
            // addOrderProduct
            // 
            this.addOrderProduct.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addOrderProduct.Location = new System.Drawing.Point(8, 8);
            this.addOrderProduct.Name = "addOrderProduct";
            this.addOrderProduct.Size = new System.Drawing.Size(472, 55);
            this.addOrderProduct.TabIndex = 17;
            // 
            // OrderProductActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 245);
            this.Controls.Add(this.addOrderProduct);
            this.Controls.Add(this.editOrderProduct);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.MinimizeBox = false;
            this.Name = "OrderProductActionForm";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Button cancelButton;
        private Button addButton;
        private EditOrderProductControl editOrderProduct;
        private AddOrderProductControl addOrderProduct;
    }
}
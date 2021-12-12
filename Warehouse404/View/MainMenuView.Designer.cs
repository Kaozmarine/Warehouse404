namespace Warehouse404.View
{
    partial class MainMenuView
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
            this.loginButton = new System.Windows.Forms.Button();
            this.usersButton = new System.Windows.Forms.Button();
            this.clientsButton = new System.Windows.Forms.Button();
            this.productsButton = new System.Windows.Forms.Button();
            this.ordersButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.loginButton.Location = new System.Drawing.Point(0, 264);
            this.loginButton.Margin = new System.Windows.Forms.Padding(5);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(220, 66);
            this.loginButton.TabIndex = 9;
            this.loginButton.Text = "Logowanie";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // usersButton
            // 
            this.usersButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.usersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.usersButton.Location = new System.Drawing.Point(0, 198);
            this.usersButton.Margin = new System.Windows.Forms.Padding(5);
            this.usersButton.Name = "usersButton";
            this.usersButton.Size = new System.Drawing.Size(220, 66);
            this.usersButton.TabIndex = 8;
            this.usersButton.Text = "Użytkownicy";
            this.usersButton.UseVisualStyleBackColor = true;
            this.usersButton.Click += new System.EventHandler(this.UsersButton_Click);
            // 
            // clientsButton
            // 
            this.clientsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.clientsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.clientsButton.Location = new System.Drawing.Point(0, 132);
            this.clientsButton.Margin = new System.Windows.Forms.Padding(5);
            this.clientsButton.Name = "clientsButton";
            this.clientsButton.Size = new System.Drawing.Size(220, 66);
            this.clientsButton.TabIndex = 7;
            this.clientsButton.Text = "Klienci";
            this.clientsButton.UseVisualStyleBackColor = true;
            this.clientsButton.Click += new System.EventHandler(this.ClientsButton_Click);
            // 
            // productsButton
            // 
            this.productsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.productsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.productsButton.Location = new System.Drawing.Point(0, 66);
            this.productsButton.Margin = new System.Windows.Forms.Padding(5);
            this.productsButton.Name = "productsButton";
            this.productsButton.Size = new System.Drawing.Size(220, 66);
            this.productsButton.TabIndex = 6;
            this.productsButton.Text = "Produkty";
            this.productsButton.UseVisualStyleBackColor = true;
            this.productsButton.Click += new System.EventHandler(this.ProductsButton_Click);
            // 
            // ordersButton
            // 
            this.ordersButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ordersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ordersButton.Location = new System.Drawing.Point(0, 0);
            this.ordersButton.Margin = new System.Windows.Forms.Padding(5);
            this.ordersButton.Name = "ordersButton";
            this.ordersButton.Size = new System.Drawing.Size(220, 66);
            this.ordersButton.TabIndex = 5;
            this.ordersButton.Text = "Zamównienia";
            this.ordersButton.UseVisualStyleBackColor = true;
            this.ordersButton.Click += new System.EventHandler(this.OrdersButton_Click);
            // 
            // MainMenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.usersButton);
            this.Controls.Add(this.clientsButton);
            this.Controls.Add(this.productsButton);
            this.Controls.Add(this.ordersButton);
            this.MaximumSize = new System.Drawing.Size(220, 335);
            this.Name = "MainMenuView";
            this.Size = new System.Drawing.Size(220, 335);
            this.ResumeLayout(false);

        }

        #endregion

        private Button loginButton;
        private Button usersButton;
        private Button clientsButton;
        private Button productsButton;
        private Button ordersButton;
    }
}

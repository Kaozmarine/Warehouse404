namespace Warehouse404.View
{
    partial class UsersView
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
            this.mainGroupBox = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.resetFilterButton = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.actionsGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.itemsListView = new System.Windows.Forms.ListView();
            this.loginColumn = new System.Windows.Forms.ColumnHeader();
            this.nameColumn = new System.Windows.Forms.ColumnHeader();
            this.roleColumn = new System.Windows.Forms.ColumnHeader();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mainGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.searchGroupBox.SuspendLayout();
            this.actionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainGroupBox
            // 
            this.mainGroupBox.Controls.Add(this.panel1);
            this.mainGroupBox.Controls.Add(this.itemsListView);
            this.mainGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mainGroupBox.Location = new System.Drawing.Point(0, 0);
            this.mainGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mainGroupBox.Name = "mainGroupBox";
            this.mainGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mainGroupBox.Size = new System.Drawing.Size(762, 350);
            this.mainGroupBox.TabIndex = 2;
            this.mainGroupBox.TabStop = false;
            this.mainGroupBox.Text = "Użytkownicy";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.searchGroupBox);
            this.panel1.Controls.Add(this.actionsGroupBox);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.MinimumSize = new System.Drawing.Size(766, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 172);
            this.panel1.TabIndex = 7;
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.Controls.Add(this.loginTextBox);
            this.searchGroupBox.Controls.Add(this.label1);
            this.searchGroupBox.Controls.Add(this.resetFilterButton);
            this.searchGroupBox.Controls.Add(this.button7);
            this.searchGroupBox.Controls.Add(this.nameTextBox);
            this.searchGroupBox.Controls.Add(this.nameLabel);
            this.searchGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.searchGroupBox.Location = new System.Drawing.Point(8, 16);
            this.searchGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.searchGroupBox.Size = new System.Drawing.Size(537, 104);
            this.searchGroupBox.TabIndex = 4;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "Wyszukiwanie";
            // 
            // resetFilterButton
            // 
            this.resetFilterButton.Location = new System.Drawing.Point(416, 16);
            this.resetFilterButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.resetFilterButton.Name = "resetFilterButton";
            this.resetFilterButton.Size = new System.Drawing.Size(115, 38);
            this.resetFilterButton.TabIndex = 12;
            this.resetFilterButton.Text = "Wyczyść filtry";
            this.resetFilterButton.UseVisualStyleBackColor = true;
            this.resetFilterButton.Click += new System.EventHandler(this.ResetFilterButton_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(416, 56);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(115, 39);
            this.button7.TabIndex = 6;
            this.button7.Text = "Szukaj";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(88, 32);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(187, 22);
            this.nameTextBox.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(8, 40);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(53, 16);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Nazwa";
            // 
            // actionsGroupBox
            // 
            this.actionsGroupBox.Controls.Add(this.deleteButton);
            this.actionsGroupBox.Controls.Add(this.editButton);
            this.actionsGroupBox.Controls.Add(this.addButton);
            this.actionsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.actionsGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.actionsGroupBox.Location = new System.Drawing.Point(552, 16);
            this.actionsGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.actionsGroupBox.Name = "actionsGroupBox";
            this.actionsGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.actionsGroupBox.Size = new System.Drawing.Size(202, 150);
            this.actionsGroupBox.TabIndex = 6;
            this.actionsGroupBox.TabStop = false;
            this.actionsGroupBox.Text = "Akcje";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(104, 88);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(88, 52);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Usuń";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(8, 88);
            this.editButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(88, 52);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edytuj";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(8, 25);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(88, 52);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // itemsListView
            // 
            this.itemsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.loginColumn,
            this.nameColumn,
            this.roleColumn});
            this.itemsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.itemsListView.FullRowSelect = true;
            this.itemsListView.GridLines = true;
            this.itemsListView.Location = new System.Drawing.Point(0, 208);
            this.itemsListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.itemsListView.MultiSelect = false;
            this.itemsListView.Name = "itemsListView";
            this.itemsListView.Size = new System.Drawing.Size(758, 144);
            this.itemsListView.TabIndex = 3;
            this.itemsListView.UseCompatibleStateImageBehavior = false;
            this.itemsListView.View = System.Windows.Forms.View.Details;
            // 
            // loginColumn
            // 
            this.loginColumn.Text = "Login";
            this.loginColumn.Width = 100;
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Imię i nazwisko";
            this.nameColumn.Width = 140;
            // 
            // roleColumn
            // 
            this.roleColumn.Text = "Rola";
            this.roleColumn.Width = 120;
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(88, 64);
            this.loginTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(187, 22);
            this.loginTextBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Login";
            // 
            // UsersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainGroupBox);
            this.MinimumSize = new System.Drawing.Size(762, 350);
            this.Name = "UsersView";
            this.Size = new System.Drawing.Size(762, 350);
            this.Tag = "Users";
            this.mainGroupBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.actionsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox mainGroupBox;
        private GroupBox actionsGroupBox;
        private Button deleteButton;
        private Button editButton;
        private Button addButton;
        private GroupBox searchGroupBox;
        private Button button7;
        private TextBox nameTextBox;
        private Label nameLabel;
        private ListView itemsListView;
        private Panel panel1;
        private ColumnHeader loginColumn;
        private ColumnHeader nameColumn;
        private ColumnHeader roleColumn;
        private Button resetFilterButton;
        private TextBox loginTextBox;
        private Label label1;
    }
}

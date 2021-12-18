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
            this.countToLabel = new System.Windows.Forms.Label();
            this.countToTextBox = new System.Windows.Forms.TextBox();
            this.countFromTextBox = new System.Windows.Forms.TextBox();
            this.countFromLabel = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.priceToLabel = new System.Windows.Forms.Label();
            this.priceToTextBox = new System.Windows.Forms.TextBox();
            this.priceFromTextBox = new System.Windows.Forms.TextBox();
            this.priceFromLabel = new System.Windows.Forms.Label();
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
            this.searchGroupBox.Controls.Add(this.countToLabel);
            this.searchGroupBox.Controls.Add(this.countToTextBox);
            this.searchGroupBox.Controls.Add(this.countFromTextBox);
            this.searchGroupBox.Controls.Add(this.countFromLabel);
            this.searchGroupBox.Controls.Add(this.button7);
            this.searchGroupBox.Controls.Add(this.priceToLabel);
            this.searchGroupBox.Controls.Add(this.priceToTextBox);
            this.searchGroupBox.Controls.Add(this.priceFromTextBox);
            this.searchGroupBox.Controls.Add(this.priceFromLabel);
            this.searchGroupBox.Controls.Add(this.nameTextBox);
            this.searchGroupBox.Controls.Add(this.nameLabel);
            this.searchGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.searchGroupBox.Location = new System.Drawing.Point(8, 16);
            this.searchGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.searchGroupBox.Size = new System.Drawing.Size(537, 150);
            this.searchGroupBox.TabIndex = 4;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "Wyszukiwanie";
            // 
            // countToLabel
            // 
            this.countToLabel.AutoSize = true;
            this.countToLabel.Location = new System.Drawing.Point(198, 118);
            this.countToLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.countToLabel.Name = "countToLabel";
            this.countToLabel.Size = new System.Drawing.Size(25, 16);
            this.countToLabel.TabIndex = 10;
            this.countToLabel.Text = "do";
            // 
            // countToTextBox
            // 
            this.countToTextBox.Location = new System.Drawing.Point(232, 111);
            this.countToTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.countToTextBox.Name = "countToTextBox";
            this.countToTextBox.Size = new System.Drawing.Size(98, 22);
            this.countToTextBox.TabIndex = 9;
            // 
            // countFromTextBox
            // 
            this.countFromTextBox.Location = new System.Drawing.Point(90, 111);
            this.countFromTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.countFromTextBox.Name = "countFromTextBox";
            this.countFromTextBox.Size = new System.Drawing.Size(98, 22);
            this.countFromTextBox.TabIndex = 8;
            // 
            // countFromLabel
            // 
            this.countFromLabel.AutoSize = true;
            this.countFromLabel.Location = new System.Drawing.Point(9, 114);
            this.countFromLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.countFromLabel.Name = "countFromLabel";
            this.countFromLabel.Size = new System.Drawing.Size(62, 16);
            this.countFromLabel.TabIndex = 7;
            this.countFromLabel.Text = "Ilosć od";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(414, 103);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(115, 39);
            this.button7.TabIndex = 6;
            this.button7.Text = "Szukaj";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // priceToLabel
            // 
            this.priceToLabel.AutoSize = true;
            this.priceToLabel.Location = new System.Drawing.Point(198, 74);
            this.priceToLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.priceToLabel.Name = "priceToLabel";
            this.priceToLabel.Size = new System.Drawing.Size(25, 16);
            this.priceToLabel.TabIndex = 5;
            this.priceToLabel.Text = "do";
            // 
            // priceToTextBox
            // 
            this.priceToTextBox.Location = new System.Drawing.Point(232, 71);
            this.priceToTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.priceToTextBox.Name = "priceToTextBox";
            this.priceToTextBox.Size = new System.Drawing.Size(98, 22);
            this.priceToTextBox.TabIndex = 4;
            // 
            // priceFromTextBox
            // 
            this.priceFromTextBox.Location = new System.Drawing.Point(90, 71);
            this.priceFromTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.priceFromTextBox.Name = "priceFromTextBox";
            this.priceFromTextBox.Size = new System.Drawing.Size(98, 22);
            this.priceFromTextBox.TabIndex = 3;
            // 
            // priceFromLabel
            // 
            this.priceFromLabel.AutoSize = true;
            this.priceFromLabel.Location = new System.Drawing.Point(9, 74);
            this.priceFromLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.priceFromLabel.Name = "priceFromLabel";
            this.priceFromLabel.Size = new System.Drawing.Size(65, 16);
            this.priceFromLabel.TabIndex = 2;
            this.priceFromLabel.Text = "Cena od";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(90, 32);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(187, 22);
            this.nameTextBox.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(9, 39);
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
        private Label countToLabel;
        private TextBox countToTextBox;
        private TextBox countFromTextBox;
        private Label countFromLabel;
        private Button button7;
        private Label priceToLabel;
        private TextBox priceToTextBox;
        private TextBox priceFromTextBox;
        private Label priceFromLabel;
        private TextBox nameTextBox;
        private Label nameLabel;
        private ListView itemsListView;
        private Panel panel1;
        private ColumnHeader loginColumn;
        private ColumnHeader nameColumn;
        private ColumnHeader roleColumn;
    }
}

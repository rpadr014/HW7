namespace hw7
{
    partial class SearchForm
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
            this.filesListBox = new System.Windows.Forms.ListBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.extDropdown = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // filesListBox
            // 
            this.filesListBox.FormattingEnabled = true;
            this.filesListBox.ItemHeight = 15;
            this.filesListBox.Location = new System.Drawing.Point(0, -34);
            this.filesListBox.Name = "filesListBox";
            this.filesListBox.Size = new System.Drawing.Size(802, 409);
            this.filesListBox.TabIndex = 0;
            this.filesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.filesListBox_MouseDoubleClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(713, 392);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(632, 392);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Start";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // extDropdown
            // 
            this.extDropdown.FormattingEnabled = true;
            this.extDropdown.Items.AddRange(new object[] {
            ".txt",
            ".html",
            ".htm"});
            this.extDropdown.Location = new System.Drawing.Point(12, 392);
            this.extDropdown.Name = "extDropdown";
            this.extDropdown.Size = new System.Drawing.Size(614, 23);
            this.extDropdown.TabIndex = 4;
            this.extDropdown.SelectedIndexChanged += new System.EventHandler(this.extDropdown_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(51, 17);
            this.statusLabel.Text = "Stopped";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.extDropdown);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.filesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchForm_FormClosing);
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox filesListBox;
        private Button cancelButton;
        private Button searchButton;
        private ComboBox extDropdown;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
    }
}
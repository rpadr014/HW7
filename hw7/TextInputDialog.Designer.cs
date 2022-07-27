namespace HW7
{
    partial class TextInputDialog
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
            this.textInputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.zOrderBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.colorBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.backColorBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.yBox = new System.Windows.Forms.NumericUpDown();
            this.xBox = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.fontSizeBox = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.fontStyleLabel = new System.Windows.Forms.Label();
            this.fontStyleComboBox = new System.Windows.Forms.ComboBox();
            this.fontFamilyComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.zOrderBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textInputBox
            // 
            this.textInputBox.Location = new System.Drawing.Point(73, 21);
            this.textInputBox.Name = "textInputBox";
            this.textInputBox.Size = new System.Drawing.Size(400, 31);
            this.textInputBox.TabIndex = 0;
            this.textInputBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // zOrderBox
            // 
            this.zOrderBox.Location = new System.Drawing.Point(95, 128);
            this.zOrderBox.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.zOrderBox.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.zOrderBox.Name = "zOrderBox";
            this.zOrderBox.Size = new System.Drawing.Size(91, 31);
            this.zOrderBox.TabIndex = 2;
            this.zOrderBox.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "zOrder:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // colorBox
            // 
            this.colorBox.FormattingEnabled = true;
            this.colorBox.Location = new System.Drawing.Point(327, 126);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(112, 33);
            this.colorBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Color:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(518, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Back Color:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // backColorBox
            // 
            this.backColorBox.FormattingEnabled = true;
            this.backColorBox.Location = new System.Drawing.Point(624, 127);
            this.backColorBox.Name = "backColorBox";
            this.backColorBox.Size = new System.Drawing.Size(112, 33);
            this.backColorBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(95, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Font Family:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.yBox);
            this.groupBox1.Controls.Add(this.xBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(457, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 101);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location";
            // 
            // yBox
            // 
            this.yBox.Location = new System.Drawing.Point(167, 47);
            this.yBox.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.yBox.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.yBox.Name = "yBox";
            this.yBox.Size = new System.Drawing.Size(85, 31);
            this.yBox.TabIndex = 5;
            // 
            // xBox
            // 
            this.xBox.Location = new System.Drawing.Point(47, 48);
            this.xBox.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.xBox.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(85, 31);
            this.xBox.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(138, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "x:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(506, 342);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(112, 34);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(634, 342);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 34);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancelClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(108, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "Font Size:";
            // 
            // fontSizeBox
            // 
            this.fontSizeBox.Location = new System.Drawing.Point(202, 247);
            this.fontSizeBox.Name = "fontSizeBox";
            this.fontSizeBox.Size = new System.Drawing.Size(166, 31);
            this.fontSizeBox.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(374, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 25);
            this.label9.TabIndex = 16;
            this.label9.Text = "px";
            // 
            // fontStyleLabel
            // 
            this.fontStyleLabel.AutoSize = true;
            this.fontStyleLabel.Location = new System.Drawing.Point(102, 294);
            this.fontStyleLabel.Name = "fontStyleLabel";
            this.fontStyleLabel.Size = new System.Drawing.Size(94, 25);
            this.fontStyleLabel.TabIndex = 17;
            this.fontStyleLabel.Text = "Font Style:";
            // 
            // fontStyleComboBox
            // 
            this.fontStyleComboBox.FormattingEnabled = true;
            this.fontStyleComboBox.Location = new System.Drawing.Point(202, 291);
            this.fontStyleComboBox.Name = "fontStyleComboBox";
            this.fontStyleComboBox.Size = new System.Drawing.Size(198, 33);
            this.fontStyleComboBox.TabIndex = 18;
            // 
            // fontFamilyComboBox
            // 
            this.fontFamilyComboBox.FormattingEnabled = true;
            this.fontFamilyComboBox.Location = new System.Drawing.Point(202, 197);
            this.fontFamilyComboBox.Name = "fontFamilyComboBox";
            this.fontFamilyComboBox.Size = new System.Drawing.Size(198, 33);
            this.fontFamilyComboBox.TabIndex = 19;
            // 
            // TextInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 388);
            this.Controls.Add(this.fontFamilyComboBox);
            this.Controls.Add(this.fontStyleComboBox);
            this.Controls.Add(this.fontStyleLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fontSizeBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.backColorBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.zOrderBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textInputBox);
            this.Name = "TextInputDialog";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.zOrderBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textInputBox;
        private Label label1;
        private NumericUpDown zOrderBox;
        private Label label2;
        private ComboBox colorBox;
        private Label label3;
        private Label label4;
        private ComboBox backColorBox;
        private Label label5;
        private GroupBox groupBox1;
        private Label label6;
        private NumericUpDown yBox;
        private NumericUpDown xBox;
        private Label label7;
        private Button saveButton;
        private Button cancelButton;
        private Label label8;
        private NumericUpDown fontSizeBox;
        private Label label9;
        private Label fontStyleLabel;
        private ComboBox fontStyleComboBox;
        private ComboBox fontFamilyComboBox;
    }
}
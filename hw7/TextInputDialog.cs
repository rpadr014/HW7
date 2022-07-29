using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW7
{
    public partial class TextInputDialog : Form
    {
        public event EventHandler<TextInputEventArgs> OnSave;
        public bool editing { get; set; }
        public bool importedText { get; set; }

        public TextInputDialog()
        {
            InitializeComponent();
            
            ArrayList ColorList = new ArrayList();
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
                                          BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.colorBox.Items.Add(c.Name);
                this.backColorBox.Items.Add(c.Name);
            }

            this.fontStyleComboBox.DataSource = Enum.GetValues(typeof(FontStyle));
            this.fontFamilyComboBox.DrawItem += FontFamilyComboBox_DrawItem;
            this.fontFamilyComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.fontFamilyComboBox.DataSource = FontFamily.Families.ToList();
        }

        private void FontFamilyComboBox_DrawItem(object? sender, DrawItemEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.Items[e.Index];
            var font = new Font(fontFamily, comboBox.Font.SizeInPoints);

            e.DrawBackground();
            e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            if (!importedText)
            {
                var textSplit = textInputBox.Text.Split(' ');
                foreach (String t in textSplit)
                {
                    var text = new Text();
                    text.SavedText = t;
                    text.Color = Color.FromName(this.colorBox.Text);
                    text.zOrder = ((int)this.zOrderBox.Value);
                    text.BackColor = Color.FromName(this.backColorBox.Text);
                    text.Font = new Font(this.fontFamilyComboBox.SelectedText, (int)this.fontSizeBox.Value, (FontStyle)this.fontStyleComboBox.SelectedItem, GraphicsUnit.Pixel);
                    text.Location = new Point(((int)this.xBox.Value), (int)this.yBox.Value);
                    if (OnSave != null)
                    {
                        this.OnSave.Invoke(sender, new TextInputEventArgs(text));
                    }
                }
            }

            else
            {
                var text = new Text();
                text.SavedText = this.textInputBox.Text;
                text.Color = Color.FromName(this.colorBox.Text);
                text.zOrder = ((int)this.zOrderBox.Value);
                text.BackColor = Color.FromName(this.backColorBox.Text);
                text.Font = new Font(this.fontFamilyComboBox.SelectedText, (int)this.fontSizeBox.Value, (FontStyle)this.fontStyleComboBox.SelectedItem, GraphicsUnit.Pixel);
                text.Location = new Point(((int)this.xBox.Value), (int)this.yBox.Value);
                if (OnSave != null)
                {
                    this.OnSave.Invoke(sender, new TextInputEventArgs(text));
                }
            }
            importedText = false;
        }

        public void setText(string text)
        {
            this.textInputBox.Text = text;
        }

     
    }
}

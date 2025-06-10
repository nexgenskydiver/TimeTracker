namespace TimeTracker.WinForms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RichTextBox richTextBoxNotes;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Label lblElapsed;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            dateTimePicker1 = new DateTimePicker();
            richTextBoxNotes = new RichTextBox();
            checkedListBox1 = new CheckedListBox();
            btnStart = new Button();
            btnEnd = new Button();
            lblElapsed = new Label();
            dataGridViewEntries = new DataGridView();
            btnAddTag = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEntries).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(17, 20);
            dateTimePicker1.Margin = new Padding(4, 5, 4, 5);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(170, 31);
            dateTimePicker1.TabIndex = 0;
            // 
            // richTextBoxNotes
            // 
            richTextBoxNotes.Location = new Point(17, 68);
            richTextBoxNotes.Margin = new Padding(4, 5, 4, 5);
            richTextBoxNotes.Name = "richTextBoxNotes";
            richTextBoxNotes.Size = new Size(641, 331);
            richTextBoxNotes.TabIndex = 1;
            richTextBoxNotes.Text = "";
            // 
            // checkedListBox1
            // 
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.Location = new Point(666, 83);
            checkedListBox1.Margin = new Padding(4, 5, 4, 5);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(195, 368);
            checkedListBox1.TabIndex = 2;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(17, 409);
            btnStart.Margin = new Padding(4, 5, 4, 5);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(272, 62);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // btnEnd
            // 
            btnEnd.Location = new Point(386, 409);
            btnEnd.Margin = new Padding(4, 5, 4, 5);
            btnEnd.Name = "btnEnd";
            btnEnd.Size = new Size(272, 62);
            btnEnd.TabIndex = 4;
            btnEnd.Text = "End";
            btnEnd.UseVisualStyleBackColor = true;
            // 
            // lblElapsed
            // 
            lblElapsed.Location = new Point(276, 20);
            lblElapsed.Margin = new Padding(4, 0, 4, 0);
            lblElapsed.Name = "lblElapsed";
            lblElapsed.Size = new Size(286, 38);
            lblElapsed.TabIndex = 5;
            lblElapsed.Text = "Elapsed: 00:00:00";
            // 
            // dataGridViewEntries
            // 
            dataGridViewEntries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEntries.Location = new Point(17, 479);
            dataGridViewEntries.Name = "dataGridViewEntries";
            dataGridViewEntries.RowHeadersWidth = 62;
            dataGridViewEntries.Size = new Size(873, 344);
            dataGridViewEntries.TabIndex = 6;
            // 
            // btnAddTag
            // 
            btnAddTag.Location = new Point(666, 20);
            btnAddTag.Name = "btnAddTag";
            btnAddTag.Size = new Size(196, 55);
            btnAddTag.TabIndex = 7;
            btnAddTag.Text = "Add Tag";
            btnAddTag.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(902, 849);
            Controls.Add(btnAddTag);
            Controls.Add(dataGridViewEntries);
            Controls.Add(dateTimePicker1);
            Controls.Add(richTextBoxNotes);
            Controls.Add(checkedListBox1);
            Controls.Add(btnStart);
            Controls.Add(btnEnd);
            Controls.Add(lblElapsed);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            Text = "Time Tracker";
            ((System.ComponentModel.ISupportInitialize)dataGridViewEntries).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewEntries;
        private Button btnAddTag;
    }
}

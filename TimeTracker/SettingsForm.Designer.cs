namespace TimeTracker
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label labelDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelServer = new Label();
            txtServer = new TextBox();
            labelDatabase = new Label();
            txtDatabase = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // labelServer
            // 
            labelServer.AutoSize = true;
            labelServer.Location = new Point(12, 15);
            labelServer.Name = "labelServer";
            labelServer.Size = new Size(65, 25);
            labelServer.TabIndex = 0;
            labelServer.Text = "Server:";
            // 
            // txtServer
            // 
            txtServer.Location = new Point(103, 12);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(250, 31);
            txtServer.TabIndex = 1;
            // 
            // labelDatabase
            // 
            labelDatabase.AutoSize = true;
            labelDatabase.Location = new Point(12, 50);
            labelDatabase.Name = "labelDatabase";
            labelDatabase.Size = new Size(90, 25);
            labelDatabase.TabIndex = 2;
            labelDatabase.Text = "Database:";
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(103, 47);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(250, 31);
            txtDatabase.TabIndex = 3;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(174, 90);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 33);
            btnOK.TabIndex = 4;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(255, 90);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 33);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AcceptButton = btnOK;
            CancelButton = btnCancel;
            ClientSize = new Size(505, 148);
            Controls.Add(labelServer);
            Controls.Add(txtServer);
            Controls.Add(labelDatabase);
            Controls.Add(txtDatabase);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

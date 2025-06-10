using System.Windows.Forms;

namespace TimeTracker
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        /// <summary>The edited connection string.</summary>
        public string Server
        {
            get => txtServer.Text.Trim();
            set => txtServer.Text = value;
        }

        public string Database
        {
            get => txtDatabase.Text.Trim();
            set => txtDatabase.Text = value;
        }
    }
}

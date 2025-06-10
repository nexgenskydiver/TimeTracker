using System.Windows.Forms;

namespace TimeTracker
{
    public partial class AddTagForm : Form
    {
        public AddTagForm()
        {
            InitializeComponent();
        }

        /// <summary> The tag the user typed. </summary>
        public string TagName => txtTagName.Text.Trim();
    }
}

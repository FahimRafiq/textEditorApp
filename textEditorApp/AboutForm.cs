using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using textEditorApp;

namespace textEditorApp
{
    public partial class AboutForm : Form // About form class
    {
        public AboutForm()
        {
            InitializeComponent();
        }
        //When ok button is pressed about form is hidden
        private void aboutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Belatrix;
using Belatrix.Clases;

namespace WindowsFormsApp1
{
    public partial class frmTest : Form
    {
        CJobLogger _CJobLogger = new CJobLogger(new DJobLogger());

        public frmTest()
        {
            InitializeComponent();
        }

        private void btn_guardar_logs_Click(object sender, EventArgs e)
        {
            _CJobLogger.IfJobLogger.LogToDatabase = false;

            try
            {
                _CJobLogger.LogMessage("test message", Enumerations.LogType.message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}

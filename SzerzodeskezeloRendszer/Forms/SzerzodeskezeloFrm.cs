using SLRDbConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SzerzodeskezeloRendszer.Forms;

namespace SzerzodeskezeloRendszer
{
    public partial class SzerzodeskezeloFrm : Form
    {
        DbConnector db;

        public SzerzodeskezeloFrm()
        {
            InitializeComponent();
            db = new DbConnector();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                if (checkLogin())
                {
                    using (Form_Dashboard form_Dashboard = new Form_Dashboard())
                    {
                        form_Dashboard.ShowDialog();
                    }
                }

            }
        }

        private bool checkLogin()
        {
            string username = db.getSingleValue("select UserName from tblUsers where UserName = '"+txtUserName.Text+"' and Password = '"+txtPassword.Text+"'", out username, 0);
            if (username == null)
            {
                MessageBox.Show("Hibás felhasználónév, vagy jelszó!","Hibás adatok!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool isFormValid()
        {
            if (txtUserName.Text.ToString().Trim()== string.Empty || txtPassword.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Hiányzó felhasználónév, vagy jelszó!","Kérlek töltsd ki a hiányzó mezőket!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

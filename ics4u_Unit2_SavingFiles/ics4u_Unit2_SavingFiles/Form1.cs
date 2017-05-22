using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*************************
 * Ian McTavish
 * Sept 2014
 * Program to demonstrate variety of ways to save and open files
 * ***********************/
namespace ics4u_Unit2_SavingFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTextFile_Click(object sender, EventArgs e)
        {
            //Declare and initialize a new instance of the frmText
            frmText f = new frmText();
            //ShowDialog returns a DialogResult when the form closes
            DialogResult dr = f.ShowDialog();
            //You could check what was returned (i.e. OK, Cancel) and 
            //deal with it
        }

        //The other methods follow the same pattern as above
        private void btnXml_Click(object sender, EventArgs e)
        {
            frmXml f = new frmXml();
            DialogResult dr = f.ShowDialog();
        }

        private void btnBinary_Click(object sender, EventArgs e)
        {
            frmBinary f = new frmBinary();
            DialogResult dr = f.ShowDialog();
        }

    }
}

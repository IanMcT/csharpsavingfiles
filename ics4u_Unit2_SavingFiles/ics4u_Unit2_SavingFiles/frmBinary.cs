using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ics4u_Unit2_SavingFiles
{
    public partial class frmBinary : Form
    {
        //A DataTable will store the data and is serializable so we can write it to the file
        DataTable dt = new DataTable();
        public frmBinary()
        {
            InitializeComponent();
        }

        /********************
         * Form load
         * *****************/
        private void frmBinary_Load(object sender, EventArgs e)
        {
            //add the columns to the data table
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Phone");
            //Sets the dataGridView to use the data table
            dataGridView1.DataSource = dt;
            //Make everything pretty
            this.WindowState = FormWindowState.Maximized;
            dataGridView1.Columns[0].Width = this.Width / 3;
            dataGridView1.Columns[1].Width = this.Width / 3;
            dataGridView1.Columns[2].Width = this.Width / 3;
        }

        /*********************************
         * Save file
         * *******************************/
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //run the saveFile dialos and ensure they clicked OK.
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK) 
            {
                //Need to create the binary formatter
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                try 
                {
                    //Create the instance of the file stream to write to
                    System.IO.Stream stream = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.OpenOrCreate);
                    
                    //serializes the data and sends it to the file stream
                    formatter.Serialize(stream, dt);
                    //flush and close the stream
                    stream.Flush();
                    stream.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }//end catch
            }//end if
        }

        /****************************
         * Opens the file
         * *************************/
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Runs the open file dialog and makes sure they click OK
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK) 
            {
                //Create a new instance of a binary formatter
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                try
                {
                    //Creates a file stream to open based on the file the user chose
                    System.IO.Stream stream = new System.IO.FileStream(openFileDialog1.FileName, System.IO.FileMode.Open);

                    //Since the save option only serializes a datatable
                    //we can deserialize from the stream, cast it to a DataTable
                    //and assign the value to our DataTable
                    dt = (DataTable)formatter.Deserialize(stream);
                    //Makes sure the DataGridView is updated to use the DataTable for the source of data
                    dataGridView1.DataSource = dt;

                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }//end catch
            }//end if
        }
    }
}

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
    public partial class frmText : Form
    {
        public frmText()
        {
            InitializeComponent();
        }

        private void frmText_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        /**************
         * Save file method
         * runs when Save button is pressed
         * Takes the data entered and saves it to a text file
         * ************/
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prepare a string to write to the file
            string s = "";
            //loop through the rows
            foreach (DataGridViewRow r in dataGridView1.Rows) 
            {
                //loop through each cell in the row
                foreach (DataGridViewCell c in r.Cells) 
                {
                    //Make sure the cell contains data
                    try 
                    {
                        s+=c.Value.ToString()+",";//adds the cell and a comma
                    }
                    catch (Exception ex) //cathes any errors and quietly deals with
                    {
                        Console.WriteLine("Error: " + ex.Message + "\n");
                    }//end try/catch
                }//end cell loop
                //gets rid of the comma at the end and adds a new line
                if(s.Length >0)
                    s = s.Substring(0, s.Length - 1) + "\r\n";
            }//end row loop
            //saveFileDialog1 was added to the form
            DialogResult dr = saveFileDialog1.ShowDialog();
            //If the person cancels you do not want to save the file
            if (dr == System.Windows.Forms.DialogResult.OK) 
            {
                //The System.IO namespace contains classes for files
                //note - you could add a using line at the top to reduce the
                //amount of typing
                //The file name is taken from openFileDialog1
                System.IO.StreamWriter writer = new System.IO.StreamWriter(saveFileDialog1.FileName);

                //Potential errors - try/catch to deal with
                try 
                {
                    writer.Write(s);//writes the string
                    writer.Flush();
                    MessageBox.Show(s + "\n\nWas saved.");
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Error: " + ex.Message + "\n");
                }
                writer.Close();//Always close your files
            }
            
        }

        /**************
        * Open file method
        * runs when Open button is pressed
        * Takes the data from a text file and puts in the cells
        * ************/

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //run the openFileDialog1
            DialogResult dr = openFileDialog1.ShowDialog();
            //Make sure the user picked a file
            if (dr == System.Windows.Forms.DialogResult.OK) 
            {
                //clear the data
                dataGridView1.Rows.Clear();
                //open the streamreader
                System.IO.StreamReader reader = new System.IO.StreamReader(openFileDialog1.FileName);
                //lots of potential errors, use try/catch
                try 
                {
                    //loop until the file is done
                    while (!reader.EndOfStream) 
                    {
                        //reads a line of text
                        string temp = reader.ReadLine();
                        //creates an array based on the commas
                        string[] cells = temp.Split(new char[]{','});
                        //make sure the line has three value since
                        //this program only takes three values
                        if (cells.Length == 3) 
                        {
                            //Add a row using the array
                            dataGridView1.Rows.Add(cells);
                        }
                    }
                    reader.Close();//close the file
                }
                catch (Exception ex) { Console.WriteLine("Error: " + ex.Message + "\n"); }
            }
        }
    }
}

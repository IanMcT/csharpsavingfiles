using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/***********************
 * McTavish
 * Opening and Saving files XML example
 * Sept, 2014
 * ********************/
namespace ics4u_Unit2_SavingFiles
{
    public partial class frmXml : Form
    {
        public frmXml()
        {
            InitializeComponent();
        }
        /*************************
         * Save example
         * creates an xml file from the data grid
         * ***********************/
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Run dialog and make sure user picks a file
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                //Create a new XmlWriter based on the users pick for file name
                //Note you could add using System.Xml to reduce typing
                using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(saveFileDialog1.FileName))
                {
                    //Starts the document and adds a <Addresses> tag
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Addresses");

                    //Loops through the rows
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        //could crash if row not closed
                        try
                        {
                            //Adds a contact for each row.  
                            writer.WriteStartElement("Contact");

                            //Cells property of rows is accessed like an array
                            //WriteElementString writes the tag adds the text i.e. <FirstName>Bob</FirstName> 
                            writer.WriteElementString("FirstName", r.Cells[0].Value.ToString());
                            writer.WriteElementString("LastName", r.Cells[1].Value.ToString());
                            writer.WriteElementString("Phone", r.Cells[2].Value.ToString());

                            //Closes the Contact tag
                            writer.WriteEndElement();
                        }
                        catch (Exception ex) { }
                    }//end loop
                    //Closses the Address tag
                    writer.WriteEndElement();
                    //Finished up the document
                    writer.WriteEndDocument();
                }//end using writer
            }//end if
        }
        /************************
         * Form load
         * Maximizes the window
         * *********************/
        private void frmXml_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        /*****************************
         * Open file
         * Opens an XML document and puts data in grid
         * ****************************/
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                //creates a new instance of XmlReader
                using (System.Xml.XmlReader reader = System.Xml.XmlReader.Create(openFileDialog1.FileName))
                {
                    //Creates a temporary array of three elements - initializes each element to an empty string
                    string[] temp = new string[3] { "", "", "" };
                    //potential for bad xml so use try/catch
                    try
                    {
                        //loop through all the Xml
                        while (reader.Read())
                        {
                            // Only detect start elements.
                            if (reader.IsStartElement())
                            {
                                // Get element name and switch on it.
                                switch (reader.Name)
                                {
                                    case "Addresses":
                                        // Detect this element.
                                        Console.WriteLine("Start <address> element.");
                                        break;
                                    case "Contact":
                                        // Detect this contact element.
                                        Console.WriteLine("Start <contact> element.");
                                        break;
                                    case "FirstName":
                                        //reads the firstname and sets the value to the array
                                        if (reader.Read())
                                        {
                                            temp[0] = reader.Value.Trim();
                                        }
                                        break;
                                    case "LastName":
                                        //reads the lastname and sets the value to the array
                                        if (reader.Read())
                                        {
                                            temp[1] = reader.Value.Trim();
                                        }
                                        break;
                                    case "Phone":
                                        //reads the phone and sets the value
                                        if (reader.Read())
                                        {
                                            temp[2] = reader.Value.Trim();
                                            //Phone is the last element so it adds a row based on the array
                                            dataGridView1.Rows.Add(temp);
                                        }
                                        break;




                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);//any errors from improperly formatted xml will show
                    }
                }
            }
        }
    }
}

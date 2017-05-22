namespace ics4u_Unit2_SavingFiles
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTextFile = new System.Windows.Forms.Button();
            this.btnXml = new System.Windows.Forms.Button();
            this.btnBinary = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTextFile
            // 
            this.btnTextFile.BackColor = System.Drawing.Color.White;
            this.btnTextFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTextFile.Location = new System.Drawing.Point(13, 13);
            this.btnTextFile.Name = "btnTextFile";
            this.btnTextFile.Size = new System.Drawing.Size(342, 58);
            this.btnTextFile.TabIndex = 0;
            this.btnTextFile.Text = "Open/Save Text Files";
            this.btnTextFile.UseVisualStyleBackColor = false;
            this.btnTextFile.Click += new System.EventHandler(this.btnTextFile_Click);
            // 
            // btnXml
            // 
            this.btnXml.BackColor = System.Drawing.Color.White;
            this.btnXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXml.Location = new System.Drawing.Point(13, 89);
            this.btnXml.Name = "btnXml";
            this.btnXml.Size = new System.Drawing.Size(342, 58);
            this.btnXml.TabIndex = 1;
            this.btnXml.Text = "Open/Save Xml Files";
            this.btnXml.UseVisualStyleBackColor = false;
            this.btnXml.Click += new System.EventHandler(this.btnXml_Click);
            // 
            // btnBinary
            // 
            this.btnBinary.BackColor = System.Drawing.Color.White;
            this.btnBinary.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBinary.Location = new System.Drawing.Point(12, 165);
            this.btnBinary.Name = "btnBinary";
            this.btnBinary.Size = new System.Drawing.Size(342, 58);
            this.btnBinary.TabIndex = 2;
            this.btnBinary.Text = "Open/Save Binary Files";
            this.btnBinary.UseVisualStyleBackColor = false;
            this.btnBinary.Click += new System.EventHandler(this.btnBinary_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 544);
            this.Controls.Add(this.btnBinary);
            this.Controls.Add(this.btnXml);
            this.Controls.Add(this.btnTextFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTextFile;
        private System.Windows.Forms.Button btnXml;
        private System.Windows.Forms.Button btnBinary;
    }
}


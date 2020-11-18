using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenFileDialogueSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                ProcessFile myProcessFile = new ProcessFile();
                List<Object> myObjects = new List<Object>();
                List<Driver> myDrivers = new List<Driver>();
                Driver myDriver = new Driver();
                List<Trip> myTrips = new List<Trip>();
                Trip myTrip = new Trip();
                this.txtResult.Text = myProcessFile.ReadFileFromPath(openFileDialog1.FileName.ToString());
            }
        }
    }
}

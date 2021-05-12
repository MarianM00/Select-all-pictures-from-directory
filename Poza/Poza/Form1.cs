using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poza
{
    public partial class Form1 : Form
    {

        string currentDir = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedImage = listBoxImages.SelectedItems[0].ToString();

                if(!string.IsNullOrEmpty(selectedImage)&& !string.IsNullOrEmpty(currentDir))
                {

                    var fullPath = Path.Combine(currentDir, selectedImage);

                    pictureBoxImagePreview.Image = Image.FromFile(fullPath);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var fb = new FolderBrowserDialog();
                if(fb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    currentDir = fb.SelectedPath; // user select the folder


                    textBoxDirectory.Text = currentDir;
                    //get all image from directory
                    //first create directory

                    var dirInfo = new DirectoryInfo(currentDir);

                    //get the files

                    var files = dirInfo.GetFiles().Where(c => (c.Extension.Equals(".jpg") || c.Extension.Equals(".jpeg") || c.Extension.Equals(".bmp") || c.Extension.Equals(".png")));
                
                        
                    foreach(var image in files)
                    {

                        //add images to list box
                        listBoxImages.Items.Add(image.Name);

                    }
                
                
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("there  was an error: " + ex.Message + "" + ex.Source);
            }
        }
            
        


    }
}

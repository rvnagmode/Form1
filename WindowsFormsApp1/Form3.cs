using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            string path = @"D:\T-Systems\Tfiles.txt";
            if(File.Exists(path))
            {
                MessageBox.Show("file already exists");
            }
            else
            {
                File.Create(path);
                MessageBox.Show("created");
            }
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            string path = @"D:\T-Systems";
            if(Directory.Exists(path))
            {
                MessageBox.Show("folder already exists");
            }
            else
            {
                Directory.CreateDirectory(path);
                MessageBox.Show("Created");
            }
            
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"D:\T-Systems\Tfiles", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            try
            {
               
                bw.Write(Convert.ToInt32(txtDeptId.Text));
                bw.Write(txtName.Text);
                bw.Write(txtLocation.Text);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bw.Close();
                fs.Close();
            }
        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"D:\T-Systems\Tfiles", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            try
            {
                
                txtDeptId.Text = br.ReadInt32().ToString();
                txtName.Text = br.ReadString();
                txtLocation.Text = br.ReadString();
                
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                br.Close();
                fs.Close();
            }
        }
    }
}

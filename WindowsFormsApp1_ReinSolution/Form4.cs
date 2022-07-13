using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text.Json;

namespace WindowsFormsApp1_ReinSolution
{
    
    public partial class Form4 : Form
    {
        FileStream fs;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                prod.ID = Convert.ToInt32(txtId.Text);
                prod.Name = txtName.Text;
                prod.Price = Convert.ToInt32(txtPrice.Text);
                FileStream fs = new FileStream(@"D:\Product", FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, prod);
             
                MessageBox.Show("File Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                FileStream fs = new FileStream(@"G:\thinkQu\Product", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                prod = (Product)bf.Deserialize(fs);
                txtId.Text = prod.ID.ToString();
                txtName.Text = prod.Name;
                txtPrice.Text = prod.Price.ToString();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                prod.ID = Convert.ToInt32(txtId.Text);
                prod.Name = txtName.Text;
                prod.Price = Convert.ToInt32(txtPrice.Text);
                fs = new FileStream(@"G:thinkQu\ProductXml", FileMode.Create, FileAccess.Write);
                XmlSerializer xs = new XmlSerializer(typeof(Product));
                xs.Serialize(fs, prod);
                MessageBox.Show("XML File Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                fs = new FileStream(@"G:thinkQu\ProductXml", FileMode.Open, FileAccess.Read);
                XmlSerializer xs = new XmlSerializer(typeof(Product));
                prod = (Product)xs.Deserialize(fs);
                txtId.Text = prod.ID.ToString();
                txtName.Text = prod.Name;
                txtPrice.Text = prod.Price.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                prod.ID = Convert.ToInt32(txtId.Text);
                prod.Name = txtName.Text;
                prod.Price = Convert.ToInt32(txtPrice.Text);
                fs = new FileStream(@"G:thinkQu\ProductSOAP", FileMode.Create, FileAccess.Write);
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fs, prod);
                MessageBox.Show("Soap File Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                fs = new FileStream(@"G:thinkQu\ProductXml", FileMode.Open, FileAccess.Read);
                SoapFormatter sf = new SoapFormatter();
                prod = (Product)sf.Deserialize(fs);
                txtId.Text = prod.ID.ToString();
                txtName.Text = prod.Name;
                txtPrice.Text = prod.Price.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                prod.ID = Convert.ToInt32(txtId.Text);
                prod.Name = txtName.Text;
                prod.Price = Convert.ToInt32(txtPrice.Text);
                fs = new FileStream(@"G:thinkQu\ProductJson", FileMode.Create, FileAccess.Write);
                JsonSerializer.Serialize(fs, prod);
                MessageBox.Show("json File Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }


        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product();
                fs = new FileStream(@"G:thinkQu\ProductJson", FileMode.Open, FileAccess.Read);
                prod = JsonSerializer.Deserialize<Product>(fs);
                txtId.Text = prod.ID.ToString();
                txtName.Text = prod.Name;
                txtPrice.Text = prod.Price.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }

        }
    }
}





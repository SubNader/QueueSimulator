using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Simulator
{

    public partial class Form1 : Form
    {
        int flag = 0;
        Service CustomerService = new Service();
        Service[] ClientList;
        Service[] ClientList_1;
        Queuee QueueeTest;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (((int)numericUpDown2.Value < (int)numericUpDown3.Value) && ((int)numericUpDown4.Value < (int)numericUpDown5.Value) && (int)numericUpDown1.Value >= 1)
            {
                if (flag == 0)
                {
                    flag = 1;
                    label7.Text = "Simulating..";
                    label8.Text = "Simulating..";
                    label18.Text = "Simulation in progress..";
                    label7.Refresh();
                    label8.Refresh();
                    label18.Refresh();
                    numericUpDown1.Enabled = false;
                    numericUpDown2.Enabled = false;
                    numericUpDown3.Enabled = false;
                    numericUpDown4.Enabled = false;
                    numericUpDown5.Enabled = false;
                    numericUpDown6.Enabled = false;
                    button1.Enabled = false;
                    CustomerService.WorkingHours = (int)numericUpDown1.Value;
                    CustomerService.MinimumCustomers = (int)numericUpDown2.Value;
                    CustomerService.MaximumCustomers = (int)numericUpDown3.Value;
                    CustomerService.MinimumServingTime = (int)numericUpDown4.Value;
                    CustomerService.MaximumServingTime = (int)numericUpDown5.Value;
                    int SimRate = (int)numericUpDown6.Value;
                    Random Random1 = new Random(DateTime.Now.Second);
                    CustomerService.Number = Random1.Next(CustomerService.MinimumCustomers, CustomerService.MaximumCustomers);
                    label19.Text = Convert.ToString(CustomerService.Number);
                    label19.Refresh();
                    ClientList = new Service[CustomerService.Number];
                    QueueeTest = new Queuee(ClientList);

                    for (int i = 0; i < CustomerService.Number; i++)
                    {
                        ClientList[i] = new Service();
                        CustomerService.ServingTime = Random1.Next(CustomerService.MinimumServingTime, CustomerService.MaximumServingTime);
                        ClientList[i].ServingTime = CustomerService.ServingTime;

                        QueueeTest.enqueue(ClientList[i]);

                    }
                    int temp = CustomerService.Number;
                    for (int i = 0; temp > 0; i++)
                    {
                        CustomerService.TotalServingTime += ClientList[i].ServingTime;
                        temp--;
                    }
                    label19.Text = Convert.ToString(CustomerService.Number);
                    progressBar1.Maximum = CustomerService.Number*600;

                    //Animation starts here.
                    int x, y;
                    for (int j = 0; j < CustomerService.Number; j++)
                    {
                        label22.Text = Convert.ToString(j + 1);
                        label22.Refresh();
                        label24.Text = Convert.ToString(ClientList[j].ServingTime);
                        label24.Refresh();
                        
                        pictureBox2.Location = new Point(314, 285);
                        System.Threading.Thread.Sleep(500);
                        for (int i = 0; i < 600; i++)
                        {
                            progressBar1.Value++;
                            x = pictureBox2.Location.X;
                            y = pictureBox2.Location.Y;

                            if (x == 702)
                            {
                                System.Threading.Thread.Sleep(ClientList[j].ServingTime);
                            }

                            else
                            {

                                pictureBox2.Location = new Point(x + 1, y);
                                System.Threading.Thread.Sleep(10 / SimRate);
                            }

                        }
                    }
                    Serve(ClientList);
                    Display();

                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Invalid input detected. Please verify the entered values.","Invalid input.");
            }

        }

        private void Serve(Service[] _myObjectList)
        {

            ClientList_1 = new Service[CustomerService.Number];

            int i = 0;

            while (i < CustomerService.Number)
            {
                ClientList_1[i] = QueueeTest.dequeue() as Service;
                i++;
            }
        }
        private void Display()
        {

            label7.Text = Convert.ToString(CustomerService.TotalServingTime);
            label8.Text = Convert.ToString(CustomerService.WorkingHours * 60 - CustomerService.TotalServingTime);
            label18.Text = "Simulation complete!";
            button1.Text = "Exit.";
            label22.Text = "Complete.";
            label24.Text = "Complete.";
            button1.Enabled= true;
            MessageBox.Show("Total Serving Time: " + CustomerService.TotalServingTime + "\n" +"Number Of Customers Served: " + CustomerService.Number,"Statistics");



        }

        private void numericUpDown1_TextChanged(object sender, EventArgs e)
        {

        }



        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void numericUpDown2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void numericUpDown3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void numericUpDown4_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(numericUpDown4.Text) > 24)
            {
                numericUpDown4.Text = "24";
                numericUpDown4.Select(0, 2);


            }
        }

        private void numericUpDown5_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(numericUpDown5.Text) > 24)
            {
                numericUpDown5.Text = "24";
                numericUpDown5.Select(0, 2);


            }
        }

        private void numericUpDown4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void numericUpDown5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 0)
            {
                numericUpDown1.Value = 1;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value < 0)
            {
                numericUpDown2.Value = 1;
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3.Value < 0)
            {
                numericUpDown3.Value = 1;
            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown4.Value < 0)
            {
                numericUpDown4.Value = 1;
            }
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown5.Value < 0)
            {
                numericUpDown5.Value = 1;
            }
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }
    }

}


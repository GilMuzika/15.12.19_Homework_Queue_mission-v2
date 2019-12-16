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

namespace _15._12._19_Homework_Queue_mission
{
    public partial class MainForm : Form
    {
        private MyQueue<Customer> currentQueue = new MyQueue<Customer>();
        private Random _rnd = new Random();        
        private ToolTip toolTip1 = new ToolTip();
        private ToolTip toolTip2 = new ToolTip();
        private string[] namesToUsing = null;
        private Clerk currentClerk = new Clerk();
        private Timer timer = new System.Windows.Forms.Timer();


        public MainForm()
        {
            InitializeComponent();
            Initialize();
            ReadFromFile();
        }
        private void Initialize()
        {
            pnlQueue.drawBorder(1, Color.Black);
            
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;            
            toolTip1.SetToolTip(btnAddCustomer, "New customer arive and join the queue");

            toolTip2.AutoPopDelay = 5000;
            toolTip2.InitialDelay = 1;
            toolTip2.ReshowDelay = 500;            
            toolTip2.IsBalloon = false;
            toolTip2.ShowAlways = false;

            currentClerk.Location = new Point(pnlQueue.Width - currentClerk.Width - 5, pnlQueue.Height / 2 - currentClerk.Height / 2);
            pnlQueue.Controls.Add(currentClerk);


            timer.Interval = 10;
            timer.Tick += (object sender, EventArgs e) =>
            {
                Intersection();
            };
            timer.Enabled = true;
            timer.Start();

            lblHelp.Location = new Point(1, this.ClientRectangle.Height - lblHelp.Height );
            lblHelp.Text =" Drag the first customer in the queue (green border) onto the clerk to dequeue. \nDouble click on a customer = \nאני רק שאלה ";

            Customer dummy = new Customer();

            string[] propertyValueNames = dummy.GetType().GetProperties().Where(x => x.DeclaringType == typeof(Customer) && !x.GetValue(dummy).GetType().Name.Equals("Boolean") && !x.GetValue(dummy).GetType().Name.Equals("Guid")).Select(x => x.Name).ToArray();
            string[] propertyTypeNames = dummy.GetType().GetProperties().Where(x => x.DeclaringType == typeof(Customer) && !x.GetValue(dummy).GetType().Name.Equals("Boolean") && !x.GetValue(dummy).GetType().Name.Equals("Guid")).Select(x => x.GetValue(dummy).GetType().Name).ToArray();
            string[][] propertyValuesAndTypes = new string[2][];
            propertyValuesAndTypes[0] = propertyValueNames;
            propertyValuesAndTypes[1] = propertyTypeNames;
            //cmbSortByAnyProperty.Items.AddRange(propertyValueNames);
            ComboItem<string>[] comboItems = new ComboItem<string>[propertyValueNames.Length];
            for(int i = 0; i < comboItems.Length; i++)
            {
                comboItems[i] = new ComboItem<string>(propertyValueNames[i], propertyTypeNames[i]);
            }

            cmbSortByAnyProperty.Items.AddRange(comboItems);
            cmbSortByAnyProperty.SelectedIndexChanged += (object sender, EventArgs e) => 
                {
                    try
                    {
                        //MessageBox.Show((sender as ComboBox).Text);
                        currentQueue.SortBy(((sender as ComboBox).SelectedItem as ComboItem<string>).ValueName, ((sender as ComboBox).SelectedItem as ComboItem<string>).ValueType);
                        lblCustomerInfo.Text = currentQueue.ToString();
                        afterSort();
                    }
                    catch (Exception ex)
                    {
                        pnlQueue.Controls.Add(currentClerk);
                        currentQueue.Clear();
                        MessageBox.Show(ex.Message);
                    }
                };

        }

        private void Intersection()
        {
            foreach(Customer s in currentQueue)
            {
                if(ReferenceEquals(s, currentQueue.WhoIsNext()) && s.Bounds.IntersectsWith(currentClerk.Bounds) && s.IsIntersected == false)
                {
                    s.IsIntersected = true;
                    try
                    {                    
                        pnlQueue.Controls.Remove(currentQueue.Dequeue());
                        lblCustomerInfo.Text = currentQueue.ToString();
                        DrawBorderOnImage(currentQueue.WhoIsNext());
                    }
                    catch(Exception ex)
                    {
                        currentQueue.Clear();
                        MessageBox.Show(ex.Message);
                    }
                    return;                      
                }
            }
        }

        private void ReadFromFile()
        {
            string names = string.Empty;
            try
            {
                names = File.ReadAllText("_names.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \n\nSo the program will use the defult names");
                names = " Alfred Benny Connnor Daniel Eran ";
            }
            namesToUsing = names.Split(new char[] { ' ', '\t', '\n' }).Where(x => !String.IsNullOrEmpty(x)).ToArray();
        }


        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer(_rnd.Next(100000000, 999999999), namesToUsing[_rnd.Next(namesToUsing.Length - 1)], _rnd.Next(1950, 2010), Statics.GetUniqueKeyOriginal_BIASED(10), _rnd.Next(1000, 9999));
            customer.Location = new Point(_rnd.Next(2, pnlQueue.Width - 150), _rnd.Next(2, pnlQueue.Height - 1));
            customer.TotalPurchases = _rnd.Next(0, 1000);
            customer.doubleClicknNow += () => 
                {
                    currentQueue.AniRakSheeela(customer);
                    afterSort();
                    MessageBox.Show(customer.ToString(), "אני רק שאלה!"); 

                };
            currentQueue.Enqueue(customer);
            toolTip1.SetToolTip(customer, customer.ToString());
            pnlQueue.Controls.Add(customer);

            try
            {
                DrawBorderOnImage(currentQueue.WhoIsNext());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            lblCustomerInfo.Text = currentQueue.ToString();

        }

        private void DrawBorderOnImage(Customer customer)
        {
            Bitmap btmp = (Bitmap)customer.Image;
            customer.drawBorder(2, Color.Green);
            customer.Image = new Bitmap(btmp);

            toolTip2.SetToolTip(customer, "אני הבא בתור");
        }

        private void btnSortByProtection_Click(object sender, EventArgs e)
        {
            try
            {
                currentQueue.SortByProtection();
                lblCustomerInfo.Text = currentQueue.ToString();
                afterSort();
            }
            catch(Exception ex)
            {
                pnlQueue.Controls.Add(currentClerk);
                currentQueue.Clear();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
        }

        private void btnSortByYear_Click(object sender, EventArgs e)
        {
            try 
            { 
            currentQueue.SortByBirthYear();
            lblCustomerInfo.Text = currentQueue.ToString();
            afterSort();
            }
            catch (Exception ex)
            {
                pnlQueue.Controls.Add(currentClerk);
                currentQueue.Clear();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
        }

        private void btnSortByTotalPurchases_Click(object sender, EventArgs e)
        {
            try 
            { 
            currentQueue.SortByTotalPurchases();
            lblCustomerInfo.Text = currentQueue.ToString();
            afterSort();
            }
            catch (Exception ex)
            {
                pnlQueue.Controls.Add(currentClerk);
                currentQueue.Clear();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
        }
        private void afterSort()
        {
            pnlQueue.Controls.Clear();
            foreach (Customer s in currentQueue) { s.drawBorder(2, SystemColors.Control); s.Image = new Bitmap(Properties.Resources.customer, s.Width, s.Height); }
            pnlQueue.Controls.AddRange(currentQueue.ToArray());
            DrawBorderOnImage(currentQueue.WhoIsNext());
            pnlQueue.Controls.Add(currentClerk);
        }
    }
}

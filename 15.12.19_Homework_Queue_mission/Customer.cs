using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15._12._19_Homework_Queue_mission
{
    class Customer : PictureBox
    {
        public delegate void doubleClick();
        public event doubleClick doubleClicknNow;

        private bool IsDragging = false;
        public bool IsIntersected { get; set; } = false;

        public Guid GuidId { get; } = Guid.NewGuid();

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int BirthYear { get; set; }
        public string Address { get; set; }
        public int Protection { get; set; }
        public int TotalPurchases { get; set; }

        public Customer(int id, string name, int birthYear, string address, int protection)
        {
            Id = id;
            CustomerName = name;
            BirthYear = birthYear;
            Address = address;
            Protection = protection;

            Bitmap customer_original = new Bitmap(Properties.Resources.customer);
            this.Width = customer_original.Width / 6;
            this.Height = customer_original.Height / 6;
            this.Image = new Bitmap(customer_original, new Size(this.Width, this.Height));

            motion();
        }

        //dummy constructor for reflection purposes
        public Customer()
        {
            Id = 12345;
            CustomerName = "kl/hn.hkh";
            BirthYear = 9999;
            Address = "aaaaaaaaa";
            Protection = 45698;
            TotalPurchases = 354543;
        }

        private void motion()
        {
            int currentX = 0;
            int currentY = 0;
            Color backColor = SystemColors.Control;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler((object sender, System.Windows.Forms.MouseEventArgs e) =>
            {
                IsDragging = true;
                this.Cursor = System.Windows.Forms.Cursors.Hand;

                currentX = e.X;
                currentY = e.Y;


            });
            this.MouseUp += new System.Windows.Forms.MouseEventHandler((object sender, System.Windows.Forms.MouseEventArgs MouseE) =>
            {
                IsDragging = false;
                this.Cursor = System.Windows.Forms.Cursors.Arrow;

            });
            this.MouseMove += (object sender, System.Windows.Forms.MouseEventArgs e) =>
            {
                if (IsDragging)
                {

                    this.Top = this.Top + (e.Y - currentY);
                    this.Left = this.Left + (e.X - currentX);
                }
            };

            this.DoubleClick += (object sender, EventArgs e) => { doubleClicknNow?.Invoke(); };
        }


        public override string ToString()
        {
            string str = string.Empty;
            var types = this.GetType().GetProperties().Where(x => x.DeclaringType == typeof(Customer) && !x.GetValue(this).GetType().Name.Equals("Boolean") && !x.GetValue(this).GetType().Name.Equals("Guid")).ToArray();

            foreach (var s in types)  { str += $"{s.Name}: {s.GetValue(this)}\n"; }
            str += "------------------\n";
            return str;
        }


    }
}

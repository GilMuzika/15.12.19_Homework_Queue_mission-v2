using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15._12._19_Homework_Queue_mission
{
    class Clerk: PictureBox
    {
        public Clerk()
        {
            Bitmap image = (Bitmap)Bitmap.FromFile("clerk.png");
            this.Width = image.Width / 7;
            this.Height = image.Height / 7;
            this.Image = new Bitmap(image, this.Width, this.Height);
        }

    }
}

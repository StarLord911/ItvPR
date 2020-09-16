using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Itv
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();    
        }
        
        

        private void Form2_Move(object sender, EventArgs e)
        {
            label1.Text = "Позиция " + "Х " + Location.X.ToString() + " Y " + Location.Y.ToString();
            label2.Text = "Размеры " + "Ширина " + Size.Width.ToString() + " Высота " + Size.Height.ToString();
        }
    }
}

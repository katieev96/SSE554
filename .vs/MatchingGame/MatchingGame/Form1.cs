using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!", "!","N","N","G","G","k","k",
            "2","2","v","v","x","x","z","z"
        };

        public void AssignIcons()
        {
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label iconsLabel = control as Label;
                if(iconsLabel != null)
                {
                    int rand = random.Next(icons.Count);
                    iconsLabel.Text = icons[rand];
                    //iconsLabel.ForeColor = iconsLabel.BackColor;
                    icons.RemoveAt(rand);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            AssignIcons();
        }
    }
}

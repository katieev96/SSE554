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
        Label clickedFirst = null;
        Label clickedSecond = null;

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
                    iconsLabel.ForeColor = iconsLabel.BackColor;
                    icons.RemoveAt(rand);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            AssignIcons();
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label labelClicked = sender as Label;

            if(labelClicked != null)
            {
                if (labelClicked.ForeColor == Color.Black)
                    return;

                if(clickedFirst == null)
                {
                    clickedFirst = labelClicked;
                    clickedFirst.ForeColor = Color.Black;
                    return;
                }

                clickedSecond = labelClicked;
                clickedSecond.ForeColor = Color.Black;

                CheckForWinner();

                if(clickedFirst.Text == clickedSecond.Text)
                {
                    clickedFirst = null;
                    clickedSecond = null;
                    return;
                }

                timer1.Start();
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            clickedFirst.ForeColor = clickedFirst.BackColor;
            clickedSecond.ForeColor = clickedSecond.BackColor;

            clickedFirst = null;
            clickedSecond = null;
        }

        private void CheckForWinner()
        {
            foreach(Control c in tableLayoutPanel1.Controls)
            {
                Label L = c as Label;

                if(L != null)
                {
                    if (L.ForeColor == L.BackColor)
                        return;
                }
            }
            
            MessageBox.Show("You win!! You matched all the icons!", "Congratulations");
            Close();
        }


    
    }
}

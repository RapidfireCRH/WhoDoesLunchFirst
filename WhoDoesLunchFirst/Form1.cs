using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoDoesLunchFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public struct userst : IComparable<userst>
        {
            public string name;
            public long num;
            public long distoffnum;
            public int CompareTo(userst other)
            {
                if (other.distoffnum > this.distoffnum)
                    return -1;
                if (other.distoffnum < this.distoffnum)
                    return 1;
                //if (other.distoffnum == this.distoffnum)
                return 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long.TryParse(textBox1.Text, out long maxnum);
            if (maxnum <= 0)
            {
                MessageBox.Show("The max number " + textBox1.Text + " cannot be read.");
                return;
            }

            List<userst> users = new List<userst>();
            if (textBox2.Text != "")
            {
                int x;
                int.TryParse(textBox2.Text, out x);
                if (x == 0 && textBox2.Text != "0")
                { 
                    MessageBox.Show("Michela's number " + textBox2.Text + " cannot be read.");
                    return;
                }
                if (x > maxnum || x < 1)
                { 
                    MessageBox.Show("Michela's number " + textBox2.Text + " is invalid. Please enter a number between 1 and " + maxnum);
                    return;
                }
                userst temp = new userst();
                temp.name = "Michela";
                temp.num = x;
                users.Add(temp);
            }
            if (textBox3.Text != "")
            {
                int x;
                int.TryParse(textBox3.Text, out x);
                if (x == 0 && textBox3.Text != "0")
                {
                    MessageBox.Show("Tony's number " + textBox3.Text + " cannot be read.");
                    return;
                }
                if (x > maxnum || x < 1)
                {
                    MessageBox.Show("Tony's number " + textBox3.Text + " is invalid. Please enter a number between 1 and " + maxnum);
                    return;
                }
                userst temp = new userst();
                temp.name = "Tony";
                temp.num = x;
                users.Add(temp);
            }
            if (textBox4.Text != "")
            {
                int x;
                int.TryParse(textBox4.Text, out x);
                if (x == 0 && textBox4.Text != "0")
                {
                    MessageBox.Show("David's number " + textBox4.Text + " cannot be read.");
                    return;
                }
                if (x > maxnum || x < 1)
                {
                    MessageBox.Show("David's number " + textBox4.Text + " is invalid. Please enter a number between 1 and " + maxnum);
                    return;
                }
                userst temp = new userst();
                temp.name = "David";
                temp.num = x;
                users.Add(temp);
            }

            if (users.Count == 0)
            {
                MessageBox.Show("Please enter values into guessers textboxes.");
                return;
            }

            Random rand = new Random();
            long randnum = (long)(rand.NextDouble() * maxnum) + 1;

            List<userst> usersfinal = new List<userst>();

            foreach ( userst y in users)
            {
                userst temp = y;
                temp.distoffnum = Math.Abs(temp.num - randnum);
                usersfinal.Add(temp);
            }
            usersfinal.Sort();

            string message = "The number was " + randnum + ".\r\n" +
                                usersfinal[0].name + " is the winner, off by " + usersfinal[0].distoffnum + ".\r\n";
            if (usersfinal.Count >= 2)
                message += usersfinal[1].name + " came in second, off by " + usersfinal[1].distoffnum + ".\r\n";
            if (usersfinal.Count == 3)
                message += usersfinal[2].name + " came in last, off by " + usersfinal[2].distoffnum + ".\r\n";

            message += "Congratulations. *Pops Confetti Cannon*";

            MessageBox.Show(message, "Congratulations to " + usersfinal[0].name, MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}

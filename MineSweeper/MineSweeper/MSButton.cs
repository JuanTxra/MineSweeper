using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MineSweeper
{
    public class MSButton : Button
    {

        public MSButton()
        {
            this.Location = new Point(10, 10);
            this.Size = new Size(10, 10);
            this.Text = "Teste";
        }
        public void CreateButtons()
        {
            System.Windows.Forms.Button button1 = new System.Windows.Forms.Button();

            button1.Location = new Point(10, 10);
            button1.Width = 10;
            button1.Height = 10;
            button1.BackColor = Color.Red;
            button1.ForeColor = Color.Blue;
            button1.Text = "I am Dynamic Button";
            button1.Name = "DynamicButton";
            button1.Font = new Font("Georgia", 16);

            
        }
        
    }
}

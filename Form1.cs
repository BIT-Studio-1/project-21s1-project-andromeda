using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_andromeda
{
    public partial class mainGui : Form
    {
        private ControlCollection guiControls;

        public mainGui(ControlCollection guiControls)
        {
            InitializeComponent();
            Form ownerShip = Owner;
            guiControls = new ControlCollection(ownerShip);
            this.guiControls = guiControls;
        }
        private void mainGui_Load(object sender, EventArgs e)
        {
            fillControlCollection();
        }

        private void buttonNorth_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonEast_Click(object sender, EventArgs e)
        {

        }

        private void buttonWest_Click(object sender, EventArgs e)
        {

        }

        private void buttonSouth_Click(object sender, EventArgs e)
        {

        }

        private void fillControlCollection()
        {
            guiControls.Add(textOutput);
            guiControls.Add(directionalLabel);
            guiControls.Add(buttonNorth);
            guiControls.Add(buttonEast);
            guiControls.Add(buttonWest);
            guiControls.Add(buttonSouth);
        }
    }
}

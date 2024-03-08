/* DHallQgame.cs
 * Assignment 2
 * Revision History:
 *  Dana Hall, November 1st 2023: Created.
 *  Dana Hall, November 4th 2023: Finished debugging and adding documentation.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHallQGame
{
    /// <summary>
    /// A form acting as QGame's main menu. Has three options: Design, Play, and Exit.
    /// </summary>
    public partial class MenuForm : Form
    {
        /// <summary>
        /// Initializes menu form components.
        /// </summary>
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            DesignForm design = new DesignForm();
            design.Show();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayForm play = new PlayForm();
            play.Show();
        }
    }
}

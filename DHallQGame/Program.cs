/* DHallQgame.cs
 * Assignment 2
 * Revision History:
 *  Dana Hall, November 1st 2023: Created.
 *  Dana Hall, November 4th 2023: Finished debugging and adding documentation.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHallQGame
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuForm());
        }
    }
}

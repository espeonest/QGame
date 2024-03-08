/* DHallQgame.cs
 * Assignment 2
 * Revision History:
 *  Dana Hall, November 1st 2023: Created.
 *  Dana Hall, November 4th 2023: Finished debugging and adding documentation.
 *  
 * Assignment 3
 * Revision History:
 *  Dana Hall, November 26th 2023: PlayForm added.
 *  Dana Hall, November 27th 2023: Position properties added to Tile object. Added control functionality.
 *  Dana Hall, December 2nd, 2023: Formatted and added documentation.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHallQGame
{
    /// <summary>
    /// A child of PictureBox. Holds a tileState integer to 
    /// represent the current game object occupying the tile as
    /// well as tilePositionX and tilePositionY indicating its
    /// position on the game board.
    /// </summary>
    internal class Tile : PictureBox
    {
        private const int TILE_WIDTH = 100;
        private const int TILE_HEIGHT = 100;

        private int tileState;
        public int TileState { get => tileState; set => tileState = value; }

        private int tilePositionX;
        public int TilePositionX { get=> tilePositionX; set => tilePositionX = value; }

        private int tilePositionY;
        public int TilePositionY { get => tilePositionY; set => tilePositionY = value; }

        /// <summary>
        /// Instantiates the tile, assigning its appearance and
        /// component settings.
        /// </summary>
        public Tile()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.White;
            this.Width = TILE_WIDTH;
            this.Height = TILE_HEIGHT;
            this.SizeMode = PictureBoxSizeMode.Zoom;
        }

        /// <summary>
        /// Takes the tileState integer and returns it as a string.
        /// </summary>
        /// <returns>a single-character string representing the tile's state</returns>
        public override string ToString()
        {
            return tileState.ToString();
        }

    }
}

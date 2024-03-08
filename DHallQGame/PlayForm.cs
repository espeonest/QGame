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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHallQGame
{
    /// <summary>
    /// A form for loading and playing qgame levels.
    /// </summary>
    public partial class PlayForm : Form
    {
        #region constants
        // necessary variables copied from DesignForm
        private const int TOP_MARGIN = 80;
        private const int LEFT_MARGIN = 300;
        private const int SPACING = 5; // gap between tiles
        // to make future code easier to read, the below constants represent the top and left edges
        // of the game grid.
        private const int TOP_BORDER = 0;
        private const int LEFT_BORDER = 0;

        // int variables used to represent the game objects
        // given meaningful names for readability
        // eraser has been replaced with empty
        private const int EMPTY = 0;
        private const int WALL = 1;
        private const int RED_BOX = 2;
        private const int GREEN_BOX = 3;
        private const int RED_DOOR = 4;
        private const int GREEN_DOOR = 5;
        #endregion

        #region global variables
        private Image wall;
        private Image redBox;
        private Image greenBox;
        private Image redDoor;
        private Image greenDoor;

        private List<Image> gameComponents;
        private Tile[,] levelTiles;

        private int rowCount;
        private int columnCount;
        private int boxCount;
        private int moveCount;

        private enum boxSelected { none, red, green };
        private boxSelected selection;
        private Tile tileSelected;
        #endregion

        /// <summary>
        /// Initializes PlayForm elements and assigns images to variables. Sets the box selection variable to "none"
        /// </summary>
        public PlayForm()
        {
            wall = Properties.Resources.Wall;
            redBox = Properties.Resources.RedBox;
            greenBox = Properties.Resources.GreenBox;
            redDoor = Properties.Resources.RedDoor;
            greenDoor = Properties.Resources.GreenDoor;
            gameComponents = new List<Image> { null, wall, redBox, greenBox, redDoor, greenDoor };
            selection = boxSelected.none;
            InitializeComponent();
        }

        /// <summary>
        /// Resets the rowCount, moveCount, and boxCount variables. Sets box selection variable back to "none".
        /// Disposes tiles from the previously-loaded level and then changes the form mode to NothingLoaded.
        /// </summary>
        public void Clear()
        {
            rowCount = 0;
            moveCount = 0;
            txtMoves.Text = moveCount.ToString();
            boxCount = 0;
            selection = boxSelected.none;
            lblSelected.Text = "";
            foreach (Tile tile in levelTiles)
            {
                tile.Dispose();
            }
            NothingLoaded();
        }

        /// <summary>
        /// A method that sets various form elements to their initial state and disables the box movement buttons.
        /// </summary>
        public void NothingLoaded()
        {
            lblInstructions.Visible = false;
            lblInstructions2.Visible = false;
            btnDown.Enabled = false;
            btnUp.Enabled = false;
            btnLeft.Enabled = false;
            btnRight.Enabled = false;
        }

        /// <summary>
        /// A method that reveals instructional labels and enables buttons so the loaded level can be played.
        /// Sets the moveCount to 0.
        /// </summary>
        public void LevelLoaded()
        {
            lblInstructions.Visible = true;
            lblInstructions2.Visible = true;
            btnDown.Enabled = true;
            btnUp.Enabled = true;
            btnLeft.Enabled = true;
            btnRight.Enabled = true;
            moveCount = 0;
        }

        /// <summary>
        /// Displays a victory message box and calls the Clear() method.
        /// </summary>
        public void Victory()
        {
            MessageBox.Show("Congratulations! You beat the level in " + moveCount + " moves.");
            Clear();
        }

        /// <summary>
        /// A method that checks what tile has been clicked and changes the selection variable accordingly.
        /// </summary>
        /// <param name="sender">The component that has been clicked</param>
        /// <param name="e">Event data.</param>
        private void gridTile_Click(object sender, EventArgs e)
        {
            Tile tile = (Tile)sender;
            if (tile.TileState == RED_BOX)
            {
                tileSelected = tile;
                selection = boxSelected.red;
                lblSelected.ForeColor = Color.Red;
                lblSelected.Text = "Currently selected: Red box";
            }
            else if (tile.TileState == GREEN_BOX)
            {
                tileSelected = tile;
                selection = boxSelected.green;
                lblSelected.ForeColor = Color.Green;
                lblSelected.Text = "Currently selected: Green box";
            }
            else
            {
                // allowing player to deselect by clicking another tile
                selection = boxSelected.none;
                lblSelected.Text = "";
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // checks to see if something has already been loaded and then clears the board
            if (btnUp.Enabled)
            {
                Clear();
            }
            string fileName;
            int characterCount = 0;
            openFileDialog.Filter = "QGame level (*.qgame) | *.qgame| All files(*.*) | *.*";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                FileStream fileStream = new FileStream(fileName, FileMode.Open);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string fileData = reader.ReadToEnd();
                    foreach (char c in fileData)
                    {
                        if (c == '\n')
                        {
                            rowCount++;
                            // the final character of a row will always be nextline
                            // based on how the file string is generated. So no need 
                            // to add one to the row count.
                        }
                        else
                        {
                            characterCount++;
                        }
                    }
                    columnCount = characterCount / rowCount;
                    // since nextline characters are excluded from total character count
                    // it should be evenly divisible by rowcount if it's a valid file.
                    // if not, the try block below will catch it.

                    levelTiles = new Tile[rowCount, columnCount];
                    string levelData = "";
                    // now saving only relevant characters to a new string for parsing
                    foreach (char c in fileData)
                    {
                        if (c != '\n')
                        {
                            levelData += c;
                        }
                    }
                    try
                    {
                        int index = 0;
                        for (int i = 0; i < rowCount; i++)
                        {
                            for (int j = 0; j < columnCount; j++)
                            {
                                levelTiles[i, j] = new Tile();
                                levelTiles[i, j].TileState = int.Parse(levelData[index].ToString());
                                levelTiles[i, j].Image = gameComponents[levelTiles[i, j].TileState];
                                levelTiles[i, j].Left = (j * (levelTiles[i, j].Width + SPACING) + LEFT_MARGIN);
                                levelTiles[i, j].Top = (i * (levelTiles[i, j].Height + SPACING) + TOP_MARGIN);
                                // j is current column therefore represents x position
                                // and vice versa for i
                                levelTiles[i, j].TilePositionX = j;
                                levelTiles[i, j].TilePositionY = i;
                                this.Controls.Add(levelTiles[i, j]);
                                levelTiles[i, j].Click += gridTile_Click;
                                if (levelTiles[i, j].TileState == 2 || levelTiles[i, j].TileState == 3)
                                {
                                    boxCount++;
                                }
                                index++;
                            }
                        }
                        LevelLoaded();
                        txtBoxes.Text = boxCount.ToString();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error: File data unreadable. Please ensure a valid .qgame file was selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Checks whether or not spaces above the selected box can be passed through and
        /// sets the tile states accordingly. If a space is occupied, the space directly below it
        /// will now contain the selected box and its previous location is set to empty. If the
        /// box reaches a door of its same colour, it is removed from the board altogether.
        /// </summary>
        /// <returns>true if the selected box is sent through a door, false otherwise.</returns>
        private bool BoxUp()
        {
            Tile spaceOccupied = null;
            int x = tileSelected.TilePositionX;
            int y = tileSelected.TilePositionY;
            tileSelected.TileState = EMPTY;
            tileSelected.Image = null;
            for (int i = y; i >= TOP_BORDER; i--)
            {
                if (selection == boxSelected.red && spaceOccupied is null)
                {
                    switch (levelTiles[i, x].TileState)
                    {
                        case EMPTY:
                            break;
                        case WALL:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        case RED_BOX:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        case GREEN_BOX:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        case RED_DOOR:
                            selection = boxSelected.none;
                            return true;
                        case GREEN_DOOR:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        default:
                            break;
                    }
                }
                else if (selection == boxSelected.green && spaceOccupied is null)
                {
                    switch (levelTiles[i, x].TileState)
                    {
                        case EMPTY:
                            break;
                        case WALL:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        case RED_BOX:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        case GREEN_BOX:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        case RED_DOOR:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        case GREEN_DOOR:
                            selection = boxSelected.none;
                            return true;
                        default:
                            break;
                    }
                }
            }
            if (selection == boxSelected.red)
            {
                if (spaceOccupied is null)
                {
                    levelTiles[TOP_BORDER, x].TileState = RED_BOX;
                    levelTiles[TOP_BORDER, x].Image = redBox;
                    tileSelected = levelTiles[TOP_BORDER, x];
                }
                else
                {
                    // stops one box below the occupied tile
                    levelTiles[spaceOccupied.TilePositionY + 1, x].TileState = RED_BOX;
                    levelTiles[spaceOccupied.TilePositionY + 1, x].Image = redBox;
                    tileSelected = levelTiles[spaceOccupied.TilePositionY + 1, x];
                }
            }
            else if (selection == boxSelected.green)
            {
                if (spaceOccupied is null)
                {
                    levelTiles[TOP_BORDER, x].TileState = GREEN_BOX;
                    levelTiles[TOP_BORDER, x].Image = greenBox;
                    tileSelected = levelTiles[TOP_BORDER, x];
                }
                else
                {
                    levelTiles[spaceOccupied.TilePositionY + 1, x].TileState = GREEN_BOX;
                    levelTiles[spaceOccupied.TilePositionY + 1, x].Image = greenBox;
                    tileSelected = levelTiles[spaceOccupied.TilePositionY + 1, x];
                }
            }
            return false;
        }

        /// <summary>
        /// Checks whether or not spaces below the selected box can be passed through and
        /// sets the tile states accordingly. If a space is occupied, the space directly above it
        /// will now contain the selected box and its previous location is set to empty. If the
        /// box reaches a door of its same colour, it is removed from the board altogether.
        /// </summary>
        /// <returns>true if the selected box is sent through a door, false otherwise.</returns>
        private bool BoxDown()
        {
            Tile spaceOccupied = null;
            int x = tileSelected.TilePositionX;
            int y = tileSelected.TilePositionY;
            tileSelected.TileState = EMPTY;
            tileSelected.Image = null;
            for (int i = y; i < rowCount; i++)
            {
                if (selection == boxSelected.red && spaceOccupied is null)
                {
                    switch (levelTiles[i, x].TileState)
                    {
                        case EMPTY:
                            break;
                        case WALL:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        case RED_BOX:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        case GREEN_BOX:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        case RED_DOOR:
                            selection = boxSelected.none;
                            return true;
                        case GREEN_DOOR:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        default:
                            break;
                    }
                }
                else if (selection == boxSelected.green && spaceOccupied is null)
                {
                    switch (levelTiles[i, x].TileState)
                    {
                        case EMPTY:
                            break;
                        case WALL:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        case RED_BOX:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        case GREEN_BOX:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        case RED_DOOR:
                            spaceOccupied = levelTiles[i, x];
                            break;
                        case GREEN_DOOR:
                            selection = boxSelected.none;
                            return true;
                        default:
                            break;
                    }
                }
            }
            if (selection == boxSelected.red)
            {
                if (spaceOccupied is null)
                {
                    levelTiles[rowCount-1, x].TileState = RED_BOX;
                    levelTiles[rowCount-1, x].Image = redBox;
                    tileSelected = levelTiles[rowCount - 1, x];
                }
                else
                {
                    // stops one box above the occupied tile
                    levelTiles[spaceOccupied.TilePositionY - 1, x].TileState = RED_BOX;
                    levelTiles[spaceOccupied.TilePositionY - 1, x].Image = redBox;
                    tileSelected = levelTiles[spaceOccupied.TilePositionY - 1, x];
                }
            }
            else if (selection == boxSelected.green)
            {
                if (spaceOccupied is null)
                {
                    levelTiles[rowCount-1, x].TileState = GREEN_BOX;
                    levelTiles[rowCount-1, x].Image = greenBox;
                    tileSelected = levelTiles[rowCount - 1, x];
                }
                else
                {
                    levelTiles[spaceOccupied.TilePositionY - 1, x].TileState = GREEN_BOX;
                    levelTiles[spaceOccupied.TilePositionY - 1, x].Image = greenBox;
                    tileSelected = levelTiles[spaceOccupied.TilePositionY - 1, x];
                }
            }
            return false;
        }

        /// <summary>
        /// Checks whether or not spaces left of the selected box can be passed through and
        /// sets the tile states accordingly. If a space is occupied, the space directly to the right of it
        /// will now contain the selected box and its previous location is set to empty. If the
        /// box reaches a door of its same colour, it is removed from the board altogether.
        /// </summary>
        /// <returns>true if the selected box is sent through a door, false otherwise.</returns>
        private bool BoxLeft()
        {
            Tile spaceOccupied = null;
            int x = tileSelected.TilePositionX;
            int y = tileSelected.TilePositionY;
            tileSelected.TileState = EMPTY;
            tileSelected.Image = null;
            for (int i = x; i >= LEFT_BORDER; i--)
            {
                if (selection == boxSelected.red && spaceOccupied is null)
                {
                    switch (levelTiles[y, i].TileState)
                    {
                        case EMPTY:
                            break;
                        case WALL:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        case RED_BOX:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        case GREEN_BOX:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        case RED_DOOR:
                            selection = boxSelected.none;
                            return true;
                        case GREEN_DOOR:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        default:
                            break;
                    }
                }
                else if (selection == boxSelected.green && spaceOccupied is null)
                {
                    switch (levelTiles[y, i].TileState)
                    {
                        case EMPTY:
                            break;
                        case WALL:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        case RED_BOX:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        case GREEN_BOX:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        case RED_DOOR:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        case GREEN_DOOR:
                            selection = boxSelected.none;
                            return true;
                        default:
                            break;
                    }
                }
            }
            if (selection == boxSelected.red)
            {
                if (spaceOccupied is null)
                {
                    levelTiles[y, LEFT_BORDER].TileState = RED_BOX;
                    levelTiles[y, LEFT_BORDER].Image = redBox;
                    tileSelected = levelTiles[y, LEFT_BORDER];
                }
                else
                {
                    // stops one box right of the occupied tile
                    levelTiles[y, spaceOccupied.TilePositionX + 1].TileState = RED_BOX;
                    levelTiles[y, spaceOccupied.TilePositionX + 1].Image = redBox;
                    tileSelected = levelTiles[y, spaceOccupied.TilePositionX + 1];
                }
            }
            else if (selection == boxSelected.green)
            {
                if (spaceOccupied is null)
                {
                    levelTiles[y, LEFT_BORDER].TileState = GREEN_BOX;
                    levelTiles[y, LEFT_BORDER].Image = greenBox;
                    tileSelected = levelTiles[y, LEFT_BORDER];
                }
                else
                {
                    levelTiles[y, spaceOccupied.TilePositionX + 1].TileState = GREEN_BOX;
                    levelTiles[y, spaceOccupied.TilePositionX + 1].Image = greenBox;
                    tileSelected = levelTiles[y, spaceOccupied.TilePositionX + 1];
                }
            }
            return false;
        }

        /// <summary>
        /// Checks whether or not spaces right of the selected box can be passed through and
        /// sets the tile states accordingly. If a space is occupied, the space directly to the left of it
        /// will now contain the selected box and its previous location is set to empty. If the
        /// box reaches a door of its same colour, it is removed from the board altogether.
        /// </summary>
        /// <returns>true if the selected box is sent through a door, false otherwise.</returns>
        private bool BoxRight()
        {
            Tile spaceOccupied = null;
            int x = tileSelected.TilePositionX;
            int y = tileSelected.TilePositionY;
            tileSelected.TileState = EMPTY;
            tileSelected.Image = null;
            for (int i = x; i < columnCount; i++)
            {
                if (selection == boxSelected.red && spaceOccupied is null)
                {
                    switch (levelTiles[y, i].TileState)
                    {
                        case EMPTY:
                            break;
                        case WALL:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        case RED_BOX:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        case GREEN_BOX:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        case RED_DOOR:
                            selection = boxSelected.none;
                            return true;
                        case GREEN_DOOR:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        default:
                            break;
                    }
                }
                else if (selection == boxSelected.green && spaceOccupied is null)
                {
                    switch (levelTiles[y, i].TileState)
                    {
                        case EMPTY:
                            break;
                        case WALL:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        case RED_BOX:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        case GREEN_BOX:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        case RED_DOOR:
                            spaceOccupied = levelTiles[y, i];
                            break;
                        case GREEN_DOOR:
                            selection = boxSelected.none;
                            return true;
                        default:
                            break;
                    }
                }
            }
            if (selection == boxSelected.red)
            {
                if (spaceOccupied is null)
                {
                    levelTiles[y, columnCount - 1].TileState = RED_BOX;
                    levelTiles[y, columnCount - 1].Image = redBox;
                    tileSelected = levelTiles[y, columnCount - 1];
                }
                else
                {
                    // stops one box left of the occupied tile
                    levelTiles[y, spaceOccupied.TilePositionX - 1].TileState = RED_BOX;
                    levelTiles[y, spaceOccupied.TilePositionX - 1].Image = redBox;
                    tileSelected = levelTiles[y, spaceOccupied.TilePositionX - 1];
                }
            }
            else if (selection == boxSelected.green)
            {
                if (spaceOccupied is null)
                {
                    levelTiles[y, columnCount - 1].TileState = GREEN_BOX;
                    levelTiles[y, columnCount - 1].Image = greenBox;
                    tileSelected = levelTiles[y, columnCount - 1];
                }
                else
                {
                    levelTiles[y, spaceOccupied.TilePositionX - 1].TileState = GREEN_BOX;
                    levelTiles[y, spaceOccupied.TilePositionX - 1].Image = greenBox;
                    tileSelected = levelTiles[y, spaceOccupied.TilePositionX - 1];
                }
            }
            return false;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            bool boxExited = false;
            switch (selection)
            {
                case boxSelected.none:
                    MessageBox.Show("Nothing selected. Please click on the box you'd like to move.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case boxSelected.red:
                    boxExited = BoxUp();
                    moveCount++;
                    break;
                case boxSelected.green:
                    boxExited = BoxUp();
                    moveCount++;
                    break;
                default:
                    break;
            }
            if (boxExited)
            {
                boxCount--;
                txtBoxes.Text = boxCount.ToString();
            }
            txtMoves.Text = moveCount.ToString();
            if (boxCount == 0)
            {
                Victory();
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            bool boxExited = false;
            switch (selection)
            {
                case boxSelected.none:
                    MessageBox.Show("Nothing selected. Please click on the box you'd like to move.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case boxSelected.red:
                    boxExited = BoxDown();
                    moveCount++;
                    break;
                case boxSelected.green:
                    boxExited = BoxDown();
                    moveCount++;
                    break;
                default:
                    break;
            }
            if (boxExited)
            {
                boxCount--;
                txtBoxes.Text = boxCount.ToString();
            }
            txtMoves.Text = moveCount.ToString();
            if (boxCount == 0)
            {
                Victory();
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            bool boxExited = false;
            switch (selection)
            {
                case boxSelected.none:
                    MessageBox.Show("Nothing selected. Please click on the box you'd like to move.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case boxSelected.red:
                    boxExited = BoxLeft();
                    moveCount++;
                    break;
                case boxSelected.green:
                    boxExited = BoxLeft();
                    moveCount++;
                    break;
                default:
                    break;
            }
            if (boxExited)
            {
                boxCount--;
                txtBoxes.Text = boxCount.ToString();
            }
            txtMoves.Text = moveCount.ToString();
            if (boxCount == 0)
            {
                Victory();
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            bool boxExited = false;
            switch (selection)
            {
                case boxSelected.none:
                    MessageBox.Show("Nothing selected. Please click on the box you'd like to move.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case boxSelected.red:
                    boxExited = BoxRight();
                    moveCount++;
                    break;
                case boxSelected.green:
                    boxExited = BoxRight();
                    moveCount++;
                    break;
                default:
                    break;
            }
            if (boxExited)
            {
                boxCount--;
                txtBoxes.Text = boxCount.ToString();
            }
            txtMoves.Text = moveCount.ToString();
            if(boxCount == 0)
            {
                Victory();
            }
        }
    }
}

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
    /// A form for designing game levels.
    /// </summary>
    public partial class DesignForm : Form
    {
        #region constants
        private const int TOP_MARGIN = 80;
        private const int LEFT_MARGIN = 200;
        private const int SPACING = 5; // gap between tiles

        // int variables used to represent the game objects
        // given meaningful names for readability
        private const int ERASER = 0;
        private const int WALL = 1;
        private const int RED_BOX = 2;
        private const int GREEN_BOX = 3;
        private const int RED_DOOR = 4;
        private const int GREEN_DOOR = 5;

        // represents the default state of the selected tool
        private const int TOOL_DEFAULT = -1;
        #endregion

        #region global variables
        private bool generated = false;
        private int toolSelectionState = TOOL_DEFAULT;
        private Dictionary<int, PictureBox> toolBox = new Dictionary<int, PictureBox>();
        Tile[,] gridTiles;
        int boxCount;
        int doorCount;
        int wallCount;
        private string fileData;
        #endregion

        /// <summary>
        /// Initializes design form's components and assigns PictureBox objects
        /// to the toolBox array.
        /// </summary>
        public DesignForm()
        {
            InitializeComponent();
            // populate dictionary with our tools
            toolBox[ERASER] = pbEraser;
            toolBox[WALL] = pbWall;
            toolBox[RED_BOX] = pbRedBox;
            toolBox[GREEN_BOX] = pbGreenBox;
            toolBox[RED_DOOR] = pbRedDoor;
            toolBox[GREEN_DOOR] = pbGreenDoor;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (generated)
            {
                if (OverwriteGrid())
                {
                    CreateGrid();
                }
            }
            else
            {
                CreateGrid();
            }
        }

        /// <summary>
        /// Asks if the user would like to erase their current in-progress level
        /// and start a new grid. If yes, disposes of old tile components.
        /// </summary>
        /// <returns>true if grid is erased, false otherwise.</returns>

        private bool OverwriteGrid()
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("There is already a level in progress.\nWould you like to start a new one?\nAll current work will be erased.", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                foreach (Tile tile in gridTiles)
                {
                    tile.Dispose();
                }
                // though this value will be flipped back to true as soon as
                // a new grid is created, it is possible for the input to be
                // invalid, leaving the user with a blank design form.
                // therefore it makes sense to change generated to false to
                // prevent unnecessary warning dialogues.
                generated = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// A function for creating a level design grid made of tile components
        /// using textbox input to determine number of rows and columns. Input is 
        /// checked to ensure a valid integer value and the grid will not be
        /// created if not.
        /// </summary>
        private void CreateGrid()
        {
            int rows;
            int columns;
            try
            {
                rows = int.Parse(txtRows.Text);
                columns = int.Parse(txtColumns.Text);
                if (rows < 1 || columns < 1)
                {
                    MessageBox.Show("Error: Only positive numbers accepted.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    throw new Exception();
                }
                generated = true;

                gridTiles = new Tile[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        gridTiles[i, j] = new Tile();
                        gridTiles[i, j].Left = (j * (gridTiles[i, j].Width + SPACING) + LEFT_MARGIN);
                        gridTiles[i, j].Top = (i * (gridTiles[i, j].Height + SPACING) + TOP_MARGIN);
                        this.Controls.Add(gridTiles[i, j]);
                        gridTiles[i, j].Click += pbTiles_Click;
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error: Only positive whole numbers accepted as input.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Error: Number too large.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception)
            {
            }


        }

        private void toolBoxItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < toolBox.Count; i++)
            {
                if (toolBox[i] == sender)
                {
                    // the selection label tells the user which tool is
                    // currently selected at any given moment. It initially
                    // states "No tool currently selected."
                    toolSelectionState = i;
                    lblSelection.Text = "Current Tool: ";
                    switch (toolSelectionState)
                    {
                        case ERASER:
                            lblSelection.Text += "Eraser";
                            break;
                        case WALL:
                            lblSelection.Text += "Wall";
                            break;
                        case RED_BOX:
                            lblSelection.Text += "Red Box";
                            break;
                        case GREEN_BOX:
                            lblSelection.Text += "Green Box";
                            break;
                        case RED_DOOR:
                            lblSelection.Text += "Red Door";
                            break;
                        case GREEN_DOOR:
                            lblSelection.Text += "Green Door";
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void pbTiles_Click(object sender, EventArgs e)
        {
            // unboxing the sender
            Tile currentTile = (Tile)sender;
            foreach (Tile tile in gridTiles)
            {
                if (currentTile == tile && toolSelectionState != TOOL_DEFAULT)
                {
                    tile.TileState = toolSelectionState;
                }
            }

            // by default, the current tool's image is copied to the
            // sender tile. If no tool is selected, nothing happens. 
            // if the eraser is selected, the image becomes null.
            switch (toolSelectionState)
            {
                case TOOL_DEFAULT:
                    break;
                case ERASER:
                    currentTile.Image = null;
                    break;
                default:
                    currentTile.Image = toolBox[toolSelectionState].Image;
                    break;
            }
        }

        /// <summary>
        /// Assigns a string to the fileData variable to be used when saving
        /// the current level. Also saves the number of walls, boxes, and doors
        /// to wallCount, boxCount, and doorCount. 
        /// </summary>
        private void CreateFileString()
        {
            fileData = string.Empty;
            wallCount = 0;
            boxCount = 0;
            doorCount = 0;
            if (generated)
            {
                for (int i = 0; i < gridTiles.GetLength(0); i++)
                {
                    for (int j = 0; j < gridTiles.GetLength(1); j++)
                    {
                        fileData += gridTiles[i, j].ToString();
                        switch (gridTiles[i,j].TileState)
                        {
                            case WALL:
                                wallCount++;
                                break;
                            case RED_BOX:
                                boxCount++;
                                break;
                            case GREEN_BOX:
                                boxCount++;
                                break;
                            case RED_DOOR:
                                doorCount++;
                                break;
                            case GREEN_DOOR:
                                doorCount++;
                                break;
                            default:
                                break;
                        }
                    }
                    fileData += "\n";
                }
            }
            else
            {
                MessageBox.Show("Please generate a level before attempting to save.");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFileString();
            if (fileData != string.Empty)
            {
                string fileName;
                SaveFileDialog save = new SaveFileDialog();
                save.AddExtension = true;
                save.DefaultExt = ".qgame";
                save.Filter = "QGame level(.qgame)|.qgame";
                DialogResult result = save.ShowDialog();
                if (result == DialogResult.OK)
                {
                    fileName = save.FileName;
                    FileStream fileStream = new FileStream(fileName, FileMode.CreateNew);
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.Write(fileData);
                    }
                    MessageBox.Show($"Saved successfully. Number of\nWalls: {wallCount}\nBoxes: {boxCount}\nDoors: {doorCount}");
                }
                
            }
        }
    }
}

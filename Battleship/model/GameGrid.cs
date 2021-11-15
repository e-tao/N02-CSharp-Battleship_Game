using System.Drawing;
using System.Windows.Forms;

namespace Battleship.model
{
    public partial class GameGrid : UserControl
    {
        public delegate void GridPosition(FireEventArgs fireEventArgs);
        public event GridPosition GridClick;

        TableLayoutPanel layoutPanel;
        int rows, cols;

        public GameGrid()
        {
            InitializeComponent();
            layoutPanel = new();
            rows = GameVariables.Boundry;
            cols = GameVariables.Boundry;
            InitGrid();
        }


        private GridTile[,] missiles;

        public GridTile[,] Tiles
        {
            get
            {
                if (missiles == null)
                {
                    missiles = new GridTile[rows, cols];
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            missiles[i, j] = (GridTile)layoutPanel.GetControlFromPosition(i, j);
                        }
                    }
                }
                return missiles;
            }
        }


        private void OnFireClick(GridTile gridButton)
        {
            if (GridClick != null)
            {
                GridClick(new FireEventArgs { MissileButton = gridButton });
            }
        }


        public void InitGrid()
        {
            Controls.Clear();
            missiles = null;
            layoutPanel = new();
            layoutPanel.Dock = DockStyle.Fill;

            layoutPanel.RowCount = rows;
            layoutPanel.ColumnCount = cols;
            layoutPanel.BackgroundImage = Image.FromFile("images\\background.png");


            for (int i = 0; i < layoutPanel.RowCount; i++)
            {
                layoutPanel.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100 / layoutPanel.RowCount)
                );
            }

            for (int i = 0; i < layoutPanel.ColumnCount; i++)
            {
                layoutPanel.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 100 / layoutPanel.ColumnCount)
                    );
            }


            for (int i = 0; i < layoutPanel.RowCount; i++)
            {
                for (int j = 0; j < layoutPanel.ColumnCount; j++)
                {

                    GridTile fireButton = new GridTile(i, j);

                    fireButton.Click += (s, ea) =>
                    {
                        if (s != null)
                        {
                            GridTile gridButton = (GridTile)s;
                            OnFireClick(gridButton);
                            //MessageBox.Show($"row: {gridButton.RowCoord}, col: {gridButton.ColCoord}");
                        }
                    };
                    layoutPanel.Controls.Add(fireButton);
                }
            }
            Controls.Add(layoutPanel);
        }
    }


    public class FireEventArgs
    {
        public GridTile MissileButton { get; set; }
    }
}

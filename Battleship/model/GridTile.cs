using System.Drawing;
using System.Windows.Forms;

namespace Battleship.model
{
    public class GridTile : Button
    {
        public int RowCoord { get; set; }
        public int ColCoord { get; set; }

        private Color sea = Color.FromArgb(190, 65, 102, 245);


        public GridTile(int RowCoord, int ColCoord)
        {
            this.RowCoord = RowCoord;
            this.ColCoord = ColCoord;
            this.Dock = DockStyle.Fill;
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = sea;
        }
    }
}

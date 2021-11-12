using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.model
{
    public class GridTile:Button
    {
        public int RowCoord { get; set; }
        public int ColCoord { get; set; }


        public GridTile(int RowCoord, int ColCoord)
        {
            this.RowCoord = RowCoord;
            this.ColCoord = ColCoord;
            this.Dock = DockStyle.Fill;
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.FromArgb(65, 102, 245);
        }
    }
}

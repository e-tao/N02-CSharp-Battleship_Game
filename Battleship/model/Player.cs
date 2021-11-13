using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.model
{
    public class Player
    {
        private static Dictionary<string, List<ShipTile>> AllShips = new();

        public static int playerStepCounter { get; set; } = 0;

        public string name { get; set; } = "Player";

        public Dictionary<string, List<ShipTile>> GameStart()
        {
            if(AllShips.Count < GameVariables.numberOfShips)
            {
                MessageBox.Show("Out numbered by your opponent.", "SHIP NUMBER IS NOT ENOUGH!", MessageBoxButtons.OK);
                return null;
            }
            else
            {
                return AllShips;
            }
        }

        public static void AddShip(List<ShipTile> tempList)
        {
            List<ShipTile> currentShip = new();
            foreach(ShipTile st in tempList)
            {
                currentShip.Add(st);
            }
            int ships = AllShips.Count();
            if (ships < GameVariables.numberOfShips)
            {
                AllShips.Add("Ship" + (ships+1), currentShip);
            }
            else
            {
                MessageBox.Show("Exceeds Maximum ships");
            }
            foreach (KeyValuePair<string, List<ShipTile>> pair in AllShips)
            {
                Debug.WriteLine("Key :" + pair.Key);
                foreach (ShipTile st in pair.Value)
                {
                    Debug.WriteLine($"Coordinates:({ st.RowCoord}, { st.ColCoord})");
                }
            }
        }

        public static void ResetShip()
        {
            AllShips.Clear();
        }

    }
}

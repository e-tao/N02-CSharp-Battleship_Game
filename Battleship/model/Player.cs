using System.Collections.Generic;
using System.Linq;
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
            return AllShips;
        }

        public static void AddShip(List<ShipTile> tempList)
        {
            List<ShipTile> currentShip = new();
            foreach (ShipTile st in tempList)
            {
                currentShip.Add(st);
            }
            int ships = AllShips.Count();
            if (ships < GameVariables.NumberOfShips)
            {
                AllShips.Add("Ship" + (ships + 1), currentShip);
            }
            else
            {
                MessageBox.Show("Exceeds Maximum ships");
            }
            /*foreach (KeyValuePair<string, List<ShipTile>> pair in AllShips)
            {
                Debug.WriteLine("Key :" + pair.Key);
                foreach (ShipTile st in pair.Value)
                {
                    Debug.WriteLine($"Coordinates:({ st.RowCoord}, { st.ColCoord})");
                }
            }*/
        }
    }
}

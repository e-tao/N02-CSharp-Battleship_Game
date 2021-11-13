using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Battleship.model
{
    class Ai
    {
        Dictionary<string, List<ShipTile>> AllShips = new();

        public static int aiStepCounter { get; set; } = 0;

        private static Random rand = new();
        private static int randStartRow;
        private static int randStartCol;

        private static List<int[]> TriedTiles = new();
        private static int[] newLocation;

        public Dictionary<string, List<ShipTile>> GameStart()
        {
            List<ShipTile> currentShip;

            for (int i = 0; i < GameVariables.NumberOfShips(); i++)
            {
                currentShip = Ship.MakeAShip();
                while (AllShips != null && DuplicateTile(currentShip))
                {
                    currentShip = Ship.MakeAShip();
                }
                AllShips.Add("Ship" + (i+1), currentShip);
            }
            return AllShips;
        }

        public bool DuplicateTile(List<ShipTile> currentShip)
        {
            foreach (ShipTile st in currentShip)
            {
                foreach (KeyValuePair<string, List<ShipTile>> pair in AllShips)
                {
                    if (pair.Value.Contains(st))
                    {
                        //Debug.WriteLine("Duplicate Tile Found, Regenerate");
                        return true;
                    }
                }
            }
            return false;
        }

        public static void AiFireBack(GameGrid GrdPlayer, Dictionary<string, List<ShipTile>> AllPlayerShips)
        {


            while (RepeatedLocation())
            {
                RepeatedLocation();
            }

            TriedTiles.Add(newLocation);
            

            GridTile aShipTile = GrdPlayer.Tiles[randStartCol, randStartRow];
            ShipTile firedAt = new()
            {
                RowCoord = randStartRow,
                ColCoord = randStartCol
            };


            foreach (KeyValuePair<string, List<ShipTile>> pair in AllPlayerShips)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    if (pair.Value.Contains(firedAt) && aShipTile.BackColor == Color.Black)
                    {
                        pair.Value.Remove(firedAt);
                        aShipTile.BackColor = Color.Red;
                        //Debug.WriteLine($"Hit @ ({randStartRow}, {randStartCol})");
                    }
                    else if (aShipTile.BackColor == Color.FromArgb(65, 102, 245))
                    {
                        aShipTile.BackColor = Color.White;
                    }
                }
            }
        }

        private static bool RepeatedLocation()
        {
            randStartRow = rand.Next(0, GameVariables.Boundry());
            randStartCol = rand.Next(0, GameVariables.Boundry());
            newLocation = new int[] { randStartRow, randStartCol };
            return (TriedTiles.Any(p => p.SequenceEqual(newLocation)));

        }
    }
}

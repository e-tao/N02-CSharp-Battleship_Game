using System;
using System.Collections.Generic;
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

        private static bool hitAround = false;
        private static bool missed = true;
        private static bool repeated = false;

        private static ShipTile lastHitted;

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
                AllShips.Add("Ship" + (i + 1), currentShip);
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
            newLocation = NewLocation();

            repeated = TriedTiles.Any(p => p.SequenceEqual(newLocation)) ? true : false;

            switch (missed)
            {
                case true:
                    while (repeated)
                    {
                        newLocation = NewLocation();
                    }
                    break;

                case false:
                    newLocation = TryHitAround(lastHitted);
                    break;
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
                        lastHitted = pair.Value[0];
                        pair.Value.Remove(firedAt);
                        aShipTile.BackColor = Color.Red;

                        missed = false;
                        hitAround = true;

                        //Debug.WriteLine($"Hit @ ({randStartRow}, {randStartCol})");
                    }
                    else if (aShipTile.BackColor == Color.FromArgb(65, 102, 245))
                    {
                        aShipTile.BackColor = Color.White;
                    }
                }
            }
        }

        private static int[] NewLocation()
        {
            randStartRow = rand.Next(0, GameVariables.Boundry());
            randStartCol = rand.Next(0, GameVariables.Boundry());
            newLocation = new int[] { randStartRow, randStartCol };
            repeated = false;

            return newLocation;


        }


        private static int[] TryHitAround(ShipTile HitedTile)
        {
            newLocation = HitUp(HitedTile.RowCoord, HitedTile.ColCoord);

            if (TriedTiles.Any(p => p.SequenceEqual(newLocation)))
            {
                newLocation = HitDown(HitedTile.RowCoord, HitedTile.ColCoord);
            }

            if (TriedTiles.Any(p => p.SequenceEqual(newLocation)))
            {
                newLocation = HitLeft(HitedTile.RowCoord, HitedTile.ColCoord);
            }

            if (TriedTiles.Any(p => p.SequenceEqual(newLocation)))
            {
                newLocation = HitRight(HitedTile.RowCoord, HitedTile.ColCoord);
            }

            if (TriedTiles.Any(p => p.SequenceEqual(newLocation)))
            {
                newLocation = new int[] { randStartRow, randStartCol };
                hitAround = false;
                missed = true;
            }

            randStartRow = newLocation[0];
            randStartCol = newLocation[1];
            return newLocation;

            /*            newLocation = !TriedTiles.Any(p => p.SequenceEqual(HitUp(HitedTile.RowCoord, HitedTile.ColCoord))) ? HitDown(HitedTile.RowCoord, HitedTile.ColCoord) :
                                        !TriedTiles.Any(p => p.SequenceEqual(HitDown(HitedTile.RowCoord, HitedTile.ColCoord))) ? HitLeft(HitedTile.RowCoord, HitedTile.ColCoord) :
                                           !TriedTiles.Any(p => p.SequenceEqual(HitLeft(HitedTile.RowCoord, HitedTile.ColCoord))) ? HitRight(HitedTile.RowCoord, HitedTile.ColCoord) :
                                                 new int[] { randStartRow, randStartCol };*/


        }

        private static int[] HitUp(int r, int c)
        {
            r = (r - 1) >= 0 ? r - 1 : 0;
            newLocation = new int[] { r, c };
            return newLocation;
        }

        private static int[] HitDown(int r, int c)
        {
            r = (r + 1) <= GameVariables.Boundry() ? r + 1 : GameVariables.Boundry();
            newLocation = new int[] { r, c };
            return newLocation;
        }

        private static int[] HitLeft(int r, int c)
        {
            c = (c - 1) >= 0 ? c - 1 : 0;
            newLocation = new int[] { r, c };
            return newLocation;
        }

        private static int[] HitRight(int r, int c)
        {
            c = (c + 1) <= GameVariables.Boundry() ? c + 1 : GameVariables.Boundry();
            newLocation = new int[] { r, c };
            return newLocation;
        }


    }
}

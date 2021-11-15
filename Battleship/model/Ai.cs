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
        private static List<int[]> AroundHittedTile;

        public static int aiStepCounter { get; set; } = 0;

        private static Random rand = new();
        private static int randStartRow;
        private static int randStartCol;

        private static List<int[]> TriedTiles = new();
        private static int[] newLocation;

        private static bool hitAround = false;
        private static bool missed = true;

        private static int[] firstHitted = null;  //make it readonly unless reset
        public static int[] FirstHitted
        {
            get { return firstHitted; }
            set { if (firstHitted == null) { firstHitted = value; } }
        }


        public Dictionary<string, List<ShipTile>> GameStart()
        {
            List<ShipTile> currentShip;

            for (int i = 0; i < GameVariables.NumberOfShips; i++)
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
            if (missed)
            {
                newLocation = RandomFire();
                while (TriedTiles.Any(p => p.SequenceEqual(newLocation)))
                {
                    newLocation = RandomFire();
                }
            }
            else
            {
                newLocation = TryHitAround();
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
                        FirstHitted = new int[] { firedAt.RowCoord, firedAt.ColCoord };
                        foreach (var ft in firstHitted)
                        {
                            Debug.WriteLine(ft);
                        }

                        pair.Value.Remove(firedAt);
                        aShipTile.BackColor = Color.Red;
                        missed = false;
                        hitAround = true;
                        LocalAroudHitedTile(firedAt);
                        //Debug.WriteLine($"Hit @ ({randStartRow}, {randStartCol})");
                    }
                    else if (aShipTile.BackColor == Color.FromArgb(65, 102, 245))
                    {
                        aShipTile.BackColor = Color.White;
                    }
                }
            }
        }

        private static int[] RandomFire()
        {                                                                     // Ai guess in either [even, even] or [odd, odd] coordinates pair
            randStartRow = rand.Next(0, GameVariables.Boundry);
            randStartCol = rand.Next(0, GameVariables.Boundry);

            if (randStartRow % 2 == 0)
            {
                while (randStartCol % 2 != 0)
                {
                    randStartCol = rand.Next(0, GameVariables.Boundry);
                }

            }
            else if (randStartRow % 2 != 0)
            {
                while (randStartCol % 2 == 0)
                {
                    randStartCol = rand.Next(0, GameVariables.Boundry);
                }
            }

            newLocation = new int[] { randStartRow, randStartCol };
            return newLocation;
        }

        private static void LocalAroudHitedTile(ShipTile HittedTile)
        {
            AroundHittedTile = new();
            AroundHittedTile.Add(HitUp(HittedTile.RowCoord, HittedTile.ColCoord));
            AroundHittedTile.Add(HitDown(HittedTile.RowCoord, HittedTile.ColCoord));
            AroundHittedTile.Add(HitLeft(HittedTile.RowCoord, HittedTile.ColCoord));
            AroundHittedTile.Add(HitRight(HittedTile.RowCoord, HittedTile.ColCoord));

            for (int i = 0; i < AroundHittedTile.Count; i++)
            {
                if (TriedTiles.Any(p => p.SequenceEqual(AroundHittedTile[i])))
                {
                    AroundHittedTile.RemoveAt(i);
                }
            }
            Shuffle(AroundHittedTile);
        }


        private static void NoRepeatHit()
        {
            newLocation = AroundHittedTile[0];
            while (TriedTiles.Any(p => p.SequenceEqual(newLocation)))  // the while loop is for cornor or edge situation that the hitted tile will be added in the list.
            {
                AroundHittedTile.Remove(newLocation);
                if (AroundHittedTile.Count != 0)
                {
                    newLocation = AroundHittedTile[0];
                }
                else { break; }   //break out of the a endless loop while the last tile in the list is the red hitted tile.
            }

        }



        private static int[] TryHitAround()
        {
            if (!Form1.ShipSunk)
            {
                if (AroundHittedTile.Count > 0)
                {
                    NoRepeatHit();
                }
                else
                {                                                    //find the first hitted tile on the ship and work on the other direction
                    ShipTile firstHittedTile = new()
                    {
                        RowCoord = firstHitted[0],
                        ColCoord = firstHitted[1]
                    };
                    LocalAroudHitedTile(firstHittedTile);
                    if (AroundHittedTile.Count > 0)
                    {
                        NoRepeatHit();
                    }

                }
            }
            else if (Form1.ShipSunk)
            {
                hitAround = false;
                missed = true;
                firstHitted = null;                                   //reset the first hitted location to null for next ship
                AroundHittedTile.Clear();
                Form1.ShipSunk = false;
                newLocation = RandomFire();
                while (TriedTiles.Any(p => p.SequenceEqual(newLocation)))
                {
                    newLocation = RandomFire();
                }
            }

            randStartRow = newLocation[0];
            randStartCol = newLocation[1];
            AroundHittedTile.Remove(newLocation);
            return newLocation;
        }

        private static int[] HitUp(int r, int c)
        {
            r = (r - 1) >= 0 ? r - 1 : 0;
            newLocation = new int[] { r, c };
            return newLocation;
        }

        private static int[] HitDown(int r, int c)
        {
            r = (r + 1) < GameVariables.Boundry ? r + 1 : (GameVariables.Boundry - 1);
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
            c = (c + 1) < GameVariables.Boundry ? c + 1 : (GameVariables.Boundry - 1);
            newLocation = new int[] { r, c };
            return newLocation;
        }

        private static void Shuffle(List<int[]> hitOrders)
        {
            // Knuth shuffle algorithm :: courtesy of Wikipedia :) found online;
            for (int t = 0; t < hitOrders.Count; t++)
            {
                int[] tmp = hitOrders[t];
                int r = rand.Next(t, hitOrders.Count);
                hitOrders[t] = hitOrders[r];
                hitOrders[r] = tmp;
            }
        }
    }
}

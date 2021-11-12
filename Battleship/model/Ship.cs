using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Battleship.model
{
    public struct ShipTile
    {
        public int RowCoord;
        public int ColCoord;
    }


    public class Ship
    {
        private static int ShipLength;
        private static int randStartRow;
        private static int randStartCol;
        private static Random rand = new();

        public static List<ShipTile> MakeAShip()
        {
            string[] direction = { "up", "down", "left", "right" };
            string whichDirection = direction[rand.Next(0, 4)];

            int rDirection = 0;                     // row ^ up, rDirection --,         row v down rDirection ++
            int cDirection = 0;                     // column -> right, cDirection++,   left <- column cDirection --

            List<ShipTile> aShip = new();

            RandomStart();

            switch (whichDirection)
            {
                case "up":
                    while (OutOfBoundry(randStartRow - ShipLength))
                    {
                        Debug.WriteLine("Opps, Out of Boundry, Regenerate");
                        RandomStart();
                    }
                    for (int i = 0; i < ShipLength; i++)
                    {
                        aShip.Add(new ShipTile
                        {
                            RowCoord = randStartRow + rDirection,
                            ColCoord = randStartCol,
                        }); 
                        rDirection--;
                    }
                    Output(whichDirection);
                    return aShip;

                case "down":
                    while (OutOfBoundry(randStartRow + ShipLength))
                    {
                        Debug.WriteLine("Opps, Out of Boundry, Regenerate");
                        RandomStart();
                    }
                    for (int i = 0; i < ShipLength; i++)
                    {
                        aShip.Add(new ShipTile
                        {
                            RowCoord = randStartRow + rDirection,
                            ColCoord = randStartCol,

                        });
                        rDirection++;
                    }
                    Output(whichDirection);
                    return aShip;

                case "left":
                    while (OutOfBoundry(randStartCol - ShipLength))
                    {
                        Debug.WriteLine("Opps, Out of Boundry, Regenerate");
                        RandomStart();
                    }
                    for (int i = 0; i < ShipLength; i++)
                    {
                        aShip.Add(new ShipTile
                        {
                            RowCoord = randStartRow,
                            ColCoord = randStartCol + cDirection,

                        }); 
                        cDirection--;
                    }
                    Output(whichDirection);
                    return aShip;

                case "right":
                    while(OutOfBoundry(randStartCol + ShipLength))
                    {
                        Debug.WriteLine("Opps, Out of Boundry, Regenerate");
                        RandomStart();
                    }
                    for (int i = 0; i < ShipLength; i++)
                    {
                        aShip.Add(new ShipTile
                        {
                            RowCoord = randStartRow,
                            ColCoord = randStartCol + cDirection,
                          
                        });
                        cDirection++;
                    }
                    Output(whichDirection);
                    return aShip;
                default: return null;
            }
        }

        private static void RandomStart()
        {
            ShipLength = rand.Next(GameVariables.shipMinLength, GameVariables.shipMaxLength+1);
            randStartRow = rand.Next(0, GameVariables.boundry); 
            randStartCol = rand.Next(0, GameVariables.boundry); 
        }

        private static bool OutOfBoundry(int limit)
        {
            return (limit < 0 || limit >= GameVariables.boundry);
        }

        public static bool ShipLengthCheck(List<ShipTile> tempShip)
        {
            if(tempShip.Count < GameVariables.shipMinLength || tempShip.Count > GameVariables.shipMaxLength)
            {
                MessageBox.Show("Min 2 tiles, Max 4 tiles", "INVALID SHIP SIZE", MessageBoxButtons.OK);
                return true;
            }
            return false;
        }


        private static void Output(string whichDirection)
        {
            Debug.WriteLine($"The ship is generated to the {whichDirection}, has a length of {ShipLength}, with the Start Row of {randStartRow} and Start Col of {randStartCol}");
        }
    }
}

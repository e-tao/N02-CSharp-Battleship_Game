using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            string[] direction = { "up", "down", "left", "right" };                 //only two directions are really needed, but for the sake of the completeness, 4 are used.
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
                        //Debug.WriteLine("Opps, Out of Boundry, Regenerate");
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
                    //Output(whichDirection);
                    return aShip;

                case "down":
                    while (OutOfBoundry(randStartRow + ShipLength))
                    {
                        //Debug.WriteLine("Opps, Out of Boundry, Regenerate");
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
                    //Output(whichDirection);
                    return aShip;

                case "left":
                    while (OutOfBoundry(randStartCol - ShipLength))
                    {
                        //Debug.WriteLine("Opps, Out of Boundry, Regenerate");
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
                    //Output(whichDirection);
                    return aShip;

                case "right":
                    while(OutOfBoundry(randStartCol + ShipLength))
                    {
                        //Debug.WriteLine("Opps, Out of Boundry, Regenerate");
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
                    //Output(whichDirection);
                    return aShip;
                default: return null;
            }
        }

        private static void RandomStart()
        {
            ShipLength = rand.Next(GameVariables.shipMinLength, GameVariables.shipMaxLength+1);
            randStartRow = rand.Next(0, GameVariables.Boundry()); 
            randStartCol = rand.Next(0, GameVariables.Boundry()); 
        }

        private static bool OutOfBoundry(int limit)
        {
            return (limit < 0 || limit >= GameVariables.Boundry());
        }

        public static bool ShipLengthCheck(List<ShipTile> tempShip)
        {
            return tempShip.Count >= GameVariables.shipMinLength & tempShip.Count <= GameVariables.shipMaxLength;
        }

        public static bool OddShipShapeCheck(List<ShipTile> tempShip)
        {
            List<int> row = new();
            List<int> col = new();
            
            foreach(ShipTile st in tempShip)
            {
                row.Add(st.RowCoord);
                col.Add(st.ColCoord);
            }

            if(row[0] == row[1])
            {
                return col.Zip(col.Skip(1), (a, b) => a + 1 == b).All(x => x) || col.Zip(col.Skip(1), (a, b) => a - 1 == b).All(x => x);
            } else if(col[0] == col[1])
            {
                return row.Zip(row.Skip(1), (a, b) => a + 1 == b).All(x => x) || row.Zip(row.Skip(1), (a, b) => a - 1 == b).All(x => x);
            }
            else
            {
                return false;
            }
        }




/*        private static void Output(string whichDirection)
        {
            Debug.WriteLine($"The ship is generated to the {whichDirection}, has a length of {ShipLength}, with the Start Row of {randStartRow} and Start Col of {randStartCol}");
        }*/
    }
}

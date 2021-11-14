using Battleship.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Battleship
{
    public partial class Form1 : Form
    {
        private Ai ai;
        private Player player;

        Dictionary<string, List<ShipTile>> AllAiShips, AllPlayerShips;
        private int aiShipSunk, userShipSunk;

        public static bool ShipSunk { get; set; } = false;


        List<ShipTile> tempShip = new();

        private int shipAdded = 0;

        public Form1()
        {

            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            ai = new();
            player = new();
            aiShipSunk = 0;
            userShipSunk = 0;
            AllAiShips = ai.GameStart();
            AllPlayerShips = player.GameStart();
            EnableLeftGrid();



            /*           
                       foreach (KeyValuePair<string, List<ShipTile>> pair in AllAiShips)
                       {
                           Debug.WriteLine("Key :" + pair.Key);

                           foreach (ShipTile st in pair.Value)
                           {
                               Debug.WriteLine($"Coordinates:({ st.RowCoord}, { st.ColCoord})");
                           }
                       }*/

        }

        private void GrdFire_FireClick(FireEventArgs fireEventArgs)
        {
            Player.playerStepCounter++;
            LblStepsPlayer.Text = Player.playerStepCounter.ToString();
            HitCheck(fireEventArgs);

            Ai.AiFireBack(GrdPlayer, AllPlayerShips);
            Ai.aiStepCounter++;
            LblStepsAi.Text = Ai.aiStepCounter.ToString();

            SunkCheck();
            WinnerCheck();
        }

        private void HitCheck(FireEventArgs fireEventArgs)
        {
            int r = fireEventArgs.MissileButton.RowCoord;
            int c = fireEventArgs.MissileButton.ColCoord;
            GridTile aMissile = GrdFire.Tiles[c, r];

            ShipTile firedAt = new()
            {
                RowCoord = r,
                ColCoord = c
            };


            foreach (KeyValuePair<string, List<ShipTile>> pair in AllAiShips)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    if (pair.Value.Contains(firedAt))
                    {
                        pair.Value.Remove(firedAt);
                        aMissile.BackColor = Color.Red;
                    }
                    aMissile.BackColor = aMissile.BackColor == Color.Red ? aMissile.BackColor = Color.Red : aMissile.BackColor = Color.White;
                }
            }
        }

        private void SunkCheck()
        {
            foreach (KeyValuePair<string, List<ShipTile>> pair in AllAiShips)
            {
                if (!pair.Value.Any())
                {
                    AllAiShips.Remove(pair.Key);
                    aiShipSunk++;
                    LblAiShipLeft.Text = (GameVariables.NumberOfShips - aiShipSunk).ToString();
                    LblShipSunk.Text = "Ai " + pair.Key + " sunk.";
                }
            }

            foreach (KeyValuePair<string, List<ShipTile>> pair in AllPlayerShips)
            {
                if (!pair.Value.Any())
                {
                    AllPlayerShips.Remove(pair.Key);
                    userShipSunk++;
                    LblPlayerShipLeft.Text = (GameVariables.NumberOfShips - userShipSunk).ToString();
                    LblShipSunk.Text = "Player " + pair.Key + " sunk.";
                    ShipSunk = true;
                }
            }
        }

        private void WinnerCheck()
        {

            if (aiShipSunk == GameVariables.NumberOfShips)
            {
                LblResultPlayer.Text = "Winner";
                DisableLeftGrid();
            }
            else if (userShipSunk == GameVariables.NumberOfShips)
            {
                LblResultAi.Text = "Winner";
                DisableLeftGrid();
            }
            else
            {
                LblResultPlayer.Text = "";
                LblResultAi.Text = "";
            }

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Ship.ShipLengthCheck(tempShip) && Ship.OddShipShapeCheck(tempShip))
            {
                Player.AddShip(tempShip);
                shipAdded++;
                LblPlayerShipLeft.Text = shipAdded.ToString();
                tempShip.Clear();
            }
            else
            {
                MessageBox.Show($"Ship length between {GameVariables.shipMinLength} and {GameVariables.shipMaxLength}. \r\nIt's not Tetris, the ship need to be placed straight.", "ERROR", MessageBoxButtons.OK);
                BtnCancel_Click(sender, e);

            }
            if (shipAdded == GameVariables.NumberOfShips)
            {
                DisableRightGrid();
            }
            BtnStart.Enabled = shipAdded == GameVariables.NumberOfShips ? true : false;

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LblStepsPlayer.Text = "0";
            LblStepsAi.Text = "0";
            LblAiShipLeft.Text = GameVariables.NumberOfShips.ToString();
            BtnStart.Enabled = false;
            DisableLeftGrid();
        }


        private void GrdPlayer_GridClick(FireEventArgs fireEventArgs)
        {
            int r = fireEventArgs.MissileButton.RowCoord;
            int c = fireEventArgs.MissileButton.ColCoord;
            GridTile aShipTile = GrdPlayer.Tiles[c, r];
            aShipTile.BackColor = aShipTile.BackColor == Color.FromArgb(65, 102, 245) ? aShipTile.BackColor = Color.Black : aShipTile.BackColor = Color.FromArgb(65, 102, 245);

            ShipTile aTileAt = new()
            {
                RowCoord = r,
                ColCoord = c
            };
            tempShip.Add(aTileAt);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            int r, c;
            GridTile aShipTile;
            foreach (ShipTile st in tempShip)
            {
                r = st.RowCoord;
                c = st.ColCoord;
                aShipTile = GrdPlayer.Tiles[c, r];
                aShipTile.BackColor = Color.FromArgb(65, 102, 245);
            }
            tempShip.Clear();
        }

        private void DisableRightGrid()
        {
            this.GrdPlayer.GridClick -= new Battleship.model.GameGrid.GridPosition(this.GrdPlayer_GridClick);
            BtnAdd.Enabled = false;
            BtnCancel.Enabled = false;
        }
        private void EnableRightGrid()
        {
            this.GrdPlayer.GridClick += new Battleship.model.GameGrid.GridPosition(this.GrdPlayer_GridClick);
            BtnAdd.Enabled = true;
            BtnCancel.Enabled = true;
        }

        private void DisableLeftGrid()
        {
            this.GrdFire.GridClick -= new Battleship.model.GameGrid.GridPosition(this.GrdFire_FireClick);
            BtnStart.Enabled = false;
        }

        private void EnableLeftGrid()
        {
            this.GrdFire.GridClick += new Battleship.model.GameGrid.GridPosition(this.GrdFire_FireClick);
            BtnStart.Enabled = true;
        }
    }

    public class GameVariables
    {
        public static int shipMinLength = 2;
        public static int shipMaxLength = 4;



        public static int NumberOfShips
        {
            get { return ships = ships < 3 ? 3 : ships; }

        }

        public static int Boundry
        {
            get { return boundry = boundry < 6 ? 6 : boundry; }

        }

        private static int boundry = int.Parse(ConfigFromFile()[1]);
        private static int ships = int.Parse(ConfigFromFile()[0]);


        private static string[] ConfigFromFile()
        {
            string configFile = "config.txt";

            if (File.Exists(configFile))
            {
                using StreamReader file = new StreamReader(configFile);
                String sConfig = file.ReadToEnd();
                string[] configs = sConfig.Split(',');
                return configs;
            }
            else
            {
                string[] configs = new string[] { "3", "8" };
                return configs;
            }


        }
    }


}

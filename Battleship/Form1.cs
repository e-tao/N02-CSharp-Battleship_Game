using Battleship.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Battleship
{
    public partial class Form1 : Form
    {
        private Ai ai;
        private Player player;
    
        Dictionary<string, List<ShipTile>> AllAiShips, AllPlayerShips;
        private int aiShipSunk, userShipSunk;

        List<ShipTile> tempShip;

        public Form1()
        {
            tempShip = new();
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

            if (AllAiShips == null || AllPlayerShips == null)
            {
                Application.Restart();
            }


            foreach (KeyValuePair<string, List<ShipTile>> pair in AllAiShips)
            {
                Debug.WriteLine("Key :" + pair.Key);

                foreach (ShipTile st in pair.Value)
                {
                    Debug.WriteLine($"Coordinates:({ st.RowCoord}, { st.ColCoord})");
                }
            }
            //Debug.Write($"there are {numOfShipsAi} ships");

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
                    LblAiShipLeft.Text = (GameVariables.numberOfShips - aiShipSunk).ToString();
                    LblShipSunk.Text = "Ai " + pair.Key + " is sunk.";
                    
                    //Debug.WriteLine(pair.Key + " is sunk" + aiShipSunk + " sunk");
                }
            }

            foreach (KeyValuePair<string, List<ShipTile>> pair in AllPlayerShips)
            {
                if (!pair.Value.Any())
                {
                    AllPlayerShips.Remove(pair.Key);
                    userShipSunk++;
                    LblPlayerShipLeft.Text = (GameVariables.numberOfShips - userShipSunk).ToString();
                    LblShipSunk.Text = "Player " + pair.Key + " is sunk.";
                    //Debug.WriteLine(pair.Key + " is sunk");

                }
            }
        }

        private void WinnerCheck()
        {

            if (aiShipSunk == GameVariables.numberOfShips)
            {
                LblResultPlayer.Text = "Winner";
            }
            else if (userShipSunk == GameVariables.numberOfShips)
            {
                LblResultAi.Text = "Winner";
            }
            else
            {
                LblResultPlayer.Text="";
                LblResultAi.Text = "";
            }

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!Ship.ShipLengthCheck(tempShip))
            {
                Player.AddShip(tempShip);
                tempShip.Clear();
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            GrdPlayer.InitGrid();
            Player.ResetShip();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LblStepsPlayer.Text = "0";
            LblStepsAi.Text = "0";
            LblAiShipLeft.Text = GameVariables.numberOfShips.ToString();
            LblPlayerShipLeft.Text = GameVariables.numberOfShips.ToString();
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
    }

    public class GameVariables
    {
        private static string configFile = "config.txt";
        public static int numberOfShips = File.Exists(configFile) ? int.Parse(ConfigFromFile()[0]) : 4;
        public static int boundry = File.Exists(configFile) ? int.Parse(ConfigFromFile()[1]) : 10;
        public static int shipMinLength = 2;
        public static int shipMaxLength = 4;

        private static string[] ConfigFromFile()
        {
                StreamReader file = new StreamReader("config.txt");
                String sConfig = file.ReadToEnd();
                file.Close();
                string[] configs = sConfig.Split(',');
                return configs;
        }
    }
}

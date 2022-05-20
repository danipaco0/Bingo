using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo
{
    [Serializable]
    public partial class GamePage : Form
    {
        Client remoteServer;
        string serverIp;
        int serverPort;

        
        PlayItemInfo numberInfo = new PlayItemInfo();
        List <PlayItem> playerGrid = new List<PlayItem> ();  //liste des 25 nombres du joueur
        List <PlayItem> gameGrid = new List<PlayItem>();     //liste des nombres affichés 1 par 1
        List <PlayItem> bingoGrid = new List<PlayItem> ();   //liste qui contient les nombres bingo du joueur
        int positionX = 0;
        int positionY = 0;  
        int[] b = { 0, 5, 10, 15, 20 };      //index première colonne
        int[] i = { 1, 6, 11, 16, 21 };      //index 2eme colonne
        int[] n = { 2, 7, 12, 17, 22 };      //index 3eme colonne
        int[] g = { 3, 8, 13, 18, 23 };      //index 4eme colonne
        int[] o = { 4, 9, 14, 19, 24 };      //index 5eme colonne
        
        public GamePage()
        {
            InitializeComponent();
        }

        public GamePage(string ip, int port, String username) : this()
        {
            remoteServer = new Client();

            remoteServer.DataReceived += RemoteServer_DataReceived;
            remoteServer.ConnectionRefused += RemoteServer_ConnectionRefused;
            remoteServer.username = username;
            serverIp = ip;
            serverPort = port;
        }

        private void RemoteServer_ConnectionRefused(Client client, string message)
        {
            /* Cette fonction sera exécutée si on essaie de se connecter au serveur alors qu'il est éteint.
             * Dans ce cas on affiche le message dans un MessageBox et on ferme la fenêtre.
             * L'objet MessageBox permet d'avoir une fenêtre de dialogue standard utilisées dans toutes
             * les applications windows pour informer l'utilisateur de l'application. On évite ainsi de devoir
             * créer une nouvelle WindowForm pour ce type de tâches très courantes.
             */

            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();
        }

        private void RemoteServer_DataReceived(Client client, object data)
        {
            /* Lorsequ' on recoit des données du serveur, ces données contiennent les informations d'une forme (MovingShapeInfo).
             * On crée une nouvelle forme à partir de ses informations, et on veille à ce que sa position en X soit à 0 (à gauche).
             */
            String message = (String)data;
            if(int.TryParse(message, out int nbr))
            {
                if (positionX % 15 == 0 && positionX != 0)
                {
                    positionY++;
                    positionX = 0;
                }
                PlayItemInfo nbrInfo = new PlayItemInfo();
                nbrInfo.Value = nbr;
                PlayItem number = new PlayItem(nbrInfo);
                number.AutoSize = true;
                number.Location = new Point(20 + positionX * 30, 20 + positionY * 30);
                positionX++;

                gameGrid.Add(number);

                GamePanel.Controls.Add(number);
            }
            else
            {
                MessageBox.Show(message + " a trouvé le bingo avant vous!", "Perdu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Apparition de la page de jeu
        private void GamePage_Load(object sender, EventArgs e)
        {
            remoteServer.Connect(serverIp, serverPort); 

            BingoButton.Visible = false;

            List<int> existingItem = new List<int>();
            int startBound = 0;
            int endBound = 0;
            int val = 0;
            for(int j = 0; j < 25; j++)
            {
                if (Array.Exists(b, z => z == j))
                {
                    startBound = 1;
                    endBound = 15;
                }
                else if (Array.Exists(i, z => z == j))
                {
                    startBound = 16;
                    endBound = 30;
                }
                else if (Array.Exists(n, z => z == j))
                {
                    startBound = 31;
                    endBound = 45;
                }
                else if (Array.Exists(g, z => z == j))
                {
                    startBound = 46;
                    endBound = 60;
                }
                else if (Array.Exists(o, z => z == j))
                {
                    startBound = 61;
                    endBound = 75;
                }

                do
                {
                    val = randomNbr(startBound, endBound);
                } while(existingItem.Contains(val));

                existingItem.Add(val);

                numberInfo.Value = val;
                PlayItem playerNbr = new PlayItem(numberInfo);
               
                playerNbr.AutoSize = true;
                playerNbr.Click += PlayItem_Click;

                int x = j % 5;
                int y = j / 5;
                playerNbr.Location = new Point(20 + x * 30, 20 + y * 30);
                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new Point(x, y);
                pictureBox.Image = Properties.Resources.SeekPng_com_green_ball_png_4090967_removebg_preview;

                playerGrid.Add(playerNbr);

                bingoGridPanel.Controls.Add(playerNbr);
            }
        }

        private void GamePage_FormClosing(object sender, FormClosedEventArgs e)
        {
            remoteServer.Disconnect();
        }

        private void PlayItem_Click(object sender, EventArgs e)
        {
            PlayItem item = (PlayItem)sender;
            item.Selected = !item.Selected;
            if(lookForBingo())
            {
                BingoButton.Visible = true;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Visible = false;
            if(remoteServer != null)
            {
                if (remoteServer.ClientSocket.Connected)
                {
                    remoteServer.Send("start");
                }
            }
        }

        private void BingoButton_Click_1(object sender, EventArgs e)
        {
           // timer.Stop();
            List<bool> cheat = new List<bool>();
            //timer.newNumber -= TimerEvent_onNewNumber;
            foreach(PlayItem x in bingoGrid)
            {
                if (gameGrid.Any(p => p.Value == x.Value))
                    cheat.Add(false);
                else
                    cheat.Add(true);
            }
            
            if (!cheat.Contains(true))
            {
                if (remoteServer != null)
                {
                    if (remoteServer.ClientSocket.Connected)
                    {
                        remoteServer.Send("bingo");
                    }
                }
                MessageBox.Show("Bingo!", "Gagné!", MessageBoxButtons.OK);
                Application.Restart();
            }
            else
            {
                MessageBox.Show("Tricheur!", "Perdu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        //méthode qui génère un nombre random
        public int randomNbr(int start, int end)
        {
            int random;
            Random r = new Random();
            random = r.Next(start, end + 1);
            return random;
        }

        //méthode de recherche du bingo
        public bool lookForBingo()
        {
            bool bingo = false;

            for (int j = 0; j < 5; j++)
            {
                //recherche bingo vertical et horizontal
                if (playerGrid.ElementAt(j).Selected && playerGrid.ElementAt(j + 5).Selected && playerGrid.ElementAt(j + 10).Selected
                    && playerGrid.ElementAt(j + 15).Selected && playerGrid.ElementAt(j + 20).Selected)
                {
                    bingo = true;
                    bingoGrid.Add(playerGrid.ElementAt(j));
                    bingoGrid.Add(playerGrid.ElementAt(j+5));
                    bingoGrid.Add(playerGrid.ElementAt(j+10));
                    bingoGrid.Add(playerGrid.ElementAt(j+15));
                    bingoGrid.Add(playerGrid.ElementAt(j+20));
                }
                else if (playerGrid.ElementAt(j * 5).Selected && playerGrid.ElementAt(j * 5 + 1).Selected && playerGrid.ElementAt(j * 5 + 2).Selected
                    && playerGrid.ElementAt(j * 5 + 3).Selected && playerGrid.ElementAt(j * 5 + 4).Selected)
                {
                    bingo = true;
                    bingoGrid.Add(playerGrid.ElementAt(j*5));
                    bingoGrid.Add(playerGrid.ElementAt(j*5 + 1));
                    bingoGrid.Add(playerGrid.ElementAt(j*5 + 2));
                    bingoGrid.Add(playerGrid.ElementAt(j*5 + 3));
                    bingoGrid.Add(playerGrid.ElementAt(j*5 + 4));
                }
            }
            //recherche bingo diagonale
            if (playerGrid.ElementAt(0).Selected || playerGrid.ElementAt(4).Selected)
            {
                if ((playerGrid.ElementAt(0).Selected && playerGrid.ElementAt(6).Selected && playerGrid.ElementAt(12).Selected 
                    && playerGrid.ElementAt(18).Selected && playerGrid.ElementAt(24).Selected))
                {
                    bingo = true;
                    bingoGrid.Add(playerGrid.ElementAt(0));
                    bingoGrid.Add(playerGrid.ElementAt(6));
                    bingoGrid.Add(playerGrid.ElementAt(12));
                    bingoGrid.Add(playerGrid.ElementAt(18));
                    bingoGrid.Add(playerGrid.ElementAt(24));
                }
                else if(playerGrid.ElementAt(4).Selected && playerGrid.ElementAt(8).Selected
                     && playerGrid.ElementAt(12).Selected && playerGrid.ElementAt(16).Selected && playerGrid.ElementAt(20).Selected)
                {
                    bingo = true;
                    bingoGrid.Add(playerGrid.ElementAt(4));
                    bingoGrid.Add(playerGrid.ElementAt(8));
                    bingoGrid.Add(playerGrid.ElementAt(12));
                    bingoGrid.Add(playerGrid.ElementAt(16));
                    bingoGrid.Add(playerGrid.ElementAt(20));
                }
            }
            return bingo;
        }

    }
}

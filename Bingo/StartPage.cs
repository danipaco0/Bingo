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
    public partial class StartPage : Form
    {
        Server server;
        TimerEvent timer = new TimerEvent();
        String username, serverIp = "127.0.0.1";
        int serverPort = 9999;
        List<Client> remoteClients = new List<Client>();
        List<int> allNumbers = new List<int>();
        int playersReady = 0;
        bool gameStarted = false;

        public StartPage()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartPage_FormClosing);
            buttonStartClient.Enabled = false;
            players_ready.Visible = false;
        }

        private void serverStart_Click(object sender, EventArgs e)
        {
            if(serverStart.Text.Equals("Start Server"))
            {
                players_ready.Visible = true;
                players_ready.Text = "Players ready = 0";
                buttonStartClient.Enabled = true;
                server_ready.Text = "Server up";
                server_ready.ForeColor = Color.LimeGreen;
                serverIp = textBoxIPAdress.Text;
                serverPort = Int32.Parse(textBoxPortNumber.Text);
                server = new Server(serverIp, serverPort);
                server.ClientAccepted += Server_ClientAccepted;
                server.Start();
                serverStart.Text = "Stop Server";
                allNumbers = generateAllNumbers();
            }
            else
            {
                players_ready.Visible = false;
                playersReady = 0;
                serverStart.Text = "Start Server";
                server_ready.Text = "Server down";
                server_ready.ForeColor = Color.Red;
                buttonStartClient.Enabled = false;
                foreach (Client client in remoteClients)
                {
                    client.ClientDisconnected -= RemoteClient_ClientDisconnected;
                    client.Disconnect();
                }
                server.Stop();
                if (gameStarted)
                {
                    timer.newNumber -= TimerEvent_onNewNumber;
                    timer.Stop();
                    gameStarted = false;
                }
            }
        }

        private void Server_ClientAccepted(Client client)
        {
            /* Lorse qu'un client se connecte au serveur, on s'abonne au events et on garde une référence dans la liste remoteClients.
             * Ensuite on met à jour le nombre de clients connectés, on l'affiche dans la listBoxConnectedClients (addClientToListBox)
             * et on affiche un message dans la zone de monitoring.
             */
            Client remoteClient = client;
            client.username = nameBox.Text;
            remoteClient.DataReceived += RemoteClient_DataReceived;
            client.ClientDisconnected += RemoteClient_ClientDisconnected;
            remoteClients.Add(client);
            updateClientCount();
            addClientToListBox(client);
        }

        private void addClientToListBox(Client client)
        {
            /* On affiche le nom du joueur connecté dans la listbox
             */
            usernameList.Items.Add(client.username);
        }

        private void removeClientFromListBox(Client client)
        {
            /* La listBoxConnectedClients ne contient pas à proprement parlé les références vers les clients connectés,
             * mais uniquement une liste de string qui représente les clients. Pour supprimer un client de cette liste,
             * il faut trouver l'indice du string correspondant au client à supprimer. On retourve cet indice en cherchant
             * le string qui commence par l'adresse ip et le numéro de port du client à supprimer. 
             */
            int clientToRemoveIndex = usernameList.FindString(client.username);
            usernameList.Items.RemoveAt(clientToRemoveIndex);
        }

        private void RemoteClient_ClientDisconnected(Client client, string message)
        {
            remoteClients.Remove(client);
            removeClientFromListBox(client);
            updateClientCount();
        }

        private void updateClientCount()
        {
            labelConnectedPlayers.Text = "Joueurs connectés : "+remoteClients.Count.ToString();
        }

        private void RemoteClient_DataReceived(Client client, object data)
        {
            /* Lorse que le serveur reçoit de données, celui doit les transmettre au prochain client. L'ordre des clients dans la liste
             * remoteClients correspond à l'ordre par lesquelles doivent passer chaque forme. On pourrait donc tout simplement envoyer
             * les données au client ayant l'indice du client d'ou provient les données (client source) + 1. Ceci pose problème lorse 
             * que le client source est le dernier de la liste. Dans ce cas il faut transmettre les données au premier client de la liste
             * (la forme vient de faire le tour du monde...), sinon une erreur "index out of bounds" est levée.
             * Une manière élégante de calculer cet indice consiste à prendre comme indice le reste de la division entière de l'indice du 
             * client source +1 par le nombre de clients connectés.
             */
            int nextClientIndex = (remoteClients.IndexOf(client) + 1) % remoteClients.Count;
            String ok = (String)data;
            if (ok == "start")
            {
                playersReady++;
                players_ready.Text = "Joueurs prêts : " + playersReady;
                if(playersReady > 0)
                {
                    if(!gameStarted)
                    {
                        timer.Mode = TimerMode.START_GAME;
                        timer.ThresholdReached += TimerEvent_startGame;
                        timer.Start();
                        gameStarted = true;
                    }
                }
            }
            else if(ok == "bingo")
            {
                timer.Stop();
                remoteClients[nextClientIndex].Send(client.username);
            }
        }

        private void StartPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Client client in remoteClients)
            {
                client.ClientDisconnected -= RemoteClient_ClientDisconnected;
                client.Disconnect();
            }
            if(server != null)
                server.Stop();
        }

        private void buttonStartClient_Click(object sender, EventArgs e)
        {
            if((nameBox.Text == "")||(usernameList.Items.Contains(nameBox.Text)))
            {
                nameBox.BackColor = Color.Red;
            }
            else
            {
                GamePage client = new GamePage(serverIp, serverPort, username);
                client.Show();
            }
        }

        public int randomNbrFromList(int start, int end)
        {
            int random;
            Random r = new Random();
            random = r.Next(start, end + 1);
            return random;
        }

        private void TimerEvent_onNewNumber(object sender, EventArgs e)
        {
            int newnbrIndex, newnbr;
            if (allNumbers.Count > 0)
            {
                newnbrIndex = randomNbrFromList(0, allNumbers.Count-1);
                newnbr = allNumbers[newnbrIndex];
                allNumbers.Remove(newnbr);

                foreach (Client client in remoteClients)
                {
                    client.Send(newnbr.ToString());
                }
            }
            else
            {
                timer.Stop();
                timer.newNumber -= TimerEvent_onNewNumber;
            }
        }

        private List<int> generateAllNumbers()
        {
            List<int> numbers = new List<int>();
            for(int i = 1; i<76; i++)
                numbers.Add(i);
            return numbers;
        }

        private void TimerEvent_startGame(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Threshold = 1;
            timer.Mode = TimerMode.BINGO_GAME;
            timer.ThresholdReached -= TimerEvent_startGame;
            timer.newNumber += TimerEvent_onNewNumber;
            timer.Start();
            buttonStartClient.Enabled = false;
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            nameBox.BackColor = Color.White;
        }

       
    }
}

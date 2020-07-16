using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ex05.Logic;

namespace Ex05.UI
{
    class UI
    {
        private FormSettings m_FormSettings;
        private FormGame m_FormGame;
        private GameLogic m_Control;
        private Dictionary<int, Image> m_Collection;
        private uint m_OpenCardsCounter;
        private Point m_firstCardPlace;
        private Point m_SecondCardPlace;
        private ePlayerTurn m_CurrentPlayerTurn;
        private const int k_MaxPairs = 18;

        public UI()
        {
            m_FormSettings = new FormSettings();
            m_FormSettings.ButtonStart.Click += StartButton_Click;
            m_CurrentPlayerTurn = ePlayerTurn.playerOne;
            initializeCollection();
        }

        public void Run()
        {
            m_FormSettings.ShowDialog();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            string fieldName = m_FormSettings.FirstPlayerName;
            if(!String.IsNullOrEmpty(m_FormSettings.FirstPlayerName))
            {
                if (!String.IsNullOrEmpty(m_FormSettings.SecondPlayerName))
                {
                    Player playerOne, playerTwo;

                    if (m_Control != null)
                    {
                        m_Control.UpdatePlayersNames(m_FormSettings.FirstPlayerName, m_FormSettings.SecondPlayerName);
                        updatePlayersLabels();
                    }

                    initializePlayers(out playerOne, out playerTwo);
                    m_Control = new GameLogic(m_FormSettings.Height, m_FormSettings.Width, playerOne, playerTwo);
                    initializeFormGame(m_Control.PlayerOne, m_Control.PlayerTwo);
                    m_FormSettings.Hide();
                    m_FormGame.ShowDialog();
                }
            }
        }

        private void updatePlayersLabels()
        {
            m_FormGame.FirstPlayerScore.Text = string.Format("{0}: {1} Pairs", m_Control.PlayerOne.Name, m_Control.PlayerOne.Score);
            m_FormGame.FirstPlayerScore.Update();
            m_FormGame.SecondPlayerScore.Text = string.Format("{0}: {1} Pairs", m_Control.PlayerTwo.Name, m_Control.PlayerTwo.Score);
            m_FormGame.SecondPlayerScore.Update();
        }

        private void initializeFormGame(Player i_PlayerOne, Player i_PlayerTwo)
        {
            m_FormGame = new FormGame(m_FormSettings.Height, m_FormSettings.Width, i_PlayerOne, i_PlayerTwo);
            for (int i = 0; i < m_FormSettings.Height; i++)
            {
                for (int j = 0; j < m_FormSettings.Width; j++)
                {
                    m_FormGame.GameCards[i, j].Click += buttonCard_Click;
                }
            }
        }

        private void initializePlayers(out Player o_PlayerOne, out Player o_PlayerTwo)
        {
            o_PlayerOne = new Player(m_FormSettings.FirstPlayerName, Color.LightGreen);
            if (m_FormSettings.SecondPlayerName == "-computer-")
            {
                o_PlayerTwo = new Player(m_FormSettings.SecondPlayerName, Color.LightBlue, m_FormSettings.Height,
                    m_FormSettings.Width);
            }
            else
            {
                o_PlayerTwo = new Player(m_FormSettings.SecondPlayerName, Color.LightBlue);
            }
        }

        private void buttonCard_Click(object sender, EventArgs e)
        {
            playerMove(sender as GameCard);
        }

        private void playerMove(GameCard i_ClickedCard)
        {
            m_OpenCardsCounter++;
            int x = i_ClickedCard.X;
            int y = i_ClickedCard.Y;
            showGameCard(x, y);

            if (m_OpenCardsCounter == 1)
            {
                m_firstCardPlace = new Point(x, y);
            }
            else
            {
                m_SecondCardPlace = new Point(x, y);
                m_OpenCardsCounter = 0;
                System.Threading.Thread.Sleep(1000);

                if (!m_Control.Compare(m_firstCardPlace.X, m_firstCardPlace.Y,
                        m_SecondCardPlace.X, m_SecondCardPlace.Y, ref m_CurrentPlayerTurn))
                {
                    hideUnmatchCards(m_firstCardPlace.X, m_firstCardPlace.Y, m_SecondCardPlace.X, m_SecondCardPlace.Y);
                    passTurn();
                }
                else
                {
                    updatePoints();
                }
            }
        }
        private void computerMove()
        {
            System.Threading.Thread.Sleep(1000);
            int firstX, firstY, secondX, secondY;
            m_Control.GetComputerMove(out firstX, out firstY);
            do
            {
                m_Control.GetComputerMove(out secondX, out secondY);
            }
            while (secondX == firstX && secondY == firstY);

            showGameCard(firstX, firstY);
            System.Threading.Thread.Sleep(1000);
            showGameCard(secondX, secondY);
            System.Threading.Thread.Sleep(1000);

            if (!m_Control.Compare(firstX, firstY, secondX, secondY, ref m_CurrentPlayerTurn))
            {
                hideUnmatchCards(firstX, firstY, secondX, secondY);
            }
            else
            {
                updatePoints();
                computerMove();
            }
        }

        private void hideUnmatchCards(int i_FirstX, int i_FirstY, int i_SecondX, int i_SecondY)
        {
            m_FormGame.GameCards[i_FirstX, i_FirstY].BackgroundImage = null;
            m_FormGame.GameCards[i_SecondX, i_SecondY].BackgroundImage = null;
            m_FormGame.GameCards[i_FirstX, i_FirstY].Enabled = true;
            m_FormGame.GameCards[i_SecondX, i_SecondY].Enabled = true;
            updateCurrentPlayerLabel();
        }

        private void showGameCard(int i_X, int i_Y)
        {
            int firstKey = m_Control.Board.Matrix[i_X, i_Y].Key;
            Image data;
            m_Collection.TryGetValue(firstKey, out data);
            m_FormGame.GameCards[i_X, i_Y].Enabled = false;
            m_FormGame.GameCards[i_X, i_Y].BackgroundImage = data;
            m_FormGame.GameCards[i_X, i_Y].Update();
        }

        private void passTurn()
        {
            if(m_CurrentPlayerTurn == ePlayerTurn.playerTwo && m_Control.GameType == eGameType.againstComputer)
            {
                computerMove();
            }
        }

        private void updateCurrentPlayerLabel()
        {
            switch (m_CurrentPlayerTurn)
            {
                case ePlayerTurn.playerOne:
                    m_FormGame.CurrentPlayer.Text = string.Format("Current Player: {0}", m_Control.PlayerOne.Name);
                    m_FormGame.CurrentPlayer.BackColor = m_Control.PlayerOne.myColor;
                    m_FormGame.CurrentPlayer.Update();
                    break;
                case ePlayerTurn.playerTwo:
                    m_FormGame.CurrentPlayer.Text = string.Format("Current Player: {0}", m_Control.PlayerTwo.Name);
                    m_FormGame.CurrentPlayer.BackColor = m_Control.PlayerTwo.myColor;
                    m_FormGame.CurrentPlayer.Update();
                    break;
            }
        }

        private void updatePoints()
        {
            switch(m_CurrentPlayerTurn)
            {
                case ePlayerTurn.playerOne:
                    m_FormGame.FirstPlayerScore.Text = string.Format("{0}: {1} Pairs", m_Control.PlayerOne.Name, m_Control.PlayerOne.Score);
                    m_FormGame.FirstPlayerScore.Update();
                    break;
                case ePlayerTurn.playerTwo:
                    m_FormGame.SecondPlayerScore.Text = string.Format("{0}: {1} Pairs", m_Control.PlayerTwo.Name, m_Control.PlayerTwo.Score);
                    m_FormGame.SecondPlayerScore.Update();
                    break;
            }

            isEndGame();
        }

        private void isEndGame()
        {
            if (m_Control.isEndGame() == true)
            {
                string scoreTitle = "End Game", winnerName; 

                StringBuilder msg = new StringBuilder();

                if (m_Control.AnnounceWinner() == null)
                {
                    winnerName = "It's a tie!";
                }
                else
                {
                   winnerName = "The Winner Is " + m_Control.AnnounceWinner();
                }

                msg.AppendFormat(@"Score Board:

{0} : {1} points.
{2} : {3} points.
{4}

Restart Game?",m_Control.PlayerOne.Name, m_Control.PlayerOne.Score, m_Control.PlayerTwo.Name, m_Control.PlayerTwo.Score, winnerName);


                MessageBoxButtons scoreBox = MessageBoxButtons.YesNo;
                DialogResult rematchResult = MessageBox.Show(msg.ToString(), scoreTitle, scoreBox);

                if (rematchResult == DialogResult.No)
                {
                    MessageBox.Show("Thank you for playing, hope to see you soon!");
                    Environment.Exit(0);
                }
                else
                {
                    restartGame();
                }
            }
        }

        private void restartGame()
        {
            m_FormGame.Hide();
            initializeCollection();
            m_Control.ClearPlayersScore();
            m_Control.RestartGame();
            m_FormSettings.Show();
            m_CurrentPlayerTurn = ePlayerTurn.playerOne;

        }

        private void initializeCollection()
        {
            m_Collection = new Dictionary<int, Image>();
            int size = k_MaxPairs;
            for (int i = 0; i < size; i++)
            {
                Image imageToAdd = getRandomImage();
                m_Collection.Add(i, imageToAdd);
            }
        }

        private Image getRandomImage()
        {
            return downloadImageFromUrl("https://picsum.photos/80");
        }

        private Image downloadImageFromUrl(string imageUrl)
        {
            Image image = null;

            try
            {
                System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;
                System.Net.WebResponse webResponse = webRequest.GetResponse();
                System.IO.Stream stream = webResponse.GetResponseStream();
                image = Image.FromStream(stream);
                webResponse.Close();
            }
            catch (Exception ex)
            {
                return null;
            }

            return image;
        }
    }
}

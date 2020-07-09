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

        public UI()
        {
            m_FormSettings = new FormSettings();
            m_FormSettings.ButtonStart.Click += StartButton_Click;
            initializeCollection();
        }

        public  void Run()
        {
            m_FormSettings.ShowDialog();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            m_Control = new GameLogic(m_FormSettings.Height, m_FormSettings.Width);
            string firstPlayer = m_FormSettings.FirstPlayerName;
            string secondPlayer = m_FormSettings.SecondPlayerName;
            m_FormGame = new FormGame(m_FormSettings.Height, m_FormSettings.Width,firstPlayer,secondPlayer);
            m_FormSettings.Hide();
            m_FormGame.ShowDialog();
            startGame();
        }

        private void startGame()
        {
            while(m_Control.isEndGame() == false)
            {

            }
        }

        private void initializeCollection()
        {
            m_Collection = new Dictionary<int, Image>();
            int size = m_FormSettings.Width * m_FormSettings.Width;
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

    public enum eGameType
    {
        againstFriend = 1,
        againstComputer = 2
    }

    public enum ePlayerType
    {
        playerOne = 1,
        playerTwo = 2,
        computer = 3
    }
}

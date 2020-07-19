using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05.Logic;

namespace Ex05.UI
{
    public partial class FormGame : Form
    {
        GameCard[,] m_GameCards;
        const int k_Borders = 12;
        const int K_CardSize = 80;

        public FormGame(int i_Height, int i_Widht, Player i_FirstPlayer, Player i_SecondPlayer)
        {
            initializeGameCards(i_Height, i_Widht);
            InitializeComponent(i_FirstPlayer, i_SecondPlayer);
        }

        public GameCard[,] GameCards
        {
            get
            {
                return m_GameCards;
            }
        }

        public Label CurrentPlayer
        {
            get
            {
                return this.labelCurrentPlayer;
            }
        }

        public Label FirstPlayerScore
        {
            get
            {
                return this.labelFirstPlayerScore;
            }
        }

        public Label SecondPlayerScore
        {
            get
            {
                return this.labelSecondPlayerScore;
            }
        }

        private void initializeGameCards(int i_Height, int i_Widht)
        {
            m_GameCards = new GameCard[i_Height, i_Widht];
            for (int i = 0; i < i_Height; i++)
            {
                for(int j = 0; j < i_Widht; j++)              
                {
                    m_GameCards[i, j] = new GameCard(i, j);
                    m_GameCards[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    m_GameCards[i, j].Size = new Size(K_CardSize, K_CardSize);
                    m_GameCards[i, j].Left = (i * (K_CardSize + k_Borders)) + k_Borders;
                    m_GameCards[i, j].Top = (j * (K_CardSize + k_Borders)) + k_Borders;
                    this.Controls.Add(m_GameCards[i, j]);
                }
            }
        }
    }

    public class GameCard : Button
    {
        private int m_X;
        private int m_Y;
        private Image m_Image;

        public GameCard(int i_X, int i_Y)
        {
            m_X = i_X;
            m_Y = i_Y;
            //m_Image = new PictureBox();
            //m_Image.Top = this.Top + 7;
            //m_Image.Left = this.Left + 7;
            //m_Image.Size = new Size(65, 65);
            //m_Image.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public int X
        {
            get
            {
                return m_X;
            }
            set
            {
                m_X = value;
            }
        }
        public int Y
        {
            get
            {

                return m_Y;
            }
            set
            {
                m_Y = value;
            }
        }

        public Image CardImage
        {
            get
            {
                return m_Image;
            }
            set
            {
                m_Image = value;
            }
        }
    }

}

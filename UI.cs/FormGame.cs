using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.UI
{
    public partial class FormGame : Form
    {
        string m_FirstPlayerName;
        string m_SecondPlayerName = "computer";
        uint m_FirstPlayerScore;
        uint m_SecondPlayerScore;
        GameCard[,] m_GameCards;
        readonly Color r_FirstPlayerColor = Color.LightBlue;
        readonly Color r_SecondPlayerColor = Color.LightGreen;
        const int marginBorders = 12;
        const int squareCardSize = 80;


        public FormGame(int i_Height, int i_Widht, string i_FirstPlayerName, string i_SecondPlayerName = null)
        {
            m_FirstPlayerName = i_FirstPlayerName;
            if (i_SecondPlayerName != null)
            {
                m_SecondPlayerName = i_SecondPlayerName;
            }
            initializeGameCards(i_Height, i_Widht);
            InitializeComponent();

        }

        public GameCard[,] GameCards
        {
            get { return m_GameCards; }
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
                    m_GameCards[i, j].Size = new Size(squareCardSize, squareCardSize);
                    m_GameCards[i, j].Left = (i * (squareCardSize + marginBorders)) + marginBorders;
                    m_GameCards[i, j].Top = (j * (squareCardSize + marginBorders)) + marginBorders;
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

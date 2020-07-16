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
    public partial class FormSettings : Form
    {
        private int m_Height = 4;
        private int m_Width = 4;

        public FormSettings()
        {
            InitializeComponent();
        }

        public Button ButtonStart
        {
            get
            {
                return this.buttonStart;
            }
        }

        public Button BottonFormSize
        {
            get
            {
                return this.buttonBoardSize;
            }
        }

        public string FirstPlayerName
        {
            get
            {
                return textBoxFirstPlayer.Text;
            }
            set
            {
                textBoxFirstPlayer.Text = value;
            }
        }

        public string SecondPlayerName
        {
            get
            {
                return textBoxSecondPlayer.Text;
            }
            set
            {
              textBoxSecondPlayer.Text = value;
            }
        }

        public int Width
        {
            get
            {
                return this.m_Width;
            }
        }

        public int Height
        {
            get
            {
                return this.m_Height;
            }
        }

        private void buttonAgainstPlayer_Click_1(object sender, EventArgs e)
        {
            textBoxSecondPlayer.Enabled = true;
            textBoxSecondPlayer.Text = "";
            textBoxSecondPlayer.BackColor = Color.White;
            buttonAgainstPlayer.Text = "Against Computer";
            this.buttonAgainstPlayer.Click -= buttonAgainstPlayer_Click_1;
            this.buttonAgainstPlayer.Click += new System.EventHandler(this.buttonAgainstPlayer_Click_2);
        }

        private void buttonAgainstPlayer_Click_2(object sender, EventArgs e)
        {
            textBoxSecondPlayer.Enabled = false;
            textBoxSecondPlayer.Text = "-computer-";
            textBoxSecondPlayer.BackColor = Color.DarkGray;
            buttonAgainstPlayer.Text = "Against A Friend";
            this.buttonAgainstPlayer.Click -= buttonAgainstPlayer_Click_2;
            this.buttonAgainstPlayer.Click += new System.EventHandler(this.buttonAgainstPlayer_Click_1);
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            switch (buttonBoardSize.Text)
            {
                case "4x4":
                    buttonBoardSize.Text = "4x5";
                    m_Height = 4;
                    m_Width = 5;
                    break;
                case "4x5":
                    buttonBoardSize.Text = "4x6";
                    m_Height = 4;
                    m_Width = 6;
                    break;
                case "4x6":
                    buttonBoardSize.Text = "5x4";
                    m_Height = 5;
                    m_Width = 4;
                    break;
                case "5x4":
                    buttonBoardSize.Text = "5x6";
                    m_Height = 5;
                    m_Width = 6;
                    break;
                case "5x6":
                    buttonBoardSize.Text = "6x4";
                    m_Height = 6;
                    m_Width = 4;
                    break;
                case "6x4":
                    buttonBoardSize.Text = "6x5";
                    m_Height = 6;
                    m_Width = 5;
                    break;
                case "6x5":
                    buttonBoardSize.Text = "6x6";
                    m_Height = 6;
                    m_Width = 6;
                    break;
                default:
                    buttonBoardSize.Text = "4x4";
                    m_Height = 4;
                    m_Width = 4;
                    break;
            }
        }
    }
}

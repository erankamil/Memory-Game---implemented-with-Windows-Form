using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ex05.Logic
{
    public class Player
    {
        private string m_Name;
        private int m_Score;
        readonly Color m_Color;
        private Random m_Rand;

        public Player(string i_Name, Color i_Color)
        {
            m_Name = i_Name;
            if (i_Name == "-computer-")
            {
                m_Rand = new Random();
            }
            m_Color = i_Color;
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public Color myColor
        {
            get
            {
                return m_Color;
            }
        }

        public string RandMove(int i_Row, int i_Col)
        {
            int row = m_Rand.Next(1, i_Row);
            char col = Convert.ToChar(m_Rand.Next(1, i_Col) + 'A');
            string choice = string.Format("{0}{1}", col, row);
            return choice;
        }
    }
}

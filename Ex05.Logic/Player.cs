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

        public Player(string i_Name, Color i_Color)
        { 
            m_Name = i_Name;
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
    }
}

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
        private List<Point> m_RandMoveOptions;


        //ctor for regular player
        public Player(string i_Name, Color i_Color)
        { 
            m_Name = i_Name;
            m_Color = i_Color;
        }

        //ctor for computer player
        public Player(string i_Name, Color i_Color, int i_Rows, int i_Cols)
        {
            m_Name = i_Name;
            m_Rand = new Random();
            m_RandMoveOptions = new List<Point>();
            initializeOptionalMoves(i_Rows, i_Cols);
            m_Color = i_Color;
        }

        private void initializeOptionalMoves(int i_Rows, int i_Cols)
        {
            for (int i = 0; i < i_Rows; i++)
            {
                for (int j = 0; j < i_Cols; j++)
                {
                    Point optionalMove = new Point(i, j);
                    m_RandMoveOptions.Add(optionalMove);
                }
            }
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

        public Point RandMove()
        {
            int maxIndex = m_RandMoveOptions.Count;
            int radnIndex = m_Rand.Next(0, maxIndex);
            Point randPoint = m_RandMoveOptions[radnIndex];
            return randPoint;
        }

        public void UpdateCompterRandMoves(int i_FirstCellRow, int i_FirstCellCol, int i_SecondCellRow, int i_SecondCellCol)
        {
            Point moveToDelete1 = new Point(i_FirstCellRow, i_FirstCellCol);
            Point moveToDelete2 = new Point(i_SecondCellRow, i_SecondCellCol);
            m_RandMoveOptions.Remove(moveToDelete1);
            m_RandMoveOptions.Remove(moveToDelete2);
        }
    }
}

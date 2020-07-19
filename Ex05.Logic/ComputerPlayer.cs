using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.Logic
{
    class ComputerPlayer : Player
    {
        private Random m_Rand;
        private List<Cell> m_RandMoveOptions;
        private List<Cell> m_LastMovesCache;

        public ComputerPlayer(string i_Name, Color i_Color, Board i_GameBoard) : base(i_Name, i_Color)
        {
            m_Rand = new Random();
            m_RandMoveOptions = new List<Cell>();
            m_LastMovesCache = new List<Cell>();
            initializeOptionalMoves(i_GameBoard);
        }

        public List<Cell> RandOptions
        {
            get { return m_RandMoveOptions; }
        }

        public void AddToCache(Cell i_FirstMove, Cell i_SecondMove)
        {
            if (m_LastMovesCache.Count >= 4)
            {
                deleteMoves();
            }
            if (m_LastMovesCache.Contains(i_FirstMove) == false) // move doesn't exist
            {
                m_LastMovesCache.Add(i_FirstMove);
            }
            if (m_LastMovesCache.Contains(i_SecondMove) == false) // move doesn't exist
            {
                m_LastMovesCache.Add(i_SecondMove);
            }
        }

        private void deleteMoves()
        {
            int maxIndex = m_LastMovesCache.Count;
            int radnIndex = m_Rand.Next(0, maxIndex-1);
            m_LastMovesCache.RemoveAt(radnIndex);
            radnIndex = m_Rand.Next(0, maxIndex - 2);
            m_LastMovesCache.RemoveAt(radnIndex);
        }

        private void initializeOptionalMoves(Board i_GameBoard)
        {
            for (int i = 0; i < i_GameBoard.Rows; i++)
            {
                for (int j = 0; j < i_GameBoard.Cols; j++)
                {
                    m_RandMoveOptions.Add(i_GameBoard.Matrix[i,j]);
                }
            }
        }

        public void RandMove(out Cell io_CellMove)
        {
            int maxIndex = m_RandMoveOptions.Count - 1;
            int radnIndex = m_Rand.Next(0, maxIndex);
            io_CellMove = m_RandMoveOptions[radnIndex];
        }

        public bool CheckPairInCache(out Cell io_CellOne, out Cell io_CellTwo)
        {
            bool hasPair = false;
            io_CellOne = io_CellTwo = null;
            for (int i = 0; i < m_LastMovesCache.Count && hasPair == false; i++)
            {
                int keyToFind = m_LastMovesCache[i].Key;
                for(int j = i + 1; j < m_LastMovesCache.Count && hasPair == false; j++)
                {
                    if(m_LastMovesCache[j].Key == keyToFind)
                    {
                        io_CellOne = m_LastMovesCache[i];
                        io_CellTwo = m_LastMovesCache[j];
                        hasPair = true;
                    }
                }
            }
            return hasPair;
        }

        public void UpdateComputerMoves(Cell i_FirstMove, Cell i_SecondMove)
        {
            m_LastMovesCache.Remove(i_FirstMove);
            m_LastMovesCache.Remove(i_SecondMove);
            m_RandMoveOptions.Remove(i_FirstMove);
            m_RandMoveOptions.Remove(i_SecondMove);
        }

    }
}

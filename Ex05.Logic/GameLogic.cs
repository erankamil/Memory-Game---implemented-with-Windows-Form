using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Ex05.Logic
{
    public class GameLogic
    {
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private Board m_GameBoard;
        private int m_NumOfOpenedPairs;
        private eGameType m_GameType = eGameType.againstFriend;

        public GameLogic(int i_Rows, int i_Cols, Player i_FirstPlayer, Player i_SecondPlayer)
        {
            m_GameBoard = new Board(i_Rows, i_Cols);
            initializeLogicBoard();
            m_FirstPlayer = i_FirstPlayer;
            m_SecondPlayer = i_SecondPlayer;
            if (m_SecondPlayer.Name == "-computer-")
            {
                m_GameType = eGameType.againstComputer;
            }

            mix();
        }

        public Player PlayerOne
        {
            get
            {
                return m_FirstPlayer;
            }
        }

        public Player PlayerTwo
        {
            get
            {
                return m_SecondPlayer;
            }
        }

        public eGameType GameType
        {
            get
            {
                return m_GameType;
            }
        }

        public Board Board
        {
            get
            {
                return m_GameBoard;
            }
        }

        public int OpenedPairs
        {
            get
            {
                return m_NumOfOpenedPairs;
            }
        }

        public void mix()
        {
            Random rand = new Random();
            int randRow;
            int randCol;
            for (int i = 0; i < m_GameBoard.Rows; i++)
            {
                for (int j = 0; j < m_GameBoard.Cols; j++)
                {
                    randRow = rand.Next(0, (int)m_GameBoard.Rows);
                    randCol = rand.Next(0, (int)m_GameBoard.Cols);
                    int temp = m_GameBoard.Matrix[i, j].Key;
                    m_GameBoard.Matrix[i, j].Key = m_GameBoard.Matrix[randRow, randCol].Key;
                    m_GameBoard.Matrix[randRow, randCol].Key = temp;
                }
            }
        }

        private void initializeLogicBoard()
        {
            int currentNum = 0;
            for (int i = 0; i < m_GameBoard.Rows; i++)
            {
                for (int j = 0; j < m_GameBoard.Cols; j++)
                {
                    m_GameBoard.Matrix[i, j].Key = currentNum;
                    if (j % 2 == 1)
                    {
                        currentNum++;
                    }
                }
            }
        }

        public bool Compare(int i_FirstCellRow, int i_FirstCellCol, int i_SecondCellRow,
            int i_SecondCellCol, ref ePlayerTurn io_CurrentPlayer)
        {
            bool isMatch = m_GameBoard.Matrix[i_FirstCellRow, i_FirstCellCol].Key ==
                m_GameBoard.Matrix[i_SecondCellRow, i_SecondCellCol].Key;

            if (isMatch)
            {
                m_NumOfOpenedPairs++;
                addScore(io_CurrentPlayer);
                m_GameBoard.Matrix[i_FirstCellRow, i_FirstCellCol].IsOpen = true;          
                m_GameBoard.Matrix[i_SecondCellRow, i_SecondCellCol].IsOpen = true;
                if(m_SecondPlayer.Name == "-computer-")
                {
                    m_SecondPlayer.UpdateCompterRandMoves(i_FirstCellRow, i_FirstCellCol, i_SecondCellRow, i_SecondCellCol);
                }
            }
            else
            {
                passTurn(ref io_CurrentPlayer);
            }

            return isMatch;
        }

        private void passTurn(ref ePlayerTurn io_CurrentPlayer)
        {
            switch (io_CurrentPlayer)
            {
                case ePlayerTurn.playerOne:
                    io_CurrentPlayer = ePlayerTurn.playerTwo;
                    break;
                case ePlayerTurn.playerTwo:
                    io_CurrentPlayer = ePlayerTurn.playerOne;
                    break;
                default:
                    break;
            }
        }
        
        public void RestartGame()
        {
            for (int i = 0; i < m_GameBoard.Rows; i++)
            {
                for (int j = 0; j < m_GameBoard.Cols; j++)
                {
                    m_GameBoard.Matrix[i, j].IsOpen = false;
                }
            }
        }

        public void UpdatePlayersNames(string i_PlayerOneName, string i_PlayerTwoName) 
        {
            m_FirstPlayer.Name = i_PlayerOneName;
            if(i_PlayerTwoName == "-computer-")
            {
                m_GameType = eGameType.againstComputer;
                m_SecondPlayer = new Player(i_PlayerTwoName, m_SecondPlayer.myColor);
            }
            else
            {
                m_GameType = eGameType.againstFriend;
                m_SecondPlayer.Name = i_PlayerTwoName;
            }
        }

        private void addScore(ePlayerTurn i_PlayerType)
        {
            switch (i_PlayerType)
            {
                case ePlayerTurn.playerOne:
                    m_FirstPlayer.Score++;
                    break;
                case ePlayerTurn.playerTwo:
                    m_SecondPlayer.Score++;
                    break;
            }
        }

        public bool isEndGame()
        {
            return m_NumOfOpenedPairs == (m_GameBoard.Rows * m_GameBoard.Cols)/2;
        }

        public string AnnounceWinner()
        {
            if (m_FirstPlayer.Score > m_SecondPlayer.Score)
            {
                return m_FirstPlayer.Name;
            }
            else if (m_SecondPlayer.Score > m_FirstPlayer.Score)
            {
                return m_SecondPlayer.Name;
            }
            else
            {
                return null;
            }
        }

        public void GetComputerMove(out int io_X, out int io_Y)
        {
            Point randPoint = PlayerTwo.RandMove();
            io_X = randPoint.X;
            io_Y = randPoint.Y;
        }

        private bool checkBoardCellState(int i_Row, int i_Col)
        {
            return m_GameBoard.Matrix[i_Row, i_Col].IsOpen;
        }

        public void ClearPlayersScore()
        {
            m_FirstPlayer.Score = 0;
            m_SecondPlayer.Score = 0;
        }
    }

    public enum eGameType
    {
        againstFriend = 1,
        againstComputer = 2
    }

    public enum ePlayerTurn
    {
        playerOne = 1,
        playerTwo = 2,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.Logic
{
    public class Cell
    {
        private int m_Key;
        private bool m_IsOpened;
        private int m_X;
        private int m_Y;

        public Cell()
        {
            m_Key = 0;
            m_IsOpened = false;
        }

        public Cell(int i_X, int i_Y)
        {
            m_X = i_X;
            m_Y = i_Y;
            m_IsOpened = false;
        }

        public int Key
        {
            get
            {
                return m_Key;
            }

            set
            {
                m_Key = value;
            }
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

        public bool IsOpen
        {
            get
            {
                return m_IsOpened;
            }

            set
            {
                m_IsOpened = value;
            }
        }
    }
}

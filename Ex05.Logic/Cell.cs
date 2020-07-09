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

        public Cell()
        {
            m_Key = 0;
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

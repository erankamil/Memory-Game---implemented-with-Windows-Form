using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.UI
{
    public class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            UI ui = new UI();
            ui.Run();
        }
        
    }
}

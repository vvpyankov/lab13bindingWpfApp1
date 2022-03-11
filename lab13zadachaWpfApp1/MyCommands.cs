using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab13zadachaWpfApp1
{
    class MyCommands
    {
        public static RoutedCommand Exit { get; set; }
        static MyCommands()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            Exit = new RoutedCommand("Exit", typeof(MyCommands), inputs);
        }
    }
}

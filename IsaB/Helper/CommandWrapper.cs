using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Controls;

namespace IsaB.Helper
{
    public class CommandWrapper
    {
        public DelegateCommand Command { get; set; }
        public Symbol CommandSymbol { get; set; }
        public Type PageType { get; set; }
        public string CommandText { get; set; }
    }
}

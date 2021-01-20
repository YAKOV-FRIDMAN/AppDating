using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppDating.Utils
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName()] string name = null)
        {
            if (name != null) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

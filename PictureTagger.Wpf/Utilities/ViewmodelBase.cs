using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PictureTagger.Utilities
{
    public abstract class ViewmodelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        // usage: OnPropertyChanged() inside Property


        protected bool SetField<T>(ref T field, T value,[CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        // Usage a) set { SetField(ref name, value); 
        // Usage b) 
            /*
             private string name;
                public string Name
                {
                    get => name;
                    set => SetField(ref name, value);
                }
             */


    }
}

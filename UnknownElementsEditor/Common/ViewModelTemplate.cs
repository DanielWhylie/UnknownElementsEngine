using System.ComponentModel;
using System.Runtime.Serialization;

namespace UnknownElementsEditor
{
    [DataContract(IsReference = true)]
    public class ViewModelTemplate : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

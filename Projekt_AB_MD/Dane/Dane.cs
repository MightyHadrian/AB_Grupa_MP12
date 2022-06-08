using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dane
{
    public abstract class Data : INotifyPropertyChanged
    {
        // Klasa abstrakcyjna umożliwiająca stworzenie własnych funkcji zajmujących się daną strukturą
        public abstract int objectID { get; }
        public abstract int objectX { get; set; }
        public abstract int objectY {get; set; }
        public abstract double objectVelocity { get; set; }
        public abstract double objectMass { get; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;
    }
    
}
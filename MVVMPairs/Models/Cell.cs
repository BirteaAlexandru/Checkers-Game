using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPairs.Models
{
    
    class Cell : INotifyPropertyChanged
    {
        public Cell() { }
        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Cell(int x, int y, string piece, string displayed="")
        {
            this.X = x;
            this.Y = y;
            this.DisplayedImage = displayed;
            this.Piece = piece;
        }

        /* Am optat sa fac proprietati notificabile aici; o alta varianta ar fi fost sa lucrez in Services cu obiecte ViewModel
        care sunt notificabile, dar aceasta optiune o gasesc mai potrivita pentru MVVM */
        //public int X { get; set; }
        //public int Y { get; set; }
        //public string DisplayedImage { get; set; }
        //public string HidenImage { get; set; }

        private int x;
        public int X
        {
            get { return x; }
            set
            {
                x = value;
                NotifyPropertyChanged("X");
            }
        }
        private int y;
        public int Y
        {
            get { return y; }
            set
            {
                y = value;
                NotifyPropertyChanged("Y");
            }
        }
        private string piece;
        public string Piece
        {
            get { return piece; }
            set
            {
                piece = value;
                this.DisplayedImage = "C:/Users/alexb/OneDrive/Desktop/Lab7/MVVM-DemoGame/MVVMPairs - Copy/MVVMPairs/Resources/" + value + ".jpg";
                NotifyPropertyChanged("Piece");
            }
        }
        private string displayedImage;
        public string DisplayedImage
        {
            get { return displayedImage; }
            set
            {
                displayedImage = value;
                NotifyPropertyChanged("DisplayedImage");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

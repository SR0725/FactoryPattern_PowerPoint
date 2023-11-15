using System.ComponentModel;

namespace homework2
{
    public class Toolbar : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        const int NONE = -1;
        const int RECTANGLE = 0;
        const int LINE = 1;
        const int CIRCLE = 2;
        const int POINT_STATE = 3;
        public enum ToolbarType : int
        {
            None = NONE,
            Rectangle = RECTANGLE,
            Line = LINE,
            Circle = CIRCLE,
            PointState = POINT_STATE,
        }
        private ToolbarType _checkedType = ToolbarType.None;

        public Toolbar()
        {
        }

        public ToolbarType checkedType
        {
            get { return this._checkedType; }
            set
            {
                this._checkedType = value;
                NotifyPropertyChanged("ButtonCheck");
            }
        }

        // NotifyPropertyChanged
        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

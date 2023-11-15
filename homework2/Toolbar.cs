using System.ComponentModel;

namespace homework2
{
    public class ToolBar : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        const int NONE = -1;
        const int RECTANGLE = 0;
        const int LINE = 1;
        const int CIRCLE = 2;
        const int POINT_STATE = 3;
        public enum ToolBarType : int
        {
            None = NONE,
            Rectangle = RECTANGLE,
            Line = LINE,
            Circle = CIRCLE,
            PointState = POINT_STATE
        }
        private ToolBarType _checkedType = ToolBarType.None;

        public ToolBar()
        {
        }

        public ToolBarType checkedType
        {
            get 
            { 
                return this._checkedType; 
            }
            set
            {
                this._checkedType = value;
                const string EVENT_NAME = "ButtonCheck";
                NotifyPropertyChanged(EVENT_NAME);
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

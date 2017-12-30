using System;
using System.Windows.Forms;

namespace TokenProject
{
    public delegate void NotifyParentDelegate(TokenEventArgs customEventArgs);

    public class TokenEventArgs : EventArgs
    {
        private string _name;
        private MouseButtons _mb;
        private object _tokenItem;
        private int _index;
        public TokenEventArgs(string Name,int PositionInTokenBox , object Item, MouseButtons Mb)
        {
            _index = PositionInTokenBox;
            _name = Name;
            _tokenItem = Item;
            _mb = Mb;
        }

        public string Text
        {
            get { return _name; }
            set { _name = value; }
        }

        public MouseButtons Button
        {
            get
            {
                return _mb;
            }

            set
            {
                _mb = value;
            }
        }

        public object TokenItem
        {
            get
            {
                return _tokenItem;
            }

            set
            {
                _tokenItem = value;
            }
        }

        public int Index
        {
            get
            {
                return _index;
            }

            set
            {
                _index = value;
            }
        }
    }
}

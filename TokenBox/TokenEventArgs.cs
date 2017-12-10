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
        public TokenEventArgs(string Name, object Item, MouseButtons Mb)
        {
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
    }
}

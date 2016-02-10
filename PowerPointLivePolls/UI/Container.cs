using System;
using System.Windows;
using System.Windows.Forms;

namespace PowerPointLivePolls.UI
{
    public partial class Container : Form, IContainer
    {
        public Container()
        {
            InitializeComponent();            
        }

        private int _cntlHeight;
        public int ControlHeight
        {
            get { return _cntlHeight;}
            set
            {
                this.Height = value;
                this.MinimumSize = new System.Drawing.Size(ControlWidth, value);
            }
        }

        private int _cntlWidth;
        public int ControlWidth
        {
            get {return _cntlWidth;}

            set
            {
                this.Width = value;
                this.MinimumSize = new System.Drawing.Size(value, ControlHeight);
            }
        }
                
        public object WpfControl
        {
            get {return elementHost1.Child; }

            set
            {
                this.elementHost1.Child = (System.Windows.UIElement)value;
            }
        }

        public System.Drawing.Size ControlSize
        {
            get
            {
                return this.MinimumSize;
            }

            set
            {
                this.MinimumSize = value;
                this.Size = value;
            }
        }

        public string FormCaption
        {
            get
            {
                return this.Text;
            }

            set
            {
                this.Text = value;                
            }
        }

        public DialogResult ShowForm()
        {
            return ShowDialog();
        }

        public void CloseForm()
        {
            Close();
        }
    }
}

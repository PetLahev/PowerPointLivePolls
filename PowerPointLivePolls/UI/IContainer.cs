using System.Drawing;
using System.Windows.Forms;

namespace PowerPointLivePolls.UI
{
    public interface IContainer
    {
        object WpfControl { get; set; }
        int ControlWidth { get; set; }
        int ControlHeight { get; set; }
        Size ControlSize { get; set; }
        string FormCaption { get; set; }

        DialogResult ShowForm();
        void CloseForm();
    }
}

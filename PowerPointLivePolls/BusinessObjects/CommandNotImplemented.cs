using Microsoft.Office.Interop.PowerPoint;
using System.Windows;

namespace PowerPointLivePolls.BusinessObjects
{
    public class CommandNotImplemented : ICommand
    {
        public Presentation ActivePresentation
        {
            set; get;
        }

        public void Execute()
        {
            MessageBox.Show(I18.ResManager.GetText("NotImplemented"));
        }
    }
}

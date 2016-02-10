using Microsoft.Office.Interop.PowerPoint;

namespace PowerPointLivePolls.BusinessObjects
{
    public interface ICommand
    {
        void Execute();
        Presentation ActivePresentation { get; set; }
    }
}

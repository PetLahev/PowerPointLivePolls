using Microsoft.Office.Interop.PowerPoint;
using PowerPointLivePolls.BusinessObjects;

namespace PowerPointLivePolls
{
    public static class RibbonFactory
    {
        /// <summary>Returns instance of a class that implements ICommand interface according to given control id</summary>
        /// <param name="controlId">id of control to get instance for</param>
        /// <returns>Instance of a class that implements ICommand interface, or null if control id is not found</returns>
        public static ICommand GetCommand(string controlId)
        {
            var ppt = ThisAddIn.PPTApplication.ActivePresentation;
            switch (controlId)
            {
                case "SetPpt":
                    return new Core.SettingProject.ProjectModel() { ActivePresentation = ppt };
                case "Settings":
                    return new CommandNotImplemented() { ActivePresentation = ppt };
                case "InsertChart":
                    return new CommandNotImplemented() { ActivePresentation = ppt };
                case "InsertTable":
                    return new CommandNotImplemented() { ActivePresentation = ppt };
                case "SetAsset":
                    return new CommandNotImplemented() { ActivePresentation = ppt };
                case "About":
                    return new CommandNotImplemented() { ActivePresentation = ppt };
                default:
                    return null;
            }
        }
    }
}

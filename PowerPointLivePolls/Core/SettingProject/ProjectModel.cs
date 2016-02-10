using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.PowerPoint;
using PowerPointLivePolls.BusinessObjects;

namespace PowerPointLivePolls.Core.SettingProject
{
    public class ProjectModel : ICommand
    {
        public Presentation ActivePresentation { get; set; }

        public void Execute()
        {
            UI.WPF.Projects cntl = new UI.WPF.Projects();

            UI.IContainer container = new UI.Container();
            container.FormCaption = I18.ResManager.GetText("ProjectsFormCaption");
            container.ControlSize = cntl.ControlSize;
            container.WpfControl = cntl;
            container.ShowForm();

            container.CloseForm();

        }
    }
}

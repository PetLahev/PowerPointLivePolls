using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;

namespace PowerPointLivePolls
{
    public partial class ThisAddIn
    {
        private static PowerPoint.Application _app;
        internal static PowerPoint.Application PPTApplication
        {
            get { return _app; }
        }
        
        private static Core.PptEventHandlers _eventHandler;
        internal static Core.PptEventHandlers EventHandler
        {
            get { return _eventHandler; }
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new AddinRibbon();
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _app = Globals.ThisAddIn.Application;
            _eventHandler = new Core.PptEventHandlers(_app);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            _app = null;
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}

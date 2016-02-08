using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using System.Drawing;
using System.Windows;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new AddinRibbon();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace PowerPointLivePolls
{
    [ComVisible(true)]
    public class AddinRibbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public IList<BusinessObjects.IMenuItems> MenuItems { get; set; }

        public AddinRibbon()
        {
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("PowerPointLivePolls.AddinRibbon.xml");
        }

        #endregion

        #region Ribbon Callbacks

        public void SettingsClick(Office.IRibbonControl control)
        {
            var ppt = Globals.ThisAddIn.Application.ActivePresentation;

            //Core.Metadata.Serialize(new BusinessObjects.PollProject() { Name = "Tomas" }, ppt);

            //Core.Metadata.Deserialize(ppt);

            //Core.Metadata test = new Core.Metadata(ppt);
            //MessageBox.Show(test.HasProjects.ToString());
            UI.Settings str = new UI.Settings();
            str.ShowDialog();
        }

        public string SetPptLabel(Office.IRibbonControl control)
        {
            Core.Metadata helper = new Core.Metadata(Globals.ThisAddIn.Application.ActivePresentation);
            string key = helper.HasProjects ? "SetPptChange" : "SetPpt";
            return I18.ResManager.GetText(key);
        }

        public bool mnuLiveMenuEnable(Office.IRibbonControl control)
        {
            return MenuItems != null && MenuItems.Count > 0;
        }

        public bool Btn1Visible(Office.IRibbonControl control)
        {
            return GetItemVisibility(1);
        }

        public string Btn1Label(Office.IRibbonControl control)
        {
            return GetItemLabel(1);
        }

        public bool Btn2Visible(Office.IRibbonControl control)
        {
            return GetItemVisibility(2);
        }

        public string Btn2Label(Office.IRibbonControl control)
        {
            return GetItemLabel(2);
        }
        public bool Btn3Visible(Office.IRibbonControl control)
        {
            return GetItemVisibility(3);
        }

        public string Btn3Label(Office.IRibbonControl control)
        {
            return GetItemLabel(3);
        }

        public bool Btn4Visible(Office.IRibbonControl control)
        {
            return GetItemVisibility(4);
        }

        public string Btn4Label(Office.IRibbonControl control)
        {
            return GetItemLabel(4);
        }

        public bool Btn5Visible(Office.IRibbonControl control)
        {
            return GetItemVisibility(5);
        }

        public string Btn5Label(Office.IRibbonControl control)
        {
            return GetItemLabel(5);
        }

        public Bitmap GetImage(Office.IRibbonControl control)
        {
            switch (control.Id)
            {
                case "About":
                    return Properties.Resources.info;
                case "SetPpt":
                    return Properties.Resources.PptSettings;
                case "Settings":
                    return Properties.Resources.settings;
                case "InsertChart":
                    return Properties.Resources._3d_bar_chart;
                case "InsertTable":
                    return Properties.Resources.table;
                default:
                    return Properties.Resources.under_construction;
            }

        }

        #endregion

        private string GetItemLabel(int index)
        {
            if (this.MenuItems == null && this.MenuItems.Count < index) return null;
            return MenuItems[index].Caption;
        }

        private bool GetItemVisibility(int index)
        {
            if (this.MenuItems == null || this.MenuItems.Count < index) return false;
            return MenuItems[index].Visible;
        }

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}

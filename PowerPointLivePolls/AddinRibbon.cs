using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Office = Microsoft.Office.Core;

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

        public void RibbonButtontClick(Office.IRibbonControl control)
        {
            RibbonFactory.GetCommand(control.Id).Execute();
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

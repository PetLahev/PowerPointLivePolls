using System;
using System.Text;
using System.Reflection;
using System.Resources;
using System.Globalization;

namespace PowerPointLivePolls.I18
{
    public static class ResManager
    {
        /// <summary>Gets a text associated with given key in current culture</summary>
        /// <param name="key">a key that describes the text</param>
        /// <returns>text associated with the given key</returns>
        public static string GetText(string key)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            Assembly asm = Assembly.Load("PowerPointLivePolls");
            ResourceManager rm = new ResourceManager("PowerPointLivePolls.I18.Messages", asm);
            return rm.GetString(key, ci);            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerPointLivePolls.BusinessObjects
{
    public interface  IMenuItems
    {
        /// <summary>Sets/Gets caption of a menu item</summary>
        string Caption { get; set; }

        /// <summary>Free text. Intended to store shape name which is paired with the item </summary>
        string PairToShape { get; set; }
        
        /// <summary>Sets/Gets visibility of a menu item</summary>
        bool Visible { get; set; }
    }
}

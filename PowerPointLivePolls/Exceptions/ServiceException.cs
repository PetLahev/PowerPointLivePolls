using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace PowerPointLivePolls.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string message)
        {
            MessageBox.Show(string.Format("{0}", message));
        }

        public ServiceException(string message, Exception ex)
        {
            MessageBox.Show(string.Format("{0}\n{1}", message, ex.Message));
        }
    }
}

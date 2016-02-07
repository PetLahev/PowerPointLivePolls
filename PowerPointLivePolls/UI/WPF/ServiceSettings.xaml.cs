using System;
using System.Windows;
using System.Windows.Controls;

namespace PowerPointLivePolls.UI.WPF
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ServiceSettings : UserControl
    {
        public event EventHandler OnCancel;
        public event EventHandler OnSave;
        public event EventHandler OnTestConnection;

        public ServiceSettings()
        {
            InitializeComponent();            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (OnCancel != null) OnCancel(null, new EventArgs());
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {            
            if (OnSave != null) OnSave(sender, new EventArgs());
        }

        private void TestConnection_Click(object sender, RoutedEventArgs e)
        {
            if (OnTestConnection != null) OnTestConnection(sender, new EventArgs());
        }
    
    }
}

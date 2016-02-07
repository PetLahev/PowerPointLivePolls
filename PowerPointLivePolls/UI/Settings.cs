using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PowerPointLivePolls.UI
{
    public partial class Settings : Form
    {
        UI.WPF.ServiceSettings _dialog;        
        UI.ProgressBar _prg = null;

        public Settings()
        {
            InitializeComponent();
            _dialog = ((UI.WPF.ServiceSettings)wpfHost.Child);
            _dialog.OnCancel += new EventHandler(Settings_OnCancel);
            _dialog.OnSave += new EventHandler(Settings_OnSave);
            _dialog.OnTestConnection += new EventHandler(_dialog_OnTestConnection);
            _dialog.txtService.TextChanged += new System.Windows.Controls.TextChangedEventHandler(txtService_TextChanged);

            _dialog.txtService.Text = Properties.Settings.Default.ServiceBaseUrl;
            _dialog.txtUserName.Text = Properties.Settings.Default.ServiceUserName;
            _dialog.txtPassword.Password = Properties.Settings.Default.ServicePassword;
        }

        void _dialog_OnTestConnection(object sender, EventArgs e)
        {            
            Services.ServiceBase test = new Services.VoxVoteService();
            var response = test.GetProjects(_dialog.txtService.Text);
            

            if (string.IsNullOrWhiteSpace(response))
            {
                MessageBox.Show(string.Format("Could not connect to given url - {0}", _dialog.txtService.Text));
            }
            else
            {
                MessageBox.Show("Successfully connected");
            }
        }

        void txtService_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            _dialog.Save.IsEnabled = !string.IsNullOrWhiteSpace(_dialog.txtService.Text);
        }

        void Settings_OnSave(object sender, EventArgs e)
        {    
            bool useCredentials = _dialog.chbCredentials.IsChecked ?? (bool)_dialog.chbCredentials.IsChecked;            

            Properties.Settings.Default.ServiceBaseUrl = _dialog.txtService.Text.Trim();
            Properties.Settings.Default.ServiceUserName = _dialog.txtUserName.Text.Trim();
            Properties.Settings.Default.ServicePassword =  _dialog.txtPassword.Password.Trim();
            
            Properties.Settings.Default.Save();
            Settings_OnCancel(null, null);

        }

        void Settings_OnCancel(object sender, EventArgs e)
        {
            _dialog = null;
            Close();
        }
    }
}

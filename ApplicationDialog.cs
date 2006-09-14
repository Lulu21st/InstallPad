using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InstallPad
{
    public partial class ApplicationDialog : Form
    {
        private ApplicationItem applicationItem = null;
        /// <summary>
        /// Initialize with an application item
        /// </summary>
        /// <param name="item"></param>
        public ApplicationDialog(ApplicationItem item)
        {
            InitializeComponent();
            this.applicationItem = item;
            this.ApplicationName = item.Name;
            this.DownloadUrl = item.DownloadUrl;
            this.DownloadLatestVersion = item.Options.DownloadLatestVersion;
            this.SilentInstall = item.Options.SilentInstall;
            this.InstallerArguments = item.Options.InstallerArguments;
            Init();
        }
        public ApplicationDialog()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            this.appNameBox.TextChanged += new EventHandler(appNameBox_TextChanged);
            this.downloadUrlBox.TextChanged += new EventHandler(downloadUrlBox_TextChanged);
            EnableSaveButtonIfValid();
        }

        void appNameBox_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        void downloadUrlBox_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void ValidateForm()
        {
            if (ValidateAppName() && ValidateDownloadUrl())
                saveButton.Enabled = true;
            else
                saveButton.Enabled = false;            
        }
        private bool ValidateDownloadUrl()
        {
            if (downloadUrlBox.Text.Length <= 0)
                return false;

            return true;
        }
        private bool ValidateAppName()
        {
            if (appNameBox.Text.Length <= 0)
                return false;
            return true;
        }
        private bool ContainsCharacter(string[] characters, string str)
        {
            foreach (string s in characters)
                if (appNameBox.Text.Contains(s))
                    return true;
            return false;
        }

        /// <summary>
        /// If the form is valid, this will enable the save button.
        /// </summary>
        private void EnableSaveButtonIfValid()
        {
            if (appNameBox.Text.Length > 0 && downloadUrlBox.Text.Length > 0)
                saveButton.Enabled = true;
            else
                saveButton.Enabled = false;
        }



        #region properties
        public string Title
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }
        public string ApplicationName
        {
            get
            {
                return this.appNameBox.Text;
            }
            set
            {
                this.appNameBox.Text = value;
            }
        }
        public string DownloadUrl
        {
            get
            {
                return this.downloadUrlBox.Text;
            }
            set
            {
                this.downloadUrlBox.Text = value;
            }
        }
        public bool DownloadLatestVersion
        {
            get
            {
                return this.latestVersionCheck.Checked;
            }
            set
            {
                this.latestVersionCheck.Checked = value;
            }
        }
        public bool SilentInstall
        {
            get
            {
                return this.silentInstallCheck.Checked;
            }
            set
            {
                this.silentInstallCheck.Checked = value;
            }
        }
        public string InstallerArguments
        {
            get
            {
                return this.installerArgumentsBox.Text;
            }
            set
            {
                this.installerArgumentsBox.Text = value;
            }
        }
        public ApplicationItem ApplicationItem
        {
            get
            {
                return this.applicationItem;
            }
        }
        #endregion

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.saved = true;

            // If this was used to edit an item, update the application item
            if (this.applicationItem == null)
                this.applicationItem = new ApplicationItem();

            ModifyApplicationItemFromDialog(this.applicationItem);
            
            this.Close();
        }
        public void ModifyApplicationItemFromDialog(ApplicationItem item)
        {
            item.Name = this.ApplicationName;
            item.DownloadUrl = this.DownloadUrl;
            item.Options.DownloadLatestVersion = this.DownloadLatestVersion;
            item.Options.SilentInstall = this.SilentInstall;
            item.Options.InstallerArguments = this.InstallerArguments;
        }
        private bool saved;

        public bool Saved
        {
            get { return saved; }
        }
        
        /*public ApplicationItemOptions GetOptions
        {
            get
            {
                ApplicationItemOptions options = new ApplicationItemOptions();
                options.DownloadLatestVersion = this.latestVersionCheck.Checked;
                options.SilentInstall = this.silentInstallCheck.Checked;
                options.InstallerArguments = this.installerArgumentsBox.Text;
                return options;
            }
        }*/
        


    }
}
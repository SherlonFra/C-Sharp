﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter13programdirectories
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void lblDriveInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            string startingPath;
            int count;
            int i;
            ArrayList dirs = new ArrayList();
            startingPath = txtStartingPath.Text;

            try
            {
                DirectoryInfo myDirInfo = new DirectoryInfo(startingPath);

                if (myDirInfo.Exists == false)
                {
                    MessageBox.Show("Cannot find directory. Re-enter.*, *Directory Not Found");
                    txtStartingPath.Focus();
                    return;
                }
                clsDirectory myDirs = new clsDirectory();

                ShowDriveInfo();

                lstDirectories.Items.Clear();

                count = myDirs.ShowDirectory(myDirInfo, 0, dirs);
                for (i = 0; i < dirs.Count; i++)
                {
                    lstDirectories.Items.Add(dirs[i]);
                }
                this.Text = "Directories found: " + count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "IO Error");
                return;
            }

           
        }


        private void ShowDriveInfo()
        {
            int pos;
            long driveBytes;
            string buff;

            try
            {
                pos = txtStartingPath.Text.IndexOf('\\');
                buff = txtStartingPath.Text.Substring(0, pos);

                DriveInfo myDrive = new DriveInfo(@buff);

                driveBytes = myDrive.TotalSize / 1000000;
                lblDriveInfo.Text = "Drive" + buff + "has" + driveBytes.ToString() + "MB bytes, with "
                + myDrive.TotalFreeSpace / 1000000 + "MB bytes free.";
            }
            catch
            {
                txtStartingPath.Text = "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

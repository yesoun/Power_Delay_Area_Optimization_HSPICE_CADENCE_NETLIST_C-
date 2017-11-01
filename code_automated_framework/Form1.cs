using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDAOptFramework
{
    public partial class Form1 : Form
    {
        public bool state;
        public string sErrorMessage;
        public Form1()
        {
            InitializeComponent();
        }

        private void display(string text)
        {

            MessageBox.Show(text);
        }

        string sNoteListFile = "";
        private void bChooseNotelist_Click(object sender, EventArgs e)
        {
            if (openFileDialogNetlis.ShowDialog() == DialogResult.OK)
            {
                display(openFileDialogNetlis.FileName);
                NetlistFilePath.Text = openFileDialogNetlis.FileName;
                sNoteListFile = NetlistFilePath.Text;
            }
            else 
            {
                sErrorMessage = sErrorMessage + "Netlist file missing \r\n";
                state = false;
            }
        }


        string sCmosModel = "";
        private void bChooseCMOSmodel_Click(object sender, EventArgs e)
        {
            if ( openFileNMOSmodel.ShowDialog() == DialogResult.OK)
            {
                display(openFileNMOSmodel.FileName);
                NMOSMODEPATH.Text = openFileNMOSmodel.FileName;
                sCmosModel = NMOSMODEPATH.Text;
            }
            else
            {
                sErrorMessage = sErrorMessage + "NMOS MODEL missing\r\n";
                state = false;

            }
        
        }

        

       
        /*
        private void bChoosePMOSmodel_Click_1(object sender, EventArgs e)
        {
            if (openFilePMOSMODELFILE.ShowDialog() == DialogResult.OK)
            {
                display(openFilePMOSMODELFILE.FileName);
                PMOSMODEPATH.Text = openFilePMOSMODELFILE.FileName;
            }
            else
            {
                sErrorMessage = sErrorMessage + "PMOS MODEL missing\r\n";
                state = false;

            }

        }
        */

       

        private void textBoxTemperature_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        string sUsername= "";
        string sPassword = "";
        
        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '*';
            sPassword = textBoxPassword.Text;
            
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            sUsername = textBoxUserName.Text;
        }

        string sIstmachine;
        private void listBoxMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* int index = int.Parse(listBoxMachine[listBoxMachine - 1]);
             if (listBoxMachine.Items[index].)
             {
                 value = listBoxMachine.Items[index].Value;
                 sIstmachine = listBoxMachine. ;      

             }    
             */
        }

        string sSSHdirectory;
        private void buttonSSHdirectory_Click(object sender, EventArgs e)
        {
           // sSSHdirectory=

            if (openFileSSHdirectory.ShowDialog() == DialogResult.OK)
            {
                display(openFileSSHdirectory.FileName);
                textBoxSSHDirectory.Text = openFileSSHdirectory.FileName;
                sSSHdirectory = textBoxSSHDirectory.Text;
            }
            else
            {
                sErrorMessage = sErrorMessage + "Secure Shell Directory missing\r\n";
                state = false;

            }
        }

        private void textBoxSSHDirectory_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonNEXT_Click(object sender, EventArgs e)
        {
            double dtemp=0;
            try
            {
                dtemp = Convert.ToDouble(textBoxTemperature.Text);
            }
            catch (FormatException)
            {
                sErrorMessage = sErrorMessage + "Temprature missing\r\n";
                state = false;

            }

            PDAOptConfigs.SetsNetlistFile(sNoteListFile);
            Console.Out.WriteLine(PDAOptConfigs.GetsNetlistFile());
            PDAOptConfigs.SetssModelName(sCmosModel);
            PDAOptConfigs.SetsNetlistFile(sNoteListFile);
            PDAOptConfigs.SetdTemperature(dtemp);
            PDAOptConfigs.SetsUserName(sUsername);
            PDAOptConfigs.SetsPassword(sPassword);
            PDAOptConfigs.SetsMachineName(sIstmachine);
            PDAOptConfigs.SetsSSHDir(sSSHdirectory);
            // if everything is fine, we will set the objects of PDAoptConfigs
            if (state!=false)
            {
                PDAOptConfigs.SetssModelName(sCmosModel);
                PDAOptConfigs.SetsNetlistFile(sNoteListFile);
                PDAOptConfigs.SetdTemperature(dtemp);
                PDAOptConfigs.SetsUserName(sUsername);
                PDAOptConfigs.SetsPassword(sPassword);
                PDAOptConfigs.SetsMachineName(sIstmachine);
                PDAOptConfigs.SetsSSHDir(sSSHdirectory);
                Application.Exit();
            }
            else 
            {
                PDAOptConfigs.SetsNetlistFile(sNoteListFile);
                display(sErrorMessage);
            }
        }

       

       

        

      
       
        
       
       

      
      

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDAOptFramework
{
    ///
    /// used to hold Framework Configuration parameters,
    ///

    public static class PDAOptConfigs
    {


        private static string sProjectDir;
        public static void SetsProjectDir(string str)
        {
            sProjectDir = str;
        }
        public static string GetsProjectDir()
        {
            return sProjectDir;
        }

        private static string sModelName;
        public static void SetssModelName(string str)
        {
            sModelName = str;
        }
        public static string GetsModelName()
        {
            return sModelName;
        }

        private static double dSupplyVoltage;
        public static void SetdSupplyVoltage(double str)
        {
            dSupplyVoltage = str;
        }
        public static double GetdSupplyVoltage()
        {
            return dSupplyVoltage;
        }


        private static string sNetlistFile;
        public static void SetsNetlistFile(string str)
        {
            sNetlistFile = str;
        }
        public static string GetsNetlistFile()
        {
            return sNetlistFile;
        }


        private static double dTemperature;
        public static void SetdTemperature(double str)
        {
            dTemperature = str;
        }
        public static double GetdTemperature()
        {
            return dTemperature;
        }

        private static double dMaxPower;
        public static void SetdMaxPower(double str)
        {
            dMaxPower = str;
        }
        public static double GetdMaxPower()
        {
            return dMaxPower;
        }

        private static double dMaxArea;
        public static void SetdMaxArea(double str)
        {
            dMaxArea = str;
        }
        public static double GetdMaxArea()
        {
            return dMaxArea;
        }

        private static double dMaxDelay;
        public static void SetdMaxDelay(double str)
        {
            dMaxDelay = str;
        }
        public static double GetdMaxDelay()
        {
            return dMaxDelay;
        }

        private static string sUserName;
        public static void SetsUserName(string str)
        {
            sUserName = str;
        }
        public static string GetsUserName()
        {
            return sUserName;
        }

        private static string sPassword;
        public static void SetsPassword(string str)
        {
            sPassword = str;
        }
        public static string GetsPassword()
        {
            return sPassword;
        }

        private static string sMachineName;
        public static void SetsMachineName(string str)
        {
            sMachineName = str;
        }
        public static string GetsMachineName()
        {
            return sMachineName;
        }

        private static string sSSHDir;
        public static void SetsSSHDir(string str)
        {
            sSSHDir = str;
        }
        public static string GetsSSHDir()
        {
            return sSSHDir;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>

        public static bool init()
        {
            bool state = true;
            // check if the directory is really exited or not
            // DEFAULT VALUE c://

            // check whether the ModelName file is there.
            // make sure the chosen model file is activated.

            // check if Netlist file exited.

            // make sure the Power, Area and Delay are positive.

            // open All gate files and update temperature using ".TEMP" command

            // make sure the supply voltage is positive
            // make sure supply voltage is updated in the gates files.
            // make sure supply voltage is compatible with the model file chosen.

            // make sure ability to connect to specified host.
            // make sure you are able to start the SSH secure shell.

            // if everything pass return true else return false.
            return state;
        }


        static void Main(int[] args)
        {
            //PDAOptConfigs aa = new PDAOptConfigs();
            //aa.sProjectDir = "SDds";

            Console.Out.WriteLine("hhhh");
        }



    }// end of Class PDAOptConfigs
}

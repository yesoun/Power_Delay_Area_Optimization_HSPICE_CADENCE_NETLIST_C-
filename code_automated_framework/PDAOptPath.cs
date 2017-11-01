using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDAOptFramework
{
    /// <summary>
    /// Class used to reflerct a path information
    /// </summary>
    class PDAOptPath
    {


        private string sPathInput; 
        public void SetsPathInput(string str)
        {
            sPathInput = str;
        }
        public string GetlInputsIndx()
        {
            return sPathInput;
        }

        private string sPathOutput; 
        public void SetsPathOutput(string str)
        {
            sPathOutput = str;
        }
        public string GetsPathOutput()
        {
            return sPathOutput;
        }
        
        
        private List<PDAOptNode> lPathNodes;
        public void SetlPathNodes(List<PDAOptNode> str)
        {
            lPathNodes = str;
        }
        public List<PDAOptNode> GetlPathNodes()
        {
            return lPathNodes;
        }
            
            
        private double dPathDelay;
        public void SetdPathDelay(double str)
        {
            dPathDelay = str;
        }
        public double GetdPathDelay()
        {
            return dPathDelay;
        }

        private double dPathPower;
        public void SetdPathPower(double str)
        {
            dPathPower = str;
        }
        public double GetdPathPower()
        {
            return dPathPower;
        }


        ///
        /// MEthods definition of PDAOpt Path
        ///

    }// end class PDAOptPAth
}

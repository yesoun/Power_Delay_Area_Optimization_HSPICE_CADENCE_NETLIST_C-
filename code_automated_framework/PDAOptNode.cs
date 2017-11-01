using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDAOptFramework
{
    /// <summary>
    /// This class is used to hold information per gate include Name,Type, PMOSGATEWidth,Nmos gate width ,
    /// gate length, the gates before(inputs), the gates after(outputs),Load capacitance, Gate power, Gate delay
    /// gate area formulas or values !!
    /// </summary>
    class PDAOptNode
    {

        private string sGateName;
        public void SetsGateName(string str)
        {
            sGateName = str;
        }
        public string GetsGateName()
        {
            return sGateName;
        }

        private string sType;
        public void SetsType(string str)
        {
            sType = str;
        }
        public string GetsType()
        {
            return sType;
        }



        private double dPGateWidth;
        public void SetdPGateWidth(double str)
        {
            dPGateWidth = str;
        }
        public double GetdPGateWidth()
        {
            return dPGateWidth;
        }


        private double dNGateWidth;
        public void SetdNGateWidth(double str)
        {
            dNGateWidth = str;
        }
        public double GetdNGateWidth()
        {
            return dNGateWidth;
        }


        private double dGateLength;
        public void SetdGateLength(double str)
        {
            dGateLength = str;
        }
        public double GetdGateLength()
        {
            return dGateLength;
        }


        private List<string> lInputsIndx;
        public void SetlInputsIndx(List<string> str)
        {
            lInputsIndx = str;
        }
        public List<string> GetlInputsIndx()
        {
            return lInputsIndx;
        }

        private string sOutputsIndx;
        public void SetlOutputsIndx(string str)
        {
            sOutputsIndx = str;
        }
        public string GetsOutputsIndx()
        {
            return sOutputsIndx;
        }



        private List<PDAOptNode> lPreviousNodes;
        public void SetlPreviousNodes(List<PDAOptNode> str)
        {
            lPreviousNodes = str;
        }
        public List<PDAOptNode> GetlPreviousNodes()
        {
            return lPreviousNodes;
        }

        private List<PDAOptNode> lNextNodes;
        public void SetlNextNodes(List<PDAOptNode> str)
        {
            lNextNodes = str;
        }
        public List<PDAOptNode> GetlNextNodes()
        {
            return lNextNodes;
        }


        private double dLoadCapacitance;
        public void SetdLoadCapacitance(double str)
        {
            dLoadCapacitance = str;
        }
        public double GetdLoadCapacitance()
        {
            return dLoadCapacitance;
        }

        private double dGatePower;
        public void SetdGatePower(double str)
        {
            dGatePower = str;
        }
        public double GetdGatePower()
        {
            return dGatePower;
        }

        private double dGateDelay;
        public void SetdGateDelay(double str)
        {
            dGateDelay = str;
        }
        public double GetdGateDelay()
        {
            return dGateDelay;
        }


        private double dGateArea;
        public void SetdGateArea(double str)
        {
            dGateArea = str;
        }
        public double GetdGateArea()
        {
            return dGateArea;
        }

        ///
        ///Method Section 
        ///

        ///<summary>
        ///this method is going to be called to update the .sp files for all gates
        ///this method is going to to read SSH console output and extract needed
        ///parameters
        ///

        public bool getHSPICEvals()
        {
            bool state = false;





            return state;



        }


        /// <summary>
        /// make sure it calculates the area based on the adopted equation.
        /// </summary>
        /// <returns></returns>
        public bool CalcArea()
        {
            bool state = false;





            return state;
        }


        ///
        ///takes in parameter a value and a node and return whether or not the value
        ///is an input for the node
        ///

        public bool checkInpNode(string input)
        {
            bool state = false;
            List<string> AllInputs = this.GetlInputsIndx();
            for (int k = 0; k < AllInputs.Count(); k++)
            {
                if ((AllInputs[k].ToLower().Trim()).CompareTo(input.ToLower().Trim()) == 0)
                {
                    state = true;
                }
            }


            return state;
        }

        ///
        ///takes in parameter a value and a node and return whether or not the value
        ///is an input for the node
        ///
        public bool checkOutputNode(string soutput)
        {
            bool state;
            string Output = this.GetsOutputsIndx();
            if (soutput.ToLower().Trim().Equals(soutput.ToLower().Trim()))
            {
                state = true;
            }

            else state = false;



            return state;


        }

    }//end PDAOptNode CLASS
}

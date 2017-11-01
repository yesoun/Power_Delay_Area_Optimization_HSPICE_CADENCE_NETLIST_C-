
 ﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDAOptFramework;

namespace PDAOptFramework
{
    /// <summary>
    /// This class is used to hold all circuit nodes, inputs and outputs
    /// </summary>
    class PDAOptCircuit
    {
        private List<string> lCrctInputs = new List<string>();
        private List<string> lCrctOutputs = new List<string>();
        private List<string> lCrctGates = new List<string>();
        private List<string> lCrctAssignement = new List<string>();

        public List<PDAOptNode> lCrctNodes = new List<PDAOptNode>();
        public List<PDAOptPath> lCrctPaths = new List<PDAOptPath>();
        public List<double> lPathDelays = new List<double>();


        ///
        ///Methods definition
        ///


        ///
        ///make sure to build the circuit as set of nodes
        ///every node is a gate that has multiple characteristics, has a next and previous node 
        ///

        ///
        /// TRUE PDA OPT CIRCUIT BUT WITH LIST OF STRING AS INPUTS AND OUPUTS FOR NODES
        /// 
        /*
        public PDAOptCircuit()
        {
            lCrctInputs = PDAOptParser.getlCrctInputs();
            lCrctOutputs = PDAOptParser.getlCrctOutputs();
            lCrctGates = PDAOptParser.getlCrctGate();
            lCrctAssignement = PDAOptParser.getlCrctAssignement();

            
            for (int iterGate=0;iterGate<lCrctGates.Count;iterGate++)
            {
                PDAOptNode node=new PDAOptNode();
                string Gatename="";
                string outputGate;
                List<string> AllInputsGate=null;
                string varinp;
                int longeur;
                string[] temparrayGate = lCrctGates[iterGate].Trim().Split(',');
                outputGate = temparrayGate[temparrayGate.Length - 1];
                Gatename = temparrayGate[0];
                for(int k=1;k<temparrayGate.Length-1;k++)
                {
                    AllInputsGate.Add(temparrayGate[k]);

                }
                node.SetlInputsIndx(AllInputsGate);
                node.SetlOutputsIndx(outputGate);
                node.SetsGateName(Gatename);
                lCrctNodes.Add(node);
                   
            }
            
        }

        */

        public PDAOptCircuit()
        {
            lCrctInputs = PDAOptParser.getlCrctInputs();
            lCrctOutputs = PDAOptParser.getlCrctOutputs();
            lCrctGates = PDAOptParser.getlCrctGate();
            lCrctAssignement = PDAOptParser.getlCrctAssignement();


            ///
            /// creating for every gate a node that will contain it
            ///
            for (int iterGate = 0; iterGate < lCrctGates.Count; iterGate++)
            {
                PDAOptNode node = new PDAOptNode();
                string Gatename = "";
                string output;
                List<string> AllInputsGate = new List<string>();
                string varinp;
                int longeur;
                string[] temparrayGate = lCrctGates[iterGate].Trim().Split(',');
                output = temparrayGate[temparrayGate.Length - 1];
                Gatename = temparrayGate[0];
                for (int k = 1; k < temparrayGate.Length - 1; k++)
                {
                    AllInputsGate.Add(temparrayGate[k]);

                }
                node.SetlInputsIndx(AllInputsGate);
                node.SetlOutputsIndx(output);
                node.SetsGateName(Gatename);
                lCrctNodes.Add(node);

            } // till here all the nodes are craeted and the name,list of output, and list of inputs are setted


            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //we will set now list of next and previous nodes
            Console.Out.WriteLine("Setting list of NextNodes and Previous Nodes for every node of the circuit");
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //List<PDAOptNode> lPrevnodes = new List<PDAOptNode>();
            for (int iterNodes1 = 0; iterNodes1 < lCrctNodes.Count(); iterNodes1++)
            {
                //list of inputs of the current node
                List<string> inputs = lCrctNodes[iterNodes1].GetlInputsIndx();
                string outputIter1ate= lCrctNodes[iterNodes1].GetsOutputsIndx();
                List<PDAOptNode> lPrevnodes = new List<PDAOptNode>();
                List<PDAOptNode> lNextnodes = new List<PDAOptNode>();

                /* for (int iterInp=0;iterInp<inputs.Count();iterInp++)
                    {
                        Console.Out.WriteLine(inputs[iterInp]);
                    }*/
                for (int iterNodes2 = 0; iterNodes2 < lCrctNodes.Count(); iterNodes2++)
                {

                    // searching the previous nodes of the current one lCrctNodes[iterNodes1] and setting lPrevnodes list of nodes 
                    for (int iterInp = 0; iterInp < inputs.Count(); iterInp++)
                    {
                        string Iter2NodeOutput = lCrctNodes[iterNodes2].GetsOutputsIndx().Trim();
                        if (Iter2NodeOutput.Equals(inputs[iterInp].Trim()))
                        {
                            if (iterNodes2 != iterNodes1)
                            {
                                Console.Out.WriteLine(Iter2NodeOutput + "!!" + inputs[iterInp].Trim());
                                Console.Out.WriteLine(lCrctNodes[iterNodes2].GetsGateName() + " is previous of " + lCrctNodes[iterNodes1].GetsGateName());
                                lPrevnodes.Add(lCrctNodes[iterNodes2]);

                                //lCrctNodes[iterNodes1].GetlPreviousNodes().Add();
                            }
                        }                     
                    }//end iterator for the input


                    List<string> Iter2NodeInputs = lCrctNodes[iterNodes2].GetlInputsIndx();
                    // searching the following nodes of the current one lCrctNodes[iterNodes1] and setting lNextnodes list of nodes 
                    for (int iter2Inp = 0; iter2Inp < Iter2NodeInputs.Count(); iter2Inp++)
                    {
                        if (Iter2NodeInputs[iter2Inp].Trim().Equals(outputIter1ate.Trim()))
                        {
                            if (iterNodes2 != iterNodes1)
                            {
                                Console.Out.WriteLine((Iter2NodeInputs[iter2Inp].Trim() + "!!" + outputIter1ate.Trim()));
                                Console.Out.WriteLine(lCrctNodes[iterNodes2].GetsGateName() + " is next of " + lCrctNodes[iterNodes1].GetsGateName());
                                lNextnodes.Add(lCrctNodes[iterNodes2]);

                                //lCrctNodes[iterNodes1].GetlPreviousNodes().Add();
                            }
                        }
                    }//end iterator for the input
                    ///end of 

                }


                lCrctNodes[iterNodes1].SetlPreviousNodes(lPrevnodes);
                lCrctNodes[iterNodes1].SetlNextNodes(lNextnodes);

                Console.Out.WriteLine(lCrctNodes[iterNodes1].GetsGateName() + " has " + lCrctNodes[iterNodes1].GetlPreviousNodes().Count() + " numbers previous nodes ");
                Console.Out.WriteLine(lCrctNodes[iterNodes1].GetsGateName() + " is the previous of " + lCrctNodes[iterNodes1].GetlNextNodes().Count() + " nodes ");



            }




        }


        public void FindPath(string soutput)
        {
            List<List<PDAOptNode>> LNodesInPath = new List<List<PDAOptNode>>();
            List<PDAOptNode> lAllNodes = this.lCrctNodes;

            for (int iterNode = 2; iterNode < lAllNodes.Count(); iterNode++)
            {
                // the path having an output soutput
                List<PDAOptNode> listnode = new List<PDAOptNode>();
                string output = soutput;
                Console.Out.WriteLine(" FINDPATH");
                string outIternode=lAllNodes[iterNode].GetsOutputsIndx().Trim();
                PDAOptNode CurrentNode = new PDAOptNode();
                CurrentNode = lAllNodes[iterNode];

                while (outIternode.Equals(output.Trim()))
                {
                    //listnode.Add(CurrentNode);
                    output = lAllNodes[iterNode].GetlInputsIndx()[0];
                    //outIternode = ;
                    iterNode = 0;
                    
                    Console.Out.WriteLine(CurrentNode.GetsGateName() + "<-");
                    


                    /*if (CurrentNode.GetlInputsIndx().Count() > 1)
                    {
                        for (int k = 0; k < CurrentNode.GetlInputsIndx().Count(); k++)
                        {
                            Queue<int> q = new Queue<int>();

                        }
                    }*/





                }

            }






        }




        ///scan the the list lCrctNodes and fill the lInputsIndx and lOutputsIndx
        ///for each gate (node)

        /* public void FillCrctIndices()
         {
             // scan the the list lCrctNodes and fill the lInputsIndx and
 lOutputsIndx for each gate (node)
         }

     */
    }
}









//////////////////////previous essays

//(iterNodes2!=iterNodes1) &&
/*if ( (lCrctNodes[iterNodes2].GetsOutputsIndx().Trim().Equals(inputs[iterInp].Trim())))
{
    lPrevnodes.Add(lCrctNodes[iterNodes2]);
    Console.Out.WriteLine(lCrctNodes[iterNodes1].GetsGateName() + "node" + lCrctNodes[iterNodes2].GetsGateName());
    break;
}

else if ((iterNodes2 != iterNodes1) && (lCrctNodes[iterNodes2].checkInpNode(lCrctNodes[iterNodes1].GetsOutputsIndx())))
{

    lNextnodes.Add(lCrctNodes[iterNodes2]);

}
else
    Console.Out.WriteLine("nothing");
*/



/* for (int iterNext3=0;iterNext3<lCrctNodes.Count();iterNext3++)
 {
     Console.Out.WriteLine(lCrctNodes[iterNext3].GetsGateName()+"number of inputs gate"+lCrctNodes[iterNext3].GetlPreviousNodes().Count());
                    
  for(int k=0; k<lCrctNodes[iterNext].GetlPreviousNodes().Count();k++)
     {
         List<PDAOptNode> ll = new List<PDAOptNode>();
         ll = lCrctNodes[iterNext].GetlPreviousNodes();
      //   Console.Out.WriteLine(" the previous nodes are " + ll[k].GetsGateName());
     }
                
    // Console.Out.WriteLine("Another Gate");


 }
*/

/*      for (int iterNext = 0; iterNext < lCrctNodes.Count(); iterNext++)
      {

          Console.Out.WriteLine(lCrctNodes[iterNext].GetlPreviousNodes().Count());
      }
  */
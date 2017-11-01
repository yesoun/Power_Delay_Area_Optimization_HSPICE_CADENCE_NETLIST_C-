using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDAOptFramework
{
    /// <summary>
    /// this class is responsible for the following:
    /// -- parse the circuit file and save the generated list in the lCrctNodes.
    /// -- call the FillCrctIndices method in the PDAOptCircuit after done parsing.
    /// -- to be called to update the .sp files for all gates.
    /// -- to to read SSH console output and extract needed parameters.
    /// </summary>
    class PDAOptParser
    {
        ///
        /// to be copied to circuit object.
        ///
        private static List<string> lCrctInputs;
        public static void setlCrctInputs(List<string> list)
        {
            lCrctInputs = list;
        }
        public static List<string> getlCrctInputs()
        {
            return lCrctInputs;
        }


        private static List<string> lCrctOutputs;
        public static void setlCrctOutputs(List<string> list)
        {
            lCrctOutputs = list;
        }
        public static List<string> getlCrctOutputs()
        {
            return lCrctOutputs;
        }

        private static List<string> lCrctAssignement;
        public static void setlCrctAssignement(List<string> list)
        {
            lCrctAssignement = list;
        }
        public static List<string> getlCrctAssignement()
        {
            return lCrctAssignement;
        }

        private static List<string> lCrctGate;
        public static void setlCrctGate(List<string> list)
        {
            lCrctGate = list;
        }
        public static List<string> getlCrctGate()
        {
            return lCrctGate;
        }


        /// <summary>
        /// there is no need to : public static List<PDAOptNode> lCrctNodes;
        /// </summary>

        ///
        /// Parses the Netlist file to update the following:
        /// -- update the Wn, Wp, L.
        /// -- update the temperature, supply voltage, choose the model file.
        ///

        private bool PDAOptUpdateNetlistFile(double Wn, double Wp, double L, double Temp, double volatge, string modelName, string optionscale, string CLoad)
        {

            bool state = false;
            string[] lines = null;
            try
            {
                // getting the name and the path of the netlist file from static object sNetlistFile from PDAoptConfigs
                string sNetlisFile = PDAOptConfigs.GetsNetlistFile();
                StreamReader ReaderCircuitVerilog = File.OpenText(sNetlisFile);
                // copy all the lines of the netlist file into an array of strings
                lines = File.ReadAllLines(sNetlisFile);
                state = true;
            }

            catch (FileNotFoundException ex)
            {
                state = false;
            }
            ///
            /// Parsing the file line by line and update the values
            /// 

            ///
            /// updating nmos width and pmos width 
            /// .param N=3 
            /// .param P=3

            string sParaNameN = ".param N=";
            string sParaNameP = ".param P=";
            string sParaSupplyP = ".param SUPPLY=";
            string sModelNamePath = ".INCLUDE ";
            string sOptionScale = ".option scale=";
            string sCLoad = ".param CLoad =";
            ///
            /// Length not done yet
            /// 
            for (int k = 0; k < lines.Length; k++)
            {
                if ((lines[k].Trim().ToLower()).StartsWith(sParaNameN.Trim().ToLower()))
                {
                    sParaNameN = sParaNameN + Wn;
                    lines[k] = sParaNameN;
                }

                else if ((lines[k].Trim().ToLower()).StartsWith(sParaNameP.Trim().ToLower()))
                {
                    sParaNameP = sParaNameP + Wn;
                    lines[k] = sParaNameP;
                }


                else if ((lines[k].Trim().ToLower()).StartsWith(sParaSupplyP.Trim().ToLower()))
                {
                    sParaSupplyP = sParaSupplyP + volatge;
                    lines[k] = sParaSupplyP;
                }

                else if ((lines[k].Trim().ToLower()).StartsWith(sModelNamePath.Trim().ToLower()))
                {
                    sModelNamePath = sModelNamePath + modelName;
                    lines[k] = sModelNamePath;
                }

                else if ((lines[k].Trim().ToLower()).StartsWith(sOptionScale.Trim().ToLower()))
                {
                    sOptionScale = sOptionScale + optionscale;
                    lines[k] = sOptionScale;
                }

                else if ((lines[k].Trim().ToLower()).StartsWith(sCLoad.Trim().ToLower()))
                {
                    sCLoad = sCLoad + CLoad;
                    lines[k] = sCLoad;
                }

            }// finishing updating


            // rewriting the modified lines
            File.WriteAllLines(modelName, lines);
            return state;
        }// end of PDAOptUpdateNetlistFile


        ///
        /// used to read the list gates from the netlist file.
        /// 
        ///
        public bool PDAOptParseNetlistFile(string sNetlistCompleteDirec)
        {
            List<string> listCrctInputs = new List<string>();
            List<string> listCrctOutputs = new List<string>();
            List<string> listCrctAssignement = new List<string>();
            List<string> listCrctGate = new List<string>();



            bool state = false;
            string StrInput = "input";
            string StrOutput = "output";
            string StrAssign = "assign";
            string StrEndModule = "endmodule";
            string line = "empty";
            string line2 = "empty";
            StreamReader ReaderCircuitVerilog = File.OpenText(sNetlistCompleteDirec);
            // Parsing the file line by line and fill the number of gates in the array
            while ((line = ReaderCircuitVerilog.ReadLine()) != null)
            {
                if ((line.Trim().StartsWith(StrInput)))
                {


                    ////////////////////////////////////////////////////////////////
                    Console.Out.WriteLine("////////////////////////////////////////////////////////////////");
                    Console.Out.WriteLine("Liste of Inputs");
                    Console.Out.WriteLine("////////////////////////////////////////////////////////////////");
                    ////////////////////////////////////////////////////////////////
                    line2 = ReaderCircuitVerilog.ReadLine();
                    while ((line2.Trim().ToLower()) != StrOutput.ToLower().Trim())
                    {
                        //line2 = ReaderCircuitVerilog.ReadLine();

                        string[] tempArr1 = line2.Trim().Split(',');
                        for (int j = 0; j < tempArr1.Length; j++)
                        {
                            if (String.IsNullOrEmpty(tempArr1[j]))
                            {
                                //Console.Out.WriteLine("Output Name is empty");
                            }

                            else listCrctInputs.Add(tempArr1[j].Replace(';', ' '));


                        }


                        line2 = ReaderCircuitVerilog.ReadLine();

                    }//end while reaching output

                    // displaying list of inputs
                    for (int k = 0; k < listCrctInputs.Count; k++)
                    {
                        Console.Out.WriteLine(listCrctInputs[k]);
                    }
                    //end displaying list of inputs

                    // setting list of inputs for this circuit
                    setlCrctInputs(listCrctInputs);


                    ////////////////////////////////////////////////////////////////
                    Console.Out.WriteLine("////////////////////////////////////////////////////////////////");
                    Console.Out.WriteLine("Liste of Outputs");
                    Console.Out.WriteLine("////////////////////////////////////////////////////////////////");
                    ////////////////////////////////////////////////////////////////
                    string str;
                    while (!line2.Trim().ToLower().Contains(StrAssign))
                    {

                        string[] tempArr2 = line2.Trim().Split(',');
                        for (int j = 0; j < tempArr2.Length; j++)
                        {
                            str = tempArr2[j].Trim().Replace(';', ' ');
                            str = str.Trim().Replace("output", " ");
                            if (String.IsNullOrEmpty(str))
                            {
                                //Console.Out.WriteLine("Output Name is empty");
                            }
                            else listCrctOutputs.Add(str.Trim());
                            //ListOfOutputs.Add(tempArr2[j].Replace("output", " "));

                        }

                        line2 = ReaderCircuitVerilog.ReadLine();
                    } //end while reaching assign

                    // displaying list of Outputs
                    for (int k = 0; k < listCrctOutputs.Count; k++)
                    {
                        Console.Out.WriteLine(listCrctOutputs[k]);
                    }
                    //end displaying list of Outputs

                    //setting list of outputs for this circuit
                    setlCrctOutputs(listCrctOutputs);


                    ////////////////////////////////////////////////////////////////
                    Console.Out.WriteLine("////////////////////////////////////////////////////////////////"); 
                    Console.Out.WriteLine("Liste of Assignment output,input");
                    Console.Out.WriteLine("////////////////////////////////////////////////////////////////");
                    ////////////////////////////////////////////////////////////////
                    string strout;
                    string strinp;
                    string strassign;
                    while (line2.Trim().ToLower().StartsWith(StrAssign))
                    {
                        string[] tempArr3 = line2.Trim().Split('=');
                        strout = tempArr3[0].Trim().Replace("assign", " ");
                        strinp = tempArr3[1].Trim().Replace(';', ' ');
                        strassign = strout + "," + strinp;
                        listCrctAssignement.Add(strassign);
                        //ListOfOutputs.Add(tempArr2[j].Replace("output", " "));


                        line2 = ReaderCircuitVerilog.ReadLine();
                    } //end while reaching gates

                    // displaying list of list of assignement
                    for (int k = 0; k < listCrctAssignement.Count; k++)
                    {
                        Console.Out.WriteLine(listCrctAssignement[k]);
                    }
                    //end of displaying list of list of assignement


                    //setting list cuicrcuit assignement for inputs and outputs
                    setlCrctAssignement(listCrctAssignement);

                    ////////////////////////////////////////////////////////////////
                    Console.Out.WriteLine("////////////////////////////////////////////////////////////////");
                    Console.Out.WriteLine("Liste of Gates inputs,outputs");
                    Console.Out.WriteLine("////////////////////////////////////////////////////////////////");
                    ////////////////////////////////////////////////////////////////
                    while (!line2.Trim().ToLower().Contains(StrEndModule))
                    {
                        string strGateName = line2.Trim().Replace(");", "");
                        strGateName = strGateName.Trim().Replace("(", ",");
                        strGateName = strGateName.Trim().Replace(";", " ");
                        
                        if (String.IsNullOrEmpty(strGateName))
                        {
                            //Console.Out.WriteLine("EMPTY LINE ");
                        }
                        else listCrctGate.Add(strGateName);
                           
                        line2 = ReaderCircuitVerilog.ReadLine();
                    } //end while reaching gates
                    
                    // displaying list of list of gates
                    for (int k = 0; k < listCrctGate.Count; k++)
                    {
                        Console.Out.WriteLine(listCrctGate[k]);
                    }
                    /// setting list of gate of this circuit
                    setlCrctGate(listCrctGate);



                }// end of ((line.Trim().StartsWith(StrInput)))
            }

            return state;

        }


    }
}

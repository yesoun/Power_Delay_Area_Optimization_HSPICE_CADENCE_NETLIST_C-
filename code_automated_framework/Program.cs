using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDAOptFramework
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Console.Out.WriteLine(PDAOptConfigs.GetsNetlistFile());
            System.Console.WriteLine("BISMILLAH");
            Console.Out.WriteLine("dsdsdsdsd");
            PDAOptParser pars = new PDAOptParser();
            Console.Out.WriteLine("hhhhhh");
            bool state = pars.PDAOptParseNetlistFile(PDAOptConfigs.GetsNetlistFile());

            PDAOptCircuit aa = new PDAOptCircuit();
            Console.Out.WriteLine("length of list of all nodes" + aa.lCrctNodes.Count);
            for (int k = 0; k < aa.lCrctNodes.Count(); k++)
            {  List<PDAOptNode> nn = new List<PDAOptNode>();
                nn = aa.lCrctNodes[k].GetlPreviousNodes();
                for (int j = 0; j < aa.lCrctNodes[k].GetlPreviousNodes().Count();j++ )
                { 
                    Console.Out.WriteLine("nodes gate names : " + aa.lCrctNodes[k].GetsGateName() + "previous nodes gates names are :" + nn[j].GetsGateName());

                }               
            }

            aa.FindPath("L297");



        }
    }
}

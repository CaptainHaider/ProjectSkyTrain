//CSIS1175-002 - Muhammad Hassan Haider Student ID 300273535 - Paulo Cesar Borba Student ID 300268640
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace station
{
    public partial class frmStytrain : Form
    {
        int totalStaion = 0;
        string[] stl1 = new string[13];
        string[] stl2 = new string[4];
        string[] stl3 = new string[20];
        string[] stl4 = new string[5];
        string[] stl5 = new string[17];
        string[] stlC = new string[6];

        public frmStytrain()
        {
            InitializeComponent();
        }

        private void frmStytrain_Load(object sender, EventArgs e)
        {

            
            
            StreamReader l_Canada = File.OpenText("_CanadaLine.txt");
            StreamReader l_CanadaBranch = File.OpenText("_CanadaLine_Airport_branch.txt");
            StreamReader l_Expoline = File.OpenText("_Expo_Line.txt");
            StreamReader l_ExpolineBranch = File.OpenText("_Expo_Line_Lougheed_branch.txt");
            StreamReader l_Millenium = File.OpenText("_Millennium_Line.txt");
            StreamReader l_Connections = File.OpenText("_Connections.txt");

            HashSet<string> lstFulfill = new HashSet<string>();

            for (int i = 0; l_Canada.EndOfStream != true; i++)
            {
                stl1[i] = l_Canada.ReadLine();
                lstFulfill.Add(stl1[i]);
            }

            for (int i = 0; l_CanadaBranch.EndOfStream != true; i++)
            {
                stl2[i] = l_CanadaBranch.ReadLine();
                lstFulfill.Add(stl2[i]);
            }

            for (int i = 0; l_Expoline.EndOfStream != true; i++)
            {
                stl3[i] = l_Expoline.ReadLine();
                lstFulfill.Add(stl3[i]);
            }

            for (int i = 0; l_ExpolineBranch.EndOfStream != true; i++)
            {
                stl4[i] = l_ExpolineBranch.ReadLine();
                lstFulfill.Add(stl4[i]);
            }

            for (int i = 0; l_Millenium.EndOfStream != true; i++)
            {
                stl5[i] = l_Millenium.ReadLine();
                lstFulfill.Add(stl5[i]);
            }

            for (int i = 0; l_Connections.EndOfStream != true; i++)
            {
                stlC[i] = l_Connections.ReadLine();
            }

            foreach (string n in lstFulfill)
            {
                lstStart.Items.Add(n);
                lstEnd.Items.Add(n);
            }

        }
        private void btnRoute_Click(object sender, EventArgs e)
        {
            totalStaion = 0;
            string SourceStation = lstStart.Text; //setting source / starting point
            string DestinationStation = lstEnd.Text;//setting destination /ending point
            var vertex = 1;//destination
            var startVertex = 1;//our source

            if (SourceStation == DestinationStation)
            {
                MessageBox.Show("Please select different origin and destiny station");
            }
            else { 
                lstRoute.Items.Clear();
            var stationdetails = new StationDetails();

            List<string[]> data = new List<string[]>() { stationdetails.arrA1, stationdetails.arrA1, stationdetails.arrA2, stationdetails.arrA3, stationdetails.arrA4, stationdetails.arrA5 };

            


            //this is for finding destination array to set it to startVertex
            int pos = Array.IndexOf(stationdetails.arrA1, DestinationStation);
            if (pos > -1)
            {

                vertex = 1;


            }
            pos = Array.IndexOf(stationdetails.arrA2, DestinationStation);//pos=15
            if (pos > -1)//true
            {
                vertex = 2;//
            }
            pos = Array.IndexOf(stationdetails.arrA3, DestinationStation);
            if (pos > -1)
            {
                vertex = 3;
            }
            pos = Array.IndexOf(stationdetails.arrA4, DestinationStation);
            if (pos > -1)
            {
                vertex = 4;
            }
            pos = Array.IndexOf(stationdetails.arrA5, DestinationStation);
            if (pos > -1)
            {
                vertex = 5;
            }
            /////////////////////////////////////////

            //this is for finding source array to set it to vertex



            int poss = Array.IndexOf(stationdetails.arrA1, SourceStation);
            int chk = 0;




            if (poss > -1 && chk == 0)
            {

                startVertex = 1;
                if (poss == 0) chk = 1;
            }
            poss = Array.IndexOf(stationdetails.arrA2, SourceStation);
            if (poss > -1 && chk == 0)
            {
                startVertex = 2;
                if (poss == 0) chk = 1;
            }
            poss = Array.IndexOf(stationdetails.arrA3, SourceStation);
            if (poss > -1 && chk == 0)
            {
                startVertex = 3;
                    chk = 1;
                    // if (poss == 0) chk = 1;
                }
            poss = Array.IndexOf(stationdetails.arrA4, SourceStation);
            if (poss > -1 && chk == 0)
            {
                startVertex = 4;
               //if (poss == 0) chk = 1;
            }
            poss = Array.IndexOf(stationdetails.arrA5, SourceStation);
            if (poss > -1 && chk == 0)
            {
                startVertex = 5;
               // if (poss == 0) chk = 1;
            }

            ////////////////////////////////////////////////////


            //finding smallest route using if else//////////////////////////////////////////////////////////////////////////
            //Console.WriteLine("+++++++++++++++++++");
            var smallestRoute = new NodeFinder();
            string nodes = smallestRoute.ShortNode(startVertex, vertex);
          Console.WriteLine(nodes);

            var chars = nodes.ToCharArray();
          //  Console.WriteLine("+++++++++++++++++++");

            ///////////////////////////////////////////////////////////////////////////////////////////////
            int[] myInts = nodes.Select(c => int.Parse(c.ToString())).ToArray();
            // if (chars[0]=='3'&&chars[1]=='5')
            //           shortRoute(data[2], data[4], DestinationStation);

            string newdestination = DestinationStation;
            string newSource = SourceStation;

            lstRoute.Items.Add(SourceStation);
           // Console.WriteLine(SourceStation);//printing current station
            for (int i = 0; i < myInts.Length - 1; i++)
            {

                newdestination = shortRoute(data[myInts[i]], data[myInts[i + 1]], newdestination);
                //Console.WriteLine(newdestination);//updating new destination w.r.t connecting point
                PrintStations(data[myInts[i]], newSource, newdestination);

                newSource = newdestination;


            }

            PrintStations(data[myInts[myInts.Length - 1]], newSource, DestinationStation);

                string lastStation = "";
                int cl = lstRoute.Items.Count;

                if (lstRoute.Items.Count > 0)
                {
                    lastStation = lstRoute.Items[lstRoute.Items.Count - 1].ToString();
                }
                lstRoute.Items.RemoveAt(cl - 1);
                lastStation= lastStation.Replace("*","");
               
                lstRoute.Items.Add(lastStation);


                totalStaion++;
            txtNumStations.Text = totalStaion.ToString();

            }

            
        }

        public void PrintStations(string[] a, string startStation, string endStation)
        {
           // Console.WriteLine("/////////////////////////////////////////////////");
            int dpos = Array.IndexOf(a, endStation);
            int spos = Array.IndexOf(a, startStation);
            int counter = 0;


            if (dpos > spos)
            {

                while (dpos != spos)
                {
                    spos++;
                    counter++;
                    totalStaion++;
                    if (stlC.Contains(a[spos])==true)
                    {
                        int trans = Array.IndexOf(stlC, a[spos]);
                        lstRoute.Items.Add("*** "+stlC[trans]+" ***");
                    }
                    else
                    { 
                    lstRoute.Items.Add(a[spos]);
                    }
                }
              //  int cl = lstRoute.Items.Count;
              //  lstRoute.Items.RemoveAt(cl-1);
              //  lstRoute.Items.Add(a[spos]);


            }
            if (spos > dpos)
            {

                while (dpos != spos)
                {
                    spos--;
                    counter++;
                    totalStaion++;
                    if (stlC.Contains(a[spos]) == true)
                    {
                        int trans = Array.IndexOf(stlC, a[spos]);
                        lstRoute.Items.Add("*** " + stlC[trans] + " ***");
                    }
                    else
                    {
                        lstRoute.Items.Add(a[spos]);
                    }
                }
               // int cl = lstRoute.Items.Count;
               // lstRoute.Items.RemoveAt(cl - 1);
               // lstRoute.Items.Add(a[spos]);

            }

            

            // Console.WriteLine("/////////////////////////////////////////////////");
        }
        public string shortRoute(string[] b, string[] a, string DestinationStation)
        {

            //


            int spos;
            int counter = 0;
            int smallcounter = 100;
            string shortroute = "";


            int dpos = Array.IndexOf(a, DestinationStation);//destination postion in its station
            var listCommon = b.Intersect(a);//common connecting points


            foreach (string s in listCommon)
            {
                // Console.WriteLine(s); //for printing commoin connecting points

                spos = Array.IndexOf(b, s);//your source postion w.r.t connecting point
                ///
                if (dpos > spos)
                {

                    while (dpos != spos)
                    {
                        spos++;
                        counter++;
                    }

                }
                if (spos > dpos)
                {

                    while (dpos != spos)
                    {
                        spos--;
                        counter++;
                    }
                }
                ///
                if (counter < smallcounter) { smallcounter = counter;  shortroute = s;
                    ;
                }
                
                //Console.WriteLine("dis " + counter);//for calculating distance
                counter = 0;
            }
            //Console.WriteLine(shortroute);
            return shortroute;
            //

            /



        }
    }
}



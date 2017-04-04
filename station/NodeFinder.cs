using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace station
{
   public class NodeFinder
    {
        public string ShortNode(int startvertice, int endvertices)
        {


            //for node 1 possible routes

            if (startvertice == 1 && endvertices == 1)
                return "11";

            if (startvertice == 1 && endvertices == 2)
                return "12";

            if (startvertice == 1 && endvertices == 3)
                return "123";

            if (startvertice == 1 && endvertices == 4)
                return "123";

            if (startvertice == 1 && endvertices == 5)
                return "1235";




            //for node 2 possible routes



            if (startvertice == 2 && endvertices == 1)
                return "21";

            if (startvertice == 2 && endvertices == 2)
                return "22";

            if (startvertice == 2 && endvertices == 3)
                return "23";

            if (startvertice == 2 && endvertices == 4)
                return "234";

            if (startvertice == 2 && endvertices == 5)
                return "235";


            //for node 3 possible routes


            if (startvertice == 3 && endvertices == 1)
                return "321";

            if (startvertice == 3 && endvertices == 2)
                return "32";

            if (startvertice == 3 && endvertices == 3)
                return "33";

            if (startvertice == 3 && endvertices == 4)
                return "34";

            if (startvertice == 3 && endvertices == 5)
                return "35";



            //for node 4 possible routes


            if (startvertice == 4 && endvertices == 1)
                return "4321";

            if (startvertice == 4 && endvertices == 2)
                return "432";

            if (startvertice == 4 && endvertices == 3)
                return "43";

            if (startvertice == 4 && endvertices == 4)
                return "44";

            if (startvertice == 4 && endvertices == 5)
                return "435";


            //for node 5 possible routes


            if (startvertice == 5 && endvertices == 1)
                return "5321";

            if (startvertice == 5 && endvertices == 2)
                return "532";

            if (startvertice == 5 && endvertices == 3)
                return "53";

            if (startvertice == 5 && endvertices == 4)
                return "534";

            if (startvertice == 5 && endvertices == 5)
                return "55";


            return "";

        }
    }
}

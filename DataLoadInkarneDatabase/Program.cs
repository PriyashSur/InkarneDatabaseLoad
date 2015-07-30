using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataLoadInkarneDatabase
{
    class Program
    {

        static void Main(string[] args)
        {
            //SCRIPT INSTANTIATE
            WriteData wd = new WriteData();
            //THIS MODULE(writeIntoDatabase) WILL CALL ALL THE FUNCTION RELATED TO TABLE WHICH WILL EXECUTE THE INSERT QUERY INTO THE EMPTY TABLE.
            wd.writeIntoDatabase();
            
        }
    }
}

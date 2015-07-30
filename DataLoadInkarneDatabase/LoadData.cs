using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoadInkarneDatabase
{
    class LoadData
    {
        string path;
        string path2;
        string path3;
        csv csv;
        csv csv2;
        csv csv3;
        List<string[]> list;
        List<string[]> combList;
        List<string[]> comboInfo;
        public LoadData()
        {
            list = new List<string[]>();
            combList = new List<string[]>();
            comboInfo = new List<string[]>();
            //DATA DESIGN
            path = @"InkarneData.csv";
            csv = new csv(path);
            list = csv.parseCSV();
            //COMBO(BEST_SELLER_COMBO)
            path2 = @"BS_Details.csv";
            csv2 = new csv(path2);
            combList = csv2.parseCSV();
            //COMBO_INFO_LIST(COMBO_INFO)
            path3 = @"Combo_Info.csv";
            csv3 = new csv(path3);
            comboInfo = csv3.parseCSV();
        }

       public List<string[]> getData() { return list; }
       public List<string[]> getData2() { return combList; }
       public List<string[]> getData3() { return comboInfo; }


    }
}

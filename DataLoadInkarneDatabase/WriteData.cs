using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataLoadInkarneDatabase
{
    class WriteData
    {
        SqlConnection conn;
        string[] s9;
        string connString = "Data Source=INKARNE\\INKARNESERVER; Initial Catalog=InkarneDBS;User ID=PRIYASH;Password=Inkarne123";
        LoadData ld;
        List<string[]> list;
        List<string[]> list2;
        List<string[]> list3;
        public WriteData()
        {
            conn = new SqlConnection(connString);
            ld = new LoadData();
            list = ld.getData();
            list2 = ld.getData2();
            list3 = ld.getData3();
        }

         void writeSKUData()
        {
            if(conn.State.ToString()=="Closed")
            {
                conn.Open();
            }
            //SKU_ID
            string[] s1 = list[0];
            //SKU_CLUSTER_NUMBER
            string[] s2 = list[1];
            //SIZE_CODE
            string[] s3 = list[2];
            for (int i = 1; i <= 112; i++)
            {
                //CONSTRUCTING THE QUERY FOR 
                string query1 = "INSERT INTO SkuData(SKU_ID,SKU_Cluster_Number,Size_Code) VALUES(@sku_id,@sku_cluster_number,@size_code)";
                SqlCommand cmd = new SqlCommand(query1, conn);
                //ASSIGINING TEH VALUES
                cmd.Parameters.Add("@sku_id", SqlDbType.VarChar).Value = s1[i];
                cmd.Parameters.Add("@sku_cluster_number", SqlDbType.VarChar).Value = s2[i];
                cmd.Parameters.Add("@size_code", SqlDbType.VarChar).Value = s3[i];

                //EXECUTING THE QUERY
               // cmd.ExecuteNonQuery();


            }
        }

         void writeSKUPricingData()
        {
            //SKU_ID
            string[] s4 = list[3];
            //PRICE
            string[] s5 = list[4];
            for (int i = 1; i <= 112; i++)
            {
                string query2 = "INSERT INTO SkuPricingData(SKU_ID,price) VALUES(@sku_id,@price)";
                SqlCommand cmd = new SqlCommand(query2, conn);
                cmd.Parameters.Add("@sku_id",SqlDbType.VarChar).Value = s4[i];
                cmd.Parameters.Add("@price", SqlDbType.VarChar).Value = s5[i];

            }
        }

         void writeVendorData()
        {
            //VENDOR_ID
            string[] s6 = list[5];
            //VENDOR_NAME
            string[] s7 = list[6];
            //VENDOR_BRAND
            string[] s8 = list[7];
            //VENDOR_DESIGNER
            string[] s9 = list[8];
            this.s9 = s9;
            //VENDOR_ADDRESS
            string[] s10 = list[9];
            for(int i=1;i<=112;i++)
            {
                string query3 = "INSERT INTO VenderData(Vendor_ID,Vendor_Name,Vendor_Brand,Vendor_Address) VALUES(@vendor_id,@vendor_name,@vendor_brand,@vendor_address)";
                SqlCommand cmd = new SqlCommand(query3, conn);
                //EXTRA NEW COLUMN VENDOR_DESIGNER WHICH IS NOT IN THE DATABASE
                cmd.Parameters.Add("@vendor_id", SqlDbType.VarChar).Value = s6[i];
                cmd.Parameters.Add("@vendor_name", SqlDbType.VarChar).Value = s7[i];
                cmd.Parameters.Add("@vendor_brand", SqlDbType.VarChar).Value = s8[i];
                //DATABASE TABLE(VenderData) DESIGNER COLUMN IS NOT THERE
               // cmd.Parameters.Add("@vendor_designer", SqlDbType.VarChar).Value = s9[i];
                cmd.Parameters.Add("@vendor_address", SqlDbType.VarChar).Value = s10[i];

                //cmd.ExecuteNonQuery();
            }
        }

         void writeSKUAttributes()
        {
            //SKU_Cluster_Number
            string[] s11 = list[10];
            //Gender
            string[] s12 = list[11];
            //Type
            string[] s13 = list[12];
            //SOURCE
            string[] s14 = list[13];
            //VENDOR_ID
            string[] s15 = list[14];
            //SKU_CATEGORY
            string[] s16 = list[15];
            //APPAREL_TYPE
            string[] s17 = list[16];
            //STYLE_CATEGORY
            string[] s18 = list[17];
            //WEARING CONTEXT
            string[] s19 = list[18];
            //BASE_COLOR
            string[] s20 = list[19];
            //COLOR_PRINT
            string[] s21 = list[20];
            //FABRIC
            string[] s22 = list[21];
            //STYLE_PATTERN
            string[] s23 = list[22];
            //FIT
            string[] s24 = list[23];
            //DESCRIPTION
            string[] s25 = list[24];
            //CARE_LABEL
            string[] s26 = list[25];
       

            for (int i = 1; i <= 112; i++)
            {
                string query4 = "INSERT INTO SkuAttributes(SKU_Cluster_Number,Gender,Type,Source,Vendor_ID,Designer,SKU_Category,Apparal_Type,Style_Category,Wearing_Context,Base_Colour,Colour_Print,Fabric,Style_Pattern,Fit,Description,Care_Label) VALUES(" +
                                                         "@SKU_Cluster_Number,@Gender,@Type,@Source,@Vendor_ID,@Designer,@SKU_Category,@Apparal_Type,@Style_Category,@Wearing_Context,@Base_Colour,@Colour_Print,@Fabric,@Style_Pattern,@fit,@Description,@Care_Label)";

                SqlCommand cmd = new SqlCommand(query4, conn);
                //INSERTING THE VALUES PARSED FROM CSV FILE 
                cmd.Parameters.Add("@SKU_Cluster_Number", SqlDbType.VarChar).Value = s11[i];
                cmd.Parameters.Add("@Gender", SqlDbType.Char).Value = s12[i];
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = s13[i];
                cmd.Parameters.Add("@Source", SqlDbType.VarChar).Value = s14[i];
                cmd.Parameters.Add("@Vendor_ID", SqlDbType.VarChar).Value = s15[i];
                cmd.Parameters.Add("@Designer", SqlDbType.VarChar).Value = s9[i];
                cmd.Parameters.Add("@SKU_Category", SqlDbType.VarChar).Value = s16[i];
                cmd.Parameters.Add("@Apparal_Type", SqlDbType.VarChar).Value = s17[i];
                cmd.Parameters.Add("@Style_Category", SqlDbType.VarChar).Value = s18[i];
                cmd.Parameters.Add("@Wearing_Context", SqlDbType.VarChar).Value = s19[i];
                cmd.Parameters.Add("@Base_Colour", SqlDbType.VarChar).Value = s20[i];
                cmd.Parameters.Add("@Colour_Print", SqlDbType.VarChar).Value = s21[i];
                cmd.Parameters.Add("@Fabric", SqlDbType.VarChar).Value = s22[i];
                cmd.Parameters.Add("@Style_Pattern", SqlDbType.VarChar).Value = s23[i];
                cmd.Parameters.Add("@fit", SqlDbType.VarChar).Value = s24[i];
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = s25[i];
                cmd.Parameters.Add("@Care_Label", SqlDbType.VarChar).Value = s26[i];

                //EXECUTING THE QUERY
                //cmd.ExecuteNonQuery();

            }

        }


         void writeSKULogic()
        {
            //SKU_CLUSTER_NUMBER
            string[] s1 = list[50];
            //SKU_TITLE
            string[] s2 = list[51];
            //BEST_SELLER_FLAG
            string[] s3 = list[52];
            //BEST_SELLER_CLUSTER_1
            string[] s4 = list[53];
            //BEST_SELLER_CLUSTER_2
            string[] s5 = list[54];
            //LAYER
            string[] s6 = list[55];
            //COMBO_FLAG
            string[] s7 = list[56];
            //COMBO_CLUSTER_1
            string[] s8 = list[57];

            for(int i=1;i<=112;i++)
            {
                string query5 = "INSERT INTO SkuLogic(SKU_Cluster_Number,SKU_Title,Best_Seller_Flag,Best_Seller_Cluster1,Best_Seller_Cluster2,Layer,Combo_Flag,Combo_Cluster1) VALUES(@SKU_Cluster_Number,@SKU_Title,@Best_Seller_Flag,@Best_Seller_Cluster1,@Best_Seller_Cluster2,@Layer,@Combo_Flag,@Combo_Cluster1)";
                SqlCommand cmd = new SqlCommand(query5, conn);

                cmd.Parameters.Add("@SKU_Cluster_Number", SqlDbType.VarChar).Value = s1[i];
                cmd.Parameters.Add("@SKU_Title", SqlDbType.VarChar).Value = s2[i];
                cmd.Parameters.Add("@Best_Seller_Flag", SqlDbType.VarChar).Value = s3[i];
                cmd.Parameters.Add("@Best_Seller_Cluster1", SqlDbType.VarChar).Value = s4[i];
                cmd.Parameters.Add("@Best_Seller_Cluster2", SqlDbType.VarChar).Value = s5[i];
                cmd.Parameters.Add("@Layer", SqlDbType.Int).Value = Convert.ToInt16(s6[i].ToString());
                cmd.Parameters.Add("@Combo_Flag", SqlDbType.VarChar).Value = s7[i];
                cmd.Parameters.Add("@Combo_Cluster1", SqlDbType.VarChar).Value = s8[i];

                //cmd.ExecuteNonQuery();
            }
        }

         void writeFashionRatingDescription()
        {
            string[] s1 = list[58];
            string[] s2 = list[59];
            string[] s3 = list[60];
            string[] s4 = list[61];
            string[] s5 = list[62];
            string[] s6 = list[63];
            string[] s7 = list[64];
            string[] s8 = list[65];
            string[] s9 = list[66];
            string[] s10 = list[67];
            string[] s11 = list[68];

            for(int i=1;i<=112;i++)
            {
                string query6 = "INSERT INTO FashionRatingDescription(SKU_Cluster_Number,SR1D,SR2D,SR3D,SR4D,SR5D,FR1D,FR2D,FR3D,FR4D,FR5D) VALUES(@SKU_Cluster_Number,@SR1D,@SR2D,@SR3D,@SR4D,@SR5D,@FR1D,@FR2D,@FR3D,@FR4D,@FR5D)";
                SqlCommand cmd = new SqlCommand(query6, conn);
                cmd.Parameters.Add("@SKU_Cluster_Number", SqlDbType.VarChar).Value = s1[i];
                cmd.Parameters.Add("@SR1D", SqlDbType.VarChar).Value = s2[i];
                cmd.Parameters.Add("@SR2D", SqlDbType.VarChar).Value = s3[i];
                cmd.Parameters.Add("@SR3D", SqlDbType.VarChar).Value = s4[i];
                cmd.Parameters.Add("@SR4D", SqlDbType.VarChar).Value = s5[i];
                cmd.Parameters.Add("@SR5D", SqlDbType.VarChar).Value = s6[i];
                cmd.Parameters.Add("@FR1D", SqlDbType.VarChar).Value = s7[i];
                cmd.Parameters.Add("@FR2D", SqlDbType.VarChar).Value = s8[i];
                cmd.Parameters.Add("@FR3D", SqlDbType.VarChar).Value = s9[i];
                cmd.Parameters.Add("@FR4D", SqlDbType.VarChar).Value = s10[i];
                cmd.Parameters.Add("@FR5D", SqlDbType.VarChar).Value = s11[i];

                //EXECUTING THE QUERY
                //cmd.ExecuteNonQuery();
             
            }

        }

         void writeStyleRatingData()
        {
            string[] s1 = list[71];
            string[] s2 = list[72];
            string[] s3 = list[73];
            string[] s4 = list[74];
            string[] s5 = list[75];
            string[] s6 = list[76];
            string[] s7 = list[77];
            string[] s8 = list[78];
            string[] s9 = list[79];
            string[] s10 = list[80];
            string[] s11 = list[81];
            string[] s12 = list[82];
            string[] s13 = list[83];

            for(int i=1;i<=112;i++)
            {
                string query7 = "INSERT INTO StyleRatingTable(SKU_Cluster_Number,SKU_BTM1_SR,SKU_BTM2_SR,SKU_BTM3_SR,SKU_BTM4_SR,SKU_BTM5_SR,SKU_BTM6_SR,SKU_BTM7_SR,SKU_BTF1_SR,SKU_BTF2_SR,SKU_BTF3_SR,SKU_BTF4_SR,SKU_BTF5_SR) VALUES(@SKU_Cluster_Number,@SKU_BTM1_SR,@SKU_BTM2_SR,@SKU_BTM3_SR,@SKU_BTM4_SR,@SKU_BTM5_SR,@SKU_BTM6_SR,@SKU_BTM7_SR,@SKU_BTF1_SR,@SKU_BTF2_SR,@SKU_BTF3_SR,@SKU_BTF4_SR,@SKU_BTF5_SR)";

                SqlCommand cmd = new SqlCommand(query7, conn);
                cmd.Parameters.Add("@SKU_Cluster_Number", SqlDbType.VarChar).Value = s1[i];
                cmd.Parameters.Add("@SKU_BTM1_SR", SqlDbType.VarChar).Value = s2[i];
                cmd.Parameters.Add("@SKU_BTM2_SR", SqlDbType.VarChar).Value = s3[i];
                cmd.Parameters.Add("@SKU_BTM3_SR", SqlDbType.VarChar).Value = s4[i];
                cmd.Parameters.Add("@SKU_BTM4_SR", SqlDbType.VarChar).Value = s5[i];
                cmd.Parameters.Add("@SKU_BTM5_SR", SqlDbType.VarChar).Value = s6[i];
                cmd.Parameters.Add("@SKU_BTM6_SR", SqlDbType.VarChar).Value = s7[i];
                cmd.Parameters.Add("@SKU_BTM7_SR", SqlDbType.VarChar).Value = s8[i];
                cmd.Parameters.Add("@SKU_BTF1_SR", SqlDbType.VarChar).Value = s9[i];
                cmd.Parameters.Add("@SKU_BTF2_SR", SqlDbType.VarChar).Value = s10[i];
                cmd.Parameters.Add("@SKU_BTF3_SR", SqlDbType.VarChar).Value = s11[i];
                cmd.Parameters.Add("@SKU_BTF4_SR", SqlDbType.VarChar).Value = s12[i];
                cmd.Parameters.Add("@SKU_BTF5_SR", SqlDbType.VarChar).Value = s13[i];

                //cmd.ExecuteNonQuery();
                

            }
            
        }



        //2ND PHASE

        void writeBestSellerInfo()
        {
            string query8 = "INSERT INTO BSDetails(BS_Code,BS_Description,BS_Price,BS_SKU_Top,BS_SKU_Bottom,BS_SKU_Jacket) VALUES(@BS_Code,@BS_Description,@BS_Price,@BS_SKU_Top,@BS_SKU_Bottom,@BS_SKU_Jacket)";
           
            for (int i = 1; i < list2.Count(); i++)
            {
                SqlCommand cmd = new SqlCommand(query8, conn);
                string[] s1 = list2[i];
                cmd.Parameters.Add("@BS_Code", SqlDbType.VarChar).Value = s1[0];
                cmd.Parameters.Add("@BS_Description", SqlDbType.VarChar).Value = s1[1];
                cmd.Parameters.Add("@BS_Price", SqlDbType.VarChar).Value = s1[2];
                cmd.Parameters.Add("@BS_SKU_Top", SqlDbType.VarChar).Value = s1[3];
                cmd.Parameters.Add("@BS_SKU_Bottom", SqlDbType.VarChar).Value = s1[4];
                cmd.Parameters.Add("@BS_SKU_Jacket", SqlDbType.VarChar).Value = s1[5];

                //cmd.ExecuteNonQuery();
            }

        }

        void writeComboInfo()
        {
            string query9 = "INSERT INTO ComboDetails(Combo_Code,Combo_Description,Combo_Price,Combo_SKU_Top,Combo_SKU_Bottom) VALUES(@Combo_Code,@Combo_Description,@Combo_Price,@Combo_SKU_Top,@Combo_SKU_Bottom)";
            for(int i=1;i<list3.Count();i++)
            {
                SqlCommand cmd = new SqlCommand(query9, conn);
                string[] s1 = list3[i];
                cmd.Parameters.Add("@Combo_Code", SqlDbType.VarChar).Value = s1[0];
                cmd.Parameters.Add("@Combo_Description", SqlDbType.VarChar).Value = s1[1];
                cmd.Parameters.Add("@Combo_Price", SqlDbType.VarChar).Value = s1[2];
                cmd.Parameters.Add("@Combo_SKU_Top", SqlDbType.VarChar).Value = s1[3];
                cmd.Parameters.Add("@Combo_SKU_Bottom", SqlDbType.VarChar).Value = s1[4];

                //cmd.ExecuteNonQuery();

            }
        }

        public void writeIntoDatabase()
        {
            writeSKUData();
            writeSKUPricingData();
            writeVendorData();
            writeSKUAttributes();
            writeSKULogic();
            writeFashionRatingDescription();
            writeStyleRatingData(); 
  
        }
    }
}

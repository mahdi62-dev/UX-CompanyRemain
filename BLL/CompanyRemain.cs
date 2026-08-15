using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace BLL
{

    public class CompanyRemain
    {
        APP.ConvertDtToList _appConvertDtToList = new APP.ConvertDtToList();
        APP.ConvertDRowToModel _appConvertDRowToModel = new APP.ConvertDRowToModel();

        public List<Models.CompanyRemain> GetCompanyRemain()
        {
            var tsql = @"
                SELECT *
                FROM Masih.dbo.vCompanyRemain
                ";

            SqlCommand com = new SqlCommand();
           

            var dalData = new DataService();
            var dt = dalData.GetDataTableByText(CSet.cnStringHIS, com, tsql);

            return _appConvertDtToList.ConvertDataTable<Models.CompanyRemain>(dt);

        }


        public List<Models.CompanyRemain> GetCompanyRemainCRUD(Models.CompanyRemain cr)
        {
            var com = new SqlCommand();

            com.Parameters.AddWithValue("@CRUD", cr.CRUD);

            com.Parameters.AddWithValue("@Rec", cr.Rec);
            com.Parameters.AddWithValue("@Code", cr.Code);
            com.Parameters.AddWithValue("@CodeMeli", cr.CodeMeli);
            com.Parameters.AddWithValue("@Name", cr.Name);
            com.Parameters.AddWithValue("@Type", cr.Type);
            com.Parameters.AddWithValue("@B1401", cr.B1401);
            com.Parameters.AddWithValue("@B1402", cr.B1402);
            com.Parameters.AddWithValue("@B1403", cr.B1403);
            com.Parameters.AddWithValue("@B1404", cr.B1404);
            com.Parameters.AddWithValue("@B1405", cr.B1405);
            com.Parameters.AddWithValue("@BBarAvordi", cr.BBaravordi);

            com.Parameters.AddWithValue("@BTotal", cr.BTotal);

            com.Parameters.AddWithValue("@P98", cr.P98);
            com.Parameters.AddWithValue("@P99", cr.P99);
            com.Parameters.AddWithValue("@P1400", cr.P1400);
            com.Parameters.AddWithValue("@P1401", cr.P1401);
            com.Parameters.AddWithValue("@P1402", cr.P1402);
            com.Parameters.AddWithValue("@P1403", cr.P1403);
            com.Parameters.AddWithValue("@P1404", cr.P1404);
            com.Parameters.AddWithValue("@P1405", cr.P1405);

            com.Parameters.AddWithValue("@Note", cr.Note);
            com.Parameters.AddWithValue("@IR", cr.IR);
            com.Parameters.AddWithValue("@DepositID", cr.DepositID);


            

            var dalData = new DataService();
            var dt = dalData.GetDataTableBySP(CSet.cnStringMasih, com, "spCompanyRemain");
            return _appConvertDtToList.ConvertDataTable<Models.CompanyRemain>(dt);
        }

    }
}
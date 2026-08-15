using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL;

public class ADR
{
    APP.ConvertDtToList _appConvertDtToList = new APP.ConvertDtToList();
    APP.ConvertDRowToModel _appConvertDRowToModel = new APP.ConvertDRowToModel();

    public List<Models.ADR> GetAdrListSP(string ADName)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", 1);
        com.Parameters.AddWithValue("@FuncType", 1);
        com.Parameters.AddWithValue("@ADName", ADName);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringMasih, com, "spADR");
        return _appConvertDtToList.ConvertDataTable<Models.ADR>(dt);
    }

    public List<Models.ADR> GetAdrListSpTSQL(string TSQL)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", 1);
        com.Parameters.AddWithValue("@FuncType", 1);
        com.Parameters.AddWithValue("@TSQL", TSQL);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringMasih, com, "spADR");
        return _appConvertDtToList.ConvertDataTable<Models.ADR>(dt);
    }

    public List<Models.ADR> ADRCRUD(Models.ADR adr)
    {
        var com = new SqlCommand();

        com.Parameters.AddWithValue("@CRUD", adr.CRUD);
        com.Parameters.AddWithValue("@FuncType", adr.FuncType);
        com.Parameters.AddWithValue("@ADID", adr.ADID);
        com.Parameters.AddWithValue("@ID", adr.ID);
        com.Parameters.AddWithValue("@Name", adr.Name);
        com.Parameters.AddWithValue("@Name2", adr.Name2);
        com.Parameters.AddWithValue("@Val1", adr.Val1);
        com.Parameters.AddWithValue("@Val2", adr.Val2);

        com.Parameters.AddWithValue("@Name3", adr.Name3);
        com.Parameters.AddWithValue("@Explain", adr.Explain);
        com.Parameters.AddWithValue("@ParentADID", adr.ParentADID);
        com.Parameters.AddWithValue("@ParentID", adr.ParentID);
        com.Parameters.AddWithValue("@GroupName", adr.GroupName);
        com.Parameters.AddWithValue("@SortID", adr.SortID);
        com.Parameters.AddWithValue("@GroupA", adr.GroupA);
        com.Parameters.AddWithValue("@MapIDA", adr.MapIDA);
        com.Parameters.AddWithValue("@ValStr1", adr.ValStr1);
        com.Parameters.AddWithValue("@ValStr2", adr.ValStr2);
        com.Parameters.AddWithValue("@CenterID", adr.CenterID);

        com.Parameters.AddWithValue("@IsDisable", adr.isDisable);

        var dalData = new DataService();
        var dt = dalData.GetDataTableBySP(CSet.cnStringMasih, com, "spADR");
        return _appConvertDtToList.ConvertDataTable<Models.ADR>(dt);
    }
}
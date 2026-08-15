using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

public class ADR
{
    public int CRUD { get; set; } // int, not null
    public int FuncType { get; set; } // int, not null
    public int ADID { get; set; } // int, not null
    public string ADName { get; set; } // nvarchar(50), not null
    public int ID { get; set; } // int, not null
    public string Name { get; set; } // nvarchar(100), null
    public string Explain { get; set; } // nvarchar(100), null
    public bool isDisable { get; set; } // bit, not null
    public string Name2 { get; set; } // nvarchar(100), null
    public string Name3 { get; set; } // nvarchar(100), null
    public int ParentADID { get; set; } // int, not null
    public int ParentID { get; set; } // int, not null
    public string GroupName { get; set; } // nvarchar(1000), null
    public string GroupA { get; set; } // nvarchar(1000), null
    public int SortID { get; set; } // int, not null
    public int MapIDA { get; set; } // int, not null
    public int Val1 { get; set; } // int, not null
    public string ValStr1 { get; set; } // nvarchar(max), null
    public int Val2 { get; set; } // int, not null
    public string ValStr2 { get; set; } // nvarchar(max), null
    public string Text => $"{Name} {Name2}";
    public int CenterID { get; set; } // int, not null

}

[Table("AD")]
[Description("جدول لیستها")]
public class AD
{
    public AD()
    {
        isDisable = false;
        IsHardCode = true;
        IsEditable = false;
    }

    [Key]
    [Column(Order = 1)]
    [Description("کد")]
    public int ID { get; set; } // int, not null

    [Key]
    [Column(Order = 2)]
    [MaxLength(50)]
    [Description("نام")]
    public string Name { get; set; } // nvarchar(50), not null

    [MaxLength(50)] public string DName { get; set; } // nvarchar(50), null
    [Description("غیرفعال")] public bool isDisable { get; set; } // bit, not null
    [MaxLength] public string Explain { get; set; } // nvarchar(max), null
    [MaxLength(100)] public string StandardName { get; set; } // nvarchar(100), null
    public bool IsHardCode { get; set; } // bit, not null
    public bool IsEditable { get; set; } // bit, not null
}
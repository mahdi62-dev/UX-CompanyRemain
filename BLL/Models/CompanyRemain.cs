using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models
{
    [Table("CompanyRemain")]
    public class CompanyRemain
    {
        public int? CRUD { get; set; } // float, null

        public int? Rec { get; set; } // float, null
        public int Code { get; set; } // float, null
        public string CodeName { get; set; } // nvarchar(255), null

        [MaxLength(255)]
        public string CodeMeli { get; set; } // nvarchar(255), null
        [MaxLength(255)]
        public string Name { get; set; } // nvarchar(255), null
        [MaxLength(255)]
        public string Type { get; set; } // nvarchar(255), null
        public double? B1401 { get; set; } // float, null
        public double? B1402 { get; set; } // float, null
        public double? B1403 { get; set; } // float, null
        public double? B1404 { get; set; } // float, null
        public double? B1405 { get; set; } // float, null

        public double? BBaravordi { get; set; } // float, null

        public double? BTotal { get; set; } // float, null

        //public double? Total { get; set; } // float, null

        public double? P98 { get; set; } // float, null
        public double? P99 { get; set; } // float, null
        public double? P1400 { get; set; } // float, null
        public double? P1401 { get; set; } // float, null
        public double? P1402 { get; set; } // float, null
        public double? P1403 { get; set; } // float, null
        public double? P1404 { get; set; } // float, null
        public double? P1405 { get; set; } // float, null

        public string ActionDate { get; set; } // nvarchar(255), null
        public string Note { get; set; } // nvarchar(255), null
        public string IR { get; set; } // nvarchar(255), null
        public string DepositID { get; set; } // nvarchar(255), null

        
    }

}
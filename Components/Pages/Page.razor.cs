using APP;
using BLL.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using DevExpress.Blazor;
using DevExpress.Pdf.Native.DocumentSigning;
using BLL;
using Microsoft.JSInterop;
using DevExpress.ClipboardSource.SpreadsheetML;
using Microsoft.AspNetCore.Components.Authorization;


namespace UX.Components.Pages
{
    public partial class Page : ComponentBase, IDisposable
    {
        protected List<BLL.Models.CompanyRemain> _CompanyRemainList = new();
        protected BLL.Models.CompanyRemain _CompanyRemain = new();

        protected BLL.CompanyRemain _bllCompanyRemain = new();
        private IGrid MyGrid { get; set; }
        private const string ExportFileName = "ExportResult";
        protected bool PanelVisible, _EnableSave = true;
        protected string LoadingPanelText, _Date;
        protected Toast MyToast = new();

        protected readonly BLL.ADR _bllADR = new();
        protected List<BLL.Models.ADR> _AdrRemainTypeList = new();

        protected BLL.Models.ADR _AdrRemainType = new();

        protected int _Code;
        protected int _GridPageSize = 10;
        private DotNetObjectReference<Page> _pageReference;

        // داده‌ها و وضعیت پاپ‌آپ گزارش توزیع بدهی
        protected bool _DebtDistributionPopupVisible;
        protected string _DebtDistributionReportDate = string.Empty;
        protected List<DebtDistribution> _DebtDistributionList = new();
        protected override void OnInitialized()
        {
            _AdrRemainTypeList = _bllADR.GetAdrListSP("RemainType");

            LoadTable();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _pageReference = DotNetObjectReference.Create(this);
                await JS.InvokeVoidAsync("companyRemainGrid.initialize", _pageReference);
            }
        }

        [JSInvokable]
        public async Task SetGridPageSize(int pageSize)
        {
            if (_GridPageSize != pageSize)
            {
                _GridPageSize = pageSize;
                await InvokeAsync(StateHasChanged);
            }
        }

        protected void LoadTable()
        {
            _CompanyRemain.CRUD = 1;
            _CompanyRemainList = _bllCompanyRemain.GetCompanyRemainCRUD(_CompanyRemain);
            _Date = _CompanyRemainList.OrderByDescending(b => b.ActionDate).FirstOrDefault().ActionDate;

        }

        private async Task ExportXlsxItem_Click()
        {
            await MyGrid.ExportToXlsxAsync(ExportFileName);
        }
        private void ColumnChooserButton_Click()
        {
            MyGrid.ShowColumnChooser();
        }
        private void Grid_CustomizeSummaryDisplayText(GridCustomizeSummaryDisplayTextEventArgs e)
        {
            //e.DisplayText = "جمع: " + Convert.ToInt64(e.Value).ToString("N0");
            e.DisplayText = Convert.ToInt64(e.Value).ToString("N0");

            if (e.Item.FieldName == "Name")
            {
                e.DisplayText = "تعداد: " + Convert.ToInt64(e.Value).ToString("N0");
            }
        }

        private async Task OnEditModelSaving(GridEditModelSavingEventArgs e)
        {
            if (e.IsNew)
            {
                var item = (BLL.Models.CompanyRemain)e.EditModel;

                _CompanyRemainList.Add((BLL.Models.CompanyRemain)e.EditModel);

                item.CRUD = 0;
                item.BTotal = item.B1401 + item.B1402 + item.B1403;

                _bllCompanyRemain.GetCompanyRemainCRUD(item);

            }

            //if (e.IsNew == false)
            //{
            //    var item = (BLL.Models.CompanyRemain)e.EditModel;
            //    e.CopyChangesToDataItem();
            //}

            if (e.IsNew == false)
            {
                var item = (BLL.Models.CompanyRemain)e.EditModel;
                e.CopyChangesToDataItem();

                item.CRUD = 2;
                item.BTotal = item.B1401 + item.B1402 + item.B1403;
                //item.Code = _CompanyRemain.Code;

                _bllCompanyRemain.GetCompanyRemainCRUD(item);
            }

            LoadTable();

        }
        private async Task OnCodeChanged(object newValue, BLL.Models.CompanyRemain issue)
        {

            var item = issue;

            item.CRUD = 2;
            item.Code = (int)newValue;

            _bllCompanyRemain.GetCompanyRemainCRUD(item);

            LoadTable();

        }
        private async Task AsyncSave()
        {
            //_EnableSave = false;
            //LoadingPanelText = "در حال ذخیره ...";
            //PanelVisible = true;

            //await Task.Run(() => DoSave());

            //PanelVisible = false;
            //_EnableSave = true;

            // MyToast.ToastShow("ذخیره گردید", null);

        }

        protected void DoSave()
        {
            //_CompanyRemain.CRUD = 3;
            //_bllCompanyRemain.GetCompanyRemainCRUD(_CompanyRemain);


            //foreach (var cr in _CompanyRemainList)
            //{
            //    cr.CRUD = 0;
            //    cr.BTotal = cr.B1401 + cr.B1402 + cr.B1403;

            //    _bllCompanyRemain.GetCompanyRemainCRUD(cr);
            //}

            MyToast.ToastShow("ذخیره گردید", null);
            LoadTable();
        }

        private async Task DoDash()
        {
            await JS.InvokeVoidAsync("openInNewTab", "http://192.168.86.120/ReportsMasih/powerbi/Accounting/CompanyRemain");
        }

        private Task OpenDebtDistributionReport()
        {
            LoadDebtDistributionReport();
            _DebtDistributionPopupVisible = true;
            return Task.CompletedTask;
        }

        private void LoadDebtDistributionReport()
        {
            var now = DateTime.Now;
            var pc = new PersianCalendar();
            _DebtDistributionReportDate = $"{pc.GetYear(now):0000}/{pc.GetMonth(now):00}/{pc.GetDayOfMonth(now):00} - {now:HH:mm}";

            var activityNames = _AdrRemainTypeList.ToDictionary(x => x.ID, x => x.Name);
            _DebtDistributionList = _CompanyRemainList
                .GroupBy(x => x.Code)
                .Select(x =>
                {
                    // فیلدهای مبلغ در مدل از نوع double? هستند؛ مقادیر null صفر در نظر گرفته می‌شوند.
                    var estimatedCommitment = x.Sum(i => i.BBaravordi ?? 0d);
                    var totalDebt = x.Sum(i =>
                        (i.B1401 ?? 0d) +
                        (i.B1402 ?? 0d) +
                        (i.B1403 ?? 0d) +
                        (i.B1404 ?? 0d) +
                        (i.B1405 ?? 0d) +
                        (i.BBaravordi ?? 0d));
                    return new DebtDistribution
                    {
                        ActivityName = activityNames.TryGetValue(x.Key, out var activityName) ? activityName : "بدون طبقه‌بندی",
                        EstimatedCommitment = estimatedCommitment,
                        TotalDebt = totalDebt,
                        // بدهی واقعی: بدهی کل منهای تعهد برآوردی
                        Debt = totalDebt - estimatedCommitment
                    };
                })
                // طبقه‌هایی که هر سه مبلغ آن‌ها صفر است در گزارش نمایش داده نمی‌شوند.
                .Where(x => x.Debt != 0 || x.EstimatedCommitment != 0 || x.TotalDebt != 0)
                .OrderByDescending(x => x.TotalDebt)
                .ToList();

            for (var i = 0; i < _DebtDistributionList.Count; i++)
                _DebtDistributionList[i].Rec = i + 1;
        }

        private async Task PrintDebtDistributionReport()
        {
            await JS.InvokeVoidAsync("printDebtDistributionReport");
        }

        private void CloseDebtDistributionReport()
        {
            _DebtDistributionPopupVisible = false;
        }

        private void DebtDistribution_CustomizeSummaryDisplayText(GridCustomizeSummaryDisplayTextEventArgs e)
        {
            e.DisplayText = Convert.ToDecimal(e.Value).ToString("N0");
            if (e.Item.FieldName == "ActivityName")
                e.DisplayText = "تعداد: " + Convert.ToInt32(e.Value).ToString("N0");
        }

        void Grid_CustomizeElement(GridCustomizeElementEventArgs e)
        {
            if (e.ElementType == GridElementType.DataRow && e.VisibleIndex % 2 == 1)
            {
                e.CssClass = "alt-item";
            }

            if (e.ElementType == GridElementType.HeaderCell)
            {
                var a = e.Column.Caption;
                if (e.Column.Caption == "بدهی کل")
                {
                    //e.Style = "highlighted-item";
                    e.CssClass = "text-danger";
                }

                if (e.Column.Caption == "بدهی برآوردی" || e.Column.Caption == "بدهی 1405"|| e.Column.Caption == "بدهی 1404" || e.Column.Caption == "بدهی 1403" || e.Column.Caption == "بدهی 1402" || e.Column.Caption == "بدهی 1401")
                {
                    //e.Style = "highlighted-item";
                    e.CssClass = "text-warning";
                }



                if (e.Column.Caption == "پرداخت 1405" ||e.Column.Caption == "پرداخت 1404" || e.Column.Caption == "پرداخت 1403" || e.Column.Caption == "پرداخت 1402" || e.Column.Caption == "پرداخت 1401")
                {
                    //e.Style = "highlighted-item";
                    e.CssClass = "text-success";
                }
            }
        }
        async Task NewItem_Click()
        {
            await MyGrid.StartEditNewRowAsync();
        }

        protected class DebtDistribution
        {
            public int Rec { get; set; }
            public string ActivityName { get; set; }
            public double Debt { get; set; }
            public double EstimatedCommitment { get; set; }
            public double TotalDebt { get; set; }
        }

        public void Dispose()
        {
            _pageReference?.Dispose();
        }

        #region inject
        [Inject] protected NavigationManager NavigationManager { get; set; }

        [Inject] IJSRuntime JS { get; set; }

        #endregion

    }
}
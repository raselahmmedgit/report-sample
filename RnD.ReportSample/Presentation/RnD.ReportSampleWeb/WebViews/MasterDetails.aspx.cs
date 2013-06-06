using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using RnD.ReportSampleService;
using RnD.ReportSampleWeb.ViewModels;
using MasterDetailsViewModel = RnD.ReportSampleViewModel.MasterDetailsViewModel;

namespace RnD.ReportSampleWeb.WebViews
{
    public partial class MasterDetails : System.Web.UI.Page
    {
        //private readonly IMasterDetailsReportService _iMasterDetailsReportService;

        //public MasterDetails(IMasterDetailsReportService iMasterDetailsReportService)
        //{
        //    this._iMasterDetailsReportService = iMasterDetailsReportService;
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int categoryId = Convert.ToInt32(Request.QueryString["catid"]);

                IMasterDetailsReportService _iMasterDetailsReportService = new MasterDetailsReportService();

                var masterDetailsViewModels = _iMasterDetailsReportService.GetMasterDetailsViewModelsByCategoryId(categoryId);

                var detailsViewModels = masterDetailsViewModels as List<MasterDetailsViewModel> ?? masterDetailsViewModels.ToList();
                var reportData = detailsViewModels;

                ReportClass reportClass = new ReportClass();
                reportClass.FileName = Server.MapPath("~/CrystalReports/MasterDetails.rpt");
                reportClass.Load();

                reportClass.SetDataSource(reportData);
                masterDetailsCrystalReportViewer.ReportSource = reportClass;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
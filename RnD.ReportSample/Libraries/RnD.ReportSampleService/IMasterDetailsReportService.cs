using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RnD.ReportSampleViewModel;

namespace RnD.ReportSampleService
{
    public interface IMasterDetailsReportService
    {
        IEnumerable<MasterDetailsViewModel> GetMasterDetailsViewModels();
        IEnumerable<MasterDetailsViewModel> GetMasterDetailsViewModelsByCategoryId(int id);
    }
}

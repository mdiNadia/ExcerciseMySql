using Application.Dtos;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Interfaces;
using Persistence.Interfaces.GenericRepo;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Excercise.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICrudDapper _dapper;
        private readonly IExcerciseService _excerciseService;
        public IEnumerable<ExcerciseEntity> _Model;

        public IndexModel(ILogger<IndexModel> logger, ICrudDapper dapper,IExcerciseService excerciseService)
        {
            _logger = logger;
            this._dapper = dapper;
            this._excerciseService = excerciseService;
        }

        public IActionResult OnGet()
        {
            var data = _dapper.GetAll<ExcerciseEntity>("ExcerciseEntities");
            _Model = data;
            return Page();
        }

        public IActionResult OnGetDelete()
        {
            var data =  _dapper.DeleteAll("ExcerciseEntities");
        
           return RedirectToPage();
        }

        //https://localhost:8000/Index?handler=Report&serial=28218094
        [HttpPost]
        public async Task<IActionResult> OnGetReport(string serial)
        {
            var data = _excerciseService.GetReportData<GetDeviceInfoDto>(serial);
            //var data = await _excerciseService.GetQueryList().AsNoTracking().Where(c => c.SerialNumber == serial)
            //    .GroupBy(c => c.DeviceId)
            //    .Select(g => new GetDeviceInfoDto()
            //    {
            //        MachinId = g.Select(r => r.IdMachine).OrderByDescending(r => r).First(),
            //        RefId = g.Select(r => r.RefId).OrderByDescending(r => r).First(),
            //        EventId = g.Select(r => r.IdEvent).OrderBy(r => r).First(),
            //        DeviceId = g.Select(r => r.DeviceId).OrderBy(r => r).First(),
            //        FirstDate = g.Min(r => r.CreateDate),
            //        LastDate = g.Max(r => r.CreateDate)
            //    })
            //    .ToListAsync();
            var s = data;

            return Partial("_ReportPartial",data);

        }

    }
}

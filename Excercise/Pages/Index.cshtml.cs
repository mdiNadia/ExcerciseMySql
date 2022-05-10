using Application.Services.GenericRepo;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Excercise.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDapper _dapper;
        public IEnumerable<ExcerciseEntity> _Model;

        public IndexModel(ILogger<IndexModel> logger, IDapper dapper)
        {
            _logger = logger;
            this._dapper = dapper;
        }

        public IActionResult OnGet()
        {
            var data = _dapper.GetAll<ExcerciseEntity>("ExcerciseEntities");
            _Model = data;
            return Page();
        }


    }
}

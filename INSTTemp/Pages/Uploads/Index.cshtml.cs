using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using INSTTemp.Data;
using INSTTemp.Data.Models;

namespace INSTTemp.Pages.Uploads
{
    public class IndexModel : PageModel
    {
        private readonly APPDBC _db;

        public IndexModel(APPDBC db)
        {
            _db = db;
        }

        public IList<Upload> _Upl { get;set; }

        public async Task OnGetAsync()
        {
            _Upl = await _db.Uploads.ToListAsync();
        }
    }
}

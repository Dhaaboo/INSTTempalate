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
    public class DetailsModel : PageModel
    {
        private readonly INSTTemp.Data.APPDBC _context;

        public DetailsModel(INSTTemp.Data.APPDBC context)
        {
            _context = context;
        }

        public Upload Upload { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Upload = await _context.Uploads.FirstOrDefaultAsync(m => m.Id == id);

            if (Upload == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

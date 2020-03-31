using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INSTTemp.Data;
using INSTTemp.Data.Models;

namespace INSTTemp.Pages.Uploads
{
    public class EditModel : PageModel
    {
        private readonly INSTTemp.Data.APPDBC _context;

        public EditModel(INSTTemp.Data.APPDBC context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Upload).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UploadExists(Upload.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UploadExists(long id)
        {
            return _context.Uploads.Any(e => e.Id == id);
        }
    }
}

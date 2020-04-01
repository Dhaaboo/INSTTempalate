using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using INSTTemp.Data;
using INSTTemp.Data.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace INSTTemp.Pages.Uploads
{
    //[HttpPost()]
    [ValidateAntiForgeryToken]
    [RequestFormLimits(MultipartBodyLengthLimit = 268435456)]
    public class CreateModel : PageModel
    {
        private readonly APPDBC _db;
        private readonly IWebHostEnvironment _HostE;

        public CreateModel(APPDBC db, IWebHostEnvironment HostE)
        {
            _db = db;
            _HostE = HostE;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Upload _Upl { get; set; }
        [BindProperty]
        [Required]
        public IFormFile _Fup { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var doc = "application/msword";
            var docx = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            var ppt = "application/vnd.ms-powerpoint";
            var pptx = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
            var xls = "application/vnd.ms-excel";
            var xlsx = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var pdf = "application/pdf";
            if (_Fup == null)
            {
                ModelState.AddModelError("File", "Please Select Your Documents");
                return Page();
            }
            if (!(_Fup.ContentType == doc || _Fup.ContentType == docx || _Fup.ContentType == ppt || _Fup.ContentType == pptx || _Fup.ContentType == xls || _Fup.ContentType == xlsx || _Fup.ContentType == pdf))
            {
                ModelState.AddModelError("ilaalin", "Waxaa La Ogolyahay Kaliya :jpg/png/gif");
                return Page();
            }
            if (_Fup != null)
            {
                var _Fn = Path.GetFileName(_Fup.FileName);
                if (_Fup.Length > 0)
                {
                    byte[] DataDoc = null;
                    using (var Fs1 = _Fup.OpenReadStream())
                    using (var Ms = new MemoryStream())
                    {
                        Fs1.CopyTo(Ms);
                        DataDoc = Ms.ToArray();
                    }
                    _Upl.DataDoc = DataDoc;
                    _Upl.FileSize = _Fup.Length;
                    _Upl.CreatedOn = DateTime.Now;
                    _Upl.FilePath = "/Uploads/" + _Fn;
                    var _path = Path.Combine(_HostE.WebRootPath, "Uploads");
                    if (!Directory.Exists(_path))
                        Directory.CreateDirectory(_path);
                    using (var Fs = new FileStream(Path.Combine(_path, _Fn), FileMode.Create))
                    {
                        await _Fup.CopyToAsync(Fs);
                    }

                }
            }

            _db.Uploads.Add(_Upl);
            await _db.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}

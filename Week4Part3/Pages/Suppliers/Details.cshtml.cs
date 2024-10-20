using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductModel;
using Week4Part3.Data;

namespace Week4Part3.Pages.Suppliers
{
    public class DetailsModel : PageModel
    {
        private readonly Week4Part3.Data.Week4Part3Context _context;

        public DetailsModel(Week4Part3.Data.Week4Part3Context context)
        {
            _context = context;
        }

        public Supplier Supplier { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier.FirstOrDefaultAsync(m => m.ID == id);
            if (supplier == null)
            {
                return NotFound();
            }
            else
            {
                Supplier = supplier;
            }
            return Page();
        }
    }
}

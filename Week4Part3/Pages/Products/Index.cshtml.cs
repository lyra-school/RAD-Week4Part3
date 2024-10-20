using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductModel;
using Week4Part3.Data;

namespace Week4Part3.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Week4Part3.Data.Week4Part3Context _context;

        public IndexModel(Week4Part3.Data.Week4Part3Context context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Product
                .Include(p => p.associatedCategory).ToListAsync();
        }
    }
}

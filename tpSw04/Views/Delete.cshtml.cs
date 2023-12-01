using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tpSw04.Data;
using tpSw04.Models;

namespace tpSw04.Views
{
    public class DeleteModel : PageModel
    {
        private readonly tpSw04.Data.CarroContext _context;

        public DeleteModel(tpSw04.Data.CarroContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Carro Carro { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Carros == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros.FirstOrDefaultAsync(m => m.Id == id);

            if (carro == null)
            {
                return NotFound();
            }
            else 
            {
                Carro = carro;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Carros == null)
            {
                return NotFound();
            }
            var carro = await _context.Carros.FindAsync(id);

            if (carro != null)
            {
                Carro = carro;
                _context.Carros.Remove(Carro);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

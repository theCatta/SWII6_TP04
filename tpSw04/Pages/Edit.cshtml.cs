using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tpSw04.Data;
using tpSw04.Models;

namespace tpSw04.Pages
{
    public class EditModel : PageModel
    {
        private readonly tpSw04.Data.CarroContext _context;

        public EditModel(tpSw04.Data.CarroContext context)
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

            var carro =  await _context.Carros.FirstOrDefaultAsync(m => m.Id == id);
            if (carro == null)
            {
                return NotFound();
            }
            Carro = carro;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Carro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(Carro.Id))
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

        private bool CarroExists(int id)
        {
          return (_context.Carros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

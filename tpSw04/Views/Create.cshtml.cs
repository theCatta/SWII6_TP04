using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using tpSw04.Data;
using tpSw04.Models;

namespace tpSw04.Views
{
    public class CreateModel : PageModel
    {
        private readonly tpSw04.Data.CarroContext _context;

        public CreateModel(tpSw04.Data.CarroContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Carro Carro { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Carros == null || Carro == null)
            {
                return Page();
            }

            _context.Carros.Add(Carro);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly tpSw04.Data.CarroContext _context;

        public IndexModel(tpSw04.Data.CarroContext context)
        {
            _context = context;
        }

        public IList<Carro> Carro { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Carros != null)
            {
                Carro = await _context.Carros.ToListAsync();
            }
        }
    }
}

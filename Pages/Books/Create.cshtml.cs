using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lazar_Horatiu_Lab2.Data;
using Lazar_Horatiu_Lab2.Models;

namespace Lazar_Horatiu_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Lazar_Horatiu_Lab2.Data.Lazar_Horatiu_Lab2Context _context;

        public CreateModel(Lazar_Horatiu_Lab2.Data.Lazar_Horatiu_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

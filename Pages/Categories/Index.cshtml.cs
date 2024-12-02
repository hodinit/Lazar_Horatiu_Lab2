using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lazar_Horatiu_Lab2.Data;
using Lazar_Horatiu_Lab2.Models;
using Lazar_Horatiu_Lab2.Models.ViewModels;

namespace Lazar_Horatiu_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Lazar_Horatiu_Lab2.Data.Lazar_Horatiu_Lab2Context _context;

        public IndexModel(Lazar_Horatiu_Lab2.Data.Lazar_Horatiu_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
            .Include(i => i.Books)
            .ThenInclude(c => c.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
                CategoryData.Books = category.Books;
            }
        }
        
    }
}

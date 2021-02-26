using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EHut.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EHut.Pages.Admin.Category
{
    // [Authorize(Roles = SD.ManagerRole)]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitofwork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }

        [BindProperty]
        public Models.Category CategoryObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            CategoryObj = new Models.Category();
            if (id != null)
            {
                CategoryObj = _unitofwork.Category.GetFirstOrDefault(u => u.Id == id);
                if (CategoryObj == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost()  //IActionResult(Models.Category CategoryObj) remove for [BindProperty]
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (CategoryObj.Id == 0)
            {
                _unitofwork.Category.Add(CategoryObj);
            }
            else
            {
                _unitofwork.Category.Update(CategoryObj);
            }
            _unitofwork.Save();
            return RedirectToPage("./Index");
        }
    }
}
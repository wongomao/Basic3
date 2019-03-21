using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            Restaurant = _restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            // we can capture info about the validation of any piece of data coming from the form/page
            // through the ModelState
            //var x = ModelState["Location"].ValidationState;

            // typically all we need to do is ask if the modelstate is valid
            if (ModelState.IsValid)
            {
                Restaurant = _restaurantData.Update(Restaurant);
                _restaurantData.Commit();
                return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id } );
            }

            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }
    }
}
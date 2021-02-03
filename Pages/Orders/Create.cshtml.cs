using DataLibray.Data;
using DataLibray.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cdv_razor.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly IFoodData foodData; 
        private readonly IOrderData orderData;

        public List<SelectListItem> FoodItems { get; set; }

        [BindProperty]
        public OrderModel   Order { get; set; }

        public CreateModel(IFoodData foodData, IOrderData orderData)
        {
            this.foodData = foodData;
            this.orderData = orderData;
        }

        public async Task OnGet()
        {
            var food = await this.foodData.GetFood();
            FoodItems = new List<SelectListItem>();
            food.ForEach(f =>
            FoodItems.Add(new SelectListItem { Value = f.Id.ToString(), Text = f.Title }));
        }
    }
}

using System.Collections.Generic;
using SportsStore.Domain.Entities;
namespace SportsStore.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Products> Products { get; set; }

        public PageInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}
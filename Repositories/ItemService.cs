using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore2.Models;


namespace NetCore2.Repositories
{
    public class ItemService: IItemService
    {
        private readonly TodoContext _context;
        public ItemService(TodoContext context)
        {
            _context = context;
        }                          
        public IEnumerable<Item> FetchItems()
        {
            try
            {
                return _context.Items;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore2.Models;

namespace NetCore2.Repositories
{
    public interface IItemService
    {
        IEnumerable<Item> FetchItems();
    }
}

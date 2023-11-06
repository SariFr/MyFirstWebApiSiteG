using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public interface IcategoryService
{
    Task<IEnumerable<Category>> getCategoriesAsync();

}

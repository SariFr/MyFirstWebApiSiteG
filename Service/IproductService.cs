﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

public interface IproductService
{
    Task<IEnumerable<Product>> getProductsAsync();

}

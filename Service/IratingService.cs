using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IratingService
    {
        Task<Rating> addRating(Rating rating);
    }
}

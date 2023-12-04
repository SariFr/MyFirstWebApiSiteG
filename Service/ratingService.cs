﻿using Entities;
using Repositories;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ratingService: IratingService
    {

        private readonly IratingRepository _ratingRepository;


        public ratingService(IratingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task addRating(Rating rating)
        {
            await _ratingRepository.addRating(rating);
        }
    }
}

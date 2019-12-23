﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        //public List<MovieModel> Movies { get; set; }
        public IEnumerable<Genre> Genres {get; set;}
        public MovieModel Movie { get; set; }

        public string Title
        {
            get
            {
                if (Movie != null && Movie.ID != 0)
                    return "Edit Movie";
                return "New Movie";
            }
        }

    }
}
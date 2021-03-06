﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parcial_II.Data;

namespace Parcial_II.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Roles de Usuario")]
        [UIHint("List")]

        public List<SelectListItem> Roles { get; set; }
        public string Rol { get; set; }
        public RegisterViewModel()
        {
            Roles = new List<SelectListItem>();
        }
        public void obtenerRoles(ApplicationDbContext _context)
        {
            var roles = (from r in _context.identityRole select r).ToList();
            foreach (var item in roles)
            {
                Roles.Add(new SelectListItem()
                {
                    Value = item.Id,
                    Text = item.Name
                });
            }
        }
    }
}

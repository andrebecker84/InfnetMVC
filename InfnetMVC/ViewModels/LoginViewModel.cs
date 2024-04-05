﻿using System.ComponentModel.DataAnnotations;

namespace InfnetMVC.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email é inválido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
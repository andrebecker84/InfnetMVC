﻿using System.ComponentModel.DataAnnotations;

namespace InfnetMVC.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string? ConfirmPassword { get; set; }
    }
}

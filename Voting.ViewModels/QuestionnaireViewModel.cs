using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Voting.ViewModels
{
    public class QuestionnaireViewModel
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        [MaxLength(50, ErrorMessage = "Максимальная длина - 50 символов")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        [MaxLength(50, ErrorMessage = "Максимальная длина - 50 символов")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        [MaxLength(50, ErrorMessage = "Максимальная длина - 50 символов")]
        public string Patronymic { get; set; }

        public string Title { get; set; }

        public List<QuestionViewModel> Questions { get; set; }

        public List<AnswerViewModel> Answers { get; set; }
    }
}

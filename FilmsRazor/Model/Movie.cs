using System.ComponentModel.DataAnnotations;

namespace FilmsRazor.Model
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название фильма обязательно.")]
        [StringLength(80, ErrorMessage = "Название не должно превышать 80 символов.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Режиссёр обязателен.")]
        [StringLength(50, ErrorMessage = "Имя режиссёра не должно превышать 50 символов.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Жанр обязателен.")]
        [StringLength(30, ErrorMessage = "Жанр не должен превышать 30 символов.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Год выпуска обязателен.")]
        [YearValidation(ErrorMessage = "Год должен быть в диапазоне от 1900 до 2100.")]
        public int Year { get; set; }

        [StringLength(500, ErrorMessage = "Описание не должно превышать 500 символов.")]
        public string? Description { get; set; }

        public string? Poster { get; set; }
    }
}

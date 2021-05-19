using DigiClassroom.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace DigiClassroom.Web.Controllers.ClassroomCt.Dtos
{
    public class ClassroomForm
    {
        [Required(ErrorMessage = "O campo Nome precisa ser preenchido.")]
        [StringLength(50,ErrorMessage = "O campo Nome deve ter no máximo {1} caracteres e no mínimo {2}.", MinimumLength =10)]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo Descrição precisa ser preenchido.")]
        [StringLength(120, ErrorMessage = "O campo Descrição deve ter no máximo {1} caracteres e no mínimo {2}.", MinimumLength = 10)]
        public string Description { get; set; }
        [Required(ErrorMessage = "O campo Localização da Sala precisa ser preenchido.")]
        [StringLength(120, ErrorMessage = "O campo Localização da Sala deve ter no máximo {1} caracteres e no mínimo {2}.", MinimumLength = 10)]
        public string LocationClassroom { get; set; }

        public Classroom ToClassroom()
        {
            return new Classroom {
                Name=this.Name,
                Description=this.Description,
                LocationClassroom=this.LocationClassroom
            };
        }

    }
}

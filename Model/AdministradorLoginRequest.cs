using System.ComponentModel.DataAnnotations;

namespace Model.Request
{
    public class AdministradorLoginRequest
    {
        [Required]
        public string CorreoElectronico { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

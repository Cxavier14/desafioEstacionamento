using ParkingControl.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingControl.Domain.ExceptionValidation
{
    public class ValidationMessage
    {
        /// <summary>
        /// Mensagem para tratar validação e/ou exceção.
        /// </summary>
        [NotMapped]
        public string Mensagem { get; set; }

        /// <summary>
        /// Classe css do tipo de alerta
        /// Sucess, Warning, Danger, Info
        /// </summary>
        [NotMapped]
        public string ClasseTipoAlerta { get; set; }

        public string RetornarTipoAlerta(TipoAlerta tipo)
        {
            return (int)tipo switch
            {
                (int)TipoAlerta.Sucess => "alert alert-success",
                (int)TipoAlerta.Warning => "alert alert-warning",
                (int)TipoAlerta.Danger => "alert alert-danger",
                (int)TipoAlerta.Info => "alert alert-info",
                _ => string.Empty
            };
        }
    }
}

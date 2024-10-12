using ParkingControl.Domain.Enums;

namespace ParkingControl.Domain.ExceptionValidation
{
    public class ValidationMessage
    {
        /// <summary>
        /// Mensagem para tratar validação e/ou exceção.
        /// </summary>
        public virtual string Mensagem { get; set; }

        public static string RetornarTipoAlerta(TipoAlerta tipo)
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

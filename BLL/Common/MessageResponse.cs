using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Common
{
    public class MessageResponse
    {
        public const string CapitalsNotFound = "No existen capitales resgistradas";
        public const string CapitalLst = "Listado de capitales";
        public const string CapitalNotFound = "Capital no encontrada";
        public const string Capital = "Capital";
        public const string SuccessfulRegistration = "Registro exitoso";
        public const string SuccessfulUpdating = "Actualización exitosa";
        public const string RegistrationFailed = "No se pudo completar el registro";
        public const string UpdatingFailed = "No se pudo completar la actualización";
    }
}

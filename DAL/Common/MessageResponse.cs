using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
    public class MessageResponse
    {
        public const string CountryList = "Listado de paises";
        public const string CountriesNotFound = "No se encontraron paises registrados";
        public const string CountryNotFound = "País no encontrado";
        public const string Country = "País";
        public const string SuccessfulRegistration = "Registro exitoso";
        public const string SuccessfulUpdating = "Actualización exitosa";
        public const string SuccessfulDeleting = "Eliminación exitosa";
        public const string CountryAlreadyExist = "El país ya se encuentra registrado";
    }
}

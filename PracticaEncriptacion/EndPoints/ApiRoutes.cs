using Microsoft.Identity.Client;

namespace PracticaEncriptacion.EndPoints
{
    public class ApiRoutes
    {
        public static class Capitales
        {
            public const string Add = "Add";
            public const string GetByPostalCodeStartsWith = "GetByPostalCodeStartsWith/{searchTerm}";
            public const string GetByPostalCode = "GetByPostalCode/{postalCode}";
            public const string GetById = "GetById/{id}";
            public const string GetAll = "GetAll";
            public const string Update = "Update/{id}";
            public const string Delete = "Delete/{id}";
        }

        public static class Paises
        {
            public const string GetAll = "GetAll";
            public const string GetById = "GetById/{id}";
            public const string GetByAcronimo = "GetByAcronimo/{acronimo}";
            public const string GetByAcronimoStartsWith = "GetByAcronimoStartsWith/{acronimo}";
            public const string GetOrderByAcronimoDESC = "GetOrderByAcronimoDESC";
            public const string Add = "Add";
            public const string Update = "Update/{id}";
            public const string Delete = "Delete/{id}";
        }
    }
}

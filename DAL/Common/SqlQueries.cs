using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
    public class SqlQueries
    {
        public const string InsertCapitals = "INSERT INTO Capitales (ID, Nombre, Acronimo, CodigoPostal, PaisID) VALUES (@ID, @Nombre, @Acronimo, @CodigoPostal, @PaisID)";
        public const string SelectCapitalsByCodigoPostal = "SELECT * FROM Capitales WHERE CodigoPostal = @CodigoPostal";
        public const string SelectCapitalsById = "SELECT * FROM Capitales WHERE ID = @ID";
        public const string SelectAllCapitals = "SELECT * FROM Capitales";
        public const string UpdateCapitals = "UPDATE Capitales SET ID = @ID, Nombre = @Nombre, Acronimo = @Acronimo, CodigoPostal = @CodigoPostal, PaisID = @PaisID WHERE ID = @ID";
        public const string DeleteCapitals = "DELETE FROM Capitales WHERE ID = @ID";
        public const string GetByIdNamePostalCode = "SELECT COUNT(1) FROM Capitales WHERE ID = @ID OR Nombre = @Nombre OR CodigoPostal = @CodigoPostal";
    }
}

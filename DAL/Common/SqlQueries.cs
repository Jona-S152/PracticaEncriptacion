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
    }
}

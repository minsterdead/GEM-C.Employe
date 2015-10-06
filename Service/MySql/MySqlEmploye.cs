using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEM_C_E.Models.Entities;
using GEM_C_E.Service.Definitions;
using Immobilus.Logic.Services.Helpers;
using MySql.Data.MySqlClient;

namespace GEM_C_E.Service.MySql
{
    public class MySqlEmploye : IEmployeService

    {
        private MySqlConnexion connexion;

        public IList<Employe> RetrieveAll()
        {
            IList<Employe> result = new List<Employe>();
            try
            { 
                connexion = new MySqlConnexion();

                string requete = "SELECT idEmploye, nom, prenom FROM Employes";
                DataSet  dataset = connexion.Query(requete);
                DataTable table = dataset.Tables[0];

                foreach (DataRow employe in table.Rows)
                {
                    result.Add(ConstructEmploye(employe));
                }
            }
            catch (MySqlException)

            throw ;
        }

        private Employe ConstructEmploye (DataRow row)
        { 
            return new Employe()
            {
                IdEmploye = (int)row["idEmploye"],
                Nom = (string)row["nom"],
                Prenom = (string)row["prenom"]
            };
        }
    }
}

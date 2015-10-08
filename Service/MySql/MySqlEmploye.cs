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

                string requete = "SELECT idEmploye, CONCAT(prenom,' ', nom) as nom FROM Employes";
                DataSet  dataset = connexion.Query(requete);
                DataTable table = dataset.Tables[0];

                foreach (DataRow employe in table.Rows)
                {
                    result.Add(ConstructEmploye(employe));
                }
            }
            catch (MySqlException)
            {
                throw ;
            }
            return result;

        }

        private Employe ConstructEmploye (DataRow row)
        { 
            return new Employe()
            {
                IdEmploye = (int)row["idEmploye"],
                NomPrenom = (string)row["nom"]
            };
        }

        public bool VérifierDemArr(int IdEmploye) 
        {
            try
            { 
                connexion = new MySqlConnexion();

                string requete = "SELECT * FROM CompteursTemps WHERE idEmploye = '" + IdEmploye + "' AND dateTimerEnd IS NULL";
                DataSet dataset = connexion.Query(requete);
                DataTable table = dataset.Tables[0];

                if(table.Site == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException)
            {
                throw;
            }
        }
    }
}

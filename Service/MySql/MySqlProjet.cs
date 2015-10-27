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
    public class MySqlProjet : IProjetService 
    {
        private MySqlConnexion connexion;

        public IList<Projet> Retrieve(int idEmploye) 
        {
            IList<Projet> result = new List<Projet>();

            try
            {
                connexion = new MySqlConnexion();

                StringBuilder req = new StringBuilder();
                req.Append("SELECT p.idProjet, p.nom, p.dateDebut, p.dateFin FROM LiaisonProjetEmployes AS lpe INNER JOIN Projets AS p WHERE lpe.idProjet =");
                req.Append(idEmploye);
                req.Append(" AND lpe.idProjet = p.idProjet");

                DataSet dataset = connexion.Query(req.ToString());
                DataTable table = dataset.Tables[0];

                foreach (DataRow projet in table.Rows)
                {
                    result.Add(ConstructProjet(projet));
                }
            }
            catch (MySqlException)
            {
                throw;
            }

            return result;
        }

        private Projet ConstructProjet (DataRow row)
        { 
            return new Projet()
            {
                IdProjet =  (int)row["idProjet"],
                Nom = (string)row["nom"],
                DateDebut = (DateTime)row["dateDebut"],
                DateFin = (DateTime)row["dateFin"]
            };
        }

        public void  CreerTemps(int idEmploye, int idProjet)
        {
            try
            {
                connexion = new MySqlConnexion();

                StringBuilder req = new StringBuilder();
                req.Append("INSERT INTO compteurstemps (idEmploye, idProjet, dateTimerStart) VALUES ('");
                req.Append(idEmploye);
                req.Append("', '");
                req.Append(idProjet);
                req.Append("', '");
                req.Append(DateTime.Now);
                req.Append("')");

                DataSet dataset = connexion.Query(req.ToString());
            }
            catch (MySqlException)
            {
                throw;
            }
        }
    }
}

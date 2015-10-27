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

        public void UpdateCompteurs(int idEmploye)
        {
            try
            {
                connexion = new MySqlConnexion();

                StringBuilder req = new StringBuilder();
                req.Append("UPDATE compteurstemps SET dateTimerEnd = '");
                req.Append(DateTime.Now);
                req.Append("' WHERE idEmploye = '");
                req.Append(idEmploye);
                req.Append("' AND dateTimerEnd IS NULL");

                DataSet dataset = connexion.Query(req.ToString());
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        public List<string> RecupeDonnees(int idEmploye)
        {
            List<string> donnees = new List<string>();

            try
            {
                connexion = new MySqlConnexion();

                StringBuilder req = new StringBuilder();
                req.Append("SELECT p.nom, c.dateTimerStart, c.idProjet FROM compteurstemps AS c ");
                req.Append("INNER JOIN projets AS p ");
                req.Append("WHERE idEmploye = '");
                req.Append(idEmploye);
                req.Append("' AND p.idProjet = c.idProjet AND dateTimerEnd is null");

                DataSet dataset = connexion.Query(req.ToString());
                DataTable table = dataset.Tables[0];

                foreach (DataRow donnes in table.Rows)
                {
                    for(int i = 0; i < 2; i++)
                    {
                        donnees.Add(donnes[i].ToString());
                    }
                }

                StringBuilder requete = new StringBuilder();
                requete.Append("SELECT SUM(TIMESTAMPDIFF( MINUTE, dateTimerStart, dateTimerEnd)/60) as temps FROM compteurstemps ");
                requete.Append("WHERE idEmploye = '");
                requete.Append(idEmploye);
                requete.Append("' AND idProjet = '");
                requete.Append(table.Rows[0][2]);
                requete.Append("' AND dateTimerEnd IS NOT NULL");

                dataset = connexion.Query(requete.ToString());
                table = dataset.Tables[0];

                donnees.Add(table.Rows[0][0].ToString());

            }
            catch (MySqlException)
            {
                throw;
            }

            return donnees;
        }

        public bool VerifierDemArr(int IdEmploye) 
        {
            try
            { 
                connexion = new MySqlConnexion();

                StringBuilder req = new StringBuilder();
                req.Append("SELECT * FROM compteurstemps WHERE idEmploye = '");
                req.Append(IdEmploye);
                req.Append("' AND dateTimerEnd IS NULL");

                DataSet dataset = connexion.Query(req.ToString());
                DataTable table = dataset.Tables[0];

                if(table.Rows.Count == 0)
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

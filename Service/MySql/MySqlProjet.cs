﻿using System;
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
                req.Append("SELECT p.idProjet, p.nom, p.dateDebut, p.dateFin ");
                req.Append("FROM LiaisonProjetEmployes AS lpe INNER JOIN Projets AS p ");
                req.Append("WHERE lpe.idEmploye = '");
                req.Append(idEmploye);
                req.Append("' AND p.idProjet = lpe.idProjet  AND etat = 'ECS' ");

                //SUM(TIMESTAMPDIFF( MINUTE, cp.dateTimerStart, cp.dateTimerEnd)/60) as temps FROM INNER JOIN compteurstemps as cp WHERE cp.idProjet = lpe.idProjet AND dateTimerEnd is not null

                DataSet dataset = connexion.Query(req.ToString());
                DataTable table = dataset.Tables[0];

                foreach (DataRow projet in table.Rows)
                {
                    string tmp = (RecupHrProjet(projet[0].ToString()) != ""? RecupHrProjet(projet[0].ToString()) : "0");
                    result.Add(ConstructProjet(projet, tmp));
                }
            }
            catch (MySqlException)
            {
                throw;
            }

            return result;
        }

        private Projet ConstructProjet (DataRow row, string tmp)
        { 
            try
            {
                return new Projet()
                {
                    IdProjet = (int)row["idProjet"],
                    Nom = (string)row["nom"],
                    DateDebut = (DateTime)row["dateDebut"],
                    DateFin = (DateTime)row["dateFin"],
                    HeureCumuler = Convert.ToSingle(tmp)
                };
            }
            catch(Exception)
            {
                return new Projet()
                {
                };
            }
           
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

        private string RecupHrProjet(string idprojet)
        {
            connexion = new MySqlConnexion();

            StringBuilder requete = new StringBuilder();
            requete.Append("SELECT SUM(TIMESTAMPDIFF( MINUTE, dateTimerStart, dateTimerEnd)/60) as temps FROM compteurstemps ");
            requete.Append("WHERE idProjet = '");
            requete.Append(idprojet);
            requete.Append("' AND dateTimerEnd IS NOT NULL");

            DataSet dataset = connexion.Query(requete.ToString());
            DataTable table = dataset.Tables[0];

            return table.Rows[0][0].ToString();
        }
    }
}

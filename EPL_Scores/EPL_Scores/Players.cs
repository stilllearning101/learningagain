using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EPL_Scores
{
    //created properties to get the teamid and teamname. 
    public class TeamPlayers
    {
        public int TeamID { get; set; }       
        public string TeamName { get; set; } 
    }

    public class TeamPlayersAcessLayer
    {
        public static List<TeamPlayers> GetAllTeams()
        {
            List<TeamPlayers> listTeams = new List<TeamPlayers>();
            string cs = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;// connection to connectionstring
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllTeam", con); //decided to use the stroed procedure as helps to prevent SQL injection, safety.
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TeamPlayers Team = new TeamPlayers();
                    Team.TeamID = Convert.ToInt32(rdr["ID"]);
                    Team.TeamName = rdr["TeamName"].ToString();

                    listTeams.Add(Team);
                }
            }
            return listTeams;
        }
    }
}
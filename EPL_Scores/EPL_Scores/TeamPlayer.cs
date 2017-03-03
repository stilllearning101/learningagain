using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EPL_Scores
{
    //Gets and sets the properties 
    public class AllPlayer
    {
        public int PlayerID { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public string Country { get; set; }
        public string TeamName { get; set; }

       
    }

    public class AllPlayerAcessLayer
    {      
        //What I would like to do here is instead of having to write multiple connection and parameter properties for all the connection function
        //I want to create another class just for the connection and on this just call that with parameters only. This should help in code reuse.
        //or may be better way of working with connection string to connect with database.

        public static List<AllPlayer>GetAllPlayer(int PlayerID)
        {
            List<AllPlayer> AllPlayer = new List<AllPlayer>();
            string cs = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllPlayerforTeam", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@TeamID", PlayerID);
                cmd.Parameters.Add(parameter);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AllPlayer Players = new AllPlayer();
                    //Players.PlayerID = Convert.ToInt32(rdr["ID"]);
                    Players.FullName = rdr["FLName"].ToString();
                    Players.Age = Convert.ToInt32(rdr["Age"]);
                    Players.Position = rdr["Position"].ToString();
                    Players.Country = rdr["Country"].ToString();
                    Players.TeamName = rdr["TeamName"].ToString();

                    AllPlayer.Add(Players);
                }
            }
            return AllPlayer;
        }

        
          

        public string UpdatePlayers(int PlayerID, string FullName, int Age, string Position, string Country)
            {                          

                string cs = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spUpdatePlayer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameterID = new SqlParameter("@Playerid", PlayerID);
                    cmd.Parameters.Add(parameterID);
                    SqlParameter paramName = new SqlParameter("@FullName", FullName);
                    cmd.Parameters.Add(paramName);
                    SqlParameter paramAge = new SqlParameter("@Age", Age);
                    cmd.Parameters.Add(paramAge);
                    SqlParameter paramPosition = new SqlParameter("@Position", Position);
                    cmd.Parameters.Add(paramPosition);
                    SqlParameter paramCountry = new SqlParameter("@Country", Country);
                    cmd.Parameters.Add(paramCountry);
                    con.Open();
                    cmd.ExecuteNonQuery();

                return "";       
                }
            }

        public string InsertPlayers(string FullName, int Age, string Position, string Country, int fid)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertPlayer", con);
                cmd.CommandType = CommandType.StoredProcedure;                
                SqlParameter paramName = new SqlParameter("@FullName", FullName);
                cmd.Parameters.Add(paramName);
                SqlParameter paramAge = new SqlParameter("@Age", Age);
                cmd.Parameters.Add(paramAge);
                SqlParameter paramPosition = new SqlParameter("@Position", Position);
                cmd.Parameters.Add(paramPosition);
                SqlParameter paramCountry = new SqlParameter("@Country", Country);
                cmd.Parameters.Add(paramCountry);
                SqlParameter paramFid = new SqlParameter("@fid", fid);
                cmd.Parameters.Add(paramFid);
                con.Open();
                cmd.ExecuteNonQuery();

                return " ";
            }
        }

           
        }
    }
    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPL_Scores
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                   
        }       
        /*The front page allows the user to select the team. I wanted to add the statistics and other news article from other website. I will definately be working
         * on this as my side project.
         * 
         */
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int a;
            a = DropDownTeams.SelectedIndex + 1;

            TeamPlayers Team = new TeamPlayers(); //Calls the teamplayer object which has teamid and teamname as properties
            Team.TeamID = a;

            Session["TeamID"] = Team.TeamID; /*While reading through couple of different option to store the ID for the next page
            the option to use hidden field was also there. But thought this was easy and both has is similar in security and performance.*/

            Response.Redirect("PlayersName.aspx"); //Sends the user to another page. This application does not have the 404 error page. In case of exception to redirect
            //we can use response.redirect 
          
            
        }        
    }
}
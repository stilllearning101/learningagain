using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using static EPL_Scores.AllPlayerAcessLayer;
using System.Data;

namespace EPL_Scores
{
    public partial class PlayersName : System.Web.UI.Page
    {       

        private void binddata()
        {
            
            //I do not know why I was not able to bind the data after the insert so had to switch around some code as previously 
            //I had all these code inside page load.
            AllPlayer player = new AllPlayer();
            player.PlayerID = Convert.ToInt32(Session["TeamID"]);

            GridView1.DataSourceID = null;
            GridView1.DataSource = AllPlayerAcessLayer.GetAllPlayer(player.PlayerID);
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Fetches the database for the name of the players
            if (!Page.IsPostBack)
            {

                binddata();
            }

        }

        protected void GridView1_SelectedIndexChanging(Object sender, GridViewSelectEventArgs e)
        {
            //I spent about a week trying to figure out how to get the selected row. I had to try so many things it got crazy. 
            
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];



        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Insead of having user to update the gridview I am thinking about changing it to web api or something to get update all the players.
            //You would be surprised which player might move to which club every transfer season which happens twice a year. Crazy, if someone would have to 
            //do it manually. 
            GridView1.EditIndex = e.NewEditIndex;
        }
        /*I know I have done something wrong so wrong here. The above method calls for the row edit and row select but the below code does 
         * the updating. I have no clue which one is working but if I remove one it will error out. Breakpoints too lazy for that, the problem that I have is
         * I am trying to achieve row edit through drag and drop approach and update and insert through code behind file. I have no clue how to work around to 
         * have the consistency but it works. I am happy. :)
         */ 
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //RowIndex, I will never forget this word never. Took me like weeks to find out the rowindex. To get the row index so that I can get the textbox 
            //from textbox to get the text and set the value to the get and set properties. No joke took me ages.
            GridViewRow row = GridView1.Rows[e.RowIndex];

            int playerid = Convert.ToInt32(Session["TeamID"]);

            TextBox fullname = (row.FindControl("txtfullName") as TextBox);
            TextBox age = (row.FindControl("txtAge") as TextBox);
            TextBox position = (row.FindControl("txtPosition") as TextBox);
            TextBox country = (row.FindControl("txtCountry") as TextBox);

            AllPlayer update = new AllPlayer();
            update.FullName = fullname.Text.ToString();
            update.Age = Convert.ToInt32(age.Text);
            update.Position = position.Text.ToString();
            update.Country = country.Text.ToString();

            //I went nuts on this as well, I know I have done it correctly but does I do not know how why or what did it but it did not like the way I had called the method
            //Crazy how one small issue takes such a long time to fix a issue. I was passing the parameters directly into the object. Took me ages to 
            //to figure out that I had to assign the gridview updatemethod to the object update method for the values to be updated. 
            AllPlayerAcessLayer allplayer = new AllPlayerAcessLayer();
     

            GridView1.UpdateMethod = allplayer.UpdatePlayers(playerid, update.FullName, update.Age, update.Position, update.Country);

            

            binddata();



          

        }
        //Allows user to cancel the insert
        protected void GridView1_RowCancel(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;

            binddata();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                TextBox fullname = (TextBox)GridView1.FooterRow.FindControl("txtfullName1");
                TextBox age = (TextBox)GridView1.FooterRow.FindControl("txtAge1");
                TextBox position = (TextBox)GridView1.FooterRow.FindControl("txtPosition1");
                TextBox country = (TextBox)GridView1.FooterRow.FindControl("txtCountry1");
                //Allows user to insert but validation is problem. To validate I need to use my brain and now I am too exhausted to continue using my brain for another
                //day or two. Will continue working further on this.
                if (age.Text == null)
                {
                    //verify if the age entered is text and number need to find control for the validation and enable is true
                    //or validation through server side than client side
                }
             

                AllPlayer insert = new AllPlayer();
                insert.FullName = fullname.Text.ToString();
                insert.Age = Convert.ToInt32(age.Text);
                insert.Position = position.Text.ToString();
                insert.Country = country.Text.ToString();
                insert.PlayerID = Convert.ToInt32(Session["TeamID"]);

                AllPlayerAcessLayer allplayer = new AllPlayerAcessLayer();
                

                ObjectDataSource1.InsertMethod = allplayer.InsertPlayers(insert.FullName, insert.Age, insert.Position, insert.Country, insert.PlayerID);

                binddata();           
            
            }
        }
    }
}

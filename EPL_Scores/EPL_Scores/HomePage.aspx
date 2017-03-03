<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EPL_Scores.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 690px;
            height: 337px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        English Premier League <br />
        <br />
        <img alt="" class="auto-style1" src="Pictures/Premier-League.jpg" /><br />
        <br />
        Select Your Team</div>
        <asp:DropDownList ID="DropDownTeams" runat="server" DataSourceID="ObjectDataSource1" DataTextField="TeamName" DataValueField="TeamID">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllTeams" TypeName="EPL_Scores.TeamPlayersAcessLayer"></asp:ObjectDataSource>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <br />
        <br />
        <p> 
            Since the day I started learning C# and web application development, I have always wanted to work on something. My best friend wrties a blog, 
            he had asked me create a website for him. But never actually had that energy on me. Then for the final project, I asked him if he would like me create
            one. Unfortunately, he said "NO". 
             <br />
            Then, I was reading through some article to see if I could work on it. I realized it might need some client side programming using javascript. That 
            changed my mind. 
             <br />
            After couple days, we were watching soccer game. I had an idea of getting name of all the player's name of a team. Along with that, if I could get
            recent statistics and other information. Then I realized I might need to create an API or enter all that information on a database. 
             <br />
             Then, with all the energy and hard working as I am decided to manually writing name of the player in the database. The database includes following 
            information:
             <br />
            1. Table list of all the teams(needed) and including individual table for individual team(this was not needed, like I said "hard working")....
             <br />

            2. One table with all the players
             <br />
            While you look through the code, I have written comments for the thought process that went through and the difficulties that I had. Along with some frustration of writing code. :(<br />
            Hope it is Okay.

        </p>
    </form>
</body>
</html>

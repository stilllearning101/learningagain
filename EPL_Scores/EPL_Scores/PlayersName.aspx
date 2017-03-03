<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlayersName.aspx.cs" Inherits="EPL_Scores.PlayersName" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 515px;
            height: 356px;
        }
    </style>
</head>
<body> List Of All the Players<p>
    &nbsp;</p>
    <p>
        <img alt="" class="auto-style1" src="Pictures/PremierLeagueTeams.jpg" /></p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
&nbsp;<form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="ObjectDataSource1" 
            GridLines="Horizontal" onselectedindexchanging="GridView1_SelectedIndexChanging"
            onrowediting="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancel" 
            OnRowCommand ="GridView1_RowCommand" ShowFooter="True">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns> 
                <asp:TemplateField HeaderText="Controls">
                    <ItemTemplate>
                        <asp:Button Text="Edit" ID="EditButton" runat="server" CommandName="Edit" />                        
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button Text="Update" ID="UpdateButton" runat="server" CommandName="Update" />
                        <asp:Button Text="Cancel" ID="CancelButton" runat="server" CommandName="Cancel" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Button Text="Insert" ID="InsertButton" runat="server" CommandName="Insert" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PlayerID" HeaderText="PlayerID" SortExpression="PlayerID" visible="false" />
              <asp:TemplateField HeaderText="FullName" SortExpression="FullName">                                 
                  <EditItemTemplate>                      
                        <asp:TextBox ID="txtfullName"   runat ="server" Text='<%# Bind("FullName") %>'></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is Required" ControlToValidate="txtfullName"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                  <ItemTemplate>
                        <asp:Label ID="lblfullName" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
                    </ItemTemplate>
                  <FooterTemplate>
                      <asp:TextBox ID="txtfullName1"  runat ="server" ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Enabled="false" ErrorMessage="Name is Required" ControlToValidate="txtfullName1"></asp:RequiredFieldValidator>

                  </FooterTemplate>                                                
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Age" SortExpression="Age">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAge" runat="server" Text='<%# Bind("Age") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Age is Required" ControlToValidate="txtAge"></asp:RequiredFieldValidator>
                         <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" 
                            ControlToValidate="txtAge" ErrorMessage="Value must be a number" />

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAge" runat="server" Text='<%# Eval("Age") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtAge1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Enabled="false" ErrorMessage="Age is Required" ControlToValidate="txtAge1"></asp:RequiredFieldValidator>
                         <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" 
                            ControlToValidate="txtAge1" ErrorMessage="Value must be a number" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Position" SortExpression="Position">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPosition" runat="server" Text='<%# Bind("Position") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Position is Required" ControlToValidate="txtPosition"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPosition" runat="server" Text='<%# Eval("Position") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtPosition1" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Enabled="false" ErrorMessage="Position is Required" ControlToValidate="txtPosition1"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country" SortExpression="Country">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCountry" runat="server" Text='<%# Bind("Country") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Country is Required" ControlToValidate="txtCountry"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtCountry1" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Enabled="false" ErrorMessage="Country is Required" ControlToValidate="txtCountry1"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>              
                   
                <asp:TemplateField HeaderText="TeamName" SortExpression="TeamName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("TeamName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TeamName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllPlayer" TypeName="EPL_Scores.AllPlayerAcessLayer" UpdateMethod="UpdatePlayer" InsertMethod="InsertPlayers">
            <SelectParameters>
                <asp:SessionParameter Name="PlayerID" SessionField="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="PlayerID"  Type="Int32" />
                <asp:Parameter Name="FullName" Type="String"  />
                <asp:Parameter Name="Age" Type="Int32" />
                <asp:Parameter Name="Position" Type="String" />
                <asp:Parameter Name="Country" Type="String" />                
            </UpdateParameters>
        </asp:ObjectDataSource>   
    <b /> 
    <b />
        <p>
            This page shows the list of players. User can update, insert players name, position, age and country. The option to delete really never crossed my mind until
            I started typing this. Now, too lazy to add a button to delete the record. Hope being lazy is fine. :)
            <b />

        </p>
    </form>
</body>
</html>

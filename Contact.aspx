<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="css/Login.css" rel="stylesheet"/>
    
  <script src="http://codepen.io/assets/libs/fullpage/jquery.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="container" >
  <div class="row">
    <div class="Absolute-Center is-Responsive">
        <h1>CONTACT US FORM</h1>
     <div class="col-sm-12 col-md-10 col-md-offset-1">
     
          <div>

          <div class="form-group input-group">
            <asp:textbox id="username" runat="server"  placeholder="Enter your username"></asp:textbox>
 
         </div>

          <div class="form-group input-group">
            <asp:TextBox ID="useremail" runat="server"  placeholder="Enter your email" TextMode="Email"></asp:TextBox>
          </div>

            <div class="form-group input-group">
            <asp:TextBox ID="usermsg" runat="server"  placeholder="Type your message..."></asp:TextBox>
          </div>

          <div class="form-group">
            <asp:Label ID="ErrorMessage" runat="server" Text=""></asp:Label>
              <asp:Button ID="btnForm" runat="server" Class="btn btn-def btn-block" Text="Submit" OnClick="btnForm_Click" />
              
          </div>

              <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
              </div>

      </div>  
    </div>    
  </div>
</div>
</asp:Content>


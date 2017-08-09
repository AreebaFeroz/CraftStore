<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ImageDisplay.aspx.cs" Inherits="ImageDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
       .pic-size {
             width:320px;
             height:360px;
                 }
       .pic-size-1 {
        width:280px;
        height:210px;
                   }
         p,h3 {
            
    -o-text-overflow: ellipsis;   /* Opera */
    text-overflow:    ellipsis;   /* IE, Safari (WebKit) */
    overflow:hidden;              /* don't show excess chars */
    white-space:nowrap;           /* force single line */
    width: 300px;                 /* fixed width */

         }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- jumbotron-->

    <div class="jumbotron">
        <div class="container text-center">
            <h1><i class="fa fa-paint-brush"></i> Craft Store</h1>
             <div class="row">
               <div class="col-xs-12">
                  <div class="btn-group">
                      <ul class="nav nav-tabs">
                          <li class="active"><a data-toggle="tab" href="#menu1" class="btn btn-lg btn-block " style="background-color:red; color:white;">Graphics</a></li>
                         <!--<li><a data-toggle="tab" href="#menu1" class="btn btn-lg " style="background-color:orange; color:white;">Handicrafts</a></li> -->
                          <li class="dropdown">
                              <a class="dropdown-toggle" data-toggle="dropdown" href="#menu2" class="btn btn-lg btn-block " style="background-color:orange; color:white;">Potraits
                              <span class="caret"></span></a>
                              <ul class="dropdown-menu">
                                <li><a data-toggle="tab" href="#menu3">Paintings</a></li>
                                <li><a data-toggle="tab" href="#menu7">Sketches</a></li>
                              </ul>
                            </li>


                          <li><a data-toggle="tab" href="#menu3" class="btn btn-lg " style="background-color:yellow; color:white;">Paintings</a></li>
                          <li><a data-toggle="tab" href="#menu4" class="btn btn-lg " style="background-color:green; color:white;">Jewellery</a></li>
                          <li><a data-toggle="tab" href="#menu5" class="btn btn-lg " style="background-color:blue; color:white;">Interios</a></li>
                          <li><a data-toggle="tab" href="#menu6" class="btn btn-lg " style="background-color:purple; color:white;">Handicrafts</a></li>
                          <li><a data-toggle="tab" href="#menu7" class="btn btn-lg " style="background-color:black; color:white;">Sketches</a></li>
                    </ul>
                </div>
              </div>
             </div>
         
        </div>
    </div>
 <!-- END jumbotron-->

    <div class="container">
  <div class="tab-content">
    

     <!-- ******************graphics*************-->
              
                            
         
     <div class="panel panel-default">
            <!-- Default panel contents -->

            <asp:Repeater ID="rptrImages" runat="server">
                <HeaderTemplate>
                   
                </HeaderTemplate>
                <ItemTemplate>
                 <div class="tab-pane fade in active">    
         <%--       <div class = "row">--%>
                    <div class = " col-xs-12 col-sm-4 col-md-4 pic-size">
                        <div class = "thumbnail">
                        <asp:Image ID="Image1" runat="server" alt="image" height="200" width="300" style="border:5px solid black"  ImageUrl='<%#Accessible.GetImage(Eval("Image")) %>' />
                        </div>
                                 
                        <div class = "caption">
                     
                        <h3 style="color:white;"><%# Eval("ProductName") %></h3>
                        <p style="color:white;"><%# Eval("Description") %>.</p>
                              
                        <p>
                            <a href = "#" class = "btn btn-primary" role = "button">
                                <i class="fa fa-shopping-cart"> Buy Now</i>
                            </a> 
                            <a href = "#" class = "btn btn-default" role = "button">
                                More...
                            </a>
                        </p>
                                    
                        </div>
                    </div>
                  <%--  </div>--%>
                </div>
                  
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
      </div>
        </div>
   
</asp:Content>

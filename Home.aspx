<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <!-- slider-->
    <div class="container" style=" width:100%; height: 400px;">
        <section >

            <div class="carousel slide" id="screenshot-carousel" data-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-target="#screenshot-carousel" data-slide-to="0" class="active"></li>
                    <li data-target="#screenshot-carousel" data-slide-to="1"></li>
                    <li data-target="#screenshot-carousel" data-slide-to="2"></li>
                    <li data-target="#screenshot-carousel" data-slide-to="3"></li>
                </ol>

                <div class="carousel-inner">
                    <div class="item active">
                        <img src="Images\image2.jpg" alt="text of the image" style=" width:100%; height: 400px;" />
                        <div class="carousel-caption">
                            <h3>background 1</h3>
                            <p>this is the caption</p>
                        </div>
                    </div>
                    <div class="item">
                        <img src="Images\image3.jpg" alt="text of the image" style=" width:100%; height: 400px;" />
                        <div class="carousel-caption">
                            <h3>background 2</h3>
                            <p>this is the caption</p>
                        </div>
                    </div>
                    <div class="item">
                        <img src="Images\image4.jpg" alt="text of the image" style=" width:100%; height: 400px;"/>
                        <div class="carousel-caption">
                            <h3>background 3</h3>
                            <p>this is the caption</p>
                        </div>
                    </div>
                    <div class="item">
                        <img src="Images\image5.jpg" alt="text of the image" style=" width:100%; height: 400px;" />
                        <div class="carousel-caption">
                            <h3>background 4</h3>
                            <p>this is the caption</p>
                        </div>
                    </div>
                </div>
                <!--end carousel inner-->



                <a href="#screenshot-carousel" class="left carousel-control" data-slide="prev">
                    <span class="glyphicon  glyphicon-chevron-left"></span>
                </a>

                <a href="#screenshot-carousel" class="right carousel-control" data-slide="next">
                    <span class="glyphicon  glyphicon-chevron-right"></span>
                </a>

            </div>
            <!--end carousel-->
        </section>
    </div>
    <!--end slider-->





    <!-- jumbotron-->

    <div class="jumbotron">
        <div class="container text-center">
            <h1><i class="fa fa-paint-brush"></i> Craft Store</h1>
            <p>20% off ALL Outdoor Play<br> Stock up on outdoor summer must haves.<br>Save on sidewalk chalk, paint, bubbles, and more! </p>
                <a href="" class="btn btn-lg btn-warning">Visit Store and Shop Now</a>
          
        </div>
    </div>
    <!-- END jumbotron-->

   <!-- videos and one pic-->
    <div class="container">
        <section>
            
            <div class="row">
                <div class="col-md-7 text-center" >
                        <img src = "Images\image14.png" alt = "Generic placeholder thumbnail" >
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum ex ante, 
                            a dictum nulla ultricies vitae. Fusce lorem ex, posuere eu commodo ac, 
                            fermentum a massa. Donec lacinia eros faucibus efficitur porttitor.
                        </p>
                        
         
                    <a href="" class="btn btn-lg btn-info">Book Painting Party</a>
                     <br><br>

                     <iframe width="320" height="345" src="https://www.youtube.com/embed/VYYZzZ2rE6o">
                      </iframe>
                      <iframe width="320" height="345" src="https://www.youtube.com/embed/gssiA9tBbD0">
                      </iframe>
                </div>
                <div class="col-md-5 text-center">
                    <img src = "Images\image9.jpg" alt = "Generic placeholder thumbnail">
                </div>
               
            </div>
        </section>
    </div>
    <!-- END container-->



    <!-- jumbotron-->

    <div class="jumbotron">
        <div class="container text-center">


            <div class="btn-group">
                <a href="#" class="btn btn-lg " style="background-color:red; color:white;">Paintings</a>
                <a href="#" class="btn btn-lg " style="background-color:orange; color:white;">Handicrafts</a>
                <a href="#" class="btn btn-lg " style="background-color:yellow; color:white;">Graphics</a>
                <a href="#" class="btn btn-lg " style="background-color:green; color:white;">Jewellery</a>
                <a href="#" class="btn btn-lg " style="background-color:blue; color:white;">Interios</a>
                <a href="#" class="btn btn-lg " style="background-color:purple; color:white;">Potraits</a>
                <a href="#" class="btn btn-lg " style="background-color:black; color:white;">Sketches</a>
            </div>
        </div>
    </div>
    <!-- END jumbotron-->


    <!-- products-->
    <div class="container">
        <section>
            
            <div class = "row">
                  <div class = "col-sm-6 col-md-4">
                     <div class = "thumbnail">
                        <img src = "Images\image13.jpg" alt = "Generic placeholder thumbnail">
                     </div>
                     
                     <div class = "caption">
                        <h3>Thumbnail label</h3>
                        <p>Some sample text. Some sample text.</p>
                        
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
                  
                  <div class = "col-sm-6 col-md-4">
                     <div class = "thumbnail">
                        <img src = "Images\image7.jpg" alt = "Generic placeholder thumbnail">
                     </div>
                     
                     <div class = "caption">
                        <h3>Thumbnail label</h3>
                        <p>Some sample text. Some sample text.</p>
                        
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
                  
                  <div class = "col-sm-6 col-md-4">
                     <div class = "thumbnail">
                        <img src = "Images\image13.jpg" alt = "Generic placeholder thumbnail">
                     </div>
                     
                     <div class = "caption">
                        <h3>Thumbnail label</h3>
                        <p>Some sample text. Some sample text.</p>
                        
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
                  
               </div>


                <div class = "row">
                  
                     
                  <div class = "col-sm-6 col-md-4">
                     <div class = "thumbnail">
                        <img src = "Images\image4.jpg" alt = "Generic placeholder thumbnail">
                     </div>
                     
                     <div class = "caption">
                        <h3>Thumbnail label</h3>
                        <p>Some sample text. Some sample text.</p>
                        
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
                  
                  <div class = "col-sm-6 col-md-4">
                     <div class = "thumbnail">
                        <img src = "Images\image13.jpg" alt = "Generic placeholder thumbnail">
                     </div>
                     
                     <div class = "caption">
                        <h3>Thumbnail label</h3>
                        <p>Some sample text. Some sample text.</p>
                        
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
                  
                  <div class = "col-sm-6 col-md-4">
                     <div class = "thumbnail">
                        <img src = "Images\image8.jpg" alt = "Generic placeholder thumbnail">
                     </div>
                     
                     <div class = "caption">
                        <h3>Thumbnail label</h3>
                        <p>Some sample text. Some sample text.</p>
                        
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
                  
               </div>




            <hr />

            <div class="row">
                <div class="col-sm-4">
                    <div class="panel panel-default text-center">
                        <div class="panel-body">
                            <span class="glyphicon glyphicon-ok"></span>
                            <h4>This is the heading</h4>
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum ex ante, 
                            a dictum nulla ultricies vitae. Fusce lorem ex, posuere eu commodo ac, 
                            fermentum a massa. Donec lacinia eros faucibus efficitur porttitor.
                            </p>
                        </div>
                    </div>
                </div>

                <div class="col-sm-4">
                    <div class="panel panel-default text-center">
                        <div class="panel-body">
                            <span class="glyphicon glyphicon-star"></span>
                            <h4>This is the heading</h4>
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum ex ante, 
                            a dictum nulla ultricies vitae. Fusce lorem ex, posuere eu commodo ac, 
                            fermentum a massa. Donec lacinia eros faucibus efficitur porttitor.
                            </p>
                        </div>
                    </div>
                </div>

                <div class="col-sm-4">
                    <div class="panel panel-default text-center">
                        <div class="panel-body">
                            <span class="glyphicon glyphicon-play-circle"></span>
                            <h4>This is the heading</h4>
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum ex ante, 
                            a dictum nulla ultricies vitae. Fusce lorem ex, posuere eu commodo ac, 
                            fermentum a massa. Donec lacinia eros faucibus efficitur porttitor.
                            </p>
                        </div>
                    </div>
                </div>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CraftStoreDatabaseConnectionString1 %>" DeleteCommand="DELETE FROM [Customer] WHERE [CustomerID] = @CustomerID" InsertCommand="INSERT INTO [Customer] ([CustomerID], [CustomerEmail], [CustomerPassword], [CustomerName], [CustomerAddress]) VALUES (@CustomerID, @CustomerEmail, @CustomerPassword, @CustomerName, @CustomerAddress)" ProviderName="<%$ ConnectionStrings:CraftStoreDatabaseConnectionString1.ProviderName %>" SelectCommand="SELECT [CustomerID], [CustomerEmail], [CustomerPassword], [CustomerName], [CustomerAddress] FROM [Customer]" UpdateCommand="UPDATE [Customer] SET [CustomerEmail] = @CustomerEmail, [CustomerPassword] = @CustomerPassword, [CustomerName] = @CustomerName, [CustomerAddress] = @CustomerAddress WHERE [CustomerID] = @CustomerID">
                    <DeleteParameters>
                        <asp:Parameter Name="CustomerID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CustomerID" Type="Int32" />
                        <asp:Parameter Name="CustomerEmail" Type="String" />
                        <asp:Parameter Name="CustomerPassword" Type="String" />
                        <asp:Parameter Name="CustomerName" Type="String" />
                        <asp:Parameter Name="CustomerAddress" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CustomerEmail" Type="String" />
                        <asp:Parameter Name="CustomerPassword" Type="String" />
                        <asp:Parameter Name="CustomerName" Type="String" />
                        <asp:Parameter Name="CustomerAddress" Type="String" />
                        <asp:Parameter Name="CustomerID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
            <!--end row-->

        </section>
    </div>
    <!-- end products-->




    <!-- drawing with natasha-->

    <div class="jumbotron">
        <div class="container text-center">
            <div class="row">
                <div class="col-md-4 text-center" >
                        <img src = "Images\image11.jpg" alt = "Generic placeholder thumbnail" >
                        
                </div>
                <div class="col-md-4 text-center" >
                        
                        <p> Hi! My name is Natasha! Since 2004, 
                            I've been running my own studio, 
                            creating art and teaching to all ages.
                            
                        </p>
                </div>

                <div class="col-md-4  text-center">
                    <img src = "Images\image10.png" alt = "Generic placeholder thumbnail">
                </div>
               
            </div>
          
        </div>
    </div>
    <!-- END jumbotron-->


</asp:Content>


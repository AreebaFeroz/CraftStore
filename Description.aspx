<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Description.aspx.cs" Inherits="Description" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="css/description.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    
     <!-- jumbotron-->

    <div class="jumbotron">
        <div class="container text-center">
            <h1><i class="fa fa-paint-brush"></i> Craft Store</h1>   
                   
                  <span class=" glyphicon glyphicon-picture logo-small" style="color:red;  font-size:50px;"></span> 
                      <span class="glyphicon glyphicon-gift logo-small" style="color:yellow;  font-size:50px;"></span> 
                           <span class="glyphicon glyphicon-scissors logo-small" style="color:green;  font-size:50px;"></span>  
                              <i class="fa fa-diamond logo-small" aria-hidden="true" style="color:silver; font-size:50px;"></i>   
                                 <i class="fa fa-paint-brush logo-small" aria-hidden="true" style="color:blue; font-size:50px;"></i>
                    







                   </div>           
    </div>
    <!-- END jumbotron-->
<section>
                <div class="container">
                       <div class = "row">

                              <div class = " col-xs-12 col-sm-6 col-md-6 pic-size">
                                 <div class = "thumbnail">
                                    <img src = "Images\graphics\image1.jpg" alt = "Generic placeholder thumbnail"  style="height: 350px;width:445px;">
                                 </div>
                                 
                                 
                                 </div>

                                 <div class = " col-xs-12 col-sm-5 col-md-5 pic-size">
                                         <div class="container-fluid">
                                                <div class="row">
                                                  <div class="col-sm-12">
                                                    <div class="panel panel-default text-center" style="width: 347px;height: 372px;">
                                                      <div class="panel-heading">
                                                        <h1>Basic</h1>
                                                      </div>
                                                      <div class="panel-body">
                                                        <p><strong>20</strong> Lorem</p>
                                                        <p><strong>15</strong> Ipsum</p>
                                                        <p><strong>5</strong> Dolor</p>
                                                        <p><strong>2</strong> Sit</p>
                                                        <p><strong>Endless</strong> Amet</p>
                                                      </div>

                                                      <a href = "#" class = "btn btn-primary btn-lg" role = "button">
                                                          <i class="fa fa-shopping-cart"> Buy Now</i>
                                                       </a> 
                                                      <br><br>
                                                    </div> 
                                                   </div> 
                                                </div>
                                          </div>
                                          

                                </div>

                          </div>
                          </div>
                          </section>
                          <br><br><br><br>



















    <!-- offers-->
    <div class="container">
        <section>
           <div class="row">
                <div class="col-sm-4">
                    <div class="panel panel-default text-center">
                        <div class="panel-body">
                           <span class="glyphicon glyphicon-gift " style="color:purple; font-size: 50px;"></span>
                            <h4>GIFTS</h4>
                            <p>
                            It’s great to send a card/painting when it’s someone’s birthday or a special 
                            occasion to make them smile , right ?
                            </p>
                        </div>
                    </div>
                </div>

                <div class="col-sm-4">
                    <div class="panel panel-default text-center">
                        <div class="panel-body">
                            <span class=" glyphicon glyphicon-picture " style="color:red; font-size:50px;"></span>
                             <h4>WALLPAPERS</h4>
                            <p>
                                Lovingly crafted to order, Papercuts intricately designed wallpapers are perfect for any room.<br /><br />
                            </p>
                        </div>
                    </div>
                </div>

                <div class="col-sm-4">
                    <div class="panel panel-default text-center">
                        <div class="panel-body">
                            <span class="glyphicon glyphicon-scissors " style="color:green; font-size:50px;"></span>
                            <h4>CRAFT-WORK</h4>
                            <p>
                                CraftStore’s delicately handcrafted accessories are super quirky and cute.
                                Want an Alice in Wonderland inspired bracelet? This is the place to go      
                                <br />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <!--end row-->

        </section>
    </div>
    <!-- end products-->




    <!-- drawing with natasha-->

    <div class="jumbotron">
        <div class="container text-center">
            <div class="row">
                <div class="col-sm-5 col-md-4 text-center" >
                        <img src = "Images\image11.jpg" alt = "Generic placeholder thumbnail" >
                        
                </div>
                <div class="col-sm-3 col-md-4 text-center" >
                        
                        <p> Hi! My name is Natasha! Since 2004, 
                            I've been running my own studio, 
                            creating art and teaching to all ages.
                            
                        </p>
                </div>

                <div class="col-sm-3 col-md-4  text-center">
                    <img src = "Images\image10.png" alt = "Generic placeholder thumbnail">
                </div>
               
            </div>
          
        </div>
    </div>
    <!-- END jumbotron-->



</asp:Content>


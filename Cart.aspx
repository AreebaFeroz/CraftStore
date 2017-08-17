<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="jumbotron">
    <div class="container">
    <div class="row">
        <div class="col-sm-12 col-md-10 col-md-offset-1" style="margin-top:80px;">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>Product</th>
                        <th>Quantity</th>
                        <th class="text-center">Price</th>
                        <th class="text-center">Total</th>
                        <th> </th>
                    </tr>
                </thead>
                <tbody>
                    <h2  runat="server" id="h2NoItems"></h2>

                     <asp:Repeater ID="rptrCartProducts" runat="server">
                     <ItemTemplate>
                       <tr>

                        <td class="col-sm-8 col-md-6">
                         <div class="media">
                            <div class="media-left">

                            <!-- image shoould be here -->
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading"><%#Eval("ProductName") %></h4>
                            </div>
                          </div>


                        </td>
                        <td class="col-sm-1 col-md-1" style="text-align: center"><strong>1</strong></td>
                        <td class="col-sm-1 col-md-1 text-center"><strong><%#Eval("Price") %></strong></td>
                        <td class="col-sm-1 col-md-1 text-center"><strong>$14.61</strong></td>
                        <td class="col-sm-1 col-md-1">
                        <asp:LinkButton runat="server" type="button" class="btn btn-danger" CommandArgument='<%#Eval("ProductID") %>' OnClick="btnRemoveItem_Click">
                            <span class="glyphicon glyphicon-remove"></span> Remove
                        </asp:LinkButton></td>
                                
                    </tr>
                    </ItemTemplate>
                  </asp:Repeater>
                </tbody>
                <tfoot>
                    <tr>
                        <td>   </td>
                        <td>   </td>
                        <td>   </td>
                        <td><h5>Subtotal<br/>Estimated shipping</h5><h3>Total</h3></td>
                        <td class="text-right"><h5><strong>$24.59<br/>$6.94</strong></h5><h3>$31.53</h3></td>
                    </tr>
                    <tr>
                        <td>   </td>
                        <td>   </td>
                        <td>   </td>
                        <td>
                        <button type="button" class="btn btn-default">
                            <span class="glyphicon glyphicon-shopping-cart"></span> Continue Shopping
                        </button></td>
                        <td>
                        <button type="button" class="btn btn-success">
                            Checkout <span class="glyphicon glyphicon-play"></span>
                        </button></td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>
</div>
</div>

</asp:Content>


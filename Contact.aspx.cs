using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Net.Mail;
using System.Net;



public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    Accessible access = new Accessible();

    protected void btnForm_Click(object sender, EventArgs e)
    {
        string User, Email, Msg;
        if (username.Text != "" && useremail.Text != "" && usermsg.Text != "")
        {

            User = username.Text.ToString();
            Email = useremail.Text.ToString();
            Msg = usermsg.Text.ToString();
            
            //sendMsg(Email, User, Msg);


            SmtpClient smtpClient = new SmtpClient();
        MailMessage message = new MailMessage();

        try
        {
            MailAddress fromAddress = new MailAddress(Email, User);

            // You can specify the host name or ipaddress of your server
            // Default in IIS will be localhost
            smtpClient.Host = "localhost";

            //Default port will be 25
            smtpClient.Port = 25;
            smtpClient.UseDefaultCredentials = true;

            //From address will be given as a MailAddress Object
            message.From = fromAddress;

            // To address collection of MailAddress
            message.To.Add("craftstore50@gmail.com");
            message.Subject = "Feedback";

            // CC and BCC optional
            // MailAddressCollection class is used to send the email to various users
            // You can specify Address as new MailAddress("admin1@yoursite.com")
            //message.CC.Add("admin1@yoursite.com");
            //message.CC.Add("admin2@yoursite.com");

            // You can specify Address directly as string
            //message.Bcc.Add(new MailAddress("admin3@yoursite.com"));
            //message.Bcc.Add(new MailAddress("admin4@yoursite.com"));

            //Body can be Html or text format
            //Specify true if it  is html message
            message.IsBodyHtml = false;

            // Message body content
            message.Body = Msg;

            // Send SMTP mail
            smtpClient.Send(message);
            
            lblStatus.Text = "Email successfully sent.";
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Send Email Failed." + ex.Message;
        }

    




            //   Session["newEmail"] = User;
          //  Response.Redirect("~/Home.aspx");


        }
        /*email code*/
        else
        {
            ErrorMessage.ForeColor = Color.Red;
            ErrorMessage.Text = "All fields are mandatory";
        }
    }



 
}
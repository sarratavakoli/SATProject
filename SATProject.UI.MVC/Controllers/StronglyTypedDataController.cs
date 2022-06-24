
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using MimeKit;
using SATProject.UI.MVC.Models;


namespace SATProject.UI.MVC.Controllers
{
    public class StronglyTypedDataController : Controller
    {


        //public IActionResult Index()
        //{
        //    return View();
        //}

        #region Adding Credentials to appsettings.json
        //Before creating any actions or Views 
        #endregion

        private readonly IConfiguration _config;

        public StronglyTypedDataController(IConfiguration config)
        {
            _config = config;
        }



        public IActionResult Contact()
        {
            #region Code Generation Steps

            //1. Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution
            //2. Go to the Browse tab and search for Microsoft.VisualStudio.Web
            //3. Click Microsoft.VisualStudio.Web.CodeGeneration.Design
            //4. On the right, check the box next to the CORE1 project, then click "Install"
            //5. Once installed, return here and right click the Contact action
            //6. Select Add View, then select the Razor View template and click "Add"
            //7. Enter the following settings:
            //      - View Name: Contact
            //      - Template: Create
            //      - Model Class: ContactViewModel
            //8. Leave all other settings as-is and click "Add"

            #endregion

            return View();
        }

        //Now we need to handle what to do when the user submits the form. For this,
        //we will make another Contact Action, this time intended to handle the POST request.
        [HttpPost]
        public IActionResult Contact(ContactViewModel cvm)
        {
            //When a clasds hass validfation attributes,

            if (!ModelState.IsValid)
            {
                //Send them back to the form. We can pass the object to the View
                //so the form will contain the original information they provided.
                return View(cvm);
            }
            //To handle sending the email, we'll need to install a NuGet Package.
            #region Email Setup Steps & Email Info

            //1. Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution
            //2. Go to the Browse tab and search for NETCore.MailKit
            //3. Click NETCore.MailKit
            //4. On the right, check the box next to the CORE1 project, then click "Install"
            //5. Once installed, return here
            //6. Add the following using statements & comments:
            //      - using MimeKit; //Added for access to MimeMessage class
            //      - using MailKit.Net.Smtp; //Added for access to SmtpClient class
            //7. Once added, return here to continue coding email functionality

            //MIME - Multipurpose Internet Mail Extensions - Allows email to contain
            //information other than ASCII, including audio, video, images, and HTML

            //SMTP - Secure Mail Transfer Protocol - An internet protocol (similar to HTTP)
            //that specializes in the collection & transfer of email data

            #endregion

            //Create the format for the message content we will recieve from the contact form
            string message = $"You have received a new email from your site's contact form!<br />" +
                $"Sender: {cvm.Name}<br />Email: {cvm.Email}<br />Subject: {cvm.Subject}<br />" +
                $"Message: {cvm.Message}";


            //create a MimeMessage object to assist with storing/transporting the email
            //omformatiom from the contact form
            var mm = new MimeMessage();

            //Even though the use is the one attempting to send a message to us, the 
            //actual sender of the email is the email user we set up with our hosting provider.

            //We can access the credentials for this email user from our appsetting.json file
            mm.From.Add(new MailboxAddress("User", _config.GetValue<string>("Credentials:Email:User")));

            //The recipient of this email will be our personal email address, which is also
            //stored is appseting.json

            mm.To.Add(new MailboxAddress("Personal", _config.GetValue<string>("Credentials:Email:Recipient")));

            //The subjects wull be the one provided by the one provided by the user, which is stored in the cvm object
            mm.Subject = cvm.Subject;

            //The body of the message will be formatted with the string we created above.
            mm.Body = new TextPart("HTML") { Text = message };

            //We can set the priority of the message as "urgent" so it will be flagged in our mailbox
            mm.Priority = MessagePriority.Urgent;

            //We can also add the user's provided email address to the list of ReplyTo addresses
            //so our replies can be sent edirectly to them (instead of sending to our own email user).
            mm.ReplyTo.Add(new MailboxAddress("Sender", cvm.Email));

            //The using directive will create the SmtpClient object, which is used to send the email.
            //Once all of the code inside the using directive's scope has been exceuted, it will
            //automatically close any open connections and sipose of the object fror us.

            using (var client = new SmtpClient())
            {
                //I must use port 8889 for my internet provider
                client.Connect(_config.GetValue<string>("Credentials:Email:Client"), 8889);

                //Log in to mail server using the credentials for our email user
                client.Authenticate(

                      //Username
                      _config.GetValue<string>("Credentials:Email:User"),

                    //Password
                    _config.GetValue<string>("Credentials:Email:Password")
                    );
                //Its possible the mail server may be down when the user attemots to contact us.
                //So we can "encapsulate" our code to send the message in a try/catch
                try
                {
                    //try to send the email
                    client.Send(mm);
                }
                catch (Exception ex)
                {
                    //if their is a issue, we can store an error message un the ViuewBag
                    // tpo bne displayed in  the view
                    ViewBag.ErrorMessage = $"There was an error processing yojur request. Please try" +
                        $"again later.<br />Error Message: {ex.StackTrace}";

                    //Return the user to the View with their form informatin intact
                    return View(cvm);

                }


            }

            //if all goes well, return a view that dispolays a comnfirmation to the use that their email has been sent successfully


            return View("EmailConfirmation", cvm);
        }


    }
}

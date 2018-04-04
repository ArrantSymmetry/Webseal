using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using EncryptionLibrary;
using Webseal.Util;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Webseal.Controllers
{
    //change ViewBag.msg del  WebsealMapper
    //chamge this int proxyID = Int32.Parse(paramDecrypt[1]);
    //change references to db to service
    //create a GetTitle(User.UserId).ToString(); method
    //check proxy logic works
    //check decryption
    //change getheader remove segmentation class from string extentions

   // [Route("{parm:string}")]
    public class HomeController : Controller
    {

        [HttpGet]
        public ViewResult Index()
        {
            string parm = Properties.Resource.urlParam;
            if (parm == Constants.SessionExpire) //If redirected due to session expired this is a possible 
                                                 //webseal parameter
            {
                //landing page action for view Expired
                //Redirect to:  SearchView(ViewBag.ErrorMsg);
                ViewBag.Msg = Constants.SessionExpire;
                //log.Info(ViewBag.Msg);
            }
            if (!(Properties.Resource.ByPassWebSeal == "1")) //If Webseal is not bypassed
            {
                if (!string.IsNullOrEmpty(parm)) //Check that parameter that is passed from webseal != null
                {
                    //Get UserId from encrypted string
                    string paramEncode = Convert.ToBase64String(Encoding.ASCII.GetBytes(parm));
                    string todayDate = "27/03/2018";  //Normally would be DateTime.Now.ToString("dd/MM/yyyy");

                    Crypto urlCrypto = new Crypto(todayDate);
                    SessionUser.UserDecryptedValue = urlCrypto.DecryptAndUrlDecodeStringAES(paramEncode, todayDate);


                    string[] paramDecrypted = SessionUser.UserDecryptedValue.Split('|');

                    if (!string.IsNullOrEmpty(paramDecrypted[1])) //For External Users
                    {

                        int userID =
                            Int32.Parse(Regex.Match(paramDecrypted[0], @"\d+").Value); //Get only interger portion
                        int proxyID = Int32.Parse(Regex.Match(paramDecrypted[1], @"\d+").Value); //Get only interger portion

                        if (userID.Equals(proxyID)) //Non Proxy User
                        {
                            //Set The SessionUser values 
                            SessionUser.UserId = Int32.Parse(Regex.Match(paramDecrypted[0], @"\d+").Value); //Get only interger portion
                            SessionUser.IsProxy = false;
                            //Sanlan format for Mud user, keep?							
                            SessionUser.MudUserId = paramDecrypted[0].Substring(1).PadLeft(8, '0');
                            SessionUser.UserType = (int)Constants.UserIdType.User;
                        }
                        else //Proxy User
                        {

                            SessionUser.UserId = Int32.Parse(Regex.Match(paramDecrypted[0], @"\d+").Value); //Get only interger portion
                            SessionUser.IsProxy = true;
                            SessionUser.ProxyId = SessionUser.UserId;
                            SessionUser.MudUserId = SessionUser.UserId.ToString().Substring(1).PadLeft(8, '0');
                            SessionUser.UserType = (int)Constants.UserIdType.Proxy;
                        }
                    }
                    else if (!string.IsNullOrEmpty(paramDecrypted[0])) //For Internal Users
                    {
                        SessionUser.UserId = Int32.Parse(Regex.Match(paramDecrypted[0], @"\d+").Value); //Get only interger portion
                        SessionUser.MudUserId = paramDecrypted[0].Substring(1).PadLeft(8, '0');
                        SessionUser.UserType = (int)Constants.UserIdType.Internal;
                        SessionUser.IsMudUser = true;
                    }
                    else //If Did Not find value in Parameters 0 and 1
                    {
                        ViewBag.Msg = Webseal.Properties.Resource.NoProxyData;
                        //redirect to:  SearchView(ViewBag.Msg);
                        throw new ArgumentNullException(ViewBag.ErrorMsg);

                    }

                }
                else //Parameter is not passed
                {
                    if (SessionUser.UserId is null) //Session is empty
                    {
                        SessionUser.UserType = 0;
                        ViewBag.ErrorMsg = Webseal.Properties.Resource.UnauthorisedUser;
                        //this should then redirect to an error message SearchView(ViewBag.Msg)
                        throw new ArgumentNullException(ViewBag.ErrorMsg);
                    }
                }
            }
            else //if web seal off.
            {
                //set user to be domainUser a preconfigured role with preconfigured privs
                SessionUser.UserId = Convert.ToInt32(Webseal.Properties.Resource.domainUser.Substring(1));
                SessionUser.MudUserId = SessionUser.UserId.ToString().Substring(1).PadLeft(8, '0');
                SessionUser.UserType = (int)Constants.UserIdType.Internal;

            }

            //JsonConvert.DeserializeObject<IDictionary<string, string>>(SessionUser.ConvertToJson())
            return View();
    }


        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "lEADS BITCH!";
            return View(ViewBag.Message);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Msg = "Contact page.";
            return View(ViewBag.Msg);
        }


    }
  
}
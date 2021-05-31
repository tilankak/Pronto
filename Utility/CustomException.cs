using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronto.Utility
{
    public class TokenInvalidException: Exception
    {

    }
    public class WebLogonRequiredException : Exception
    {
        

        public WebLogonRequiredException(string Message) : base(Message)
        {
            
        }

        public WebLogonRequiredException() : base("")
        {

        }

    }

    public class InvalidHardwareException : Exception
    {


        public InvalidHardwareException(string Message) : base(Message)
        {
            
        }

        public InvalidHardwareException() : base("")
        {

        }

    }

    public class ConnectionErrorException : Exception
    {


        public ConnectionErrorException(string Message) : base(Message)
        {

        }

        public ConnectionErrorException() : base(GetMessage())
        {
            
        }

        private static string GetMessage()
        {
           
             return "Connection Error. Unable to connect to Server"; 
        }

    }

    public class CFTException: Exception
    {
        Dictionary<int, string> dicErrorMessages = new Dictionary<int, string>();

        private string _message;
        private string ErrorDetails;
        public string ErrorDescription { get; set; }
        public CFTException(string Message,string Detail,int ErrorNumber) : base(Message)
        {
            ErrorDetails = Detail;

            dicErrorMessages.Add(909, "Ops! System Error (Multiple Errors. Check Logs for More Details). Please Contact Your Support Team for any further Help.");
            dicErrorMessages.Add(910, "Error: Access Denied. This Document is Enabled for Location Validation. Your Location Check Has Failed. Please Contact File/Data Owner for More Detail.");
            dicErrorMessages.Add(911, "Error: Access Denied. This Document is Enabled for Public IP Validation. Your Public IP Validation has Failed. Please Contact File/Data Owner for More Detail.");
            dicErrorMessages.Add(912, "Error: Access Denied. This Document is Enabled to Open from Different Application. Your Application Validation Has Failed. Please Contact File/Data Owner for More Detail.");
            dicErrorMessages.Add(913, "Error: Access Denied. Date Validation Failed. Your Document Access has Expired. Please Contact File/Data Owner for More Details.");
            dicErrorMessages.Add(914, "Error: Access Denied. This Document is Enabled for Mobile MFA. Your Mobile MFA Validation Failed. Make Sure You are Using Correct Mobile Device, which is Registered on Server to Get the Notification and You Should Respond to it Ontime. Please Contact File/Data Owner for More Detail.");
            dicErrorMessages.Add(915, "Error: Access Denied. This Document is Enabled to use Different Authentication Method. Your Authentication Validation Has Failed. File Owner Can Enable Hardware, Web or Both (Hardware +Web) type Authentication on a Document. Please Contact File/Data Owner for More Detail.");
            dicErrorMessages.Add(916, "Error: Access Denied. This Document is Enabled for Mobile MFA. Your Mobile MFA Validation Failed. Make Sure Your Mobile Device is Registered on Server to Get the Notification and You Should Respond to it Ontime. Please Contact File/Data Owner for More Detail.");
            dicErrorMessages.Add(917, "Error: Access Denied. Request Rejected by Mobile User. This Document is Enabled for Mobile MFA. Your Mobile MFA Validation Failed. Please Contact File/Data Owner for More Detail. ");
            dicErrorMessages.Add(918, "Error: Access Denied. This Document is Enabled to use only Web Authentication Method. Your Authentication Validation Has Failed. File Owner Can Enable Hardware, Web or Both (Hardware +Web) type Authentication on a Document. Please Contact File/Data Owner for More Detail.");
            dicErrorMessages.Add(950, "Error: Request Failed, User Already Exist. Please Contact Your Support Team for any further Help.");
            dicErrorMessages.Add(951, "Error: Request Failed, Invalid Verification Code. Please Check If Your Email is Correct and Enter the Code Received in your Email. Please Contact Your Support Team for any further Help.");
            dicErrorMessages.Add(952, "Error: Request Failed, Invalid Verification Code. Please Check If Your Email is Correct and Enter the Code Received in your Emails. Hardware details of this machine already registered on Server with different Email to What you have entered in previous Screen. You will Receive TWO verification code, one code in Your Email entered on previous Screen and Another code in an email, which Exist on Server with these Hardware Details. Please Contact Your Support Team for any further Help.");
            dicErrorMessages.Add(953, "Error: Request Failed, Passcode Expired. Please Request New Passcode and Check Your Email. Please Contact Your Support Team for any further Help.");
            dicErrorMessages.Add(954, "Error: Request Failed, Invalid Verification Code. Email & Passcode combination entered is Wrong. Please Provide Correct Email & Passcode Combination in your Request. Please Contact Your Support Team for any further Help.");

            if(dicErrorMessages.ContainsKey(ErrorNumber))
            {
                ErrorDescription = dicErrorMessages[ErrorNumber];
            }
            else
            {
                ErrorDescription = Message;
            }

        }

        public CFTException(Exception ex, string Detail) : base(ex.Message)
        {
            this.ErrorDescription = ex.Message;
            this.ErrorDetails = string.Format("{0} \n {1}", Detail, ex.ToString());
        }

        public override string Message
        {
            get
            {
                _message = base.Message;
                return this.ErrorDescription;
            }
        }

        public override string ToString()
        {
            return  string.Format("{0} \n {1} \n {2}", this._message ,this.ErrorDetails, base.ToString());
        }
    }

}

using System;
using System.Globalization;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Citadel.RahkaranClient.Models.Authentication;

namespace Citadel.RahkaranClient
{
    public class SessionContext
    {
        private static SessionContext _sessionContext;

        public WebClient Client { get; private set; }
        internal static string BaseAddress { get; private set; }
        internal static string SgName { get; private set; }
        internal static string UserName { get; private set; }
        internal static string Password { get; private set; }
        internal int AuthourizeRetryTime { get; set; } = 5;
        internal int AuthourizeRetryDelay { get; set; } = 3;

        private ServiceClientWrapper ClientWrapper; 
        public string Id { get; private set; }
        public string Cookie { get; private set; }
        private DateTime TimeSpan { get; set; }
        
        internal static SessionContext Current { get; private set; }

        private void AuthorizeSession()
        {
            ClientWrapper = ServiceClientWrapper.Create(BaseAddress, false);
            ClientWrapper.Login(UserName, Password, out var sessionId, out var sessionCookie);
            _sessionContext.Id = sessionId;
            _sessionContext.Cookie = sessionCookie;
        }

        public static SessionContext Create(Configuration configuration)
        {
            BaseAddress = configuration.BaseAddress;
            UserName = configuration.UserName;
            Password = configuration.Password;
            SgName = configuration.SgName;
            

            return Current;
        }

        internal static void Authorize()
        {
            if (_sessionContext != null && _sessionContext.TimeSpan >= DateTime.Now.AddSeconds(-30)) return;

            _sessionContext = new SessionContext();
            _sessionContext.AuthorizeSession();
            _sessionContext.TimeSpan = DateTime.Now;
            Current = _sessionContext;
        }

        class ServiceClientWrapper
        {
            const string AuthenticationServiceRelativeAddress = "/Services/Framework/AuthenticationService.svc";

            private readonly string AuthenticationServiceAddress;
            public readonly string AddressPrefix;

            private ServiceClientWrapper(string addressPrefix)
            {
                AddressPrefix = addressPrefix;
                AuthenticationServiceAddress = $"{AddressPrefix}/{SgName}/{AuthenticationServiceRelativeAddress}";
            }

            public WebClient Login(string userName, string password, out string sessionID, out string sessionCookie)
            {
                string authCookie = "";
                WebClient client = new WebClient();
                //We need to login to Rahakarn before any business service call//in case of successful login an authentication cookie will be returnedsessionID = Login(client, userName, password, outauthCookie);//var sessionID = Login(client, "admin", "admin", out authCookie);client.Headers["Set-Cookie"] = authCookie;client.Headers["content-Type"] = "application/json";client.Encoding = Encoding.UTF8;returnclient;}
                sessionID = Login(client, userName, password, out authCookie);
                client.Headers["Set-Cookie"] = authCookie;
                sessionCookie = authCookie;
                client.Headers["content-Type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                return client;
            }

            public void Logout(WebClient client, string sessionID)
            {
                client.UploadString(AuthenticationServiceAddress + "/logout", JsonConvert.SerializeObject(sessionID)); 
                client.Dispose();
            }

            public string MakeServiceAddress(string relativeServiceAddress)
            {
                return AddressPrefix + relativeServiceAddress;
            }

            //Wraps login process
            private string Login(WebClient client, string userName, string password, out string authCookie)
            {
                authCookie = "";
                try
                {
                    var result = client.DownloadString(AuthenticationServiceAddress + "/session");
                    var session = JsonConvert.DeserializeObject<AuthenticationSession>(result);
                    var m = HexStringToBytes(session.RSA.M);
                    var e = HexStringToBytes(session.RSA.E);
                    var rsa = new RSACryptoServiceProvider(1024);
                    rsa.ImportParameters(new RSAParameters{
                        Exponent = e, Modulus = m
                    });
                    var sessionPlusPassword = session.Id + "**" + password;
                    client.Headers["content-Type"] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    client.Headers["Set-Cookie"] = client.ResponseHeaders["Set-Cookie"];

                    ExtendedIdentity ei;
                    ei.sessionId = session.Id;
                    ei.username = userName;
                    ei.password = BytesToHexString(rsa.Encrypt(Encoding.Default.GetBytes(sessionPlusPassword), false));
                    var data = JsonConvert.SerializeObject(ei);
                    client.UploadString(AuthenticationServiceAddress + "/login", "POST", data);
                    authCookie = client.ResponseHeaders["Set-Cookie"].Split(',')[1];
                    return session.Id;
                }
                catch (WebException webEx)
                {
                    if (webEx.Response != null)
                    {
                        return "";
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            private static byte[] HexStringToBytes(string hex)
            {
                if (hex.Length == 0)
                {
                    return new byte[] { 0 };
                }

                if (hex.Length % 2 == 1)
                {
                    hex = "0" + hex;
                } 
                
                byte[] result = new byte[hex.Length / 2];
                
                for (int i = 0; i < hex.Length / 2; i++)
                {
                    result[i] = byte.Parse(hex.Substring(2 * i, 2), NumberStyles.AllowHexSpecifier);
                } 
                
                return result;
            }

            private static string BytesToHexString(byte[] input)
            {
                StringBuilder hexString = new StringBuilder(64);

                for (int i = 0; i < input.Length; i++)
                {
                    hexString.Append(String.Format("{0:X2}", input[i]));
                }

                return hexString.ToString();
            }

            public static ServiceClientWrapper Create(string baseWebAddress, bool configureBasedOnSgVirtualPath)
            {
                const string BaseAddressResolverServiceRelativeAddress = "/BaseAddressResolver.svc";

                try
                {
                    var addressPrefix = "";
                    if (!configureBasedOnSgVirtualPath)
                    {
                        addressPrefix = baseWebAddress;
                    }
                    else
                    {
                        string baseAddressResolverService = baseWebAddress + BaseAddressResolverServiceRelativeAddress;
                        WebClient client = new WebClient();
                        //client.Proxy.Credentials = new NetworkCredential("mohsenta", "---");
                        string redirectorAddress =
                            client.DownloadString(baseAddressResolverService + "/GetBaseAddress");
                        redirectorAddress = JsonConvert.DeserializeObject<string>(redirectorAddress);
                        baseWebAddress = baseWebAddress.Substring(0, baseWebAddress.LastIndexOf("/"));
                        addressPrefix = baseWebAddress + redirectorAddress;
                    }

                    return new ServiceClientWrapper(addressPrefix);
                }
                catch (WebException webEx)
                {
                    if (webEx.Response != null)
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        [Serializable]
        struct ExtendedIdentity
        {
            [DataMember(Order = 1)] 
            public string sessionId;
            [DataMember(Order = 2)] 
            public string username;
            [DataMember(Order = 3)] 
            public string password;
        }
}
}

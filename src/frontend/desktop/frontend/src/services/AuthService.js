import { UserAgentApplication } from "msal";
import {User} from "../models/User";

export default class AuthService 
{
    constructor() {
     
        //https://www.youtube.com/watch?v=Dg9rUXxNV-c
        //var clientid =  window.backend.Config.AzureAD.AADClientId;
        //var authority =  window.backend.Config.AzureAD.AADUrl;

        //console.log(window.backend.Config)
        const isIE = () => {
          const ua = window.navigator.userAgent;
          const msie = ua.indexOf("MSIE ") > -1;
          const msie11 = ua.indexOf("Trident/") > -1;
        
          // If you as a developer are testing using Edge InPrivate mode, please add "isEdge" to the if check
          // const isEdge = ua.indexOf("Edge/") > -1;
        
          return msie || msie11;
      };

        this.msalApp = new UserAgentApplication({
            auth: {
              clientId: "clientid", 
              authority: "https://login.microsoftonline.com/common", 
              validateAuthority: true,
              //postLogoutRedirectUri: Config.PortalUrl(),
              navigateToLoginRequestUrl: false
            },
            cache: {
              cacheLocation: "sessionStorage",
              storeAuthStateInCookie: isIE()
            }
          });
        
        
    }

    signIn() {

       // var scope = window.backend.Config.AzureAD.AADScope

        this.msalApp.loginPopup("scope")
          .then(loginResponse => {
            console.log('id_token acquired at: ' + new Date().toString());
            console.log(loginResponse);
      
            if (this.msalApp.getAccount()) {
              var acct = this.msalApp.getAccount();
            }
          }).catch(error => {
            console.log(error);
          });
    }

    signOut() {
        this.msalApp.logout();
    }
}
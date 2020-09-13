import { UserAgentApplication } from "msal";
import {User} from "../models/User";

export default class AuthService 
{
    constructor() {

        //https://www.youtube.com/watch?v=Dg9rUXxNV-c
        var clientid =  window.backend.configs.AAD.AADClientId;
        var authority =  window.backend.configs.AAD.AADUrl;

        this.msalApp = new UserAgentApplication({
            auth: {
              clientId: clientid, 
              authority: authority, 
              validateAuthority: true,
              //postLogoutRedirectUri: Config.PortalUrl(),
              navigateToLoginRequestUrl: false
            },
            cache: {
              cacheLocation: "sessionStorage",
              storeAuthStateInCookie: isIE()
            }
          });
        
        const isIE = () => {
            const ua = window.navigator.userAgent;
            const msie = ua.indexOf("MSIE ") > -1;
            const msie11 = ua.indexOf("Trident/") > -1;
          
            // If you as a developer are testing using Edge InPrivate mode, please add "isEdge" to the if check
            // const isEdge = ua.indexOf("Edge/") > -1;
          
            return msie || msie11;
        };
    }

    signIn() {

        var scope = window.backend.configs.AAD.AADScope

        this.msalApp.loginPopup(scope)
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
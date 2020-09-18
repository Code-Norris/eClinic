import { UserAgentApplication } from "msal";
import User from "../models/User";

export default class AuthService 
{
    constructor() {
     
        //https://www.youtube.com/watch?v=Dg9rUXxNV-c
        //var clientid =  window.backend.Config.AzureAD.AADClientId;
        //var authority =  window.backend.Config.AzureAD.AADUrl;
        var clientid = "14b48a21-c5f7-4c38-b2fd-16361fef68c2";
        var authority = "https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47";

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
        
        
    }

    oidcSignin() {

       // var scope = window.backend.Config.AzureAD.AADScope
       var scope = "api://14b48a21-c5f7-4c38-b2fd-16361fef68c2/desktop/All";
       
        this.msalApp.loginPopup(scope)
          .then(loginResponse => {
            console.log('id_token acquired at: ' + new Date().toString());
            console.log(loginResponse);

            this.oauthGetAccessTokenSilent(scope);


            // if (this.msalApp.getAccount()) {
            //   var acct = this.msalApp.getAccount();
            // }
          }).catch(error => {
            console.log(error);
          });
    }

    oauthGetAccessTokenSilent(scope) {

      var tokenRequest = {
        scopes: [scope],
        prompt: 'consent'
      };
      
      this.msalApp.acquireTokenSilent(tokenRequest)
            .then(response => 
            {
              var user = new User();
              user.TenantId = response.idToken.tenantId;
              user.UserName = response.account.userName;
              user.Name = response.account.name;
              user.AccessTokenExpiresOn = response.expiresOn;
              user.Scopes = response.scopes;
              user.Issuer = response.idToken.issuer;
              user.AccessToken = response.accessToken;
              user.IdToken = response.idToken.rawIdToken

            })
            .catch(error => {
                // could also check if err instance of InteractionRequiredAuthError if you can import the class.
                if (error.name === "InteractionRequiredAuthError") {
                    return this.msalApp.acquireTokenPopup(tokenRequest)
                        .then(response => {
                            // get access token from response
                            // response.accessToken
                        })
                        .catch(err => {
                          console.error(err)
                        });
                }
            });
    }

    signOut() {
        this.msalApp.logout();
    }
}
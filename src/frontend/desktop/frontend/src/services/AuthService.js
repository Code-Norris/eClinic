import { PublicClientApplication, InteractionRequiredAuthError } from "@azure/msal-browser";
import User from "../models/User";

export default class AuthService 
{
    constructor() {
     
        //https://www.youtube.com/watch?v=Dg9rUXxNV-c
        //var clientid =  window.backend.Config.AzureAD.AADClientId;
        //var authority =  window.backend.Config.AzureAD.AADUrl;
        this.clientid = "14b48a21-c5f7-4c38-b2fd-16361fef68c2";
        this.authority = "https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47";
        this.scopes = ["api://eClinic/PatientRegistration/PC.All"];

        this.msalConfig = {
          auth: {
            clientId: this.clientid,
            authority: this.authority,
            navigateToLoginRequestUrl: true
          },
          cache: {
            cacheLocation: "sessionStorage", // This configures where your cache will be stored
            storeAuthStateInCookie: false, // Set this to "true" if you are having issues on IE11 or Edge
          }
        };

        // Add scopes here for ID token to be used at Microsoft identity platform endpoints.
        this.authnIdTokenScopes = {
          scopes: this.scopes
        };
        
        // Add scopes here for access token to be used at Microsoft Graph API endpoints.
        const authzAccessTokenScope = {
          scopes: this.scopes
        };

        this.msalApp = new PublicClientApplication(this.msalConfig);
    }

    //https://docs.microsoft.com/en-us/azure/active-directory/develop/tutorial-v2-javascript-auth-code
    oidcSignin() {
       
      var signedInUser = this.msalApp.getAllAccounts()[0];
        this.silentRequest = {
          account: signedInUser,
          scopes: this.scopes
        }
        
      this.msalApp.acquireTokenSilent(this.silentRequest)
      .then((response) => {

        var user = this.createUser(response);

      }).catch(error => {

        console.warn("silent token acquisition fails. acquiring token using redirect");

        // fallback to interaction when silent call fails
        this.msalApp.loginPopup(this.authnIdTokenScopes).then((response) => {

          var user = this.createUser(response);
  
        }).catch(err => {console.error(err)});
        
      })
    }

    createUser(tokenResp) {
        var user = new User();
        user.TenantId = tokenResp.tenantId;
        user.UserName = tokenResp.account.username;
        user.Name = tokenResp.account.name;
        user.AccessTokenExpiresOn = tokenResp.expiresOn;
        user.Scopes = tokenResp.scopes;
        user.Issuer = tokenResp.idTokenClaims.iss;
        user.AccessToken = tokenResp.accessToken;
        user.IdToken = tokenResp.idToken;

        return user;
    }

    oauthGetAccessTokenSilent() {

      var tokenRequest = {
        authority: this.authority,
        scopes: [this.scope],
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
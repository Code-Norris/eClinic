import { PublicClientApplication, InteractionRequiredAuthError } from "@azure/msal-browser";
import User from "../models/User";

export default class AuthService 
{
    constructor() {
        this.user = null;

        this.clientid = "14b48a21-c5f7-4c38-b2fd-16361fef68c2";
        this.authority = "https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47";
        
        this.msalConfig = {
          auth: {
            clientId: this.clientid,
            authority: this.authority
          },
          cache: {
            cacheLocation: "sessionStorage", // This configures where your cache will be stored
            storeAuthStateInCookie: false, // Set this to "true" if you are having issues on IE11 or Edge
          }
        };

        // Add scopes here for ID token to be used at Microsoft identity platform endpoints.
        this.loginRequest  = {
          scopes: ["openid", "api://eclinic/desktop/Desktop.All"]
          //scopes: ["openid", "api://eclinic/desktop/Desktop.All"]
        };

        this.tokenRequest  = {
          scopes: ["api://eClinic/PatientRegistration/PC.All", "offline_access"],
          account: '',
          forceRefresh: false // Set this to "true" to skip a cached token and go to the server to get a new token
        };
        

        this.msalApp = new PublicClientApplication(this.msalConfig);
    }

    //https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/samples/msal-browser-samples/VanillaJSTestApp2.0/app/multipleResources/auth.js

    //https://docs.microsoft.com/en-us/azure/active-directory/develop/tutorial-v2-javascript-auth-code

    //https://github.com/Azure-Samples/ms-identity-javascript-v2
    oidcSignin(request) {
       
      //request.account = this.msalApp.getAccountByUsername(username);

      if(this.user != null) {
        request.account = this.user.Account;
      } else {
        request.account = null;
      }

      this.msalApp.acquireTokenSilent(request)
        .then(tokenResponse => {
            this.createUser(tokenResponse);
        })
        .catch(error => {

            console.warn("silent token acquisition fails. acquiring token using popup");

            if (error.toString().includes("no_account_in_silent_request") || 
                error instanceof InteractionRequiredAuthError) {

                // fallback to interaction when silent call fails

                this.msalApp.acquireTokenPopup(request)
                    .then(tokenResponse => {

                        this.createUser(tokenResponse);

                    }).catch(error => {
                        console.error(error);
                    });
            } else {
                console.warn(error);   
            }
    });

      // fallback to interaction when silent call fails
      // this.msalApp.acquireTokenPopup(this.loginRequest).then((response) => {

      //   var user = this.createUser(response);

      //   this.oauthTokenRequest(user)

      // }).catch(err => {console.error(err)});

    }

    oauthTokenRequest(user) {

      //var account = this.msalApp.getAccountByHomeId(user.AccountHomeId)
      this.tokenRequest.account = user.Account

      this.msalApp.acquireTokenSilent(this.tokenRequest)
      .then((response) => {

        //var user = this.createUser(response);
        user.accessToken = response.accessToken

      }).catch(error => {

        console.warn("silent token acquisition fails. acquiring token using redirect");

        // fallback to interaction when silent call fails
        // this.msalApp.acquireTokenPopup(this.loginRequest).then((response) => {

        //   var user = this.createUser(response);
  
        // }).catch(err => {console.error(err)});
        
      })
    }

    createUser(tokenResp) {
        this.user = new User();
        this.user.Account= tokenResp.account
        this.user.TenantId = tokenResp.tenantId;
        this.user.UserName = tokenResp.account.username;
        this.user.Name = tokenResp.account.name;
        this.user.AccessTokenExpiresOn = tokenResp.expiresOn;
        this.user.Scopes = tokenResp.scopes;
        this.user.Issuer = tokenResp.idTokenClaims.iss;
        this.user.AccessToken = tokenResp.accessToken;
        this.user.IdToken = tokenResp.idToken;

        return this.user;
    }

    // oauthGetAccessTokenSilent() {

    //   var tokenRequest = {
    //     authority: this.authority,
    //     scopes: [this.scope],
    //     prompt: 'consent'
    //   };
      
    //   this.msalApp.acquireTokenSilent(tokenRequest)
    //         .then(response => 
    //         {
    //           var user = new User();
    //           user.TenantId = response.idToken.tenantId;
    //           user.UserName = response.account.userName;
    //           user.Name = response.account.name;
    //           user.AccessTokenExpiresOn = response.expiresOn;
    //           user.Scopes = response.scopes;
    //           user.Issuer = response.idToken.issuer;
    //           user.AccessToken = response.accessToken;
    //           user.IdToken = response.idToken.rawIdToken

    //         })
    //         .catch(error => {
    //             // could also check if err instance of InteractionRequiredAuthError if you can import the class.
    //             if (error.name === "InteractionRequiredAuthError") {
    //                 return this.msalApp.acquireTokenPopup(tokenRequest)
    //                     .then(response => {
    //                         // get access token from response
    //                         // response.accessToken
    //                         this.msalApp.acquireTokenSilent(tokenRequest)
    //                         .then(response => 
    //                         {
    //                           var user = new User();
    //                           user.TenantId = response.idToken.tenantId;
    //                           user.UserName = response.account.userName;
    //                           user.Name = response.account.name;
    //                           user.AccessTokenExpiresOn = response.expiresOn;
    //                           user.Scopes = response.scopes;
    //                           user.Issuer = response.idToken.issuer;
    //                           user.AccessToken = response.accessToken;
    //                           user.IdToken = response.idToken.rawIdToken

    //                         })

    //                     })
    //                     .catch(err => {
    //                       console.error(err)
    //                     });
    //             }
    //         });
    // }

    signOut() {
        this.msalApp.logout();
    }
}
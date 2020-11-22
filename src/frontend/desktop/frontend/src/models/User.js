export default class User
{
    constructor (){
        this.Account = null;
        this.TenantId = '';
        this.Name = '';
        this.UserName = '';
        this.AccessTokenExpiresOn = '';
        this.Scopes = [];
        this.Issuer = "";
        this.IdToken = "";
        this.AccessToken = '';
    }
}
package authn

import (
	// "github.com/Azure/go-autorest/autorest"
	// "github.com/Azure/go-autorest/autorest/azure"
	// "github.com/Azure/go-autorest/autorest/azure/auth"
	oidc "github.com/coreos/go-oidc"
	"golang.org/x/oauth2"
	"net/http"
	"fmt"
	"io/ioutil"
	"encoding/json"
	"context"
	cleanhttp "github.com/hashicorp/go-cleanhttp"
	
)
//https://github.com/hashicorp/vault-plugin-auth-azure/blob/4c0b46069a2293d5a6ca7506c8d3e0c4a92f3dbc/azure.go#L58

const clientId = "782038fb-f1cc-486e-9163-eeffa5de1446"
const tenantId string = "72f988bf-86f1-41af-91ab-2d7cd011db47"
const oidcconfigurl string = "https://login.microsoftonline.com/%s/v2.0/.well-known/openid-configuration"

type oidcDiscoveryInfo struct {
	Issuer  string `json:"issuer"`
	JWKSURL string `json:"jwks_uri"`
}

//VerifyOAuthToken validates access token validity
func VerifyOAuthToken(idTokenRaw string) (error) {

	discoveryURL := fmt.Sprintf(oidcconfigurl, tenantId)

	resp, err := http.Get(discoveryURL)
	defer resp.Body.Close()

	body, err := ioutil.ReadAll(resp.Body)
	if err != nil {
		fmt.Errorf(err.Error())
	}

	if resp.StatusCode != http.StatusOK {
		fmt.Errorf("%s: %s", resp.Status, body)
	}

	var discoveryInfo oidcDiscoveryInfo

	if err := json.Unmarshal(body, &discoveryInfo); err != nil {
		fmt.Println(err.Error())
	}
	
	httpClient := cleanhttp.DefaultClient()
	ctx := context.WithValue(context.Background(), oauth2.HTTPClient, httpClient)

	remoteKeySet := oidc.NewRemoteKeySet(ctx, discoveryInfo.JWKSURL)

	verifierConfig := &oidc.Config{
		ClientID:             clientId,
		SupportedSigningAlgs: []string{oidc.RS256},
	}
	oidcVerifier := oidc.NewVerifier(discoveryInfo.Issuer, remoteKeySet, verifierConfig)
	
	token, err := oidcVerifier.Verify(ctx, idTokenRaw)
	if err != nil {
		fmt.Println(err.Error())
		return err
	}
	fmt.Println(token)

	return nil
	
}
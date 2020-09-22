package api

import(
	"net/http"
	"fmt"
	"eClinic.com/QueueSystem/infra/authn"
)


//AADBearerAuthnMiddleware validates bearer token from Azure AD
func AADBearerAuthnMiddleware(next http.HandlerFunc) http.HandlerFunc {
	return func(w http.ResponseWriter, r *http.Request) {
		
		fmt.Println("executing AADBearerMiddleware")

		bearerToken := r.Header.Get("Authorization")
		
		accessToken := bearerToken[7:]

		err := authn.VerifyOAuthToken(accessToken)

		if err != nil {
			http.Error(w, err.Error(), 403)
			return
		}

		next.ServeHTTP(w,r)

		fmt.Println("executed AADBearerMiddleware")
	}
}
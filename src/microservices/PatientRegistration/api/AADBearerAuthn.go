package api

import (
	"net/http"
)

func AADBearerAuthn(next http.HandlerFunc) http.HandlerFunc {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
	  
		//TODO: verify bearer token
		next.ServeHTTP(w, r)

	})
}
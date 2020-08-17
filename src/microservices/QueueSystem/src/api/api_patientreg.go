package api

import (
	"net/http"
	"github.com/gorilla/mux"
)

func APIInit() {

	router := mux.NewRouter()

	router.HandleFunc("/api/queue/consultation", EnqueuePatient).Methods("GET")

}

func EnqueuePatient(w http.ResponseWriter, r *http.Request) {
	//https://medium.com/@hugo.bjarred/rest-api-with-golang-and-mux-e934f581b8b5
}


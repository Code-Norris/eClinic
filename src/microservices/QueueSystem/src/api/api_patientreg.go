package api

import (
	"net/http"
	"github.com/gorilla/mux"
)

func APIInit() {

	router := mux.NewRouter().StrictSlash(true)

	router.HandleFunc("/api/queue/qpc", QueuePatientConsultation)
	router.HandleFunc("/api/queue/qppp", QueuePatientConsultation)
}

func QueuePatientConsultation(w http.ResponseWriter, r *http.Request) {
	//https://medium.com/@hugo.bjarred/rest-api-with-golang-and-mux-e934f581b8b5
}

func QueuePatientPharmPayment(w http.ResponseWriter, r *http.Request) {
	//https://medium.com/@hugo.bjarred/rest-api-with-golang-and-mux-e934f581b8b5
}


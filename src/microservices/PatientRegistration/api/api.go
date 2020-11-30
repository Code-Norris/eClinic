package api

import (
	"eClinic/patientreg/log"
	"encoding/json"
	"errors"
	"net/http"
	"time"

	"github.com/gorilla/mux"
	"math/rand"
	"github.com/bxcodec/faker/v3"
)

type Patient struct {
	Name 			string		`faker:"name"`
	DateOfBirth 	time.Time
	MobileNumber 	string		`faker:"phone_number"`
	PatienID 		string		
	HeightCM		float32		`faker:"oneof: 175, 185, 170"`
	WeightKG		float32		`faker:"oneof: 70, 80, 90"`
}


func HTTPServerInit() {
	initAPIs()

	log.Init()
}

func initAPIs() {

	log.Info("PatientRegistration service starting...")

	router := mux.NewRouter();

	router.HandleFunc("/health", handleHealth).Methods("GET")
	
	router.HandleFunc("/api/patientreg/new", AADBearerAuthn(registerNewPatient)).Methods("POST")

	router.HandleFunc("/api/patientreg/find", AADBearerAuthn(findPatientByName)).Methods("GET")

	log.Info("PatientRegistration service started at :3000")

	err := http.ListenAndServe(":3000", router)
	
	log.Err(err)
}

func registerNewPatient(w http.ResponseWriter, r *http.Request) {

	var patient Patient;

	 err := json.NewDecoder(r.Body).Decode(&patient)
	 log.Err(err)

	 w.WriteHeader(200)
}

func findPatientByName(w http.ResponseWriter, r *http.Request) {
	keys, ok := r.URL.Query()["name"]

	if !ok || len(keys[0]) < 1 {
		log.Err(errors.New("findPatientByName.name not found"))
		w.WriteHeader(400)
		w.Write([]byte("name not found"))
		return
	}

	p := Patient{}
	p.DateOfBirth = time.Now().AddDate(-20, 0 ,0)
	p.PatienID = string(rand.Int())

	err := faker.FakeData(&p)
	log.Err(err)

	byteP, _ := json.Marshal(p)

	w.Write(byteP)
	
}

func handleHealth(w http.ResponseWriter, r *http.Request) {
	w.Write([]byte("alive"))
}
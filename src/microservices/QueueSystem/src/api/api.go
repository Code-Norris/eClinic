package api

import (
	"net/http"
	"github.com/gorilla/mux"
	"encoding/json"
	"io/ioutil"
	"log"
	"time"
	"math/rand"
)

type queueRegReq struct {
	PatientID string			`json: "patientID"`
}

type QueueInfo struct {
	QueueNumber int		`json: "queueNumber"`
	PatientID string	`json: "patientID"`
	QueuedAt time.Time	`json: "queuedAt"`
}

//Listen starts REST Api hosting
func Listen() {

	router := mux.NewRouter().StrictSlash(true)

	router.HandleFunc("/api/q/pc", AADBearerAuthnMiddleware(QPatientConsultation)).Methods("POST")

	router.HandleFunc("/api/q/pp", AADBearerAuthnMiddleware(QPatientPharmPayment)).Methods("POST")


	http.ListenAndServe(":9090", router)
}

func QPatientConsultation(w http.ResponseWriter, r *http.Request) {
	//https://medium.com/@hugo.bjarred/rest-api-with-golang-and-mux-e934f581b8b5

	body, err := ioutil.ReadAll(r.Body)
	if err != nil {
		log.Print(err.Error())
	}

	pid := queueRegReq{}

	juerr := json.Unmarshal(body, &pid)
	if juerr != nil {
		log.Print(juerr.Error())
	}

	//TODO: read queueno from app svc

	mq, merr := json.Marshal((QueueInfo{
		QueueNumber: rand.Intn(50),
		PatientID: pid.PatientID,
		QueuedAt: time.Now(),
	}))
	if merr != nil {
		log.Print(merr.Error())
	}

	w.Write(mq)
}

//QPatientPharmPayment saves post-consultation patient to persistent "queue"
//for pharmacist and payment
func QPatientPharmPayment(w http.ResponseWriter, r *http.Request) {
	//https://medium.com/@hugo.bjarred/rest-api-with-golang-and-mux-e934f581b8b5
}


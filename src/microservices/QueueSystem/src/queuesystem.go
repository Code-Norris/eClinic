package main

import (
	//"fmt"
	//"eClinic.com/QueueSystem/domain"
	"eClinic.com/QueueSystem/api"
	//"eClinic.com/QueueSystem/infra/secret"
	//"eClinic.com/QueueSystem/infra/logger"
	//"eClinic.com/QueueSystem/infra/msgbroker"
	//"time"
	//"encoding/json"
	//"runtime"
)

func main() {

	api.Listen()
	
	// secret, err := secret.Init()

	// if err != nil {
	// 	fmt.Println(err)
	// }

	// fmt.Println(secret)

	// logger.Init()

	// logger.LogIE("nats: start publishing")

	// natsbroker := msgbroker.New()

	// patient := domain.Patient{
	// 	ID:"sddasaw22", 
	// 	Name:"carebear",
	// 	QueueInfo: domain.QueueInfo{
	// 		Number:5,
	// 		PatientID: "sddasaw22",
	// 		CreatedAt: time.Now() } }

	// natsbroker.SubscribePatientFromConsultation(func (p domain.Patient){
	// 	jp,_ := json.Marshal(p)
	// 	struclogger.Info("patient from consultation: " + string(jp))
	// })

	// time.Sleep(2 * time.Second)

	// natsbroker.EnqueuePatientForConsultation(patient)

	 //runtime.Goexit()
}



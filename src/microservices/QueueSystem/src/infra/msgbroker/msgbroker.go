package msgbroker

import (
	nats "github.com/nats-io/nats.go"
	"os"
	"eClinic.com/QueueSystem/domain"
	"eClinic.com/QueueSystem/infra/logger"
	"runtime"
)

var msgbroker *NatsMsgBroker
var _logger *logger.StrucLogger
const natsUrlKubeSvc = "nats://my-nats:4222"

type MsgBrokerer interface {
	EnqueuePatientForConsultation(msg domain.Patient)
	DequeuePatientFromConsultation()
	EnqueuePatientForPayPharm(msg domain.Patient)
	DequeuePatientFromPayPharm(msg domain.Patient)
}

type NatsMsgBroker struct {
	NatsUrl string
}
//nats streaming: https://github.com/nats-io/stan.go

//nats
//https://github.com/nats-io/nats.go
//https://mycodesmells.com/post/publish-subscribe-example-with-nats-and-go

func (mb * NatsMsgBroker) EnqueuePatientForConsultation(msg domain.Patient) {
	natsUrl := getConnUrl()

	natsClient, connerr := nats.Connect(natsUrl)
	//defer natsClient.Close()

	if connerr != nil {
		_logger.Err(connerr)
	}

	natsClient.Publish("QueueSystem.Doctor.Consultation", []byte("hello"))

	err := natsClient.Flush()

	if err != nil {
		_logger.Err(err)
	} else {
		_logger.Info("Msg published")
	}

	if err := natsClient.LastError(); err != nil {
		_logger.Err(err)
	}

	natsClient.Subscribe("QueueSystem.Doctor.Consultation", func(msg *nats.Msg) {
		msgFromQ := string(msg.Data)
		
		_logger.Info("at DequeuePatientFromConsultation, msg from queue is: " + msgFromQ)
	})
}

func (mb* NatsMsgBroker) DequeuePatientFromConsultation() {
	natsUrl := getConnUrl()

	conn, _ := nats.Connect(natsUrl)
	//defer conn.Close()

	_, err := conn.Subscribe("QueueSystem.Doctor.Consultation", func(msg *nats.Msg) {
		msgFromQ := string(msg.Data)
		
		_logger.Info("at DequeuePatientFromConsultation, msg from queue is: " + msgFromQ)
	})

	if err != nil {
		_logger.Err(err)
	}

	// Keep the connection alive
	runtime.Goexit()
}

func New() (*NatsMsgBroker) {
	natsurl := getConnUrl()
	msgbroker = &NatsMsgBroker{NatsUrl: natsurl}
	_logger = logger.Init()

	return msgbroker
}

func getConnUrl() (string) {
	if env := os.Getenv("env"); env == "dev" {
		return "nats://localhost:4222"
	} else {
		return natsUrlKubeSvc
	}
}
package msgbroker

import (
	nats "github.com/nats-io/nats.go"
	"os"
	"eClinic.com/QueueSystem/domain"
	"eClinic.com/QueueSystem/infra/logger"
	//"sync"
	"encoding/json"
	//"time"
)

var msgbroker *NatsMsgBroker
var _logger *logger.StrucLogger
const natsUrlKubeSvc = "nats://my-nats:4222"

var consultationQueueName = "Consultation"
var consultationQueueGroup = "Consultation.QueueGroup"

type SubFunc func(p domain.Patient)

type MsgBrokerer interface {
	EnqueuePatientForConsultation(msg domain.Patient)
	SubscribePatientFromConsultation(fn SubFunc)
	EnqueuePatientForPayPharm(msg domain.Patient)
	SubscribePatientFromPayPharm(msg domain.Patient)
}

type NatsMsgBroker struct {
	NatsUrl string
}

func (mb * NatsMsgBroker) EnqueuePatientForConsultation(msg domain.Patient) {

	//https://stackoverflow.com/questions/45886359/golang-nats-subscribe-issue
	
	natsUrl := getConnUrl()

	conn, connerr := nats.Connect(natsUrl)
	encnats, _ := nats.NewEncodedConn(conn, nats.JSON_ENCODER)
	defer encnats.Close()

	if connerr != nil {
		_logger.Err(connerr)
	}

	//https://docs.nats.io/developing-with-nats/receiving/async
	//https://stackoverflow.com/questions/50259732/nats-client-in-golang-wont-subscribe

	encnats.Publish(consultationQueueName, msg)
	puberr := encnats.Flush()

	if puberr != nil {
		_logger.Err(puberr)
	} else {
		_logger.Info("Msg published")
	}
}

func (mb* NatsMsgBroker) SubscribePatientFromConsultation(fn SubFunc) {
	natsUrl := getConnUrl()

	conn, _ := nats.Connect(natsUrl)
	encnats, _ := nats.NewEncodedConn(conn, nats.JSON_ENCODER)
	//defer encnats.Close()

	encnats.Subscribe(consultationQueueName, func(msg string) {

		patient := domain.Patient{}

		jerr := json.Unmarshal([]byte(msg), &patient)
		_logger.Err(jerr)

		fn(patient)
	})

	if err := encnats.LastError(); err != nil {
		_logger.Err(err)
	}
}

func New() (*NatsMsgBroker) {
	natsurl := getConnUrl()
	msgbroker = &NatsMsgBroker{NatsUrl: natsurl}
	_logger = logger.Init()

	return msgbroker
}

func getConnUrl() (string) {
	if env := os.Getenv("env"); env == "dev" {
		return "nats://localhost"
	} else {
		return natsUrlKubeSvc
	}
}
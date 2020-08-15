package secret

import (
	"io/ioutil"
	"os"
	"encoding/json"
	"path/filepath"
)

type SecretSource interface {
	GetSecret() QueueSecret
}

type QueueSecret struct {
	MsgBrokerUrl string `json:"MsgBrokerUrl"`
	MongoConnString string `json:"MongoConnString"`
}

type localSecretSource struct {
	Secret QueueSecret
}

type akvSecretSource struct {
	Secret QueueSecret
}

func (lss *localSecretSource) GetSecret() (QueueSecret, error) {

	pwd, _ := os.Getwd()

	secretJsonPath := "/infra/secret/secret.json"
	winPath := filepath.FromSlash(secretJsonPath)

	sp := pwd + winPath
	
	file, err := ioutil.ReadFile(sp)

	if(err != nil) {
		return QueueSecret{}, err
	}

	qs := QueueSecret{}

	json.Unmarshal([]byte(file), &qs)

	return qs, nil

}

func (akvss *akvSecretSource) GetSecret() (QueueSecret, error) {
	return QueueSecret{}, nil
}

func Init() (QueueSecret, error) {
	
	if env := os.Getenv("env"); env != "dev" || env == "" {
		akvSS := akvSecretSource{}
		return akvSS.GetSecret()
	} else {
		lss := localSecretSource{}
		return lss.GetSecret()
	}
}
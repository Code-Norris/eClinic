package config

import (
	"os"
	"github.com/spf13/viper"
)

//Config is a global variable to access configs from other packages
var Config *Configs

type Configs struct {
	AzureAD AAD			`mapstructure:"aad"`	
}
//Configs contains configurations for desktop app
type AAD struct{
	AADUrl string 		`mapstructure:"aadurl"`	
	AADClientID string 	`mapstructure:"aadclientid"`
	AADScope string		`mapstructure:"aadscope"`	
}

//Init initializes configs from config.yaml
func Init() {

	v := viper.New()

	if env := os.Getenv("env"); env == "dev" || env == "" {
		v.SetConfigName("config-dev") // name of config file (without extension)
	} else {
		v.SetConfigName("config")
	}
	
	//viper.SetConfigType("yaml") // REQUIRED if the config file does not have the extension in the name
	v.AddConfigPath(".") //for exec /bui;d .exe directly
	v.AddConfigPath("./build/") //config in /build with elinicdesktop.exe

	v.ReadInConfig()
	//TODO: log err

	v.Unmarshal(&Config)
	//TODO: log err
}
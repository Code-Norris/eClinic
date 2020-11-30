package log

import(
	"os"
	logrus "github.com/sirupsen/logrus"
)



func Init() {
	logrus.SetFormatter(&logrus.JSONFormatter{})
	logrus.SetOutput(os.Stdout)
}

func Info(message string) {
	if len(message) > 0 {
		logrus.Info(message)
	}
}

func Err(err error) {
	if err != nil {
		logrus.Error(err)
	}
	

	//log signin in user field when Authn module is up
	// logrus.WithFields(logrus.Fields{
    //     "user": "admin",
    // }).Info("Some interesting info")
}


package log

import(
	logrus "github.com/sirupsen/logrus"
)



func Init() {
	logrus.SetFormatter(&logrus.JSONFormatter{})
}

func LogErr(err error) {
	if err != nil {
		logrus.Error(err)
	}
	

	//log signin in user field when Authn module is up
	// logrus.WithFields(logrus.Fields{
    //     "user": "admin",
    // }).Info("Some interesting info")
}


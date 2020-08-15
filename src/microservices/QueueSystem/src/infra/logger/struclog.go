package logger


import (
	"go.uber.org/zap"
	"go.uber.org/zap/zapcore"
)

var _logger *zap.Logger
var sl = &StrucLogger{}

type Loggerer interface {
	Info(msg string)
	Err(err error)
}

type StrucLogger struct {
}

func (sl *StrucLogger) Info(msg string) {
	_logger.Info(msg)
}

func (sl *StrucLogger) Err(err error) {
	
}

func Init() (*StrucLogger) {
	// _logger, _ := zap.NewProduction()
	// logger = _logger.Sugar()

	loggerConfig := zap.NewProductionConfig()
	loggerConfig.EncoderConfig.TimeKey = "timestamp"
	loggerConfig.EncoderConfig.EncodeTime = zapcore.ISO8601TimeEncoder
	logger, err := loggerConfig.Build()

	if(err != nil) {
		//TODO
	}
	
	_logger = logger
	
	return sl
}
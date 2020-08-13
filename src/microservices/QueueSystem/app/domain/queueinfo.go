package domain

import(
	"time"
)

type QueueInfo struct {
	Number    int
	PatientID string
	CreatedAt time.Time
}
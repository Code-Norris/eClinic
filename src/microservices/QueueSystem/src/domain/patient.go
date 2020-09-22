package domain

import (
	"time"
)

type Address struct {
	Street string
    City string
    State string
    PostalCode string
}

type Patient struct {
	IDCardNumber string
	Name string
	Age int
	HomeAddress Address
    Height float32
    Weight float32
	Allergies []string
	RegistrationTime time.Time = time.Now()
}
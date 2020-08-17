package main

import (
	"fmt"
	"eClinic.com/QueueSystem/domain"
	"eClinic.com/QueueSystem/infra/secret"
	"eClinic.com/QueueSystem/infra/logger"
	"eClinic.com/QueueSystem/infra/msgbroker"
	"time"
	"bufio"
	"os"
)

func main() {
	
	secret, err := secret.Init()

	if err != nil {
		fmt.Println(err)
	}

	fmt.Println(secret)

	struclogger := logger.Init()

	struclogger.Info("nats: start publishing")

	natsbroker := msgbroker.New()

	patient := domain.Patient{
		ID:"sddasaw22", 
		Name:"carebear",
		QueueInfo: domain.QueueInfo{
			Number:5,
			PatientID: "sddasaw22",
			CreatedAt: time.Now() } }
	
	natsbroker.EnqueuePatientForConsultation(patient)

	time.Sleep(2 * time.Second)

	natsbroker.DequeuePatientFromConsultation()

	
	input := bufio.NewScanner(os.Stdin)
    input.Scan()

}

// func main() {

// 	//goroutine and channel
// 	sheepChannel := make(chan Sheep, 2)
// 	go countSheepTo10(sheepChannel)

// 	for sheep := range sheepChannel {
// 		fmt.Printf("Sheep counting to sleep at %v", sheep.count)
// 	}

// 	//multiple condition in If
// 	if a := 56; a >=40 && a<=60 {
// 		fmt.Println(true)
// 	} else {
// 		fmt.Println(false)
// 	}

// 	//implement interface
// 	nsvc := NotifierService{}
// 	nsvc.SetBodyPointer("new body by pointer")
// 	fmt.Println(nsvc.body)

// 	nsvc.SetBodyValue("new body by value")
// 	fmt.Println(nsvc.body)
// 	//
// 	num,str,err :=  MultiReturnValues()

// 	fmt.Println(num,str,err)

// 	notifierSvc := NotifierService {}
// 	notifierSvc.body = 	"Executed successfully, no worries"

// 	body := notifierSvc.sendEmail()

// 	fmt.Println(body)
// }

// func countSheepTo10(chanSheep chan Sheep) {
// 	sheep := Sheep{count: 1}

// 	for i := 0; i <= 10; i++ {
// 		sheep.count = i
// 		chanSheep <- sheep
// 		time.Sleep(time.Millisecond * 500)
// 	}

// 	close(chanSheep)
// }

// type Sheep struct {
// 	count int
// }

// func MultiReturnValues() (int,string,error) {
// 	return 1000, "2nd retval", errors.New("thrown on purpose")
	
// }

// type notifer interface {
// 	emailer
// 	notify() string
// }

// type emailer interface {
// 	sendEmail() string
// }

// type NotifierService struct {
// 	body string
// }
// func (ns *NotifierService) SetBodyPointer(newBody string) string {
// 	ns.body = newBody
// 	return  ns.body
// }
// func (ns NotifierService) SetBodyValue(newBody string) string {
// 	ns.body = newBody
// 	return  ns.body
// }


// func (ns NotifierService) sendEmail() string {
// 	return "email sent, content: " + ns.body
// }



// type Order struct {
// 	Id string
// 	Name string
// 	Details OrderDetails
// }


// type OrderDetails struct {
// 	DetailName string
// }

// type OrderView struct {
// 	Id string
// 	Name string
// }

// func RandomNum() {
// 	 rand.Seed(time.Now().UnixNano())

// 	 randomNum := rand.Intn(999999)

// 	 fmt.Println(randomNum)
// }

// func sliceDemo() {
// 	slices := []string{"a", "b", "c"}


// 	for _, v := range slices {
// 		fmt.Println(v)
// 	}
// }

// func MakeNestedAdd(a int) func(int) int {
// 	return func (b int) int {
// 		return a + b
// 	}
// }

// func Print(x int, y int, f func(a int, b int) int) {
// 	fmt.Println(f(x,y))
// }

// func HasSpace(str string) bool {

// 	hasSpace := false

// 	for _,v := range str {

// 		cha := rune(v)

// 		if unicode.IsSpace(cha) {
// 			hasSpace = true
// 			break
// 		} else {
// 			continue
// 		}
// 	}
// 	return hasSpace
// }

docker build -f ./API/Dockerfile -t acreclinic.azurecr.io/eclinic/patientregistration:0.0.7 --no-cache .


curl --header "Content-Type: application/json" --request POST --data '{"Name": "Bruce Banner","IdentificationNumber": "S8433750F","Age": 36,"Street": "angel street","City": "has-fallen","State": "city state","PostalCode": "99501","Height": 178,"Weight": 65,"Allergies": ["Aspirin", "penicillin", "ibuprofen"]}' http://svc-pr/patient/new


https://dev.to/mkokabi/learning-dapr-simple-dotnet-core-hello-world-b0k
FROM golang:1.12-alpine AS build_base

RUN apk add --no-cache git

# Set the Current Working Directory inside the container
WORKDIR /app

# We want to populate the module cache based on the go.{mod,sum} files.
COPY go.mod .
COPY go.sum .

RUN go mod download

COPY . .

# # Build the Go app
#RUN GOOS=linux GOARCH=amd64 go build -ldflags="-w -s" -o ./out . #/app/out
RUN go build -o /app/publish

FROM alpine:3.9  

WORKDIR /app

COPY --from=build_base /app/publish /app/

ENTRYPOINT ./publish
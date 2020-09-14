package main

import (
  "github.com/leaanthony/mewn"
  "github.com/wailsapp/wails"
  "elinic/desktop/pkg/config"
  "fmt"
)

func basic() string {
  return "World!"
}

func main() {

  js := mewn.String("./frontend/build/static/js/main.js")
  css := mewn.String("./frontend/build/static/css/main.css")

  app := wails.CreateApp(&wails.AppConfig{
    Width:  1024,
    Height: 768,
    Title:  "elinicdesktop",
    JS:     js,
    CSS:    css,
    Colour: "#131313",
  })

  config.Init()
  configs := config.Config

  fmt.Println(configs.AzureAD.AADUrl)

  app.Bind(configs)
  app.Bind(basic)
  app.Run()
}

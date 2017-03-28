{
    "intents": [
      {
          "intent": "HelloWorldIntent"
      },
      {
          "intent": "RedAlertIntent"
      },
      {
          "intent": "CommandCodeVerificationIntent",
          "slots": [
              {
                  "name": "Code",
                  "type": "COMMANDCODE"
              }
            ]
      },
      {
          "intent": "BrokeHandlerIntent"
      },
      {
          "intent": "SetCourseIntent",
          "slots": [
              {
                  "name": "Starbase",
                  "type": "STARBASENUMBER"
              },
              {
                  "name": "Warp",
                  "type": "WARPNUMBER"
              }
          ]
      },
      {
          "intent": "EngageIntent"
      },
      {
          "intent": "AMAZON.HelpIntent"
      },
      {
          "intent": "AMAZON.StopIntent"
      },
      {
          "intent": "AMAZON.CancelIntent"
      }
    ]
}
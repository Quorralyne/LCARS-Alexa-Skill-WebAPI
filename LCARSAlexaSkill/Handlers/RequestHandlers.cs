using LCARSAlexaSkill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LCARSAlexaSkill.Handlers
{
    public class RequestHandlers
    {
        public static AlexaResponse LaunchRequestHandler(AlexaRequest request)
        {
            //Alexa, start LCARS
            //ALEXA: Hello, this is Starship U.S.S. Enterprise.
            //ALEXA Reprompt: Please say Help if you need a list of commands

            var response = new AlexaResponse("Hello, this is Starship U.S.S. Enterprise.");
            response.Response.Card.Title = "LCARS Acknowledged";
            response.Response.Card.Content = "Please say Options if you need a list of commands";

            response.Response.Reprompt.OutputSpeech.Text = "Please say Options if you need a list of commands.";
            response.Response.ShouldEndSession = false;

            return response;
        }

        public static AlexaResponse IntentRequestHandler(AlexaRequest request)
        {
            AlexaResponse response = null;

            switch (request.Request.Intent.Name)
            {
                case "HelloWorldIntent":
                    response = IntentHandlers.HelloWorldIntentHandler(request);
                    break;
                case "RedAlertIntent":
                    response = IntentHandlers.RedAlertIntentHandler();
                    break;
                case "CommandCodeVerificationIntent":
                    response = IntentHandlers.CommandCodeVerificationIntentHandler(request);
                    break;
                case "BrokeHandlerIntent":
                    response = IntentHandlers.BrokeIntentHandler();
                    break;
                case "SetCourseIntent":
                    response = IntentHandlers.SetCourseIntentHandler(request);
                    break;
                case "EngageIntent":
                    response = IntentHandlers.EngageIntentHandler();
                    break;
                case "AMAZON.CancelIntent":
                case "AMAZON.StopIntent":
                    response = IntentHandlers.CancelOrStopIntentHandler();
                    break;
                case "AMAZON.HelpIntent":
                    response = IntentHandlers.HelpIntentHandler();
                    break;
                default:
                    response = IntentHandlers.DefaultIntentHandler(request);
                    break;
            }

            return response;
        }

        public static AlexaResponse SessionEndedRequestHandler(AlexaRequest request)
        {
            return null;
        }
    }
}
using LCARSAlexaSkill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LCARSAlexaSkill.Handlers
{
    public class IntentHandlers
    {
        public static AlexaResponse HelloWorldIntentHandler(AlexaRequest request)
        {
            //Alexa, ask LCARS to say hello
            //ALEXA: *acknowledgement sound* Yes counselor?
            //ALEXA Reprompt: Please say Help if you need a list of commands.

            try
            {
                var response = new AlexaResponse();
                response.Response.Card.Title = "Hello";
                response.Response.Card.Content = "Hello Counselor";
                response.Response.OutputSpeech.Type = "SSML";
                response.Response.OutputSpeech.Ssml = "<speak> <audio src=\"https://s3-us-west-2.amazonaws.com/quorralynefiles/computerbeep.mp3\" ></audio> Yes counselor. </speak>";
                response.Response.Reprompt.OutputSpeech.Text = "Please say Help if you need a list of commands.";
                response.Response.ShouldEndSession = false;

                return response;
            }
            catch (Exception ex)
            {
                var response = new AlexaResponse("I'm broke..did." + ex.Message);
                return response;
            }
        }

        public static AlexaResponse RedAlertIntentHandler(AlexaRequest request)
        {
            //Alexa, tell LCARS red alert
            //ALEXA: *distress sound* Red alert *distress sound*
            //ALEXA Reprompt: Awaiting your command.

            try
            {
                var response = new AlexaResponse();
                response.Response.Card.Title = "Red alert";
                response.Response.Card.Content = "Red alert";
                response.Response.OutputSpeech.Type = "SSML";
                response.Response.OutputSpeech.Ssml = "<speak> <audio src=\"https://s3-us-west-2.amazonaws.com/quorralynefiles/redalert.mp3\" ></audio> Red alert <audio src=\"https://s3-us-west-2.amazonaws.com/quorralynefiles/redalert.mp3\" ></audio><audio src=\"https://s3-us-west-2.amazonaws.com/quorralynefiles/redalert.mp3\" ></audio></speak>";
                response.Response.Reprompt.OutputSpeech.Text = "Awaiting your command.";
                response.Response.ShouldEndSession = false;

                return response;
            }
            catch (Exception ex)
            {
                var response = new AlexaResponse("I'm broke..did." + ex.Message);
                return response;
            }
        }

        public static AlexaResponse CommandCodeVerificationIntentHandler(AlexaRequest request)
        {
            //Access code alpha alpha three zero five
            //ALEXA: Command code AA305 has been verified. Proceed.
            //ALEXA Reprompt: Awaiting your orders.

            var code = request.Request.Intent.Slots["Code"].value.ToString();

            var response = new AlexaResponse("Command code " + code + " has been verified. Proceed.");
            response.Response.Card.Title = "Command code " + code + " has been verified.";
            response.Response.Card.Content = "Proceed.";
            response.Response.Reprompt.OutputSpeech.Text = "Awaiting your orders.";
            response.Response.ShouldEndSession = false;

            return response;
        }

        public static AlexaResponse BrokeIntentHandler(AlexaRequest request)
        {
            //Alexa, how are you feeling?
            //ALEXA: I'm broke...did.
            //ALEXA Reprompt: Please say Help if you need a list of commands.

            try
            {
                var response = new AlexaResponse();
                response.Response.Card.Title = "Broken";
                response.Response.Card.Content = "I'm broke";
                response.Response.OutputSpeech.Type = "SSML";
                response.Response.OutputSpeech.Ssml = "<speak> <audio src=\"https://s3-us-west-2.amazonaws.com/quorralynefiles/computerbeep.mp3\" ></audio> I'm broke-did. </speak>";
                response.Response.Reprompt.OutputSpeech.Text = "Please say Help if you need a list of commands.";
                response.Response.ShouldEndSession = false;

                return response;
            }
            catch (Exception ex)
            {
                var response = new AlexaResponse("I'm broke..did." + ex.Message);
                return response;
            }
        }

        public static AlexaResponse HelpIntentHandler()
        {
            //Help
            //ALEXA: Say hello or cancel to exit.
            //ALEXA Reprompt: What is your command? Say hello or cancel to exit.

            var response = new AlexaResponse("Say hello or cancel to exit.");
            response.Response.Card.Title = "How to use this skill";
            response.Response.Card.Content = "Say hello or cancel to exit.\n";
            response.Response.Reprompt.OutputSpeech.Text = "What is your command? Say hello or cancel to exit.";
            response.Response.ShouldEndSession = false;
            return response;
        }

        public static AlexaResponse CancelOrStopIntentHandler()
        {
            //Cancel
            //ALEXA: Acknowledged.

            var response = new AlexaResponse("Acknowledged.");
            response.Response.Card.Title = "";
            response.Response.Card.Content = "";
            response.Response.ShouldEndSession = true;
            return response;
        }

        public static AlexaResponse DefaultIntentHandler(AlexaRequest request)
        {
            var response = new AlexaResponse("I didn't understand what you requested. Say help to hear a list of commands or cancel to exit.");
            response.Response.Reprompt.OutputSpeech.Text = "Say help to hear a list of commands or cancel to exit.";
            response.Response.ShouldEndSession = false;
            return response;
        }
    }
}
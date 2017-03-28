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
                response.Response.Card.Content = "Hello Commander";
                response.Response.OutputSpeech.Type = "SSML";
                response.Response.OutputSpeech.Ssml = "<speak> <audio src=\"https://s3-us-west-2.amazonaws.com/quorralynefiles/computerbeep.mp3\" ></audio> Yes commander. </speak>";
                response.Response.Reprompt.OutputSpeech.Text = "Please say Options if you need a list of commands.";
                response.Response.ShouldEndSession = false;

                return response;
            }
            catch (Exception ex)
            {
                var response = new AlexaResponse("I'm broke..did." + ex.Message);
                return response;
            }
        }

        public static AlexaResponse RedAlertIntentHandler()
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
                response.Response.Reprompt.OutputSpeech.Text = "Awaiting your next command.";
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
            //ALEXA: Command code alpha alpha 305 has been verified. Proceed.
            //ALEXA Reprompt: Awaiting your orders.

            var code = request.Request.Intent.Slots["Code"].value.ToString();

            var response = new AlexaResponse("Command code " + code + " has been verified. Proceed.");
            response.Response.Card.Title = "Command code " + code + " has been verified.";
            response.Response.Card.Content = "Proceed.";
            response.Response.Reprompt.OutputSpeech.Text = "Awaiting your next command.";
            response.Response.ShouldEndSession = false;

            return response;
        }

        public static AlexaResponse BrokeIntentHandler()
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
                response.Response.OutputSpeech.Ssml = "<speak> <say-as interpret-as='interjection'>Well well! Booyah.</say-as> </speak>";
                response.Response.Reprompt.OutputSpeech.Text = "Please say Options if you need a list of commands.";
                response.Response.ShouldEndSession = false;

                return response;
            }
            catch (Exception ex)
            {
                var response = new AlexaResponse("I'm broke..did." + ex.Message);
                return response;
            }
        }

        public static AlexaResponse SetCourseIntentHandler(AlexaRequest request)
        {
            //Set course for starbase
            //ALEXA: Course laid in.
            //ALEXA Reprompt: Awaiting your command to engage.

            var starbaseNumber = request.Request.Intent.Slots["Starbase"].value.ToString();
            var warpNumber = request.Request.Intent.Slots["Warp"].value.ToString();

            var response = new AlexaResponse("Course laid in for " + starbaseNumber + ". Ready at your command.");
            response.Response.Card.Title = "Course Set for " + starbaseNumber;
            response.Response.Card.Content = "Warp " + warpNumber + ".";
            response.Response.Reprompt.OutputSpeech.Text = "Awaiting your command to engage.";
            response.Response.ShouldEndSession = false;

            return response;
        }

        public static AlexaResponse EngageIntentHandler()
        {
            //Engage
            //ALEXA: *warp sound*

            var response = new AlexaResponse();
            response.Response.Card.Title = "Engage";
            response.Response.Card.Content = "Warp speed";
            response.Response.OutputSpeech.Type = "SSML";
            response.Response.OutputSpeech.Ssml = "<speak> <audio src=\"https://s3-us-west-2.amazonaws.com/quorralynefiles/warp.mp3\" ></audio> </speak>";
            response.Response.Reprompt.OutputSpeech.Text = "Please say Options if you need a list of commands.";
            response.Response.ShouldEndSession = false;

            return response;
        }

        public static AlexaResponse HelpIntentHandler()
        {
            //Help
            //ALEXA: Say hello, red alert, your access code or cancel to exit.
            //ALEXA Reprompt: What is your command? Say hello, red alert, your access code or cancel to exit.

            var response = new AlexaResponse("Say hello, red alert, your access code or cancel to exit.");
            response.Response.Card.Title = "How to use this skill";
            response.Response.Card.Content = "Say hello, red alert, your access code or cancel to exit.\n";
            response.Response.Reprompt.OutputSpeech.Text = "What is your command? Say hello, red alert, your access code or cancel to exit.";
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
            var response = new AlexaResponse("I didn't understand what you requested. Say options to hear a list of commands or cancel to exit.");
            response.Response.Reprompt.OutputSpeech.Text = "Say options to hear a list of commands or cancel to exit.";
            response.Response.ShouldEndSession = false;
            return response;
        }
    }
}
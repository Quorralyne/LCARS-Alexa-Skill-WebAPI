using LCARSAlexaSkill.Models;
using LCARSAlexaSkill.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LCARSAlexaSkill.Controllers
{
    public class AlexaController : ApiController
    {
        private const string ApplicationId = "amzn1.ask.skill.fe105c1a-c4f5-4541-bc30-3bb27ea38999";

        [HttpPost, Route("api")]
        public AlexaResponse LCARS(AlexaRequest request)
        {
            if (request.Session.Application.ApplicationId != ApplicationId)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            var totalSeconds = (DateTime.UtcNow - request.Request.Timestamp).TotalSeconds;
            if (totalSeconds <= 0 || totalSeconds > 150)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            AlexaResponse response = null;

            if(request != null)
            {
                switch (request.Request.Type)
                {
                    case "LaunchRequest":
                        response = RequestHandlers.LaunchRequestHandler(request);
                        break;
                    case "IntentRequest":
                        response = RequestHandlers.IntentRequestHandler(request);
                        break;
                    case "SessionEndedRequest":
                        response = RequestHandlers.SessionEndedRequestHandler(request);
                        break;
                }
            }

            return response;

        }

        [HttpPost, Route("demo")]
        public dynamic AlexaDemo(dynamic request)
        {
            return new
            {
                version = "1.0",
                sessionAttributes = new { },
                response = new
                {
                    outputSpeech = new
                    {
                        type = "PlainText",
                        text = "Hello, this is Starship U.S.S. Enterprise."
                    },
                    card = new
                    {
                        type = "Simple",
                        title = "LCARS Alexa Skill Demo",
                        content = "Hello world!"
                    },
                    shouldEndSession = true
                }
            };
        }

        [HttpPost, Route("ssmldemo")]
        public dynamic AlexaSSMLDemo(dynamic request)
        {
            return new
            {
                version = "1.0",
                response = new
                {
                    shouldEndSession = true,
                    outputSpeech = new
                    {
                        type = "SSML",
                        ssml = "<speak> <audio src=\"https://s3-us-west-2.amazonaws.com/quorralynefiles/computerbeep.mp3\" ></audio> Yes counselor. </speak>"
                    }
                }
            };
        }
    }
}
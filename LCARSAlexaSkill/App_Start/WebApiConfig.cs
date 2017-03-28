using LCARSAlexaSkill.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LCARSAlexaSkill
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "AlexaApi",
            //    routeTemplate: "api/alexa",
            //    defaults: new { controller = "Alexa", id = RouteParameter.Optional },
            //    constraints: null,
            //    handler: new AlexaRequestValidationHandler()
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

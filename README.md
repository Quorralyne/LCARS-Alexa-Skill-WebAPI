# LCARS Alexa Skill in WebAPI
Novel interactions with the Star Trek computer voice known as LCARS.

Written in C#/Web API2.
Features:<br />
-Basic dynamic Alexa response<br />
-SSML demo example<br />
-Custom slot type handling<br />
-SSML Speechcon example<br />
-Security handling for certificate<br />
-Ensures Amazon-only server requests get through<br />
-Improved handling of help intents and error states<br />
<br />
Originally hosted on Azure Apps Service. Sound files hosted on Amazon S3.

# Sample Conversation
"Alexa, start LCARS."<br />
ALEXA: "Hello, this is Starship U.S.S. Enterprise."

"Alexa, ask LCARS to say hello."<br />
ALEXA: *acknowledgement beep* "Yes, Commander?."

"How are you feeling?"<br />
ALEXA: "Well, well. Booyah."

"Red alert"<br />
ALEXA: *distress sound* "Red alert." *distress sound*

"Access code {alpha alpha three zero five}" (You may say any code here)<br />
ALEXA: "Command code alpha alpha 305 has been verified. Proceed."

"Set course for starbase {STS 112} warp {6}" (words in brackets take in any word)
ALEXA: "Course laid in for {starbase}. Ready at your command."

"Engage"<br />
ALEXA: *warp sound*

"Options"<br />
ALEXA: "Say hello, red alert, your access code or cancel to exit."

"Cancel"<br />
ALEXA: "Acknowledged."

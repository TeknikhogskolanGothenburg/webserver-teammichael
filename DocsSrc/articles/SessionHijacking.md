# Session hijacking
Describe the cookie vulnerability called "Session hijacking" which the archicture of this webserver contains. Both the problem and a possible solution.

what is session hjjacking ? 

The session hijacking is a type of web attack. It works based on the principle of computer sessions. The attack takes advantage of the active sessions
(https://www.interserver.net/). 



 How to prevent the Session Hijacking ?

The best way to prevent session hijacking is enabling the protection from the client side.
 It is recommended that taking preventive measures for the session hijacking on the client side. ( https://techzone.ergon.ch/client-security) 
 Because the method often used to steal session id is by installing a malicious code on the client website and then the cookie is stealing. 
The users should have efficient antivirus, anti-malware software, and should keep the software up to date. 



There is a technique that uses engines which fingerprints all requests of a session. In addition to tracking the IP address and SSL session id, the engines also track the http headers. Each change in the header adds penalty points to the session and the session gets terminated as soon as the points exceeds a certain limit. This limit can be configured. This is effective because when intrusion occurs, it will have a different http header order.

These are the recommended preventive measures to be taken from both the client and server sides in order to prevent the session hijacking attack.
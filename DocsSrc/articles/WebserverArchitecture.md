# Webserver Architecture

* How are your webserver build?


webservern är byggt med två metoder. En är  server(string[] prifixes) som skickar prifixes
genom att använda httplistner klassen. Httplistner klassen skaffades en objekt om heter 
Listner och varje prefix adderar med foreach loop. prefix menar vi fileextentions. 

När det gäller andra metoden är Getfile() och den hämtar filen från mappen content. 





* What resources can the user access?


det går att hämmta alla html filer och bildr och mini mappen också. 



* How does the server act in case of an error?


när det uppstor error den visar 404.html sidan som visar att sidan inte finns. men
vi har inte utvecklat mer . 
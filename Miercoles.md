Lo primero ver que servicios hay y para que sirven cada uno de ellos.
Luego ver en más profundidad el Azure Service Bus y Queue Storage
https://learn.microsoft.com/es-es/training/modules/discover-azure-message-queue/

Además tendremos que ver como aplicarlo en .net como conectarnos a esa Azure Service Bus y lo haremos desde .NET Core.
https://learn.microsoft.com/es-mx/azure/service-bus-messaging/service-bus-dotnet-how-to-use-topics-subscriptions?tabs=passwordless%2Croles-azure-portal%2Csign-in-azure-cli%2Cidentity-visual-studio

Se ha realizado:
Después vamos a modificar el api de embarque y vamos a generar un método GETEmbarqueUpdate (donde le pasamos un embarque), 
el buscará ese embarque en el repositorio, si el embarqueupdate recibe un avión disinto, enviara un evento del tipo "avion-modificado-embarque", 
además si cambian los tripulantes deberá de enviar también un evento "tripulante-modificado-embarque".

En nuestro prorama Jac.Aeronautica en la rama inicioAzure estará la aplicación sobre la que jacinto hará la demo que será
Crear el service bus y crear los topics que definimos en la anterior sesión.
Topic: avion-modificado-embarque
Topic: tripulante-modificado-embarque



Esos eventos deberán de contener el Id del embarque y el viejo avion y el nuevo avion en el caso del evento avion-modificado-embarque y 
El Id de embarque y la lista de tripulantes original y la cambiada (recordar que la lista de tripulantes va en una cadena de texto)

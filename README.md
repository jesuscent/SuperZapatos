# SuperZapatos
En la empresa "Super Zapatos" ocupan realizar una aplicación web para llevar el control de inventario del calzado disponible en su zapatería. Dada esta necesidad, los expertos de tecnología de la empresa consideraron que la mejor opción sería hacer una aplicación ASP.Net utilizando MVC. El cliente desea que las paginas se ajusten al dispositivo que la está mostrando (Mobil, Tablet, PC). Esta se encargara de mostrar la información y un backend enviara la información a la base de datos, mediante servicios web. Además esta aplicación debería de permitir a los administradores de la empresa poder agregar la información en la base de datos.
Dada la necesidad anteriormente planteada, se consultó a un experto de base de datos y él recomendó tener una base de datos compleja para lograr el proyecto. Sin embargo, como el presupuesto del cliente era limitado, se concluyó que la mejor opción era tener únicamente el mantenimiento y los servicios esenciales de la aplicación, lo que implicaba únicamente tener dos tablas básicas, cuyas descripciones son:

#table articles   

id                  
name
description         
price               
total_in_shelf
total_in_vault
store_id	

#table stores

id
name
address


Dadas las necesidades de la aplicación, es necesario realizar al menos 3 servicios, cuyos URL y respuestas están descritos en la documentación del API adjunta a esta prueba, estos servicios serán consumidos a futuro por cualquier dispositivo móvil. Además se requiere crear los mantenimientos para artículos y tiendas en el cual se pueda agregar o modificar una tienda o un artículo vía WEB.
Para cerrar, para esta prueba se requerirá como entregables:
- El proyecto con las migraciones (EF), los modelos, vistas y controladores de la aplicación.
- Generar los servicios acorde con la documentación del API adjunta.
- Todas las pantallas tendrán un diseño gráfico sencillo pero agradable.
- ASP.NET MVC Razor, EF 6 Code First approach, SQL Server.
- ASP.NET WEB API para crear los servicios del API descritos en el documento Services API-JSON_v2.0.docx.

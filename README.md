#Los Juegos del Hambre: Simulador#

##Presentación del Juego##

###Bienvenido al Simulador de los Juegos del Hambre###

Este juego te invita a introducirte en la experiencia de los Juegos del Hambre junto con tus familiares y amigos. Este simulador te permite adentrarteen el mundo de Panem y sumergirte en una competencia virtual en la arena. Los tributos se enfrentan en feroces combates mano a mano, dónde solo uno puede salir victorioso. El último en sobrevivir será coronado como el **ganador de la 74ma edición de los Juegos del Hambre**.

**Disclaimer: Se asegura el funcionamiento de programa solo en windows. (Leer sección Implementación ->Sonidos y música para más detalle).**

##Funcionamiento del Juego##

Una vez que se da inicio al juego, se deben generar los personajes. Se ingresa la cantidad de jugadores que desean jugar y sus respectivos nombres. A cada uno de ellos se les asignan características de manera aleatoria. En caso de existir, se podrán utilizar los últimos personajes cargados. Si no existen o no se desea repetirlos, se generarán nuevos personajes como se detalló anteriormente. 
Cuando los personajes se han determinado, se producen las batallas. Se elige de manera aleatoria dos personajes que se enfrentarán en la arena. En cada batalla, uno de estos personajes se es derrotado y queda fuera de juego. El ganador continúa en competencia y recibirá una mejora de salud para seguir jugando. Este proceso se repite hasta que un solo tributo sobrevive. De esta manera, se lo declara ganador de *Los Juegos del Hambre: Simulador*.


##Implementación##

###Utilización de la API###

En el juego utilicé una API de clima Open-Meteo https://open-meteo.com/ para generar las condiciones de la arena. Esta API me pareció óptima ya que me permitía elegir el lugar de donde quería obtener las condiciones climáticas y seleccionar qué datos del tiempo me interesaba obtener como precipitaciones, temperaturas mínimas y máximas, cantidad de nieve acumulada, entre otros. Esto me pareció importante ya que me permitió elegir un lugar de condiciones climáticas hostiles que se parecieran a las dificultades a las cuales se enfrentan los tributos en la arena en la película.


###Interfaz gráfica###

Con el fin de agregar figura como el logo del Capitolio para hacer referencias a la película utilicé páginas generadoras de ASCII art para poder lograr una mejor presentación por consola. También, en el título del juego se utilizó ASCII art.
Recursos usados: https://www.topster.es/texto-ascii/doom.html y https://www.asciiart.eu/image-to-ascii

###Animaciones

En la búsqueda de efectos para títulos para lograr una mejor presentación del juego por la consola, me encontré con recursos como este repositorio de GitHub: https://gist.github.com/SebastianCastilloDev/466e1daab2e45729bd9ab53c247aaa17 y este video de youtube https://www.youtube.com/watch?si=OfXtKADo11WrxUCU&v=45E-IJDVSJo&feature=youtu.be que mostraban ideas para generar efectos en los textos y así decidí implementar el efecto de temblor en el título, el efecto de máquina de escribir en los anuncios y utilizar una función para generar los bordes de la información de las batallas. 

###Sonidos y música###

Para incorporar archivos de audio en el juego utilicé la clase SoundPlayer que se encuentra en el namespace System.Media. La clase SoundPlayer permite cargar y reproducir archivos de sonido (.wav) en aplicaciones .NET. Esta clase ofrece métodos para reproducir sonidos de forma sincrónica y asincrónica (en el caso de este proyecto se utiliza la reproducción de forma asíncronica). Para poder utilizar esta clase es necesario agregar al proyecto. Para poder utilizar la clase SoundPlayer se necesita agregar una referencia al ensamblado System.Windows.Extensions. Para realizar esto utilice el comando 'dotnet add package System.Windows.Extensions --version 8.0.0' que agrega el paquete NuGet System.Windows.Extensions a tu proyecto .NET. 
Al usar este comando, el uso de SoundPlayer sólo se admite en windows. De manera que sólo se asegura el funcionamiento del juego para Windows.

###Menú###

Mi idea original consistía en hacer un menú de opciones que se maneje por teclado con las flechas y seleccionar la opción con la tecla enter para de esta manera evitar que el usuario tenga que ingresar la opción del menú por pantalla y evitar sus controles pertinentes. Sin embargo, como no conocía como hacerlo, busqué un video explicativo en youtube https://youtu.be/YyD1MRJY0qI?si=KJ4SSNeIMKvm_H8x e implementé mi menú guiandome de ese código y haciendo modificaciones estéticas de acuerdo a como venía realizando mi juego.
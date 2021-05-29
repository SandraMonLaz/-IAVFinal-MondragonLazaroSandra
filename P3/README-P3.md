# IA Grupo 05
_Felipe Cuadra Plaza, Sandra Mondragón Lázaro, Antonio Jesús Guerra Garduño, Javier Cruz López De Ochoa_
____________________________________________________________________________________________________________________________
## _Práctica 3 - El fantasma de la ópera_
* [Vídeo](https://drive.google.com/file/d/19gQqHTW3Km4bQ3oaVSyKA1rqZIZWDHws/view?usp=sharing)
* [Build](https://drive.google.com/file/d/1zNAyNGNrCh2PTJlhTk3WwmiDQnSnEYsK/view?usp=sharing)
> El prototipo que vamos a desarrollar se centra en la toma de decisiones del fantasma, que será el agente inteligente con el comportamiento más complejo de todos. Su objetivo es secuestrar a la cantante, llevarla a la celda secreta que tiene preparada para ella, encerrarla allí, y poder así seguir trabajando confiado en su gloriosa (y a la vez interminable) obra maestra. La diva, por su parte, trabaja sobre el escenario aunque en el descanso entre las escenas, se retira a las bambalinas. El fantasma la aterroriza y es incapaz de ofrecer resistencia alguna si la captura. Su amigo el vizconde, por el contrario, la tranquiliza y ayuda volver a las tablas. Precisamente el avatar que controla el jugador es el vizconde, capaz de moverse por todas partes y poner remedio a todos los males que haya podido causar el fantasma. El vizconde recoloca lámparas caídas (viles atentados que en ocasiones realiza el fantasma para expulsar al público de la ópera), consuela a la cantante, la rescata de su celda, e incluso puede ensañarse a veces con la
guarida del fantasma, golpeando los muebles (¡y el piano!) que este guarda en la sala de música, haciendo enfurecer terriblemente a esta malvada criatura. Si, como jugadores, no intervenimos frente a las tropelías del fantasma, este no tardará en secuestrar a nuestra ‘prima donna’, incluso atentando contra el público, y seguir impunemente con su febril actividad artística.

__________________
## _JUGADOR (VIZCONDE)_ 
El vizconde se mueve con las teclas W, A, S, D e interactúa con la tecla E. Para dar más feedback, en la pantalla aparece cuando el usuario puede interactuar con un objeto. Entre las acciones que puede realizar el jugador cuando interactúa, se encuentran:  
   - **Reparar y Tirar lámparas**--->El usuario puede tirar o reparar las lámparas para que el público se vaya o vuelva al escenario.
   - **Coger a Diva**--------------->El usuario podrá coger a Diva con el fin de guiarla a una zona conocida. Esta acción solo la podrá realizar en caso de que diva esté confusa.
   - **Usar Barca**----------------->El usuario, para poder pasar a dterminadas zonas, deberá de ir en barca. Para esto requerirá una opción de llamar a la barca(en caso de que no se encuentre aparcada en donde se escuentre el jugador) para después volver a interactuar con ella y usarla con el fin de que le lleve a su destino.
   - **Abrir Celda**---------------->El usuario abre la celda en la que se encuentra Diva para poder salvarla.
   - **Romper Piano**--------------->El usuario tiene la opción de romper el piano del Fantasma con el fin de entretenerlo.
   - **Pegar Fantasma**------------->El usuario puede pegar al 
   
__________________
## _DIVA_ 
 ![Máquina de Estados](Assets/Markdown/Diva.png)
 
   - **Cantando**------------>Primer estado en el que diva se encuentra. Es cuando está cantando en el escenario.
   - **Agobiada**------------>Diva pasa a este estado cuando no hay público o lleva cantando durante un tiempo largo. Tras un largo tiempo se tranquiliza.
   - **Tranquila**----------->Estado intermedio entre agobiada y cantando, en el que Diva se tranquiliza y tras un tiempo vuelve a cantar.
   - **Cogida**-------------->Estado en el que se encuentra Diva cuando el usuario la coge u el fantasma la coge.
   - **Aterrorizada**-------->Estado en el que se encuentra Diva cuando el fantasma la aterroriza.
   - **Confusa**------------->Estado en el que se encuentra Diva cuando no sabe como llegar al escenario.
   - **Encarcelada**--------->Estado cuando Diva se encuentra metido en la celda.
   - **Siguiendo Vizconde**-->Estado cuando el Vizconde le dice a Diva que se siga.

__________________
## _FANTASMA_ 
 ![Árbol de comportamiento](Assets/Markdown/Fastasma.PNG)
 
   - **Reparar el piano**---------------------------->Si escucha al vizconde romper el piano, va hacia este para repararlo.
   - **Aturdido**------------------------------------>Cuando el vizconde le pega.
   - **Llevar a Diva a la celda y tocar el piano**-->Si tiene a Diva, intenta llevarsela a la celda y después tocar el piano. 
   - **Tirar las lámparas**-------------------------->Para alejar al público y que Diva se agobie.
   - **Coger a Diva**------------------------------->Si todas las condiciones se cumplen, intenta ir a por Diva. 

__________________
## _ESCENARIO_
 ![Imagen general](Assets/Markdown/Escenario.PNG)
 
 


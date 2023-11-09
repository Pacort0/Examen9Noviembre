

namespace Examen9Noviembre
{
    public partial class MainPage : ContentPage
    {
        int errores = 0; //Variable que cuenta los errores del usuario
        int puntos = 0; //Variable que cuenta los puntos del usuario
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Método que es llamado cada vez que se hace click en la imagen de la izquierda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_ImagenIzquierda(object sender, TappedEventArgs e)
        {
            fallo(); //Llama al método 'fallo'
        }
        /// <summary>
        /// Método llamado cada vez que se hace click en la imagen de la derecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_ImagenDerecha(object sender, TappedEventArgs e)
        {
            fallo(); //Llama al método 'fallo'
        }
        /// <summary>
        /// Método llamado cuando se encuentra la diferencia en la caseta derecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Caseta2_Clicked(object sender, EventArgs e)
        {
            aciertoCaseta(); //Llama al método 'aciertoCaseta'
        }
        /// <summary>
        /// Método llamado cuando se encuentra la diferencia en el cuenco derecho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cuenco2_Clicked(object sender, EventArgs e)
        {
            aciertoCuenco(); //Llama al método 'aciertoCuenco'
        }
        /// <summary>
        /// Método llamado cuando se encuentra la diferencia en la espalda derecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Espalda2_Clicked(object sender, EventArgs e)
        {
            aciertoEspalda(); //Llama al método 'aciertoEspalda'
        }
        /// <summary>
        /// Método llamado cuando se encuentra la diferencia en la caseta izquierda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Caseta1_Clicked(object sender, EventArgs e)
        {
           aciertoCaseta(); //Llama al método 'aciertoCaseta'
        }

        /// <summary>
        /// Método llamado cuando se encuentra la diferencia en el cuenco izquierdo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cuenco1_Clicked(object sender, EventArgs e)
        {
            aciertoCuenco(); //Llama al método 'aciertoCuenco'
        }
        /// <summary>
        /// Método llamado cuando se encuentra la diferencia en la espalda izquierda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Espalda1_Clicked(object sender, EventArgs e)
        {
            aciertoEspalda(); //Llama al método 'aciertoEspalda'
        }
        /// <summary>
        /// Método que determina si la partida ya se ha perdido.
        /// En caso positivo, se muestra un mensaje de alerta para notificar al usuario y
        /// se le pregunta si desea volver a jugar
        /// En caso negativo, se muestra un botón de reinicio oor si el usuario cambia de opinión
        /// </summary>
        private async void derrota()
        {
            if (errores == 3) //Si se han cometido 3 errores
            {
                //Mostramos un mensaje de alerta y guardamos la decisión del usuario en una variable booleana
                bool reset = await DisplayAlert("Derrota", "Partida finalizada.\n¿Desea volver a jugar?", "Sí", "No");
                if (reset) //Si el usuario desea reiniciar
                {
                    resetGame();//Llamamos al método resetGame
                } else //Si no, se cierra la app
                {
                    App.Current.Quit();
                }
            }   
        }
        
        /// <summary>
        /// Método que determina si la partida ya se ha ganado.
        /// En caso positivo, se muestra un mensaje notificando al usuario y 
        /// preguntándole si desea volver a jugar
        /// En caso negativo, se muestra un botón de reinicio oor si el usuario cambia de opinión
        /// </summary>
        private async void victoria()
        {
            if (puntos == 3) //Si se han conseguido los 3 puntos
            {
                //Mostramos un mensaje de alerta y guardamos la decisión del usuario en una variable booleana
                bool reset = await DisplayAlert("¡Victoria!", "Enhorabuena, ha ganado.\n¿Desea volver a jugar?", "Sí", "No");
                if (reset) //Si el usuario desea volver a jugar
                {
                    resetGame(); //Llamamos al método resetGame
                } else //Si no, se cierra la app
                {
                    App.Current.Quit();
                }
            }
        }
        /// <summary>
        /// Método que resetea todos los valores del juego a su versión original
        /// </summary>
        private void resetGame()
        {
            Caseta1.Opacity = 0;
            Caseta1.IsEnabled = true;
            Caseta2.Opacity = 0;
            Caseta2.IsEnabled = true;
            Espalda1.Opacity = 0;
            Espalda1.IsEnabled = true;
            Espalda2.Opacity = 0;
            Espalda2.IsEnabled = true;
            Cuenco1.Opacity = 0;
            Cuenco1.IsEnabled = true;
            Cuenco2.Opacity = 0;
            Cuenco2.IsEnabled = true;
            errores = 0;
            puntos = 0;
            lblAciertos.Text = "Aciertos: " + puntos;
            lblErrores.Text = "Errores: " + errores;
        }
        /// <summary>
        /// Método llamado cada vez que se comete un error
        /// Aumenta el valor de los fallos en 1, cambia el texto de errores 
        /// y llama al método derrota
        /// </summary>
        private void fallo()
        {
            errores++;
            lblErrores.Text = "Errores " + errores;
            derrota();
        }
        /// <summary>
        /// Método llamado cada vez que se acierta en la diferencia de algún cuenco
        /// Cambia la opacidad de los botones en ambas fotos, los desactiva, aumenta 
        /// el valor de los aciertos en 1, cambia el texto de aciertos y llama al
        /// método victoria
        /// </summary>
        private void aciertoCuenco()
        {
            Cuenco2.Opacity = 1;
            Cuenco1.Opacity = 1;
            Cuenco1.IsEnabled = false;
            Cuenco2.IsEnabled = false;
            puntos++;
            lblAciertos.Text = "Aciertos " + puntos;
            victoria();
        }
        /// <summary>
        /// Método llamado cada vez que se acierta en la diferencia de alguna espalda
        /// Cambia la opacidad de los botones en ambas fotos, los desactiva, aumenta 
        /// el valor de los aciertos en 1, cambia el texto de aciertos y llama al
        /// método victoria
        /// </summary>
        private void aciertoEspalda()
        {
            Espalda1.Opacity = 1;
            Espalda2.Opacity = 1;
            Espalda1.IsEnabled = false;
            Espalda2.IsEnabled = false;
            puntos++;
            lblAciertos.Text = "Aciertos: " + puntos;
            victoria();
        }
        /// <summary>
        /// Método llamado cada vez que se acierta en la diferencia de alguna caseta
        /// Cambia la opacidad de los botones en ambas fotos, los desactiva, aumenta 
        /// el valor de los aciertos en 1, cambia el texto de aciertos y llama al
        /// método victoria
        /// </summary>
        private void aciertoCaseta()
        {
            Caseta2.Opacity = 1;
            Caseta1.Opacity = 1;
            Caseta2.IsEnabled = false;
            Caseta1.IsEnabled = false;
            puntos++;
            lblAciertos.Text = "Aciertos " + puntos;
            victoria();
        }
    }
}
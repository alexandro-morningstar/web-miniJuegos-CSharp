using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WebMiniJuegos.Models
{
    // Sacar por pantalla las preguntas y mostrar las opciones asociadas a dichas preguntas

    public class DwarfQuiz
    {
        // ---------- "Propiedades" ----------

        private List<string> questions = new List<string>
        {
            "1.- Para referirse a los enanos, usted utiliza el término: ",
            "\n2.- ¿Podría usted tener una pareja enana?: ",
            "\n3.- ¿Cúantos enanos cree que entran en un Fiat 600?: ",
            "\n4.- ¿Tiene usted amigos enanos?: ",
            "\n5.- ¿Cuántas horas de tele mira por día?: ",
            "\n6.- Cuando un enano entra a la misma habitación que usted: ",
            "\n7.- ¿Si un enano se cae en el medio de un bosque, y no hay nadie que lo escuche, podemos decir que este hace ruido? (¿existe ruido en ese momento?)",
            "\n8.- ¿Cree que en esta encuesta se repite demasiado la palabra \"enano\"?: "
        };

        private Dictionary<int, Dictionary<int, string>> options = new Dictionary<int, Dictionary<int, string>>
        {
            { 1, new Dictionary<int, string> { { 1, "a) Gente pequeña" }, { 2, "b) Liliputiense" }, { 3, "c) Enano puto" }, { 4, "d) Amigo" } } },
            //{ 2, new Dictionary<string, string> { { "a", "Sí, siempre que nos amemos" }, { "b", "Sólo si tiene la altura exacta para practicarme sexo oral estando de pie" }, { "c", "No, los enanos son todos putos" }, { "d", "Sí, obvio" } } },
            //{ 3, new Dictionary<string, string> { { "a", "Seis: dos adelante y cuatro atrás" }, { "b", "Catorce: cuatro adelante, siete atrás y tres en la cajuela" }, { "c", "c) Uno solo: los enanos son todos ortivas y nunca llevan a nadie" }, { "d", "Una vez medio borracho subimos como a ocho" } } },
            //{ 4, new Dictionary<string, string> { { "a", "Sí, varios" }, { "b", "Tuve uno pero nos peleamos porque le dije \"Leñador de Bonsai\"" }, { "c", "No, no creo en la amistad entre el hombre y los enanos" }, { "d", "Sí, la mayoría" } } },
            //{ 5, new Dictionary<string, string> { { "a", "Menos de 2" }, { "b", "Entre 2 y 4" }, { "c", "Entre 4 y 6" }, { "d", "Más de 6" } } },
            //{ 6, new Dictionary<string, string> { { "a", "No se inmuta" }, { "b", "Le apoya un vaso en la cabeza" }, { "c", "Lo señala y grita: \"Enano puto\"" }, { "d", "Lo saluda" } } },
            //{ 7, new Dictionary<string, string> { { "a", "Sí, todas las cosas que se caen hacen ruido por más que nadie las escuche, al final el enano generará la suficiente perturbación en las ondas del aire para generar lo que nosotros concebimos como sonido" }, { "b", "No, porque nadie lo escucha" }, { "c", "No sé, pero siempre es gracioso" }, { "d", "No sé si hace ruido, pero seguramente le dolió" } } },
            //{ 8, new Dictionary<string, string> { { "a", "Sí, pero no me jode" }, { "b", "Sí,  la verdad me rompe un poco las pelotas" }, { "c", "Sí, dice muchas veces \"enano\" y muy pocas \"puto\"" }, { "d", "No, estoy acostumbrado" } } }
        };


        private Dictionary<int, string> results = new Dictionary<int, string> // Lista que contiene los posibles resultados del quiz.
        {
            {1, "Usted odia a los enanos. Prodía decirse que usted es algo así como \"el Hitrle de los enanos\". Seguramente usted usa bigote y en el próximo mundial va a apoyar a Alemania" },
            {2, "Usted discrimina moderadamente a los enanos; no los mataría, pero los haría sus esclavos."},
            {3, "Usted n odiscrimina a los enanos. De hecho, usted no discrimina a nigún ser vivo de este planeta. Seguramente está asociado a Greenpeace y si se encuentra billetera por la calle la devuelve sin sacar plata." },
            {4, "Usted es un enano."}
        };

        private Dictionary<string, int> optionScore = new Dictionary<string, int> { { "a", 3 }, { "b", 2 }, { "c", 1 }, { "d", 4 } }; // Diccionario que contiene el valor (puntaje) de cada opción

        private int score = 0;


        // ---------- Metodos ----------

        public string GetQuestion(int index) // Recorre la encuesta
        {
            string question = questions[index];
            return question;
        }

        public List<string> GetOptions(int index)
        {
            List<string> questionOptions = new List<string>();

            for (int i = 1; i < 5; i++)
            {
                questionOptions.Add(options[index][i]); // ERROR NO PUEDE ACCEDER AL INDICE i ----------------------------------------------------------------
            }

            return questionOptions;
        }

        /*
                //Metodos

        private string quizResult(score) {
            if (score >= 4 && score < 11) { return results[1]; }
            else if (score >= 11 && score < 19) { return results[2]; }
            else if (score >= 19 && score < 26) { return results[3]; }
            else if (score >= 26 && score < 33) { return results[4]; }
            else { return "Pero que ha pasao?!";}
        }


        private void addScore(answer) { // Suma puntaje.
            score += optionValue[answer];
        }

        private string getAnswer() { // Solicita, captura, evalua y retorna la respuesta.
            Console.Write("Ingresa una opción: ");
            try {
                string answer = Console.ReadLine();
                if (validAnswers.Contains(answer)) {return answer;} // Si es válida (en formato y opción), retorna.
                else {
                    Console.WriteLine("Opción inválida, intentalo de nuevo");
                    return getAnswer(); // Si no, hace recursión de método.
                    }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Algo ha salido mal, intentalo de nuevo");
                return getAnswer();
            }
        }

        private string getOptions(int questionIndex) { // Obtiene las opciones
            return questions[questionIndex]["options"];
        }

        private string getQuestions(int questionIndex) { // Obtiene la pregunta
            return questions[questionIndex]["question"];
        }

        public void ScrollQuiz() { // Recorre la encuesta
            int index = 0;
            while (index <= 7) {
                Console.WriteLine(getQuestions(index));
                Console.WriteLine(getOptions(index));
                string answer = getAnswer(); // Guarda la respuesta en variable porque se utiliza dos veces.
                // ------------------------ extra -----------------------------
                Console.WriteLine(answer);
                answerSummary.Add($"La repuesta de la pregunta {index+1} fue {answer}"); // Agrega respuesta al resumen.
                // ------------------------------------------------------------
                addScore(answer);
                index++;
            }
            Console.WriteLine(answerSummary);
            Console.WriteLine($"Tu resultado es: {quizResult(score)}");
        }
    }
}
         */

    }
}
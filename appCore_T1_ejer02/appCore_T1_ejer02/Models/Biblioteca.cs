namespace appCore_T1_ejer02.Models
{
    public class Biblioteca
    {
        public List<Libro> ListaLibros { get; set; }

        public Biblioteca()
        {
            ListaLibros = new List<Libro>()
            {
                new Libro {Isbn="1121", Titulo = "Aprenda Visual Studio 2022", TipoLibro="Tecnologia"},
                new Libro {Isbn="1122", Titulo = "El Principito", TipoLibro="Novela"},
                new Libro {Isbn="1123", Titulo = "Steve Jacobs : Vida y Obra", TipoLibro="Biografico"},
                new Libro {Isbn="1124", Titulo = "Introduccion a las Bases de Datos", TipoLibro="Tecnologia"},
                new Libro {Isbn="1125", Titulo = "Tradiciones Peruanas", TipoLibro="Novela"},
                new Libro {Isbn="1126", Titulo = "ASP NET Core - MVC", TipoLibro="Tecnologia"},
            };
        }

        //Metodo que busca un libro por su Isbn
        public Libro ObtenerPorIsbn(string strIsbn) 
        {
            foreach (var libro in ListaLibros)
            {
                if (libro.Isbn == strIsbn)
                {
                    return libro;
                }
            }
            //Si no encuentra el libro buscado retorna NULL
            return null;
        }
    }
}

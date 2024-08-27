using Business.DTOs;
using System.Net.Http.Json;

namespace BlazorCine.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly HttpClient httpClient;

        public PeliculaService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<PeliculaDto>> GetPeliculasAsync()
        {
            return await httpClient.GetFromJsonAsync<List<PeliculaDto>>("api/pelicula");
        }



        //Datos simulados
        public Task<List<Pelicula>> ObtenerPeliculasAsync()
        {
            // Simular la obtención de datos
            var peliculas = new List<Pelicula>
        {
                new Pelicula
{
    Titulo = "Deadpool",
    Descripcion = "Un antihéroe con un sentido del humor único",
    ImagenUrl = "/images/deapol.jpg",
    Clasificacion = "R",
    FechaEstreno = new DateTime(2024, 10, 5)
},
            new Pelicula
            {
                Titulo = "Aladin",
                Descripcion = "Una aventura llena de fantasias ",
                ImagenUrl = "/images/aladin.jpg",
                Clasificacion = "PG-13",
                FechaEstreno = new DateTime(2024, 9, 15)
            },
           new Pelicula
{
    Titulo = "Garfield",
    Descripcion = "Las aventuras de un gato amante de la lasaña",
    ImagenUrl = "/images/garfiels.jpg",
    Clasificacion = "PG",
    FechaEstreno = new DateTime(2024, 11, 10)
},
new Pelicula
{
    Titulo = "Furiosa",
    Descripcion = "Una guerrera en un mundo post-apocalíptico",
    ImagenUrl = "/images/furiosa.jpg",
    Clasificacion = "R",
    FechaEstreno = new DateTime(2024, 12, 22)
},
new Pelicula
{
    Titulo = "Venom",
    Descripcion = "Un simbionte alienígena con un anfitrión humano",
    ImagenUrl = "/images/venon.jpg",
    Clasificacion = "PG-13",
    FechaEstreno = new DateTime(2024, 9, 30)
},
new Pelicula
{
    Titulo = "Thor",
    Descripcion = "El dios del trueno en una nueva aventura",
    ImagenUrl = "/images/thor.jpg",
    Clasificacion = "PG-13",
    FechaEstreno = new DateTime(2024, 8, 25)
},
new Pelicula
{
    Titulo = "Huntsman",
    Descripcion = "Un cazador en un mundo lleno de magia y misterios",
    ImagenUrl = "/images/huntsman.jpg",
    Clasificacion = "PG-13",
    FechaEstreno = new DateTime(2024, 10, 15)
},
new Pelicula
{
    Titulo = "Borderlands",
    Descripcion = "Una aventura en un planeta peligros y saqueador",
    ImagenUrl = "/images/borderlands.jpg",
    Clasificacion = "R",
    FechaEstreno = new DateTime(2024, 11, 5)
},
new Pelicula
{
    Titulo = "Kids",
    Descripcion = "Una historia conmovedora sobre la infancia y la amistad",
    ImagenUrl = "/images/kids.webp",
    Clasificacion = "PG",
    FechaEstreno = new DateTime(2024, 7, 20)
},
new Pelicula
{
    Titulo = "Alien Romulan",
    Descripcion = "Una batalla en el espacio / humanos y alienígenas",
    ImagenUrl = "/images/alien.webp",
    Clasificacion = "R",
    FechaEstreno = new DateTime(2024, 12, 1)
},
new Pelicula
{
    Titulo = "Flyme",
    Descripcion = "Un viaje fantástico a través de mundos voladores",
    ImagenUrl = "/images/flyme.jpg",
    Clasificacion = "PG",
    FechaEstreno = new DateTime(2024, 10, 30)
},
            // Agrega más películas según sea necesario
        };

            return Task.FromResult(peliculas);
        }
    }
}

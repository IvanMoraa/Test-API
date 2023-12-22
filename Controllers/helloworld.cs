using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TestAPI.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class helloworld : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "hello world";
        }

        [HttpGet("GetSaludo/{nombre}")]
        public string Get(string nombre)
        {
            return "Hola " + nombre;
        }

        private struct User
        {
            public string nombre;
            public int id;
            public string edad;
        }

        [HttpGet("GetUsuario/{id}/{nombre}/{edad}")]
        public string Get(int id, string nombre, string edad)
        {
            User usuario = new User();
            usuario.edad = edad;
            usuario.id = id;
            usuario.nombre = nombre;

            string respuesta = JsonConvert.SerializeObject(usuario);
            return respuesta;
        }

        public class UsuarioP
        {
            public int id {get; set;}
            public string name {get; set;}
        }
        [HttpPost("PostUser")]
        public string Post(UsuarioP usuario)
        {
            return JsonConvert.SerializeObject(usuario);
        }

        [HttpPatch("UpdateUser")]
        public string Patch(UsuarioP usuario)
        {
            return "Se actualizo el usuario correctamente";
        }

        [HttpDelete("DelUsuario")]
        public string Delete(int idusuario)
        {

            return "Se elimino el usuario correctamente";
        }
    }
}
using System.Diagnostics;
using System.Text.Json;

namespace Database {


    /// <summary>
    /// Convierte de JSON a una tabla
    /// </summary>
    public class Deserializer {


        
        /// <summary>
        /// Deserializa un objeto cualquiera a partir del formato generado por el <code>ToString</code> 
        /// que proporcioné el otro día. 
        /// </summary>
        /// <remarks>Ha de reconocer el tipo de dato a partir del texto y ha de usar <see cref="DeserializeTo"/></remarks>
        /// <param name="json"></param>
        public static object? DeserializeAny(string json){

            throw new NotImplementedException("Hay que implementarlo");
        }
    

        /// <summary>
        /// Utiliza <see cref="DeserializeAny"/> para deserializar un documento completo
        /// </summary>
        /// <param name="file">Texto del archivo a deserializar</param>
        /// <returns>Array de los objetos serializados</returns>
        public static object[] DeserializeAll(string file){

            throw new NotImplementedException("Hay que implementarlo");
        }

        /// <summary>
        /// Deserializa a un tipo de clase concreto
        /// </summary>
        /// <typeparam name="T">Clase a generar</typeparam>
        /// <param name="json">Valor en formato json</param>
        public static T? DeserializeTo<T>(string json) where T : class, new() {
            try {
                var options = new JsonSerializerOptions() {
                    UnmappedMemberHandling = System.Text.Json.Serialization.JsonUnmappedMemberHandling.Disallow,
                };
                return JsonSerializer.Deserialize<T>(json,options);
            }
            catch (Exception ex) {
                Debugger.BreakForUserUnhandledException(ex);
                return null;
            }

        }
    }
}
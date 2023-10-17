using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContosoPizza.Model
{
    public class Topping
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        public decimal Calories { get; set; }

        [JsonIgnore]
        public ICollection<Pizza>? Pizzas { get; set; }
        /*Essas etapas previnem que entidades Topping incluam a propriedade Pizzas quando o código da API Web serializa a resposta para JSON. Sem essa alteração, uma coleção serializada de coberturas incluiria uma coleção de cada pizza que usa a cobertura. Cada pizza nessa coleção conteria uma coleção de coberturas, que cada uma conteria novamente uma coleção de pizzas. Esse tipo de loop infinito é chamado de referência circular e não pode ser serializado.*/
    }
}
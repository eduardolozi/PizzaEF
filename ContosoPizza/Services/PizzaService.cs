using ContosoPizza.Data;
using ContosoPizza.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoPizza.Services
{
    public class PizzaService
    {
        private readonly PizzaContext _context;

        public PizzaService(PizzaContext context)
        {
            _context = context;
        }

        public IEnumerable<Pizza> GetAll()
        {
            return _context.Pizzas.AsNoTracking().ToList();
        }

        /*
         O método de extensão Include utiliza uma expressão lambda para especificar que as propriedades de navegação Toppings e Sauce devem ser incluídas no resultado por meio do carregamento adiantado. Sem essa expressão, o EF Core retornará nulo para essas propriedades.
         O método SingleOrDefault retorna uma pizza que corresponde à expressão lambda. 
            - Se nenhum registro corresponder, null será retornado.
            - Se vários registros corresponderem, uma exceção será lançada.
         A expressão lambda descreve os registros em que a propriedade Id é igual ao parâmetro id.
         */
        public Pizza? GetById(int id) 
        {
            return _context.Pizzas
                .Include(p => p.Toppings)
                .Include(p => p.Sauce)
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == id);
        }

        public Pizza Create(Pizza newPizza)
        {
            _context.Pizzas.Add(newPizza);
            _context.SaveChanges();

            return newPizza;
        }

        public void UpdateSauce(int pizzaId, int sauceId)
        {
            var pizzaToUpdate = _context.Pizzas.Find(pizzaId);
            var sauceToUpdate = _context.Sauces.Find(sauceId);

            if(pizzaToUpdate is null || sauceToUpdate is null)
            {
                throw new InvalidOperationException("Pizza or sauce does not exist");
            }

            pizzaToUpdate.Sauce = sauceToUpdate;
            _context.SaveChanges();
        }

        public void AddTopping(int pizzaId, int toppingId)
        {
            var pizzaToUpdate = _context.Pizzas.Find(pizzaId);
            var toppingToAdd = _context.Toppings.Find(toppingId);

            if(pizzaToUpdate is null ||  toppingToAdd is null)
            {
                throw new InvalidOperationException("Pizza or topping does not exist");
            }

            if (pizzaToUpdate.Toppings is null)
            {
                pizzaToUpdate.Toppings = new List<Topping>();
            }

            pizzaToUpdate.Toppings.Add(toppingToAdd);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var pizzaToDelete = _context.Pizzas.Find(id);
            if (pizzaToDelete != null)
            {
                _context.Pizzas.Remove(pizzaToDelete);
                _context.SaveChanges();
            }
        }




    }
}

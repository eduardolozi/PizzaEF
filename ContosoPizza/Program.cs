using ContosoPizza.Data;
using ContosoPizza.Model;
using ContosoPizza.Services;
using Microsoft.Graph.Models.ODataErrors;

public class Program
{
    static void Main(string[] args)
    {
        using (var context = new PizzaContext())
        {

            //var tomatoSauce = new Sauce { Name = "Tomato Sauce", IsVegan = true };
            //var alfredoSauce = new Sauce { Name = "Alfredo Sauce", IsVegan = false };
            //var lemonPepperSauce = new Sauce { Name = "Lemon Pepper Sauce", IsVegan = false };
            //var listOfSauces = new List<Sauce>() {tomatoSauce, alfredoSauce, lemonPepperSauce };
            //context.Sauces.AddRange(listOfSauces);

            //var sausageTopping = new Topping { Name = "Sausages", Calories = 70 };
            //var pepperoniTopping = new Topping { Name = "Pepperoni", Calories = 50 };
            //var strogonoffTopping = new Topping { Name = "Strogonoff", Calories = 75 };
            //var brocolisTopping = new Topping { Name = "Brocolis", Calories = 20 };
            //var baconTopping = new Topping { Name = "Bacon", Calories = 50 };
            //var listOfTopping = new List<Topping> { sausageTopping, pepperoniTopping, strogonoffTopping, brocolisTopping, baconTopping };
            //context.Toppings.AddRange(listOfTopping);

            //var pizza = new Pizza
            //{
            //    Name = "Pepperoni & Sausage",
            //    Sauce = tomatoSauce,
            //    Toppings = new List<Topping>
            //{
            //    sausageTopping,
            //    pepperoniTopping,
            //}
            //};
            // context.Add( pizza )
            //context.SaveChanges();

            //var listOfPizzas = new Pizza[]
            //{
            //    new Pizza
            //    {
            //        Name = "Strogonoff",
            //        Sauce = lemonPepperSauce,
            //        Toppings = new Topping[]
            //        {
            //            strogonoffTopping
            //        }
            //    },
            //    new Pizza
            //    {
            //        Name = "Bacon & Brocolis",
            //        Sauce = tomatoSauce,
            //        Toppings = new Topping[]
            //        {
            //            baconTopping, 
            //            brocolisTopping
            //        }
            //    },
            //    new Pizza
            //    {
            //        Name = "Pepperoni & Sausage",
            //        Sauce = alfredoSauce,
            //        Toppings = new Topping[]
            //        {
            //            pepperoniTopping,
            //            sausageTopping
            //        }
            //    }
            //};

            //context.Pizzas.AddRange(listOfPizzas);

            //context.SaveChanges();


            //for(int i = 5; i < 14; i++)
            //{
            //    service.DeleteById(i);
            //}

            //foreach ( var p in pizzas )
            //{
            //    Console.WriteLine(p.Name);
            //}

            var service = new PizzaService(context);
            var pizzas = service.GetAll();
            Pizza pizzaAux;
            foreach(Pizza p in pizzas)
            {
                pizzaAux = service.GetById(p.Id)!;
                Console.Write($"{pizzaAux.Id} - Pizza: {pizzaAux.Name}\nMolho: {pizzaAux.Sauce!.Name}\nCobertura(s): ");
                foreach(Topping t in pizzaAux.Toppings!)
                {
                    Console.Write($"{t.Name}\n              ");
                }
                Console.WriteLine("\n--------------------------------------------------------");
            }

        }




    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudnikSaveEyes.DB
{
    public class DataAccess
    {
        public delegate void AddNewItem();
        public static event AddNewItem AddNewItemEvent;

        private static DbSet<Agent> _agents => SaveEyesDBEntities.GetContext().Agents;
        private static DbSet<ProductSale> _productSales => SaveEyesDBEntities.GetContext().ProductSales;

        public static List<Agent> GetAgents() => _agents.ToList();
        public static List<AgentType> GetAgentTypes() => SaveEyesDBEntities.GetContext().AgentTypes.ToList();
        public static List<Product> GetProducts() => SaveEyesDBEntities.GetContext().Products.ToList();


        public static void SaveAgent(Agent agent)
        {
            if (agent.ID == 0)
                _agents.Add(agent);

            SaveEyesDBEntities.GetContext().SaveChanges();
            AddNewItemEvent?.Invoke();
        }

        public static void DeleteAgent(Agent agent)
        {
            _agents.Remove(agent);
            SaveEyesDBEntities.GetContext().SaveChanges();
            AddNewItemEvent?.Invoke();
        }

        public static bool IsINNnKPPExist(Agent agent) => _agents.Any(x => x.ID != agent.ID && (x.INN == agent.INN || x.KPP == agent.KPP));


        public static void DeleteProductSale(ProductSale productSale)
        {
            _productSales.Remove(productSale);
            SaveEyesDBEntities.GetContext().SaveChanges();
            AddNewItemEvent?.Invoke();
        }
    }
}

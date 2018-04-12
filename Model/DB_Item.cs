using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class DB_Item
    {
        public List<Item> ListItem()
        {
            var items = new List<Item>();
            try
            {
                using (var db = new DBContext())
                {
                    items = db.Items.Take(100).OrderByDescending(x => x.sold_quantity).ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return items;
        }
        public Item Obtener(string id)
        {
            var items = new Item();
            try
            {
                using (var db = new DBContext())
                {
                    items = db.Items
                            .Where(x => x.ItemId == id)
                            .First();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return items;
        }
        public void Guardar(Item model)
        {
            try
            {
                using (var db = new DBContext())
                {
                    if (model.ItemId == "")
                    {
                        db.Entry(model).State = EntityState.Added;
                    }
                    else
                    {
                        db.Entry(model).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}

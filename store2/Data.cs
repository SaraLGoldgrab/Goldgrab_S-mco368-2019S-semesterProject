using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store2
{
    public class Data 
    {
        public Data()
        {

        }
        public DataClasses1DataContext db = new DataClasses1DataContext();  //global but hv to dispose it right
        public Int32 custId;
        public  dynamic productList { get; set; }  //IEnumerable<Product>
        //public static IEnumerable<String> descList { get; set; }
        private static int purchase_num ; //=0
        //public static List products 
        //private readonly String balanceLimit = "200";
        private int balanceLimit = -200;
        public IEnumerable<purchase> pastPurchases { get; set; }
        public bool useDateFilter { get; set; }
        public bool usePriceFilter { get; set; }

        public bool login(String username, String password)
        {
            custId = System.Convert.ToInt32
                (db.customers.Where(e => e.username == username && e.password == password).Select(e => e.cust_num).FirstOrDefault());
            if (custId==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void viewProducts()
        {
            productList = db.items.Select(e => new Product{ description=e.description, item_num=e.item_num, price= (Double)e.price}) ;
            //var descList = productList.Select(e => e.description)
        }
        public bool makePurchase(Product p, int qty, double tots)
        {
            // var balance= db.customers.Where(e => e.cust_num == custId).Select(e => e.balance);  //System.Linq.IQueryable
            bool balanceIsOver =db.customers.Any(e => e.cust_num == custId && e.realBalance <= balanceLimit);//.Select(e => e.realBalance);  //balance2
            //String balancestr = balance.ToString();
            //if (double.Parse(balancestr) >= double.Parse(balanceLimit))
            //if(balanceLimit-balance)
            //if(balance <= balanceLimit)
            if(!balanceIsOver)
            {
                decimal total = decimal.Parse(tots.ToString());
                purchase_num = db.purchases.Count();
                purchase pur = new purchase
                {
                    purchase_num = ++purchase_num,
                    cust_num = custId,
                    item_num = p.item_num,
                    purchase_date = DateTime.Now,
                    qty = qty,
                    total = total
                };
                db.purchases.InsertOnSubmit(pur);
                db.customers.Where(e => e.cust_num == custId).First().balance -= total;

                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void exit()
        {
            db.Dispose();
        }
        public void filterHistory( List<Func< purchase, bool>> funcs  )  //doing union is inefficinet.., or cld just pass true to not used func.. for one statement
        {
            //if (funcs.Count() == 0)
            //{
                pastPurchases = db.purchases.Where(e=> e.cust_num==custId);
                
           // }
           foreach(Func<purchase, bool> f in funcs)
            {
                pastPurchases = pastPurchases.Where(e => f(e));
            }
            //if (funcs.Count() >= 1)
            //{
            //    Func<purchase, bool> firstFunc= funcs[0];
            //    pastPurchases =pastPurchases.Where(e=>funcs[0](e));

            //}
            //if (funcs.Count() == 2)
            //{
            //    pastPurchases = pastPurchases.Where(e => funcs[1](e));
            //}
            
            
        }

    }
}

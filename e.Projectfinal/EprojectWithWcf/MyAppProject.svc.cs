using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EprojectWithWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyAppProject" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyAppProject.svc or MyAppProject.svc.cs at the Solution Explorer and start debugging.
    public class MyAppProject : IMyAppProject
    {



        DBConnectionDataContext db = new DBConnectionDataContext();

//        List<Category> CatList = new List<Category>();

        List<Brands> BrandList = new List<Brands>();
        List<Product> ProList = new List<Product>();
       

        Category catob = new Category();
        Brands brndOb = new Brands();
        string msg;
        public string Insert(string Cname)
        {
            try
            {
                db.insertIncatgory(Cname);
                msg = "Record has been inserted sucessfully....";
            }
            catch (Exception ex)
            {
                msg = "error in insert query:" + ex.Message;
            }
            return msg;
        }

        public string Update(int Cid, string Cname)
        {
            try
            {
                db.UpdateIncatgory(Cid, Cname);
                msg = "Record has been updated sucessfully....";
            }
            catch (Exception ex)
            {
                msg = "error in update query:" + ex.Message;
            }
            return msg;

        }

        public string Delete(int Cid)
        {
            try
            {
                db.DeleteIncatgory(Cid);
                msg = "record has been deleted sucessfully.....";
            }
            catch (Exception ex)
            {
                msg = "error in delete query:" + ex.Message;
            }
            return msg;
        }

        public List<Category> ViewAllCat()
        {
            List<Category> CatList = new List<Category>();
            try
            {
                foreach (SelecttIncatgoryResult result in db.SelecttIncatgory())
                {
                    Category obj = new Category();

                    obj.CID = result.cat_id;
                    obj.CName = result.cat_name;
                    CatList.Add(obj);

                }

            }
            catch (Exception ex)
            {
                msg = "Query Have Eror" + ex.Message;
            }
            return CatList;

        }

        public string InsertBrand( int Cid, string Bname)
        {

            try
            {
                db.insertInBrands(Bname, Cid);
                msg = "Record has been sucessfully inserted..";
            }
            catch (Exception ex)
            {
                msg = "error in insert query:" + ex.Message;
            }

            return msg;
        }

     public string UpdateBrand(int Bid, string Bname,int cid)
        {
         try
         {
             db.UpdateInBrands(Bid, Bname, cid);
             msg = "Record has been Update";
         }
         catch(Exception ex)
         {
             msg = "error in Update query:" + ex.Message;
         }
            return msg;
        }

   
       public string DeleteBrand(int Bid)
        {
           try
           {
               db.DeleteInBrand(Bid);
               msg = "Record has been Deleted";
           }
           catch(Exception ex)
           {
               msg = "error in Delete query:" + ex.Message;
           }
            return msg;
        }
        
        public List<Brands> ViewAllBrand()
        {

            try
            {
                foreach (SelectInBrandResult result in db.SelectInBrand())
                {
                    Brands ob = new Brands();
                    ob.BID = result.brd_id;
                    ob.PCategory = result.cat_name;
                    ob.BName = result.brd_name;
                    ob.pid = result.cat_id;
                    BrandList.Add(ob);


                }

            }
            catch (Exception ex)
            {
                msg = "Error in slect query:" + ex.Message;
            }

            return BrandList;
        }
        public List<Brands> ViewAllBrandByCat(int cat_id)
        {

            try
            {
                foreach (SelectInBrandByCatResult result in db.SelectInBrandByCat(cat_id))
                {
                    Brands ob = new Brands();
                    ob.BID = result.brd_id;
                    ob.PCategory = result.cat_name;
                    ob.BName = result.brd_name;

                    BrandList.Add(ob);


                }

            }
            catch (Exception ex)
            {
                msg = "Error in slect query:" + ex.Message;
            }

            return BrandList;
        }

        public string InsertProduct(string Product, string Price,string Quantity, int Cid, int Bid)
        {
            try
            {
                db.insertInProducts(Product, Price, Quantity, Cid, Bid);
                msg = "Record has been sucessfully inserted..";
            }
            catch(Exception ex)
            {
                msg = "Error in insert query:" + ex.Message;
            }
            return msg;
        }
       public string UpdateProduct(int Pid, string Product, string Price, string Quantity, int Cid, int Bid)
        {
            try
            {
                db.UpdateInProducts(Pid,Cid, Product, Price, Quantity,Bid);
                msg = "Data has been Udated ";
            }   
            catch (Exception ex)
            {
                msg = "Query Have Eroro" + ex.Message;
            }
            return msg;
        }
        
       public string DeleteProduct(int Pid)
        {
            try
            {
                db.DeleteInProduct(Pid);
                msg = "Record has been Deleted";
            }
            catch (Exception ex)
            {
                msg = "Have Eroro In Query" + ex.Message;
            }
            return msg;

        }
       
      public List<Product> ViewAllProduct()
        {

            try
            {

                foreach (SelectInProductResult res in db.SelectInProduct())
                {
                    Product obj = new Product();

                    obj.PID = res.pro_id;
                    obj.PName = res.pro_name;
                    
                    obj.Bname = res.brd_name;
                    obj.Cname = res.cat_name;
                    obj.Price = res.pro_price;
                    obj.QUNTITY = res.proQuantity;

                    
                    ProList.Add(obj);

                    
                  

                }
            }
            catch (Exception ex)
            {

            }
            return ProList;
        }

      public List<Product> ViewAllProductSerch(string Alp)
      {
          
          try
          {
              
              foreach (SelectfromSerchWiseResult res in db.SelectfromSerchWise(Alp))
              {
                  Product obj = new Product();

                  obj.PID = res.pro_id;
                  obj.PName = res.pro_name;

                  obj.Bname = res.brd_name;
                  obj.Cname = res.cat_name;
                  obj.Price = res.pro_price;
                  obj.QUNTITY = res.proQuantity;


                  ProList.Add(obj);




              }
          }
          catch (Exception ex)
          {

          }
          return ProList;
      }


        
    }
}
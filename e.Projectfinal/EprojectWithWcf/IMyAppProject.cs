using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EprojectWithWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyAppProject" in both code and config file together.
    [ServiceContract]
    public interface IMyAppProject
    {
        [OperationContract]
        string Insert(string Cname);
        [OperationContract]
        string Update(int Cid, string Cname);
        [OperationContract]
        string Delete(int Cid);
        [OperationContract]
        List<Category> ViewAllCat();





        [OperationContract]
        string InsertBrand(int Cid, string Bname);
        [OperationContract]
        string UpdateBrand(int Bid, string Bname, int cid);
        [OperationContract]
        string DeleteBrand(int Bid);
        [OperationContract]
        List<Brands> ViewAllBrand();
        [OperationContract]
        List<Brands> ViewAllBrandByCat(int cat_id);



        [OperationContract]
        string InsertProduct(string Product,string Price, string Quantity,int Cid, int Bid);
        [OperationContract]
        string UpdateProduct( int Pid, string Product, string Price, string Quantity, int Cid, int Bid);
        [OperationContract]
        string DeleteProduct(int Pid);
      
        
        [OperationContract]
        List<Product> ViewAllProduct();
        [OperationContract]
        List<Product> ViewAllProductSerch(string Alp);
        

       


    }


    [DataContract]
    public class Product
    {
        [DataMember]
        public int PID { get; set; }
        [DataMember]
        public string PName { get; set; }

        [DataMember]
        public string Price{ get; set; }

        [DataMember]
        public string QUNTITY { get; set; }
        [DataMember]
        public string Bname { get; set; }
        [DataMember]
        public string Cname { get; set; }

    }







    [DataContract]
    public class Category
    {
        [DataMember]
        public int CID { get; set; }
        [DataMember]
        public string CName { get; set; }
    }


    [DataContract]
    public class Brands
    {
        [DataMember]
        public int BID { get; set; }
        [DataMember]
        public string BName { get; set; }
        [DataMember]
        public string PCategory { get; set; }
        [DataMember]
        public int pid { get; set; }


    }



}

using ProductManagement.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public class ProductCategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime? CreatedDate { get; set; }
    }

    public class ProductCategoryService
    {
        private readonly string _connectionString;
        public ProductCategoryService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<ProductCategoryModel> GetList()
        {
            var list = new List<ProductCategoryModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductCategory", conn);
                var record = sqlCommand.ExecuteReader();

                while (record.Read())
                {
                    var productCategoryObject = new ProductCategoryModel();
                    productCategoryObject.Id = (int)record["Id"];
                    productCategoryObject.CategoryName = (string)record["CategoryName"];
                    if (record["CreatedDate"] != DBNull.Value)
                    {
                        productCategoryObject.CreatedDate = (DateTime)record["CreatedDate"];
                    }
                    list.Add(productCategoryObject);
                }
            }
            return list;
        }
        public void Insert(ProductCategoryModel model)
        {
            string categoryName = model.CategoryName;
            DateTime cTime = DateTime.Now;
            using (SqlConnection conn= new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO ProductCategory (CategoryName, CreatedDate) VALUES (@name,@createdTime)", conn);
                sqlCommand.Parameters.AddWithValue("@name", categoryName);
                sqlCommand.Parameters.AddWithValue("@createdTime", cTime);
                sqlCommand.ExecuteNonQuery();
            }
        }
        public void Update(ProductCategoryModel model)
        {
            string categoyName = model.CategoryName;
            int categoyId = model.Id;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE ProductCategory SET CategoryName= (@name) WHERE Id=(@id)", conn);
                sqlCommand.Parameters.AddWithValue("@name", categoyName);
                sqlCommand.Parameters.AddWithValue("@id", categoyId);
                sqlCommand.ExecuteNonQuery();
            }
        }
        public ProductCategoryModel getProductCatagoryById(int _id)
        {
            int id = _id;
            ProductCategoryModel productCategoryObject = new ProductCategoryModel();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT CategoryName, Id FROM ProductCategory WHERE Id=@id ", conn);
                sqlCommand.Parameters.AddWithValue("@id", id);
                var record = sqlCommand.ExecuteReader();
                while (record.Read())
                {
                    productCategoryObject.CategoryName = (string)record["CategoryName"];
                    productCategoryObject.Id = (int)record["Id"];
                }   
            }
            return (productCategoryObject);
        }
        public ServiceResponse removeProductCatagoryById(int _id)
        {
            int id = _id;
            var service = new ServiceResponse();
            try {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand("DELETE FROM ProductCategory WHERE ID= (@id)", conn);
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.ExecuteNonQuery();
                }
                service.IsSuccess = true;
                service.Message = "Deletion completed";
            }
            catch {
                service.IsSuccess = false;
                service.Message = "Oops! this product category is already assigned to product so, you can not delete it";
            }

            return service;
        }
    }
}

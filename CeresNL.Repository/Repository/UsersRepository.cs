using CeresNL.Core.Library;
using CeresNL.Core.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Numerics;

namespace CeresNL.Core.Repository
{
    public class UsersRepository
    {
        private readonly IConfiguration _configuration;
        string _connStringDB_CERESNL_01;

        public UsersRepository(IConfiguration config) { //constructor
            _configuration = config;
            _connStringDB_CERESNL_01 = _configuration.GetConnectionString("DB_CERESNL_01").ToString(); 
        }


        public mUsers createUsers(mUsers post)
        {
            DBManager context = new DBManager(DataProvider.SqlServer, _connStringDB_CERESNL_01);
            try
            {
                context.Open();
                context.BeginTransaction();
                context.CreateParameters(8); // jumlah parameter
                context.AddParameters(0, "@name", post.name);
                context.AddParameters(1, "@email", post.email);
                context.AddParameters(2, "@phone", post.phone);
                context.AddParameters(3, "@idRol", post.idRol);
                context.AddParameters(4, "@password", post.password);
                context.AddParameters(5, "@photo", post.photo);
                context.AddParameters(6, "@isActive", post.isActive);
                context.AddParameters(7, "@registrationDate", post.registrationDate);

                context.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, "uspUsers");

                context.CommitTransaction();
                return post;
            }
            catch (Exception ex)
            {
                return post;
            }
            finally
            {
                context.Close();
            }
        }


        public List<mUsers> getUsersList(string WhereClause = "", string orderBy = "")
        {
            DBManager context = new DBManager(DataProvider.SqlServer, _connStringDB_CERESNL_01);
            try
            {
                context.Open();
                context.CreateParameters(3); // jumlah parameter
                context.AddParameters(0, "@vType", "GetList");
                context.AddParameters(1, "@vWhereClause", WhereClause);
                context.AddParameters(2, "@vOrderBy", orderBy);
              
                DataTable dataTable = context.ExecuteDataTable(System.Data.CommandType.StoredProcedure, "uspUsers");
                List<mUsers> dataUsers = new List<mUsers>();
                dataUsers = Helper.ConvertDataTable<mUsers>(dataTable);

                return dataUsers;
            }
            catch (Exception ex)
            {
                return new List<mUsers>();
            }
            finally
            {
                context.Close();
            }
        }
    }
}
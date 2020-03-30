using BlazorAppWebAssembly.Shared.Contracts;
using BlazorAppWebAssembly.Shared.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BlazorAppWebAssembly.Server.Concrete
{
    public class OrderManager : ICorderManager
    {
        private readonly IDapperManager _dapperManager;

        public OrderManager(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }

        public Task<int> Create(c_order article)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Name", article.name, DbType.String);
            dbPara.Add("Note", article.note, DbType.String);
            var articleId = Task.FromResult(_dapperManager.Insert<int>(@"INSERT INTO c_order (name,note) VALUES (@Name,@Note);SELECT LAST_INSERT_ID();",
                            dbPara,
                            commandType: CommandType.Text));
            return articleId;
        }

        public Task<c_order> GetById(int id)
        {
            var article = Task.FromResult(_dapperManager.Get<c_order>($"select * from c_order where ID = {id}", null,
                    commandType: CommandType.Text));
            return article;
        }

        public Task<int> Delete(int id)
        {
            var deleteArticle = Task.FromResult(_dapperManager.Execute($"Delete c_order where ID = {id}", null,
                    commandType: CommandType.Text));
            return deleteArticle;
        }

        public Task<int> Count(string search)
        {
            var totArticle = Task.FromResult(_dapperManager.Get<int>($"select COUNT(*) from c_order WHERE name like '%{search}%'", null,
                    commandType: CommandType.Text));
            return totArticle;
        }

        public Task<List<c_order>> ListAll(int skip, int take, string orderBy, string direction = "DESC", string search = "")
        {
            var c_Orders= Task.FromResult(_dapperManager.GetAll<c_order>
                ($"SELECT * FROM c_order WHERE name like '%{search}%' ORDER BY {orderBy} {direction} LIMIT {skip}, {take} ; ", null, commandType: CommandType.Text));
            
            return c_Orders; //LIMIT {skip} ROWS FETCH NEXT {take} ROWS ONLY
        }

        public Task<int> Update(c_order c_Order)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Id", c_Order.id);
            dbPara.Add("Name", c_Order.name, DbType.String);

            var updateArticle = Task.FromResult(_dapperManager.Update<int>("c_order",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return updateArticle;
        }
    }
}

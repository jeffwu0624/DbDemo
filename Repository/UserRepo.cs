using System.Linq;
using Dapper;

namespace Repository
{
    public class UserRepo 
    {
        public UserInfo GetUserBy(UserQueryCondition condition)
        {
            UserInfo result = null;

            var builder = new SqlBuilder();

            var template = builder.AddTemplate("select id, name from user /**where**/ ");

            if (condition.id.HasValue)
            {
                builder.Where("id = @Id", new {Id = condition.id});
            }

            if (!string.IsNullOrWhiteSpace(condition.Name))
            {
                builder.Where("Name = @Name", new {Name = condition.Name.Trim()});
            }

            using (var cn = DbFactory.CreateConnection(""))
            {
                result = cn.Query<UserInfo>(template.RawSql, template.Parameters).FirstOrDefault();

                cn.Close();
            }

            return result;
        }
    }

    public class UserQueryCondition
    {
        public int? id { get; set; }

        public string Name { get; set; }
    }

    public class UserInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

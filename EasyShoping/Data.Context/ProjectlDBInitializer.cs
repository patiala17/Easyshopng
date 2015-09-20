using EasyShoping.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ProjectlDBInitializer : DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            IList<UserModel> defaultStandards = new List<UserModel>();

            defaultStandards.Add(new UserModel() { UserName = "admin", Password = "admin",IsActive=true,IsDelete=false,UpdateBy=1 });

            foreach (UserModel std in defaultStandards)
                context.UserMaster.Add(std);

            base.Seed(context);
        }
    }
}

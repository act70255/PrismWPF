using Checo.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checo.Repository
{
    public class BaseRepository
    {
        protected DataContext _dbContext;
        public BaseRepository()
        {
            //_dbContext.SavingChanges += _dbContext_SavingChanges;
        }

        private void _dbContext_SavingChanges(object sender, Microsoft.EntityFrameworkCore.SavingChangesEventArgs e)
        {
            if (sender is DataContext context)
            {

            }
        }
    }
}

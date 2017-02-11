using System.Data.Entity;
using System.Web;

namespace PSTodos.Infrastructure.Repository.EF
{
    public class ContextManager
    {
        private const string ContextKey = "ContextManager.PSTodosContext";

        public DbContext Context
        {
            get
            {
                if(HttpContext.Current.Items[ContextKey] == null)
                {
                    HttpContext.Current.Items[ContextKey] = new PSTodosContext();
                }

                return (PSTodosContext)HttpContext.Current.Items[ContextKey];
            }
        }
    }
}

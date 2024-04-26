using DRRCore.Infraestructure.Interfaces.MySqlRepository;

namespace DRRCore.Infraestructure.Repository.MYSQLRepository
{
    public class MySqlUserRepository : IMySqlUserRepository
    {
        //public async Task<List<TUsuario>> GetAll()
        //{
        //    try
        //    {
        //        using (var context = new MySqlContext())
        //        {
        //            var users = await context.TUsuarios.Where(x=>x.UsEstado==true).ToListAsync();
                   
        //            return users;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public async Task<TUsuario> GetMySqlUser(string id)
        //{
        //    try
        //    {
        //        using (var context = new MySqlContext())
        //        {
        //            var users = await context.TUsuarios.Where(x => x.UsEstado == true && x.UsCodigo==id).FirstOrDefaultAsync();
        //            if (users == null) throw new Exception(Messages.MessageNoDataFound);
        //            return users;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}

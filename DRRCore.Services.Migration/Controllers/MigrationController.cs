using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.Interfaces.MigrationApplication;
using Microsoft.AspNetCore.Mvc;

namespace DRRCore.Services.Migration.Controllers
{
    public class MigrationController : Controller
    {
        private readonly IMigraUser _migraUser;
      
        public MigrationController(IMigraUser migraUser)
        {
            _migraUser = migraUser;
        }
        [HttpPost()]
        [Route("arreglarNumeration")]
        public async Task<ActionResult> arreglarNumeration()
        {
            return Ok(await _migraUser.arreglarNumeration());
        }
        [HttpPost()]
        [Route("AddOrUpdateCompany")]
        public async Task<ActionResult> AddOrUpdateCompany(int migra)
        {
            return Ok(await _migraUser.AddOrUpdateCompany(migra));
        }
        
        [HttpPost()]
        [Route("AddOrUpdatePerson")]
        public async Task<ActionResult> AddOrUpdatePerson(int migra)
        {
            return Ok(await _migraUser.AddOrUpdatePerson(migra));
        }
        //[HttpPost()]
        //[Route("MigratePersonal")]
        //public async Task<ActionResult> MigratePersonal()
        //{
        //    return Ok(await _migraUser.MigratePersonal());
        //}
        //[HttpPost()]
        //[Route("empresas")]
        //public async Task<ActionResult> MigrarEmpresas()
        //{
        //    return Ok(await _migraUser.MigrateCompany());
        //}
        [HttpPost()]
        [Route("empresasPorCodigo")]
        public async Task<ActionResult> MigrarEmpresasPorCodigo(string oldCode)
        {
            return Ok(await _migraUser.MigrateCompanyByOldCode(oldCode));
        }
        //[HttpPost()]
        //[Route("personas")]
        //public async Task<ActionResult> MigrarPersonas()
        //{
        //    return Ok(await _migraUser.MigratePerson());
        //}
        [HttpPost()]
        [Route("personasPorMigra")]
        public async Task<ActionResult> MigratePersonByMigra(int migra)
        {
            return Ok(await _migraUser.MigratePersonByMigra(migra));
        }
        //[HttpPost()]
        //[Route("MigrateOccupation")]
        //public async Task<ActionResult> MigrateOccupation()
        //{
        //    return Ok(await _migraUser.MigrateOccupation());
        //}
        //[HttpPost()]
        //[Route("correcMigra")]
        //public async Task<ActionResult> correcMigra(int migra)
        //{
        //    return Ok(await _migraUser.CorrecPersona(migra));
        //}
        [HttpPost()]
        [Route("personaPorCodigo")]
        public async Task<ActionResult> MigrarPersona(string oldCode)
        {
            return Ok(await _migraUser.MigratePersonByOldCode(oldCode));
        }
        [HttpPost()]
        [Route("abonados")]
        public async Task<ActionResult> MigrarAbonados()
        {
            return Ok(await _migraUser.MigrateSubscriber());
        }
        [HttpPost()]
        [Route("agentes")]
        public async Task<ActionResult> MigrarAgentes()
        {
            return Ok(await _migraUser.MigrateAgent());
        }
        //[HttpPost()]
        //[Route("oldTicket")]
        //public async Task<ActionResult> MigrarOldTicket()
        //{
        //    return Ok(await _migraUser.MigrateOldTicket());
        //}
        [HttpPost()]
        [Route("country")]
        public async Task<ActionResult> MigrateCountry()
        {
            return Ok(await _migraUser.MigrateCountry());
        }
        //[HttpPost()]
        //[Route("empresasOther")]
        //public async Task<ActionResult> MigrarEmpresasOther(int migra)
        //{
        //    return Ok(await _migraUser.MigrateCompanyOthers(migra));
        //}
        //[HttpPost()]
        //[Route("empresasOtherImages")]
        //public async Task<ActionResult> empresasOtherImages(int migra)
        //{
        //    return Ok(await _migraUser.MigrateCompanyImageOthers(migra));
        //}
        //[HttpPost()]
        //[Route("empresasImagesByOldCode")]
        //public async Task<ActionResult> empresasImagesByOldCode(string oldCode)
        //{
        //    return Ok(await _migraUser.MigrateCompanyImageByOldCode(oldCode));
        //}
        //[HttpPost()]
        //[Route("modificarEmpresa")]
        //public async Task<ActionResult> ModificarEmpresa(int migra,int nivel)
        //{
        //    return Ok(await _migraUser.ModificarCompanyOthers(migra,nivel));
        //}
        [HttpPost()]
        [Route("subscriberCategory")]
        public async Task<ActionResult> MigrateSubscriberCategory()
        {
            return Ok(await _migraUser.MigrateSubscriberCategory());
        }
        //[HttpPost()]
        //[Route("Personal")]
        //public async Task<ActionResult> MigratePersonal()
        //{
        //    return Ok(await _migraUser.MigratePersonal());
        //}
        //[HttpPost()]
        //[Route("Profesion")]
        //public async Task<ActionResult> MigrateProfesion()
        //{
        //    return Ok(await _migraUser.MigrateProfesion());
        //}
        [HttpPost()]
        [Route("companyRelated")]
        public async Task<ActionResult> MigrateCompanyRelated(int migra)
        {
            return Ok(await _migraUser.MigrateCompanyRelationated(migra));
        }
        [HttpPost()]
        [Route("MigrationCountryOldCode")]
        public async Task<ActionResult> MigrationCountryOldCode()
        {
            return Ok(await _migraUser.MigrationCountryOldCode());
        }
        
        [HttpPost()]
        [Route("companyPerson")]
        public async Task<ActionResult> companyPerson(int migra)
        {
            return Ok(await _migraUser.MigrateCompanyPerson(migra));
        }
        //[HttpPost()]
        //[Route("MigrateCompanyBankDebt")]
        //public async Task<ActionResult> MigrateCompanyBankDebt(int migra)
        //{
        //    return Ok(await _migraUser.MigrateCompanyBankDebt(migra));
        //}
        [HttpPost()]
        [Route("UpdatePersonJob")]
        public async Task<ActionResult> UpdatePersonJob()
        {
            return Ok(await _migraUser.UpdatePersonJob());
        }
        //[HttpPost()]
        //[Route("UpdateSubscriber")]
        //public async Task<ActionResult> UpdateSubscriber()
        //{
        //        return Ok(await _migraUser.UpdateSubscriber());
        //}
    }
}

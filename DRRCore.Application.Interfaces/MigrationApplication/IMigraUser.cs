namespace DRRCore.Application.Interfaces.MigrationApplication
{
    public interface IMigraUser
    {
        Task MigrateUser();
        Task<bool> MigrateCompany();
        Task<bool> MigrateCompanyOthers(int migra);
        Task<bool> MigrateCompanyImageOthers(int migra);
        Task<bool> MigrateCompanyImageByOldCode(string oldCode);
        Task<bool> CorrecPersona(int migra);
        Task<bool> MigratePerson();
        Task<bool> MigratePersonByMigra(int migra);
        Task<bool> MigratePersonCorreccion();
        Task<bool> MigratePersonByOldCode(string oldCode);
        Task<bool> MigrateSubscriber();
        Task<bool> MigrateOldTicket();
        Task<bool> MigrateCountry();
        Task<bool> MigrateProfesion();
        Task<bool> MigrateSubscriberCategory();
        Task<bool> MigratePersonal();
        Task<bool> MigrateAgent();
        Task<bool> MigrateCompanyRelationated(int migra);
        Task<bool> MigrateCompanyPerson(int migra);
        Task<bool> MigrateCompanyShareholder();
        Task<bool> MigrateCompanyBankDebt(int migra);
        Task<bool> UpdatePersonJob();

    }
}

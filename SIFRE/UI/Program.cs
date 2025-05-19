
using BLL;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using BE;
using Infrastructure.Interfaces.BLL;
using Infrastructure.Interfaces.DAL;
using UI.Language;
using UI.Profiles;
using UI.Mantainers;
using UI.Points;
using UI.Backup;
using UI.Logs;
using UI.Security;
using UI.Reports;
using UI.Recognitions;
using UI.Objectives;
namespace UI
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            FrmLogin form = ServiceProvider.GetRequiredService<FrmLogin>();
            Application.Run(form);
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserDAL, UserDAL>();
            services.AddTransient<IUserBLL, UserBLL>();
            services.AddTransient<ILanguageBLL, LanguageBLL>();
            services.AddTransient<ILanguageDAL, LanguageDAL>();
            services.AddTransient<ILogDAL, LogDAL>();
            services.AddTransient<ILogBLL, LogBLL>();
            services.AddTransient<IRoleBLL, RoleBLL>();
            services.AddTransient<IRoleDAL, RoleDAL>();
            services.AddTransient<IProductBLL, ProductBLL>();
            services.AddTransient<IProductDAL, ProductDAL>();
            services.AddTransient<IPointBLL, PointBLL>();
            services.AddTransient<IPointDAL, PointDAL>();
            services.AddTransient<IBackupBLL, BackupBLL>();
            services.AddTransient<IBackupDAL, BackupDAL>();
            services.AddTransient<ICheckDigitBLL, CheckDigitBLL>();
            services.AddTransient<ICheckDigitDAL, CheckDigitDAL>();
            services.AddTransient<INominationBLL, NominationBLL>();
            services.AddTransient<INominationDAL, NominationDAL>();
            services.AddTransient<IRecognitionCategoryBLL, RecognitionCategoryBLL>();
            services.AddTransient<IRecognitionCategoryDAL, RecognitionCategoryDAL>();
            services.AddTransient<INominationRuleBLL, NominationRuleBLL>();
            services.AddTransient<INominationRuleDAL, NominationRuleDAL>();
            services.AddTransient<IObjectiveBLL, ObjectiveBLL>();
            services.AddTransient<IObjectiveDAL, ObjectiveDAL>();

            services.AddTransient<FrmLogin>();
            services.AddTransient<FrmPrincipal>();
            services.AddTransient<FrmManageLanguage>();
            services.AddTransient<FrmManageProfile>();
            services.AddTransient<FrmAddProducts>();
            services.AddTransient<FrmPoints>();
            services.AddTransient<FrmExchangePoints>();
            services.AddTransient<FrmViewProducts>();
            services.AddTransient<FrmBackup>();
            services.AddTransient<FrmEventsLogs>();
            services.AddTransient<FrmProductsLogs>();
            services.AddTransient<FrmInconsistencyManagement>();
            services.AddTransient<FrmTransferPoints>();
            services.AddTransient<FrmExchangeBenefits>();
            services.AddTransient<FrmObjectiveLogs>();
            services.AddTransient<FrmNominateCollaborator>();
            services.AddTransient<FrmReviewPendingNominations>();
            services.AddTransient<FrmCheckNominationStatus>();
            services.AddTransient<FrmCheckObjectives>();
            services.AddTransient<FrmCreateObjectives>();
            services.AddTransient<FrmEvaluateObjectives>();
            services.AddTransient<FrmManageNominationRules>();
            services.AddTransient<FrmConfigureRewardPolicies>();
            services.AddTransient<FrmConfigureRecognitionCategories>();
            services.AddTransient<FrmRecognitionLogs>();
            services.AddTransient<FrmObjectiveLogs>();
        }
    }
}
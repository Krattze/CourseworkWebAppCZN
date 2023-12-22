using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppCZN.Data.BD;

namespace WebAppCZN.Data
{

    public class DatabaseLog
    {
        public int Id { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public DateTime CreatedAt { get; set; }
    }


    public class LogDbContext : DbContext
    {
        public DbSet<DatabaseLog> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Укажите свою строку подключения
            optionsBuilder.UseSqlServer("YourConnectionString");
        }
    }

    public class DbLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            if (categoryName == "Microsoft.EntityFrameworkCore.Database.Command")
            {
                return new DbCommandLogger();
            }

            return null;
        }

        public void Dispose() { }
    }


    public class DbCommandLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == LogLevel.Information; // Здесь можно настроить уровни логов
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            string logMessage = formatter(state, exception);

            using (var context = new LogDbContext())
            {
                context.Logs.Add(new DatabaseLog
                {
                    LogLevel = logLevel.ToString(),
                    Message = logMessage,
                    Exception = exception?.ToString(),
                    CreatedAt = DateTime.Now
                });

                context.SaveChanges();
            }
        }
    }
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


       }

		public DbSet<Заявление> Заявления { get; set; }
        public DbSet<WebAppCZN.Data.BD.Личные_данные> Личные_данные { get; set; } = default!;
        public DbSet<График_работы> График_работы { get ; set; } = default!;   
        public DbSet<Опыт_работы> Опыт_работы { get; set; } = default!;
        public DbSet<Основания_увольнения> Основания_увольнения { get; set; } = default!;
        public DbSet<Резюме> Резюме { get; set; } = default!;
        public DbSet<Пользователи> Пользователи { get; set; } = default!;
        public DbSet<Сведения_о_последнем_месте_работы> Сведения_о_последнем_месте_работы { get; set; } = default!;
        public DbSet<Сведения_об_образовании> Сведения_об_образовании { get; set; } = default!;
        public DbSet<Образование> Образование { get; set; } = default!;
        public DbSet<Тип_занятости> Тип_занятости { get; set; } = default!;
        public DbSet<Audit> Audit { get; set; } = default!;
        public DbSet<Пол> Пол { get; set; } = default!;
        public DbSet<WebAppCZN.Data.BD.Посещения> Посещения { get; set; } = default!;
        //public DbSet<WebAppCZN.Data.BD.Вакансии> Вакансии { get; set; } = default!;
        public DbSet<WebAppCZN.Data.BD.Личные_дела> Личные_дела { get; set; } = default!;
        public DbSet<WebAppCZN.Data.BD.Организации> Организации { get; set; } = default!;
        public DbSet<WebAppCZN.Data.BD.Предложенные_вакансии> Предложенные_вакансии { get; set; } = default!;
        public DbSet<WebAppCZN.Data.BD.Вакансии> Вакансии { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Установка строки подключения к базе данных SQL Server
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-SBI2M6T;Initial Catalog=AirLogger;Integrated Security=True;TrustServerCertificate=True");
                optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddProvider(new DbLoggerProvider())));
            }
        }

    }
}

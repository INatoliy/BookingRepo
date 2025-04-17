using Serilog;

namespace BookingService.Booking.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateHostBuilder(args).Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Неожиданное завершение работы хоста");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHost CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
             .UseSerilog((context, services, config) =>
             {
                 config
                     .ReadFrom.Configuration(context.Configuration)
                     .ReadFrom.Services(services);
             })
             .ConfigureServices((context, services) =>
             {
                  var startup = new Startup(context.Configuration);
                  startup.ConfigureServices(services);
             })
             .ConfigureWebHostDefaults(webBuilder =>
             webBuilder.UseStartup<Startup>()).Build();
        }
    }
}

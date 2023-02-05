using Paypal.NET.Models;
using Paypal.NET.Models;
using SendGrid;
using System.Threading.Tasks;

namespace Paypal.NET.Data.Services
{
    public interface IEmailService
    {
        Task<Response> SendSingleEmail(ComposeEmailModel payload);
    }
}

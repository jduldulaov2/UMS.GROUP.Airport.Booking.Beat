using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Booking.Queries.GetBookingById;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using static System.Net.Mime.MediaTypeNames;
using UMS.GROUP.Airport.Booking.Application.Common.Interfaces;

namespace UMS.GROUP.Airport.Booking.Application.Auth.Commands.Email;
public record SendEmailCommand : IRequest<Result<SendEmailDto>>
{
    public string? FromEmail { get; init; }

    public string? ToEmail { get; init; }

    public string? Password { get; init; }

    public string? EmailBody { get; init; }

    public string? EmailHost { get; init; }

    public string? EmailSubject { get; init; }

    public int EmailPort { get; init; }

}

public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, Result<SendEmailDto>>
{
    public SendEmailCommandHandler()
    {
        
    }


    public async Task<Result<SendEmailDto>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        var email = new MailMessage();
        email.From = new MailAddress(request.FromEmail!);
        email.Subject = request.EmailSubject!;
        email.To.Add(new MailAddress(request.ToEmail!));
        email.Body = $"<html><body>" + request.EmailBody! + "</body></html>";

        email.IsBodyHtml = true;

        using var smtpClient = new SmtpClient
        {
            Host = request.EmailHost!,
            Port = request.EmailPort,
            Credentials = new NetworkCredential(request.FromEmail!, request.Password!),
            EnableSsl = true
        };

        await smtpClient.SendMailAsync(email);

        return  new()
        {
            Data = new SendEmailDto
            {

            },
            Message = "Failed - no record found.",
            ResultType = ResultType.Error,
        };
    }
}

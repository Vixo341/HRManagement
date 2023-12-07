﻿using HRManagement.Application.Models.Email;

namespace HRManagement.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmailAsync(EmailMessage email);
}
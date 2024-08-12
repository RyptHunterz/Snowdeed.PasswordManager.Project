﻿using MediatR;

namespace Snowdeed.PasswordManager.Application.Accounts.Commands;

public class CreateAccountCommand : IRequest
{
    public required string AccountEmail { get; set; }
    public required string PasswordHash { get; set; }
    public required string EmailContact { get; set; }
}

using ExamAspNet.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAspNet.Infrastructure.Providers
{
    public class EmailConfirmationTokenProvider<TUser>: DataProtectorTokenProvider<TUser> where TUser: class
    {
        public EmailConfirmationTokenProvider(IDataProtectionProvider dataProtectionProvider, IOptions<DataProtectionTokenProviderOptions> options, ILogger<DataProtectorTokenProvider<TUser>> userLogger) : base(dataProtectionProvider, options, userLogger)
        {
        }

    }

    public class EmailConfirmationProviderOption : DataProtectionTokenProviderOptions
    {

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using Bit.Api.Models.Response.Providers;
using Bit.Core.Models.Api;
using Bit.Core.Models.Data;
using Bit.Core.Models.Table;

namespace Bit.Api.Models.Response
{
    public class ProfileResponseModel : ResponseModel
    {
        public ProfileResponseModel(User user,
            IEnumerable<OrganizationUserOrganizationDetails> organizationsUserDetails,
            IEnumerable<ProviderUserProviderDetails> providerUserDetails,
            IEnumerable<ProviderUserOrganizationDetails> providerUserOrganizationDetails,
            bool twoFactorEnabled) : base("profile")
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            Id = user.Id.ToString();
            Name = user.Name;
            Email = user.Email;
            EmailVerified = user.EmailVerified;
            Premium = user.Premium;
            MasterPasswordHint = string.IsNullOrWhiteSpace(user.MasterPasswordHint) ? null : user.MasterPasswordHint;
            Culture = user.Culture;
            TwoFactorEnabled = twoFactorEnabled;
            Key = user.Key;
            PrivateKey = user.PrivateKey;
            SecurityStamp = user.SecurityStamp;
            ForcePasswordReset = user.ForcePasswordReset;
            UsesKeyConnector = user.UsesKeyConnector;
            Organizations = organizationsUserDetails?.Select(o => new ProfileOrganizationResponseModel(o));
            Providers = providerUserDetails?.Select(p => new ProfileProviderResponseModel(p));
            ProviderOrganizations =
                providerUserOrganizationDetails?.Select(po => new ProfileProviderOrganizationResponseModel(po));
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public bool Premium { get; set; }
        public string MasterPasswordHint { get; set; }
        public string Culture { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string Key { get; set; }
        public string PrivateKey { get; set; }
        public string SecurityStamp { get; set; }
        public bool ForcePasswordReset { get; set; }
        public bool UsesKeyConnector { get; set; }
        public IEnumerable<ProfileOrganizationResponseModel> Organizations { get; set; }
        public IEnumerable<ProfileProviderResponseModel> Providers { get; set; }
        public IEnumerable<ProfileProviderOrganizationResponseModel> ProviderOrganizations { get; set; }
    }
}

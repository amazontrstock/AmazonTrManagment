using System.Collections.Generic;
using AmazonTrManagment.Roles.Dto;

namespace AmazonTrManagment.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}
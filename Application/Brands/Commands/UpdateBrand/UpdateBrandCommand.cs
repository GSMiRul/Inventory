using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommand : IRequest<RequestResponse<String>>
    {
        public string Id { get; set; }
        public string brandName { get; set; }
        public string? shortName { get; set; }
        public string? summary { get; set; }
    }
}

﻿using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class AddressServiceModel : IMapFrom<Address>, IMapTo<Address>
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Quarter { get; set; }

        public string Street { get; set; }

        public int PostCode { get; set; }
    }
}
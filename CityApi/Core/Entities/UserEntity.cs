using System;
using System.Collections.Generic;

namespace CityApi.Core.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }=String.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<CityEntity>? CityEntities { get; set; }
    }
}
